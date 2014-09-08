using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class Parser
    {
        public static void Main(string[] args)
        {
            string file = @"C:\Users\devsane\Downloads\HistoryDownloadCredit.csv";
            string[] cols = { "\"Description\"", "\"Amount\"" };

            double totalGr = 0;
            Categories categories = new Categories();
            foreach (string[] fileCols in ColumnReader.CsvReadColumns(file, cols))
            {
                foreach (string label in categories.Categorize(fileCols[0]))
                {
                    totalGr += double.Parse(fileCols[1].Replace("\"",""));
                }
            }

            Console.WriteLine("Total groceries = " + totalGr);
        }

    }
}
