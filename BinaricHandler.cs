using System.Numerics;
using System.Text;

namespace ProtoZeke
{
    class BinaricHandler
    {

        public string StringToBin(string input) { 
            
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                sb.Append(Convert.ToString(c,2).PadLeft(8,'0'));
            }
            return sb.ToString();
        }

        public string BinToString(string input)
        {
            if (input.Length % 8 != 0)
            {
                input.PadLeft((input.Length / 8 + 1) * 8, '0');
            }

            string result = string.Empty;

            for (int i = 0; i < input.Length; i+=8)
            {
                string bytechunk = input.Substring(i, 8);

                int decimalValue = Convert.ToInt32(bytechunk, 2);

                result += (char)decimalValue;
            }
            return result;
        }

        public BigInteger BinToInt(string input)
        {
            BigInteger bigInteger = BigInteger.Parse(input);

            return bigInteger;
        }

    }
}
