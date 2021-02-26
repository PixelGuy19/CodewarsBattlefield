using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static string DecodeBits(string bits)
        {
            bits = "0" + bits + "0";
            
            List<string> Members = new List<string>();
            bool LastBit = bits[0] == '1';
            int FirstCharIndex = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] != (LastBit ? '1' : '0') || IsLastBit(ref i))
                {
                    Members.Add(bits.Substring(FirstCharIndex, i - FirstCharIndex));
                    LastBit = !LastBit;
                    FirstCharIndex = i;
                }
            }
            
            Members.Remove("0");
            int Short = Members.OrderBy(s=>s.Length).First().Length;

            string OutWord = string.Empty;
            foreach (string Member in Members)
            {
                {
                    if (Member[0] == '0')
                    {
                        if (Member.Length >= Short * 7)
                        {
                            OutWord += "   ";
                        }
                        else if (Member.Length >= Short * 3)
                        {
                            OutWord += " ";
                        }
                    }
                    else
                    {
                        if (Member.Length < 3 * Short)
                        {
                            OutWord += ".";
                        }
                        else
                        {
                            OutWord += "-";
                        }
                    }
                }
            }
            
            return OutWord;
            
            bool IsLastBit(ref int I)
            {
                if (I == bits.Length - 1)
                {
                    I++;
                    return true;
                }

                return false;
            }
        }
        public static string decodeBitsAdvanced (string bits)
        {
            if (bits == string.Empty)
            {
                return string.Empty;
            }

            bits = bits.Trim('0');
            bits = "0" + bits;
            
            List<string> Members = new List<string>();
            bool LastBit = bits[0] == '1';
            int FirstCharIndex = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] != (LastBit ? '1' : '0') || IsLastBit(ref i))
                {
                    Members.Add(bits.Substring(FirstCharIndex, i - FirstCharIndex));
                    LastBit = !LastBit;
                    FirstCharIndex = i;
                }
            }

            List<string> Zeros = Members.Where(S => S.Contains('0')).ToList();
            List<string> Ones = Members.Except(Zeros).ToList();
            
            //For each word reset
            int MaxZero = Zeros.OrderByDescending(s => s.Length).First().Length;
            int MaxOne = Ones.Max().Length;

            string OutCode = string.Empty;
            foreach (string Member in Members)
            {
                if (Member[0] == '0')
                {
                    if (Member.Length > MaxZero * 0.6f)
                    {
                        OutCode += "   ";
                    }
                    else if (Member.Length > MaxZero * 0.3f)
                    {
                        OutCode += " ";
                    }
                    else
                    {
                        OutCode += "";
                    }
                }
                else
                {
                    OutCode += Member.Length > MaxOne * 0.3f ? "-" : ".";
                }
            }

            return OutCode;

            bool IsLastBit(ref int I)
            {
                if (I == bits.Length - 1)
                {
                    I++;
                    return true;
                }

                return false;
            }

            int ScoreMidWeight(List<string> Of)
            {
                float Weight = 0;
                foreach (string Member in Of)
                {
                    Weight += Member.Length;
                }

                return (int)Math.Round(Weight / Of.Count);
            }
        }

        static Dictionary<string, char> MorseCodeVac = new Dictionary<string, char>()
        {
            {".-", 'a'},
            {"-...", 'b'},
            {"-.-.", 'c'},
            {"-..", 'd'},
            {".", 'e'},
            {"..-.", 'f'},
            {"--.", 'g'},
            {"....", 'h'},
            {"..", 'i'},
            {".---", 'j'},
            {"-.-", 'k'},
            {".-..", 'l'},
            {"--", 'm'},
            {"-.", 'n'},
            {"---", 'o'},
            {".--.", 'p'},
            {"--.-", 'q'},
            {".-.", 'r'},
            {"...", 's'},
            {"-", 't'},
            {"..-", 'u'},
            {"...-", 'v'},
            {".--", 'w'},
            {"-..-", 'x'},
            {"-.--", 'y'},
            {"--..", 'z'}
        };
        
        public static string decodeMorse (string morseCode)
        {
            morseCode = morseCode.Trim();
            string[] Words = morseCode.Split("   ");
            if (Words.Length == 0)
            {
                Words = new[] {morseCode};
            }
            for (int Index = 0; Index < Words.Length; Index++)
            {
                string Word = Words[Index];
                string OutWord = string.Empty;
                string[] Letters = Word.Split(' ');
                foreach (string Letter in Letters)
                {
                    if (MorseCodeVac.TryGetValue(Letter, out char L))
                    {
                        OutWord += L;
                    }
                }

                Words[Index] = OutWord.ToUpper();
            }

            return string.Join(' ', Words);
        }
    }
}