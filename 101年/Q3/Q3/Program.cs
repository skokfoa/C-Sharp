using System.Diagnostics;

int n = new int();
double r = new double();
List<int> m = new List<int>();

Console.Write("請輸入徑向距離(r) =");
if (!double.TryParse(Console.ReadLine(), out r))
{
    Console.WriteLine("輸入錯誤，請輸入有效的數字。");
    return;
}

Console.Write("請輸入徑向多項式的次數(n) =");
if (!int.TryParse(Console.ReadLine(), out n))
{
    Console.WriteLine("輸入錯誤，請輸入有效的數字。");
    return;
}else if (n < 0)
{
    Console.WriteLine("輸入錯誤，請輸入正整數。");
    return;
}


for (int i = 0; i <= n; i++)
{
    if ((n - Math.Abs(i)) % 2 == 0)
    {
        m.Add(i);
    }
}

for(int i = 0; i < m.Count; i++)
{
    double ans = 0;
    Console.WriteLine($"計算徑向多項式(radial polynomials) ..., r = {r}, n = {n}, m = {m[i]}");
    for(int s = 0;s <= (n - m[i]) / 2; s++)
    {
        if(s % 2 == 0)
        {
            ans += (count(n - s)) / (count(s) * count(((n + m[i]) / 2) - s) * count(((n - m[i]) / 2) - s)) * Math.Pow(r,n - 2 * s);
        }
        else
        {
            ans -= (count(n - s)) / (count(s) * count(((n + m[i]) / 2) - s) * count(((n - m[i]) / 2) - s)) * Math.Pow(r, n - 2 * s);
        }
    }
    Console.WriteLine($"所求之徑向多項式為 = {ans}");
}

Console.WriteLine("計算完畢!");
int count(int i)
{
    if (i == 0 || i == 1)
    {
        return 1;
    }
    else
    {
        return i * count(i - 1);
    }
}
