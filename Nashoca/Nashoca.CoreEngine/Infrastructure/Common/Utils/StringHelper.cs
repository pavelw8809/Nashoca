using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Infrastructure.Common.Utils
{
    public class StringHelper
    {
        public static char? GetFirstLetter(string word) => string.IsNullOrWhiteSpace(word) ? null : word.ToLower().First();

        public static char? GetLastLetter(string word) => string.IsNullOrWhiteSpace(word) ? null : word.ToLower().Last();

        public static string RemoveLetterFromEnd(string word, int endPosition) { 
            if (word.Length < endPosition) return word;

            return word.Remove(word.Length - endPosition, 1);
        }
    }
}
