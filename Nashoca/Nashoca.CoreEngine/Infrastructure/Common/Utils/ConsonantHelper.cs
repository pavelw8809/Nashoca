using Nashoca.CoreEngine.Infrastructure.Models.Main;

namespace Nashoca.CoreEngine.Infrastructure.Common.Utils
{
    public class ConsonantHelper
    {
        private static readonly Dictionary<char, char> consonantList = new()
        {
            { 'ç', 'c' },
            { 'k', 'ğ' },
            { 'p', 'b' },
            { 't', 'd' }
        };

        public static char? GetVoicedConsonant(char? letter)
        {
            if (letter.HasValue && consonantList.TryGetValue(letter.Value, out char mapped))
            {
                return mapped;
            }

            return null;
        }

        public static string ReplaceLastLetter(string word, char? newChar)
        {
            if (newChar == null || string.IsNullOrEmpty(word)) return word;

            return $"{word[..^1]}{newChar}";
        }

        public static string ReplaceStringEnding(string word, string pattern)
        {
            if (string.IsNullOrWhiteSpace(word) || word.Length < pattern.Length) return word;

            return $"{word[..pattern.Length]}{pattern}";
        }

        public static bool IsStringEndingReverted(string word, string pattern)
        {
            if (string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(pattern)) return false;

            if (word.Length < pattern.Length || pattern.Length < 2) return false;

            ReadOnlySpan<char> wordEnding = word.AsSpan(word.Length - pattern.Length);

            for (int i = 0; i < pattern.Length; i++)
            {
                if (wordEnding[i] != pattern[pattern.Length - i - 1]) return false;
            }

            return true;
        }

        public static ConsonantInfoObj GetConsonantInfo(string word, string pattern = null)
        {
            if (string.IsNullOrWhiteSpace(word)) return null;

            char? lastLetter = StringHelper.GetLastLetter(word);

            return new()
            {
                VoicedEquivalent = GetVoicedConsonant(lastLetter),
                IsStringEndingReverted = IsStringEndingReverted(word, pattern),
                LastLetter = lastLetter
            };
        }
    }
}
