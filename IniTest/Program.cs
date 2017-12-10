using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Ini;

namespace IniTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                DoWork();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        private static void DoWork()
        {
            List<bool> success = new List<bool>();
            Console.ReadLine();

            // ini writing
            IniWriter writer = new IniWriter(@"test.ini");
            Console.WriteLine();
            Console.WriteLine("IniWriter");
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Time Elapsed {0}", sw.ElapsedMilliseconds);
            success.Add(writer.WriteString("Lot", "LOTID", "TEST_2"));
            success.Add(writer.WriteString("Lot", "LFID", "LTEST_2M01S04"));
            success.Add(writer.WriteString("Lot", "MAGAZINEID", "MAG001"));
            success.Add(writer.WriteInt("Lot", "SLOTID", 1));
            success.Add(writer.WriteString("Lot", "BONDINGDIAGRAM", "VNQ3"));
            success.Add(writer.WriteString("Lot", "INSPECTMODE", "MANUAL"));
            success.Add(writer.WriteInt("Lot", "NOOFROW", 4));
            success.Add(writer.WriteInt("Lot", "NOOFCOL", 24));
            success.Add(writer.WriteString("Lot", "ORGIN", "Top-Right"));
            success.Add(writer.WriteString("Lot", "DIRECION", "Top-Right"));
            success.Add(writer.WriteString("Lot", "MATRIX", "1x1"));
            success.Add(writer.WriteString("Lot", "STATUS", "NEWLOT"));

            Console.WriteLine("Time Elapsed {0}", sw.ElapsedMilliseconds);

            // Ini reading
            IniReader reader = new IniReader(@"test.ini");
            sw = Stopwatch.StartNew();
            Console.WriteLine("Time Elapsed {0}", sw.ElapsedMilliseconds);
            string LotId = string.Empty;
            string lfid = string.Empty;
            string magazineId = string.Empty;
            int slotId = 0;
            string bondingDiagram = string.Empty;
            string inspectMode = string.Empty;
            int noOfRow = 0;
            int noOfCol = 0;
            string origin = string.Empty;
            string direction = string.Empty;
            string matrix = string.Empty;
            string status = string.Empty;

            success.Add(reader.ReadString("Lot", "LOTID", ref LotId));
            success.Add(reader.ReadString("Lot", "LFID", ref lfid));
            success.Add(reader.ReadString("Lot", "MAGAZINEID", ref magazineId));
            success.Add(reader.ReadInt("Lot", "SLOTID", ref slotId));
            success.Add(reader.ReadString("Lot", "BONDINGDIAGRAM", ref bondingDiagram));
            success.Add(reader.ReadString("Lot", "INSPECTMODE", ref inspectMode));
            success.Add(reader.ReadInt("Lot", "NOOFROW", ref noOfRow));
            success.Add(reader.ReadInt("Lot", "NOOFCOL", ref noOfCol));
            success.Add(reader.ReadString("Lot", "ORGIN", ref origin));
            success.Add(reader.ReadString("Lot", "DIRECION", ref direction));
            success.Add(reader.ReadString("Lot", "MATRIX", ref matrix));
            success.Add(reader.ReadString("Lot", "STATUS", ref status));
            Console.WriteLine("Time Elapsed {0}", sw.ElapsedMilliseconds);

            // ini sorting
            sw = Stopwatch.StartNew();
            Console.WriteLine("Time Elapsed {0}", sw.ElapsedMilliseconds);
            writer.SortIni();
            Console.WriteLine("Time Elapsed {0}", sw.ElapsedMilliseconds);

            // ini clearing
            sw = Stopwatch.StartNew();
            Console.WriteLine("Time Elapsed {0}", sw.ElapsedMilliseconds);
            writer.ClearIni();
            Console.WriteLine("Time Elapsed {0}", sw.ElapsedMilliseconds);
        }
    }
}
