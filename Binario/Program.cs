using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binario
{
    class Program
    {
        static void Main(string[] args)
        {
            string binario = ("01001001 00100000 01100001 01101101 00100000 01100011 01110101 01110010 01110010 01100101 01101110 01110100 01101100 01111001 00100000 01101100 01101111 01101111 01101011 01101001 01101110 01100111 00100000 01100110 01101111 01110010 00100000 01100001 00100000 01010011 01100101 01101110 01101001 01101111 01110010 00100000 01101100 01100101 01110110 01100101 01101100 00100000 01001010 01100001 01110110 01100001 00100000 01000100 01100101 01110110 01100101 01101100 01101111 01110000 01100101 01110010 00100000 01110100 01101111 00100000 01101010 01101111 01101001 01101110 00100000 01010011 01100001 01101110 00100000 01000110 01110010 01100001 01101110 01100011 01101001 01110011 01100011 01101111 00100111 01110011 00100000 01100110 01100001 01110011 01110100 01100101 01110011 01110100 00100000 01100111 01110010 01101111 01110111 01101001 01101110 01100111 00100000 01110011 01110100 01100001 01110010 01110100 01110101 01110000 00101110 00100000 01101100 01100101 01110111 01101001 01110011 00101110 01100001 01100100 01000000 01100100 01100001 01110010 01110111 01101001 01101110 01110010 01100101 01100011 01110010 01110101 01101001 01110100 01101101 01100101 01101110 01110100 00101110 01100011 01101111 01101101").Replace(" ", "");
            //var data = GetBytesFromBinaryString(binario);
            var data = BinaryToString("");
            //var text = Encoding.ASCII.GetString(data);

            Console.WriteLine(data);
            Console.ReadKey();
        }

        public static Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        public static string BinaryToString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                throw new ArgumentNullException("binary");

            if ((binary.Length % 8) != 0)
                throw new ArgumentException("Binary string invalid (must divide by 8)", "binary");

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < binary.Length; i += 8)
            {
                string section = binary.Substring(i, 8);
                int ascii = 0;
                try
                {
                    ascii = Convert.ToInt32(section, 2);
                }
                catch
                {
                    throw new ArgumentException("Binary string contains invalid section: " + section, "binary");
                }
                builder.Append((char)ascii);
            }
            return builder.ToString();
        }
    }
}
