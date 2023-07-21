// See https://aka.ms/new-console-template for more information

    int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            int result = GetSmallestDivisibleNumber(n);
            Console.WriteLine(result);
        }

    static int GetSmallestDivisibleNumber(int n)
    {
        int smallestDivisible = 1;
        for (int i = 2; i <= n; i++)
        {
            smallestDivisible = GetLeastCommonMultiple(smallestDivisible, i);
        }
        return smallestDivisible;
    }

    static int GetLeastCommonMultiple(int a, int b)
    {
        return (a * b) / GetGreatestCommonDivisor(a, b);
    }

    static int GetGreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }
