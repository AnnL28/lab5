using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab5.Models
{
    public class RegExFinder
    {
        public string[] GetMatches(string pattern, string input)
        {
            Regex rg = new Regex(pattern);
            return rg.Matches(input)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();

        }
    }
}
