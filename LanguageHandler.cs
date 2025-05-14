using System.Numerics;
using System.Text.RegularExpressions;

namespace ProtoZeke
{
    public class LanguageHandler
    {

        private Random Random = new Random();
        private BinaricHandler binaricHandler = new BinaricHandler();
        HashSet<BigInteger> Vocabulary = new HashSet<BigInteger>();

        //Assigns words a matrix position
        public Dictionary<BigInteger, float[]> AssignMatrix(string[] strings)
        {
            Dictionary<BigInteger, float[]> keyValuePairs = new Dictionary<BigInteger, float[]>();

            foreach (string s in strings)
            {
                float Xpos = Random.Next(-1, 1);
                float Ypos = Random.Next(-1, 1);
                float Zpos = Random.Next(-1, 1);
                float[] MatrixPos = [Xpos,Ypos,Zpos];
                BigInteger MatrixKey = binaricHandler.BinToInt(binaricHandler.StringToBin(s));

                if (!keyValuePairs.ContainsKey(MatrixKey))
                {
                    keyValuePairs.Add(MatrixKey,MatrixPos);
                }
            }

            return keyValuePairs;
        }


        //Converts text to lowerspace and splits into an array of individual words
        public string[] Tokenize(string input)
        {
            string workedInput = input.ToLower();
            workedInput = RemoveNonAlphaNumericAndSpace(workedInput);

            string[] SplitInput = workedInput.Split(' ');

            return SplitInput;
        }

        //Removes anything that isn't a Space or Char from the string
        static string RemoveNonAlphaNumericAndSpace(string input)
        {
            // This regular expression matches anything that isn't a letter or space
            return Regex.Replace(input, @"[^a-zA-Z\s]", "");
        }

        public void LoadDict()
        {
            HashSet<BigInteger> keys = new HashSet<BigInteger>();

            foreach (var Line in File.ReadLines(MemoryHandler.QueryData()))
            {
               keys.Add(binaricHandler.BinToInt(binaricHandler.StringToBin(Line.ToLower())));
            }

            Vocabulary.Clear();
            Vocabulary.UnionWith(keys);
            keys.Clear();
            Console.WriteLine($"Words Loaded: {Vocabulary.Count}...");

        }
    }
}
