using Nashoca.CoreEngine.Infrastructure.Models.Main;

namespace Nashoca.CoreEngine.Infrastructure.Common.Utils
{
    public class VowelHelper
    {
        private static readonly char[] FrontVowels = { 'e', 'i', 'ö', 'ü' };
        private static readonly char[] BackVowels = { 'a', 'ı', 'o', 'u' };
        private static readonly char[] Vowels = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };
        private static readonly char[] VoicelessVowels = { 'ç', 'f', 'h', 'k', 'p', 's', 'ş', 't' };

        private static readonly Dictionary<char, char> HarmonyVowels = new()
        {
            { 'a', 'ı' },
            { 'ı', 'ı' },
            { 'o', 'u' },
            { 'u', 'u' },
            { 'e', 'i' },
            { 'i', 'i' },
            { 'ö', 'ü' },
            { 'ü', 'ü' }
        };

        public static char? GetBasicVowelHarmony(string word)
        {
            char? lastVowel = GetLastVowel(word);
            
            if (lastVowel != null)
            {
                return HarmonyVowels.TryGetValue(lastVowel.Value, out var harmonyVowel) ? harmonyVowel : null;
            }
            else
            {
                return null;
            }
        }

        public static char? GetBasicVowelHarmony(char? vowel)
        {
            if (vowel == null) return null;

            return HarmonyVowels.TryGetValue(vowel.Value, out var harmonyVowel) ? harmonyVowel : null;
        }

        public static char? GetAEVowelHarmony(string word)
        {
            char? lastVowel = GetLastVowel(word);

            if (lastVowel != null)
            {
                bool isFrontVowel = FrontVowels.Contains(lastVowel.Value);
                return isFrontVowel ? 'e' : 'a';
            }
            else
            {
                return null;
            }
        }

        public static char? GetAEVowelHarmony(char? vowel)
        {
            if (vowel == null) return null;

            bool isFrontVowel = FrontVowels.Contains(vowel.Value);
            return isFrontVowel ? 'e' : 'a';
        }

        public static char? GetIVowelHarmony(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return null;

            char? lastVowel = GetLastVowel(word);

            if (lastVowel != null)
            {
                bool isFrontVowel = FrontVowels.Contains(lastVowel.Value);
                return isFrontVowel ? 'i' : 'ı';
            }
            else
            {
                return null;
            }
        }

        public static char? GetIVowelHarmony(char? vowel)
        {
            if (vowel == null) return null;

            bool isFrontVowel = FrontVowels.Contains(vowel.Value);
            return isFrontVowel ? 'i' : 'ı';
        }

        public static char? GetLastVowel(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return null;

            word = word.ToLower();

            return word.LastOrDefault(c => Vowels.Contains(c)) switch
            {
                '\0' => null,
                var v => v
            };
        }

        public static char? GetFirstVowel(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return null;

            word = word.ToLower();

            return word.FirstOrDefault(c => Vowels.Contains(c)) switch
            {
                '\0' => null,
                var v => v
            };
        }
        
        public static bool IsFirstCharVowel(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return false;

            char firstLetter = word.First();

            return Vowels.Contains(firstLetter);
        }

        public static bool IsLastCharVowel(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return false;

            char lastLetter = word.Last();

            return Vowels.Contains(lastLetter);
        }

        public static bool IsLastCharVoiceless(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return false;

            char lastLetter = word.Last();

            return VoicelessVowels.Contains(lastLetter);
        }

        public static HarmonyInfoObj GetHarmonyInfo(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return null;

            char? lastVowel = GetLastVowel(word);

            return new HarmonyInfoObj()
            {
                BaseHarmony = GetBasicVowelHarmony(lastVowel),
                AEHarmony = GetAEVowelHarmony(lastVowel),
                IHarmony = GetIVowelHarmony(lastVowel),
                LastVowel = lastVowel,
                IsLastCharVowel = IsLastCharVowel(word),
                IsLastCharVoiceless = IsLastCharVoiceless(word),
            };
        }
    }
}
