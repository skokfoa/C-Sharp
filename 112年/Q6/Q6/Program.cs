using System;
using System.Collections.Generic;
using System.IO;

class Elevator
{
    public bool UpOrDown { get; set; } // true=上, false=下
    public int stairs { get; set; }
    public int times { get; set; }

    public Elevator(bool UpOrDown, int stairs, int times = 0)
    {
        this.UpOrDown = UpOrDown;
        this.stairs = stairs;
        this.times = times;
    }

    public static bool upordown(string a)
    {
        return a == "U";
    }

    public static string dirString(bool b) => b ? "U" : "D";
}

class Program
{
    static readonly string[] floors = new string[]
        { "B2", "B1", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };

    static void Main()
    {
        Console.Write("Enter 1st filename:");
        string path1 = @"C:\Users\宇\Desktop\C#\112年\Q6\" + Console.ReadLine();
        var input1 = File.ReadAllLines(path1);

        Elevator A = null, B = null;
        for (int i = 0; i < 2; i++)
        {
            var line = input1[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool up = Elevator.upordown(line[1]);
            int stair = Array.IndexOf(floors, line[2]);
            if (i == 0) A = new Elevator(up, stair);
            else B = new Elevator(up, stair);
        }

        // 最後一行：最後一次外部按壓
        var end = input1[input1.Length - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        bool endUp = Elevator.upordown(end[0]);
        int endFloor = Array.IndexOf(floors, end[1]);

        bool[] AI = new bool[18], BI = new bool[18], OU = new bool[18], OD = new bool[18];
        int[] TAU = new int[18], TAD = new int[18], TBU = new int[18], TBD = new int[18];

        if (endUp) OU[endFloor] = true;
        else OD[endFloor] = true;

        Console.Write("Enter 2nd filename:");
        string path2 = @"C:\Users\宇\Desktop\C#\112年\Q6\" + Console.ReadLine();
        var input2 = File.ReadAllLines(path2);

        // 讀入表格
        for (int i = 0; i < input2.Length; i++)
        {
            var line = input2[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 1; j < line.Length; j++)
            {
                switch (i)
                {
                    case 0: AI[j - 1] = line[j] == "1"; break;
                    case 1: BI[j - 1] = line[j] == "1"; break;
                    case 2: OU[j - 1] = line[j] == "1"; break;
                    case 3: OD[j - 1] = line[j] == "1"; break;
                    case 4: TAU[j - 1] = int.Parse(line[j]); break;
                    case 5: TAD[j - 1] = int.Parse(line[j]); break;
                    case 6: TBU[j - 1] = int.Parse(line[j]); break;
                    case 7: TBD[j - 1] = int.Parse(line[j]); break;
                }
            }
        }

        // 模擬 A, B 兩部電梯到該外部按壓樓層的時間
        int timeA = CalcTime(A, AI, OU, OD, endFloor, endUp);
        int timeB = CalcTime(B, BI, OU, OD, endFloor, endUp);

        Console.WriteLine($"\n最後外部按壓: {(endUp ? "上" : "下")} 於 {floors[endFloor]}");
        Console.WriteLine($"A 電梯位置 {floors[A.stairs]} 方向 {(A.UpOrDown ? "上" : "下")}");
        Console.WriteLine($"B 電梯位置 {floors[B.stairs]} 方向 {(B.UpOrDown ? "上" : "下")}");
        Console.WriteLine($"A 到達時間: {timeA}");
        Console.WriteLine($"B 到達時間: {timeB}");

        string dispatch;
        if (timeA == 0 && timeB == 0) dispatch = "無法派遣";
        else if (timeA == 0) dispatch = "B";
        else if (timeB == 0) dispatch = "A";
        else if (timeA < timeB) dispatch = "A";
        else if (timeB < timeA) dispatch = "B";
        else dispatch = "A"; // 平手給 A

        Console.WriteLine($"👉 指派電梯：{dispatch}");
    }

    /// <summary>
    /// 計算電梯到目標樓層所需時間（秒）
    /// </summary>
    static int CalcTime(Elevator e, bool[] inside, bool[] OU, bool[] OD, int target, bool targetUp)
    {
        int pos = e.stairs;
        bool dir = e.UpOrDown;   // true=上, false=下
        int time = 0;

        const int travel = 3; // 每層 3 秒
        const int stop = 6;   // 停靠 6 秒

        while (true)
        {
            // 只看「相對於目前位置」的需求
            bool hasUp = false;
            bool hasDown = false;
            for (int i = pos + 1; i < 18; i++)
                if (OU[i] || inside[i]) { hasUp = true; break; }

            for (int i = pos - 1; i >= 0; i--)
                if (OD[i] || inside[i]) { hasDown = true; break; }

            if (!hasUp && !hasDown) return 0; // 完全沒任務

            if (dir) // 往上
            {
                if (!hasUp) { dir = false; continue; } // 上面沒同向任務 → 反向

                int next = -1;
                for (int i = pos + 1; i < 18; i++)
                    if (OU[i] || inside[i]) { next = i; break; }

                time += (next - pos) * travel;
                pos = next;
                time += stop;

                // 停站清除
                if (OU[pos]) OU[pos] = false;
                if (inside[pos]) inside[pos] = false;

                // 到達指定的“向上”目標
                if (pos == target && targetUp) return time;

                // 不在這裡判斷是否反向；回到 while 頂端重算
            }
            else // 往下
            {
                if (!hasDown) { dir = true; continue; } // 下方沒同向任務 → 反向

                int next = -1;
                for (int i = pos - 1; i >= 0; i--)
                    if (OD[i] || inside[i]) { next = i; break; }

                time += (pos - next) * travel;
                pos = next;
                time += stop;

                if (OD[pos]) OD[pos] = false;
                if (inside[pos]) inside[pos] = false;

                if (pos == target && !targetUp) return time;
            }
        }
    }

}
