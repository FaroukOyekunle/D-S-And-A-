// See https://aka.ms/new-console-template for more information


    Console.WriteLine("To input the required input:");
    int T = int.Parse(Console.ReadLine());
    
    for (int t = 0; t < T; t++)
    {
        int N = int.Parse(Console.ReadLine());
        long result = GetPandigitalSum(N);
        Console.WriteLine(result);
    }

    static long GetPandigitalSum(int N)
    {
        long sum = 0;
        List<int> digits = new List<int>();

        // Initialize digits list with 0 to N digits
        for (int i = 0; i <= N; i++)
        {
            digits.Add(i);
        }

        // Find all pandigital numbers and check the divisibility property
        FindPandigital(digits, 0, N, ref sum);

        return sum;
    }

    static void FindPandigital(List<int> digits, int start, int end, ref long sum)
    {
        if (start == end)
        {
            // Check the divisibility property for the pandigital number
            if (IsDivisiblePropertySatisfied(digits))
            {
                sum += GetNumberFromDigits(digits);
            }
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                Swap(digits, start, i);
                FindPandigital(digits, start + 1, end, ref sum);
                Swap(digits, start, i);
            }
        }
    }

    static void Swap(List<int> digits, int i, int j)
    {
        int temp = digits[i];
        digits[i] = digits[j];
        digits[j] = temp;
    }

    static bool IsDivisiblePropertySatisfied(List<int> digits)
    {
        int[] primes = { 2, 3, 5, 7, 11, 13, 17 };

        for (int i = 1; i < digits.Count - 2; i++)
        {
            int num = digits[i] * 100 + digits[i + 1] * 10 + digits[i + 2];
            if (num % primes[i - 1] != 0)
            {
                return false;
            }
        }

        return true;
    }

    static long GetNumberFromDigits(List<int> digits)
    {
        long number = 0;
        foreach (int digit in digits)
        {
            number = number * 10 + digit;
        }
        return number;
    }