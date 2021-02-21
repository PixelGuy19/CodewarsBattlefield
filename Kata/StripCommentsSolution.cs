namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static string StripComments(string text, string[] commentSymbols)
        {
            string[] Lines = text.Split('\n');
            for (int I = 0; I < Lines.Length; I++)
            {
                foreach (string T in commentSymbols)
                {
                    Lines[I] = TrimComment(Lines[I], T);
                }
            }
            return string.Join('\n', Lines);

            string TrimComment(string Str, string Comment)
            {
                if (!Str.Contains(Comment))
                {
                    return Str.TrimEnd();
                }
                return Str.Substring(0, Str.IndexOf(Comment)).TrimEnd();
            }
        }
    }
}