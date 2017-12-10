using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ini
{
    public class IniReader
    {
        private readonly IniConverter iniConverter;

        public IniReader(string filePath)
        {
            this.iniConverter = new IniConverter(filePath);
        }

        public string ReadString(string section, string key, string defaultValue = null)
        {
            string value = this.ReadProperty(section, key);

            return value != null ? value.Trim(new[] { '"' }) : defaultValue;
        }

        public byte ReadByte(string section, string key, byte defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            byte byteValue = defaultValue;
            bool parsed = byte.TryParse(value, out byteValue);

            return parsed ? byteValue : defaultValue;
        }

        public sbyte ReadSByte(string section, string key, sbyte defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            sbyte sbyteValue = defaultValue;
            bool parsed = sbyte.TryParse(value, out sbyteValue);

            return parsed ? sbyteValue : defaultValue;
        }

        public short ReadShort(string section, string key, short defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            short shortValue = defaultValue;
            bool parsed = short.TryParse(value, out shortValue);

            return parsed ? shortValue : defaultValue;
        }

        public ushort ReadUShort(string section, string key, ushort defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            ushort ushortValue = defaultValue;
            bool parsed = ushort.TryParse(value, out ushortValue);

            return parsed ? ushortValue : defaultValue;
        }

        public int ReadInt(string section, string key, int defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            int intValue = defaultValue;
            bool parsed = int.TryParse(value, out intValue);

            return parsed ? intValue : defaultValue;
        }

        public uint ReadUInt(string section, string key, uint defaultValue = 0)
        {
            string value = this.ReadProperty(section, key);

            uint uintValue = defaultValue;
            bool parsed = uint.TryParse(value, out uintValue);

            return parsed ? uintValue : defaultValue;
        }

        public double ReadDouble(string section, string key, double defaultValue = 0.0)
        {
            string value = this.ReadProperty(section, key);

            double doubleValue = defaultValue;
            bool parsed = double.TryParse(value, out doubleValue);

            return parsed ? doubleValue : defaultValue;
        }

        public decimal ReadDecimal(string section, string key, decimal defaultValue = 0.0m)
        {
            string value = this.ReadProperty(section, key);

            decimal decimalValue = defaultValue;
            bool parsed = decimal.TryParse(value, out decimalValue);

            return parsed ? decimalValue : defaultValue;
        }

        public bool ReadBool(string section, string key, bool defaultValue = false)
        {
            string value = this.ReadProperty(section, key);

            bool boolValue = defaultValue;
            bool parsed = bool.TryParse(value, out boolValue);

            return parsed ? boolValue : defaultValue;
        }

        public List<string> GetSections()
        {
            Dictionary<string, Dictionary<string, string>> lines = this.iniConverter.ReadFile();
            return lines.Keys.Select(section => section.Trim(
                new[]
                {
                    '[',
                    ']'
                })).ToList();
        }

        public int GetSectionCount()
        {
            Dictionary<string, Dictionary<string, string>> sections = this.iniConverter.ReadFile();
            return sections.Keys.Count;
        }

        public int GetPropertiesCount(string section)
        {
            Dictionary<string, Dictionary<string, string>> sections = this.iniConverter.ReadFile();
            section = '[' + section + ']';

            if (!sections.ContainsKey(section))
            {
                return 0;
            }

            return sections[section].Count;
        }

        private string ReadProperty(string section, string key)
        {
            var sections = this.iniConverter.ReadFile();
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
