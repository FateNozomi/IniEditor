using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ini
{
    public class IniWriter
    {
        private string filePath;
        private IniReader iniReader;

        public IniWriter(string filePath)
        {
            this.filePath = filePath;
            this.iniReader = new IniReader(this.filePath);
        }

        public bool FileExist
        {
            get
            {
                return File.Exists(this.filePath);
            }
        }

        public bool WriteString(string section, string key, string value)
        {
            value = "\"" + value + "\"";

            return this.WriteProperty(section, key, value);
        }

        public bool WriteByte(string section, string key, byte value)
        {
            return this.WriteProperty(section, key, value.ToString());
        }

        public bool WriteSByte(string section, string key, sbyte value)
        {
            return this.WriteProperty(section, key, value.ToString());
        }

        public bool WriteShort(string section, string key, short value)
        {
            return this.WriteProperty(section, key, value.ToString());
        }

        public bool WriteUShort(string section, string key, ushort value)
        {
            return this.WriteProperty(section, key, value.ToString());
        }

        public bool WriteInt(string section, string key, int value)
        {
            return this.WriteProperty(section, key, value.ToString());
        }

        public bool WriteUInt(string section, string key, uint value)
        {
            return this.WriteProperty(section, key, value.ToString());
        }

        public bool WriteDouble(string section, string key, double value)
        {
            return this.WriteProperty(section, key, value.ToString());
        }

        public bool WriteDecimal(string section, string key, decimal value)
        {
            return this.WriteProperty(section, key, value.ToString());
        }

        public bool WriteBool(string section, string key, bool value)
        {
            return this.WriteProperty(section, key, value ? bool.TrueString : bool.FalseString);
        }

        public bool RemoveSection(string section)
        {
            Dictionary<string, Dictionary<string, string>> sections = this.iniReader.ReadFile();
            section = '[' + section + ']';

            if (!sections.Any())
            {
                return false;
            }

            if (!sections.Remove(section))
            {
                return false;
            }

            return this.WriteFile(sections);
        }

        public bool SortIni()
        {
            var sections = this.iniReader.ReadSortedFile();

            if (sections.Any())
            {
                this.WriteSortedFile(sections);
                return true;
            }

            return false;
        }

        public bool ClearIni()
        {
            bool result = false;

            try
            {
                File.WriteAllText(this.filePath, string.Empty);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        private bool WriteProperty(string section, string key, string value)
        {
            Dictionary<string, Dictionary<string, string>> sections = this.iniReader.ReadFile();
            Dictionary<string, string> newSection;
            section = '[' + section + ']';

            if (sections.ContainsKey(section))
            {
                if (sections[section].ContainsKey(key))
                {
                    sections[section][key] = value;
                }
                else
                {
                    sections[section].Add(key, value);
                }
            }
            else
            {
                newSection = new Dictionary<string, string>();
                newSection.Add(key, value);
                sections.Add(section, newSection);
            }

            return this.WriteFile(sections);
        }

        private bool WriteFile(Dictionary<string, Dictionary<string, string>> lines)
        {
            try
            {
                using (FileStream stream = new FileStream(this.filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        foreach (var section in lines)
                        {
                            writer.WriteLine(section.Key);
                            foreach (var property in section.Value)
                            {
                                writer.WriteLine(string.Format("{0}={1}", property.Key, property.Value));
                            }

                            writer.WriteLine();
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool WriteSortedFile(SortedDictionary<string, SortedDictionary<string, string>> lines)
        {
            try
            {
                using (FileStream stream = new FileStream(this.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        foreach (var section in lines)
                        {
                            writer.WriteLine(section.Key);
                            foreach (var property in section.Value)
                            {
                                writer.WriteLine(string.Format("{0}={1}", property.Key, property.Value));
                            }

                            writer.WriteLine();
                        }
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
