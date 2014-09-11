using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Code
{
    class Categories
    {
        Dictionary<string, Regex> labelRegexes = new Dictionary<string, Regex>();

        public Categories()
        {
            Regex food = new Regex(@".*(trader|fred|safeway|mayuri).*", RegexOptions.Compiled);
            labelRegexes.Add("Grocery", food);
            Regex amazon = new Regex(@".*(amazon).*", RegexOptions.Compiled);
            labelRegexes.Add("Amazon", amazon);
            Regex cafe = new Regex(@".*(cafe cc).*", RegexOptions.Compiled);
            labelRegexes.Add("Cafe", cafe);
            Regex zipcar = new Regex(@".*(zipcar).*", RegexOptions.Compiled);
            labelRegexes.Add("Zipcar", zipcar);

        }

        public string[] Categorize(string description)
        {
            List<string> categories = new List<string>();
            foreach (KeyValuePair<string, Regex> pair in labelRegexes)
            {
                if(pair.Value.IsMatch(description.ToLower().Trim()))
                {
                    categories.Add(pair.Key);
                }
            }
            return categories.ToArray();
        }

        /*public static void Main(string[] args)
        {
            string test1 = "POS Transaction 345600147887 CHIPOTLE 0469          BELLEVUE     WAUS";
            string test2 = "POS Transaction 14-8019149213 MAYURI FOODS AND VIDEO REDMOND      WAUS";
            Categories cats = new Categories();

            Console.WriteLine(String.Join(",",cats.Categorize(test1)));
            Console.WriteLine(String.Join(",",cats.Categorize(test2)));
        }*/
    }
}
