using System;
using System.Linq;
using System.Text;

class Program
{
    const uint h0_init = 0x0000abcd, h1_init = 0x0000cdef, h2_init = 0x00002266, h3_init = 0x0000ceed, h4_init = 0x0000accd;
    const uint K = 0x00005a82;

    // 原加密函式（依題目）
    static uint[] Encrypt(uint[] M)
    {
        uint h0 = h0_init, h1 = h1_init, h2 = h2_init, h3 = h3_init, h4 = h4_init;
        uint a = h0, b = h1, c = h2, d = h3, e = h4;

        for (int i = 0; i < 5; i++)
        {
            uint f = (b + c) & 0xffffffffu;
            uint temp = ((a << 2) + f + e + K + M[i]) & 0xffffffffu;
            e = d; d = c; c = b; b = a; a = temp;
        }

        h0 = (h0 + a) & 0xffffffffu;
        h1 = (h1 + b) & 0xffffffffu;
        h2 = (h2 + c) & 0xffffffffu;
        h3 = (h3 + d) & 0xffffffffu;
        h4 = (h4 + e) & 0xffffffffu;

        return new[] { h0, h1, h2, h3, h4 };
    }

    static void Main()
    {
        // baseline：word[i] = 0
        uint[] zero = new uint[5];
        uint[] baseH = Encrypt(zero);

        string line;
        while ((line = Console.ReadLine()) != null)
        {
            line = line.Trim();
            if (line.Length == 0) continue;
            var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            uint[] H = parts.Select(p => Convert.ToUInt32(p, 16)).ToArray();

            unchecked
            {
                uint w0 = (H[4] - baseH[4]);
                uint w1 = (H[3] - baseH[3] - 4u * w0);
                uint w2 = (H[2] - baseH[2] - 17u * w0 - 4u * w1);
                uint w3 = (H[1] - baseH[1] - 73u * w0 - 17u * w1 - 4u * w2);
                uint w4 = (H[0] - baseH[0] - 313u * w0 - 73u * w1 - 17u * w2 - 4u * w3);

                byte[] bytes = {
                    (byte)((w0 + 0x20u) & 0xFFu),
                    (byte)((w1 + 0x20u) & 0xFFu),
                    (byte)((w2 + 0x20u) & 0xFFu),
                    (byte)((w3 + 0x20u) & 0xFFu),
                    (byte)((w4 + 0x20u) & 0xFFu)
                };
                Console.WriteLine(Encoding.ASCII.GetString(bytes));
            }
        }
    }
}