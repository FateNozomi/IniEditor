using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.ReadLine();

            // ini writing
            IniWriter writer = new IniWriter(@"test.ini");
            Console.WriteLine();
            Console.WriteLine("IniWriter");

            Stopwatch sw = Stopwatch.StartNew();
            writer.WriteString("Lot", "LOTID", "TEST_2");
            writer.WriteString("Lot", "LFID", "LTEST_2M01S04");
            writer.WriteString("Lot", "MAGAZINEID", "MAG001");
            writer.WriteInt("Lot", "SLOTID", 1);
            writer.WriteString("Lot", "BONDINGDIAGRAM", "VNQ3");
            writer.WriteString("Lot", "INSPECTMODE", "MANUAL");
            writer.WriteInt("Lot", "NOOFROW", 4);
            writer.WriteInt("Lot", "NOOFCOL", 24);
            writer.WriteString("Lot", "ORGIN", "Top-Right");
            writer.WriteString("Lot", "DIRECION", "Top-Right");
            writer.WriteString("Lot", "MATRIX", "1x1");
            writer.WriteString("Lot", "STATUS", "NEWLOT");

            Console.WriteLine("Time Elapsed for IniWriter Write: {0}", sw.ElapsedMilliseconds);

            // Ini reading
            IniReader reader = new IniReader(@"test.ini");
            Console.WriteLine();
            Console.WriteLine("IniReader");
            string lotId = string.Empty;
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

            sw = Stopwatch.StartNew();
            Console.WriteLine(reader.ReadString("Lot", "LOTID", lotId));
            Console.WriteLine(reader.ReadString("Lot", "LFID", lfid));
            Console.WriteLine(reader.ReadString("Lot", "MAGAZINEID", magazineId));
            Console.WriteLine(reader.ReadInt("Lot", "SLOTID", slotId));
            Console.WriteLine(reader.ReadString("Lot", "BONDINGDIAGRAM", bondingDiagram));
            Console.WriteLine(reader.ReadString("Lot", "INSPECTMODE", inspectMode));
            Console.WriteLine(reader.ReadInt("Lot", "NOOFROW", noOfRow));
            Console.WriteLine(reader.ReadInt("Lot", "NOOFCOL", noOfCol));
            Console.WriteLine(reader.ReadString("Lot", "ORGIN", origin));
            Console.WriteLine(reader.ReadString("Lot", "DIRECION", direction));
            Console.WriteLine(reader.ReadString("Lot", "MATRIX", matrix));
            Console.WriteLine(reader.ReadString("Lot", "STATUS", status));
            Console.WriteLine("Time Elapsed for IniReader Read:  {0}", sw.ElapsedMilliseconds);

            // ini sorting
            sw = Stopwatch.StartNew();
            writer.SortIni();
            Console.WriteLine("Time Elapsed for IniWriter SortIni: {0}", sw.ElapsedMilliseconds);

            // ini clearing
            // sw = Stopwatch.StartNew();
            // writer.ClearIni();
            // Console.WriteLine("Time Elapsed for InitWriter ClearIni: {0}", sw.ElapsedMilliseconds);
        }
    }
}
