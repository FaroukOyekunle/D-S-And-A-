// See https://aka.ms/new-console-template for more information

    string[] input = Console.ReadLine()!.Split();
    int N = int.Parse(input[0]);
    int K = int.Parse(input[1]);

    long sum = SumOfPalindromicNumbers(N, K);
    Console.WriteLine(sum);
    

    static long SumOfPalindromicNumbers(int N, int K)
    {
        long sum = 0;

        for (int num = 1; num < N; num++)
        {
            if (IsPalindrome(num.ToString()) && IsPalindrome(ConvertToBaseK(num, K)))
            {
                sum += num;
            }
        }

        return sum;
    }

    static bool IsPalindrome(string str)
    {
        int leftPalindrome = 0;
        int rightPalindrome = str.Length - 1;

        while (leftPalindrome < rightPalindrome)
        {
            if (str[leftPalindrome] != str[rightPalindrome])
            {
                return false;
            }
            leftPalindrome++;
            rightPalindrome--;
        }

        return true;
    }

    static string ConvertToBaseK(int num, int K)
    {
        string result = "";
        while (num > 0)
        {
            int remainder = num % K;
            result = remainder.ToString() + result;
            num /= K;
        }
        return result;
    }
