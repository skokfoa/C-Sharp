using System;
using System.Data;
using System.Dynamic;

class Program
{
    static void Main()
    {
        Console.Write("輸入檔案:");
        string path = @"C:\Users\宇\Desktop\C#\107年\Q2\" + Console.ReadLine();

        string[] input;

        using (StreamReader sr = new StreamReader(path))
        {
            input = sr.ReadToEnd().Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
        }

        double[][] data = new double[input.Length][];

        for (int i = 0; i < input.Length; i++)
        {
            data[i] = input[i]
                .Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(double.Parse)
                .ToArray();
        }

        if (data.Select(d => d.Length).Distinct().Count() != 1)
        {
            Console.WriteLine("資料長度不一致");
            return;
        }

        double[] pdm = new double[data[0].Length - 1];
        double[] mdm = new double[data[0].Length - 1];

        pdm = data[0]
            .Select((x, i) => i == 0 ? 0 : Math.Max(0, x - data[0][i - 1]))
            .Skip(1)
            .ToArray();

        mdm = data[2]
            .Select((x, i) => i == 0 ? 0 : Math.Max(0, data[2][i - 1] - x))
            .Skip(1)
            .ToArray();

        for (int i = 0; i < data[0].Length - 1; i++)
        {
            if (pdm[i] > mdm[i])
            {
                mdm[i] = 0;
            }
            else if (mdm[i] > pdm[i])
            {
                pdm[i] = 0;
            }
            else
            {
                pdm[i] = 0;
                mdm[i] = 0;
            }
        }

        double[] TR = new double[data[0].Length - 1];

        for (int i = 1; i < data[0].Length; i++)
        {
            double high = data[0][i];
            double low = data[2][i];
            double prevClose = data[1][i - 1];
            double tr1 = Math.Abs(high - low);
            double tr2 = Math.Abs(high - prevClose);
            double tr3 = Math.Abs(low - prevClose);
            TR[i - 1] = Math.Max(tr1, Math.Max(tr2, tr3));
        }

        double[] PDI, MDI;

        PDI = Enumerable.Range(0, TR.Length)
            .Select(i => i < 9 ? 0 : pdm.Skip(i - 9).Take(10).Sum() / TR.Skip(i - 9).Take(10).Sum())
            .Skip(9)
            .ToArray();

        MDI = Enumerable.Range(0, TR.Length)
            .Select(i => i < 9 ? 0 : mdm.Skip(i - 9).Take(10).Sum() / TR.Skip(i - 9).Take(10).Sum())
            .Skip(9)
            .ToArray();

        double[] DX;

        DX = Enumerable.Range(0, PDI.Length)
            .Select(i => 100 * (Math.Abs(PDI[i] - MDI[i]) / (PDI[i] + MDI[i])))
            .ToArray();

        double[] ADX;
        
        ADX = Enumerable.Range(0, DX.Length)
            .Select(i => i < 9? 0 : DX.Skip(i - 9).Take(10).Average())
            .Skip(9)
            .ToArray();

        int[] predict;

        predict = Enumerable.Range(0, ADX.Length - 1)
            .Select(i => ADX[i + 1] >= ADX[i] ? 1 : 0)
            .ToArray();

        Console.WriteLine("最高價:");
        Console.WriteLine(string.Join(" ", data[0].Select(x => $"{x,4:F1}")));
        Console.WriteLine("收盤價:");
        Console.WriteLine(string.Join(" ", data[1].Select(x => $"{x,4:F1}")));
        Console.WriteLine("最低價:");
        Console.WriteLine(string.Join(" ", data[2].Select(x => $"{x,4:F1}")));

        Console.WriteLine();
        Console.WriteLine("ADX: " + string.Join(" ", ADX.Skip(1).Select(x => $"{x,6:F2}")));
        Console.WriteLine("預測:  " + string.Join(" ", predict.Select(x => $"{x,-6}")));
    }
}