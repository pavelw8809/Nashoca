namespace Nashoca.CoreEngine.Infrastructure.Data.Nouns
{
    internal static class NounAnnotations
    {
        public static readonly string RootSuffix = "Noun Root";

        public static readonly string RootSymbol = "root";

        public static readonly string RootInfo = "Basic noun form";
        public static readonly string RootInfoChg = "Noun root form: from {0}. Last letter changes from {1} to {2} because it's voiceless";
        public static readonly string RootInfoDef = "Noun root form: from {0}. Izafet Ending {1} is removed to replace it with possesive suffix";
        public static readonly string RootInfoVowelDrop = "Noun root form from {0}. This noun is subject to vowel dropping. Hence last vowel is removed";
        public static readonly string RootInfoExc = "Noun: {0} is an exception. To create a define form, we need to add {1}";
    }
}
