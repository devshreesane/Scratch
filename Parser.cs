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

            Dictionary<string, double> total = new Dictionary<string, double>();
            total.Add("Grocery", 0);
            total.Add("Amazon", 0);
            total.Add("Cafe", 0);
            total.Add("Zipcar", 0);
            Categories categories = new Categories();
            foreach (string[] fileCols in ColumnReader.CsvReadColumns(file, cols))
            {
                foreach (string label in categories.Categorize(fileCols[0]))
                {
                    total[label] += double.Parse(fileCols[1].Replace("\"",""));
                }
            }

            Console.WriteLine("Totals ");
            foreach (KeyValuePair<string,double> item in total)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

    }
}
