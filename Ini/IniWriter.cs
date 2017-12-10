using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ini
{
    public class IniWriter
    {
        private readonly string filePath;
        private readonly IniConverter iniConverter;

        public IniWriter(string filePath)
        {
            this.filePath = filePath;
            this.iniConverter = new IniConverter(this.filePath);
        }

        public void WriteString(string section, string key, string value)
        {
            value = "\"" + value + "\"";

            this.WriteProperty(section, key, value);
        }

        public void WriteByte(string section, string key, byte value)
        {
            this.WriteProperty(section, key, value.ToString());
        }

        public void WriteSByte(string section, string key, sbyte value)
        {
            this.WriteProperty(section, key, value.ToString());
        }

        public void WriteShort(string section, string key, short value)
        {
            this.WriteProperty(section, key, value.ToString());
        }

        public void WriteUShort(string section, string key, ushort value)
        {
            this.WriteProperty(section, key, value.ToString());
        }

        public void WriteInt(string section, string key, int value)
        {
            this.WriteProperty(section, key, value.ToString());
        }

        public void WriteUInt(string section, string key, uint value)
        {
            this.WriteProperty(section, key, value.ToString());
        }

        public void WriteDouble(string section, string key, double value)
        {
            this.WriteProperty(section, key, value.ToString());
        }

        public void WriteDecimal(string section, string key, decimal value)
        {
            this.WriteProperty(section, key, value.ToString());
        }

        public void WriteBool(string section, string key, bool value)
        {
            this.WriteProperty(section, key, value ? bool.TrueString : bool.FalseString);
        }

        public bool RemoveSection(string section)
        {
            Dictionary<string, Dictionary<string, string>> sections = this.iniConverter.ReadFile();
            section = '[' + section + ']';

            if (!sections.Any())
            {
                return false;
            }

            if (!sections.Remove(section))
            {
                return false;
            }

            this.WriteFile(sections);
            return true;
        }

        public bool SortIni()
        {
            var sections = this.iniConverter.ReadSortedFile();

            if (sections.Any())
            {
                this.WriteSortedFile(sections);
                return true;
            }

            return false;
        }

        private void WriteProperty(string section, string key, string value)
        {
            Dictionary<string, Dictionary<string, string>> sections = new Dictionary<string, Dictionary<string, string>>();

            // Read from file only if it exists to allow creation of new .ini file by default.
            if (File.Exists(this.filePath))
            {
                sections = this.iniConverter.ReadFile();
            }

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

            this.WriteFile(sections);
        }

        private void WriteFile(Dictionary<string, Dictionary<string, string>> lines)
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
        }

        private void WriteSortedFile(SortedDictionary<string, SortedDictionary<string, string>> lines)
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
        }
    }
}
