using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nashoca.CoreEngine.Infrastructure.Data.Verbs
{
    internal static class VerbAnnotations
    {
        public static readonly string NounRootSuffix = "Noun Root";
        public static readonly string RootSuffix = "Verb Root";
        public static readonly string AbilityPreSuffix = "Y Consonant Buffer";
        public static readonly string AbilitySuffix = "Ability Suffix";
        public static readonly string NegationSuffix = "Negation Suffix";
        public static readonly string Tense0PreSuffix = "Y Consonant Buffer";
        public static readonly string Tense0Suffix = "{0} Tense Suffix";
        public static readonly string Tense1PreSuffix = "Y Consonant Buffer";
        public static readonly string Tense1Suffix = "Second {0} Tense Suffix";
        public static readonly string QuestionSuffix = "Question Suffix";
        public static readonly string ConsonantBufferSuffix = "Y Consonant Buffer";
        public static readonly string PluralSuffix = "Plural Suffix";
        public static readonly string PersonSuffix = "Person Suffix";
        public static readonly string QuestionPostSuffix = "Question Suffix";

        public static readonly string NounRootSymbol = "nounroot";
        public static readonly string RootSymbol = "root";
        public static readonly string AbilityPreSymbol = "abilitypre";
        public static readonly string AbilitySymbol = "ability";
        public static readonly string NegationSymbol = "negation";
        public static readonly string Tense0PreSymbol = "tense0pre";
        public static readonly string Tense0Symbol = "tense0";
        public static readonly string Tense1PreSymbol = "tense1pre";
        public static readonly string Tense1Symbol = "tense1";
        public static readonly string QuestionSymbol = "question";
        public static readonly string ConsonantBufferSymbol = "consbuf";
        public static readonly string PluralSymbol = "plural";
        public static readonly string PersonSymbol = "person";
        public static readonly string QuestionPostSymbol = "question";

        public static readonly string NounRootInfo = "Noun root form as a part of compound verb: {0}";
        public static readonly string NounRootInfoChg = "Noun root form as a part of compound verb: {0}. Last letter: {1} changes to {2} because it's not voiced";
        public static readonly string RootInfo = "Basic verb form from: {0}";
        public static readonly string AbilityPreInfo = "'y' Consonant Buffer between two vowels: {0} and {1}";
        public static readonly string AbilityInfoPos = "The ability suffix in affirmative sentences: {0} (vowel according to the vowel harmony - a/e) + bil";
        public static readonly string AbilityIngoNeg = "The ability suffix in negative sentences: {0} (vowel according to the vowel harmony)";
        public static readonly string NegationInfo = "m + {0}, according to the vowel harmony (a/e)";
        public static readonly string NegationPcInfo = "Adding 'm' only as the next suffix starts from a vowel";
        public static readonly string Tense0PreInfo = "'y' Consonant Buffer between two vowels";
        public static readonly string Tense0Info = "{0} Tense Suffix: {1}";
        public static readonly string Tense0InfoVal = "'{0}' {1} Tense Suffix for {2}. {3} person";
        public static readonly string Tense0InfoEmpty = "Empty {0} Tense Suffix for {1}. {2} person";
        public static readonly string Tense0InfoFuture = "'{0}' changes to '{1}' because the next Person Suffix starts from a vowel";
        public static readonly string Tense0InfoPastD = "{0} Tense Suffix: d + {1} (according to the vowel harmony)";
        public static readonly string Tense0InfoPastT = "{0} Tense Suffix: t + {1} (according to the vowel harmony). The last letter is voiceless, hence 't' instead of 'd'";
        public static readonly string Tense0InfoPastNw = "m + {0} + + ş (according to the vowel harmony).";
        public static readonly string Tense0InfoPc = "{0} (vowel according to the harmony vowel) + yor (Tense Suffix)";
        public static readonly string QuestionInfo = "Question Suffix: m + {0}, according to the vowel harmony";
        public static readonly string ConsBufInfo = "'y' Consonant Buffer between two vowels: {0} and {1}";
        public static readonly string PluralInfo = "In 3rd. plural person, the Plural Personal Suffix is added before the question suffix";
        public static readonly string PersonInfo = "Person Suffix for {0}. {1} person";
        public static readonly string QuestionPostInfo = "Question Suffix: m + {0}, according to the vowel harmony";
    }
}
