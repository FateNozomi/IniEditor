using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ini
{
    public class IniReader
    {
        private string filePath;

        public IniReader(string filePath)
        {
            this.filePath = filePath;
        }

        public bool FileExist
        {
            get
            {
                return File.Exists(this.filePath);
            }
        }

        #region ReadString
        public string ReadString(string section, string key, string defaultValue = null)
        {
            string value = this.ReadProperty(section, key);

            return value != null ? value.Trim(new[] { '"' }) : defaultValue;
        }

        public bool ReadString(string section, string key, ref string value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                value = retValue.Trim(new[] { '"' });
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReadByte
        public byte ReadByte(string section, string key, byte defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            byte byteValue = defaultValue;
            bool parsed = byte.TryParse(value, out byteValue);

            return parsed ? byteValue : defaultValue;
        }

        public bool ReadByte(string section, string key, ref byte value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                byte byteValue = 0;
                bool parsed = byte.TryParse(retValue, out byteValue);
                value = byteValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReadSByte
        public sbyte ReadSByte(string section, string key, sbyte defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            sbyte sbyteValue = defaultValue;
            bool parsed = sbyte.TryParse(value, out sbyteValue);

            return parsed ? sbyteValue : defaultValue;
        }

        public bool ReadSByte(string section, string key, ref sbyte value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                sbyte sbyteValue = 0;
                bool parsed = sbyte.TryParse(retValue, out sbyteValue);
                value = sbyteValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReadShort
        public short ReadShort(string section, string key, short defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            short shortValue = defaultValue;
            bool parsed = short.TryParse(value, out shortValue);

            return parsed ? shortValue : defaultValue;
        }

        public bool ReadShort(string section, string key, ref short value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                short shortValue = 0;
                bool parsed = short.TryParse(retValue, out shortValue);
                value = shortValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReadUShort
        public ushort ReadUShort(string section, string key, ushort defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            ushort ushortValue = defaultValue;
            bool parsed = ushort.TryParse(value, out ushortValue);

            return parsed ? ushortValue : defaultValue;
        }

        public bool ReadUShort(string section, string key, ref ushort value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                ushort ushortValue = 0;
                bool parsed = ushort.TryParse(retValue, out ushortValue);
                value = ushortValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReadInt
        public int ReadInt(string section, string key, int defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            int intValue = defaultValue;
            bool parsed = int.TryParse(value, out intValue);

            return parsed ? intValue : defaultValue;
        }

        public bool ReadInt(string section, string key, ref int value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                int intValue = 0;
                bool parsed = int.TryParse(retValue, out intValue);
                value = intValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReadUInt
        public uint ReadUInt(string section, string key, uint defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            uint uintValue = defaultValue;
            bool parsed = uint.TryParse(value, out uintValue);

            return parsed ? uintValue : defaultValue;
        }

        public bool ReadUInt(string section, string key, ref uint value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                uint uintValue = 0;
                bool parsed = uint.TryParse(retValue, out uintValue);
                value = uintValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReadDouble
        public double ReadDouble(string section, string key, double defaultValue = 0.0)
        {
            string value = this.ReadProperty(section, key);

            double doubleValue = defaultValue;
            bool parsed = double.TryParse(value, out doubleValue);

            return parsed ? doubleValue : defaultValue;
        }

        public bool ReadDouble(string section, string key, ref double value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                double doubleValue = 0.0;
                bool parsed = double.TryParse(retValue, out doubleValue);
                value = doubleValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReadDecimal
        public decimal ReadDecimal(string section, string key, decimal defaultValue = 0.0m)
        {
            string value = this.ReadProperty(section, key);

            decimal decimalValue = defaultValue;
            bool parsed = decimal.TryParse(value, out decimalValue);

            return parsed ? decimalValue : defaultValue;
        }

        public bool ReadDecimal(string section, string key, ref decimal value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                decimal decimalValue = 0.0m;
                bool parsed = decimal.TryParse(retValue, out decimalValue);
                value = decimalValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ReadBool
        public bool ReadBool(string section, string key, bool defaultValue = false)
        {
            string value = this.ReadProperty(section, key);

            bool boolValue = defaultValue;
            bool parsed = bool.TryParse(value, out boolValue);

            return parsed ? boolValue : defaultValue;
        }

        public bool ReadBool(string section, string key, ref bool value)
        {
            string retValue = this.ReadProperty(section, key);

            if (retValue != null)
            {
                bool boolValue = false;
                bool parsed = bool.TryParse(retValue, out boolValue);
                value = boolValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        public List<string> GetSections()
        {
            Dictionary<string, Dictionary<string, string>> lines = this.ReadFile();
            return lines.Keys.Select(section => section.Trim(
                new[]
                {
                    '[',
                    ']'
                })).ToList();
        }

        public int GetSectionCount()
        {
            Dictionary<string, Dictionary<string, string>> lines = this.ReadFile();
            return lines.Keys.Count;
        }

        public Dictionary<string, Dictionary<string, string>> ReadFile()
        {
            Dictionary<string, Dictionary<string, string>> sections = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> properties = null;

            string line = null;

            if (this.FileExist)
            {
                using (FileStream file = new FileStream(this.filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = line.Trim();

                            if (line != string.Empty)
                            {
                                if (line[0] == '[' && line[line.Length - 1] == ']')
                                {
                                    properties = new Dictionary<string, string>();
                                    sections.Add(line, properties);
                                }
                                else
                                {
                                    string[] property = line.Split(new[] { '=' }, 2);
                                    if (properties != null)
                                    {
                                        properties.Add(property[0].Trim(), property[1].Trim());
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return sections;
        }

        public SortedDictionary<string, SortedDictionary<string, string>> ReadSortedFile()
        {
            SortedDictionary<string, SortedDictionary<string, string>> sections = new SortedDictionary<string, SortedDictionary<string, string>>();
            SortedDictionary<string, string> properties = null;

            string line = null;

            if (this.FileExist)
            {
                using (FileStream file = new FileStream(this.filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            line = line.Trim();

                            if (line != string.Empty)
                            {
                                if (line[0] == '[' && line[line.Length - 1] == ']')
                                {
                                    properties = new SortedDictionary<string, string>();
                                    sections.Add(line, properties);
                                }
                                else
                                {
                                    string[] property = line.Split(new[] { '=' }, 2);
                                    if (properties != null)
                                    {
                                        properties.Add(property[0].Trim(), property[1].Trim());
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return sections;
        }

        private string ReadProperty(string section, string key)
        {
            var sections = this.ReadFile();
            string value = null;
            section = '[' + section + ']';

            if (sections.ContainsKey(section))
            {
                if (sections[section].ContainsKey(key))
                {
                    value = sections[section][key];
                }
            }

            return value;
        }
    }
}
