using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ini
{
    internal class IniConverter
    {
        private readonly string filePath;

        public IniConverter(string filePath)
        {
            this.filePath = filePath;
        }

        public Dictionary<string, Dictionary<string, string>> ReadFile()
        {
            Dictionary<string, Dictionary<string, string>> sections = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> properties = null;

            string line = null;

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

            return sections;
        }

        public SortedDictionary<string, SortedDictionary<string, string>> ReadSortedFile()
        {
            SortedDictionary<string, SortedDictionary<string, string>> sections = new SortedDictionary<string, SortedDictionary<string, string>>();
            SortedDictionary<string, string> properties = null;

            string line = null;

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

            return sections;
        }
    }
}
