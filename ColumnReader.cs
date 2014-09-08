using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class ColumnReader
    {
        //assumes first line is header
        public static IEnumerable<string[]> CsvReadColumns(string file, string[] cols)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string[] availableColumns = sr.ReadLine().Split(new char[] { ',' }, StringSplitOptions.None);
                int i = 0;
                Dictionary<string, int> columns = new Dictionary<string,int>();
                foreach (string aCol in availableColumns)
                {
                    columns.Add(aCol, i++);
                }
                int[] requiredCols = new int[cols.Length];
                for(int c=0; c < cols.Length ;c++)
                {
                    if (columns.ContainsKey(cols[c]))
                        requiredCols[c] = columns[cols[c]];
                    else
                        throw new ApplicationException("Required column is not present");
                }

                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] l = line.Split(new char[] { ',' }, StringSplitOptions.None);
                    string[] returnCols = new string[cols.Length];
                    for (int c = 0; c < cols.Length; c++)
                    {
                        returnCols[c] = l[requiredCols[c]];
                    }
                    yield return returnCols;
                }

            }
        }
    }
}
