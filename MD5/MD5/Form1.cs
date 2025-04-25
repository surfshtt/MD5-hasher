using System.Text;

namespace MD5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private uint h0 = 0x67452301;
        private uint h1 = 0xefcdab89;
        private uint h2 = 0x98badcfe;
        private uint h3 = 0x10325476;

        private readonly uint[] K = { //константы 32бита?? корни простых чисел
            0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee,
            0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501,
            0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be,
            0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821,
            0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa,
            0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8,
            0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed,
            0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a,
            0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c,
            0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70,
            0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05,
            0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665,
            0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039,
            0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1,
            0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1,
            0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
        };

        private readonly int[] S = {//кол битов для сдвига
            7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,
            5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20,
            4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23,
            6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21
        };

        private void encrypt_Click(object sender, EventArgs e)
        {
            textBox3.Text = enc(textBox2.Text);
        }

        private uint[] podgotovk(string msg)
        {
            var bytes = new List<byte>();
            byte[] msgBytes = Encoding.UTF8.GetBytes(msg);

            bytes.AddRange(msgBytes);

            bytes.Add(0x80); 

            while ((bytes.Count * 8) % 512 != 448)
            {
                bytes.Add(0x00);
            }

            ulong bitLength = (ulong)msgBytes.Length * 8; // бит в байт 1 к 8
            bytes.AddRange(BitConverter.GetBytes(bitLength));

            List<uint> blocks = new List<uint>();
            for (int i = 0; i < bytes.Count; i += 4)
            {
                uint block = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (i + j < bytes.Count)
                    {
                        block |= (uint)(bytes[i + j] << (j * 8));
                    }
                }
                blocks.Add(block);
            }
            return blocks.ToArray();
        }
        private uint sdvigLev(uint x, int c)
        {
            return (x << c) | (x >> (32 - c));
        }

        private string enc(string input)
        {
            uint a = h0, b = h1, c = h2, d = h3;
            uint[] blocks = podgotovk(input);

            uint aa = a, bb = b, cc = c, dd = d;
            for (int j = 0; j < 64; j++)
            {
                uint f, g;
                if (j < 16)
                {
                    f = (bb & cc) | ((~bb) & dd);
                    g = (uint)j;
                }
                else if (j < 32)
                {
                    f = (dd & bb) | ((~dd) & cc);
                    g = (uint)((5 * j + 1) % 16);
                }
                else if (j < 48)
                {
                    f = bb ^ cc ^ dd;
                    g = (uint)((3 * j + 5) % 16);
                }
                else
                {
                    f = cc ^ (bb | (~dd));
                    g = (uint)((7 * j) % 16);
                }
                uint temp = dd;
                dd = cc;
                cc = bb;
                bb += sdvigLev((aa + f + K[j] + blocks[g]), S[j]); //1 сам бит 2 сдвиг
                aa = temp;
            }
            a += aa;
            b += bb;
            c += cc;
            d += dd;
            
            byte[] hashBytes = new byte[16];
            Buffer.BlockCopy(new uint[] { a, b, c, d }, 0, hashBytes, 0, 16);

            StringBuilder sb = new StringBuilder();
            foreach (byte i in hashBytes)
            {
                sb.Append(i.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}