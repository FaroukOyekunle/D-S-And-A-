// See https://aka.ms/new-console-template for more information

int N = int.Parse(Console.ReadLine()!);
List<int> truncatablePrimes = GetTruncatablePrimes(N);
long sum = 0;

foreach (int prime in truncatablePrimes)
{
    sum += prime;
}

Console.WriteLine(sum);


static List<int> GetTruncatablePrimes(int N)
{
    List<int> primes = GeneratePrimes(N);
    List<int> truncatablePrimes = new List<int>();

    foreach (int prime in primes)
    {
        if (prime > 7 && IsTruncatablePrime(prime, primes))
        {
            truncatablePrimes.Add(prime);
        }
    }

    return truncatablePrimes;
}

static List<int> GeneratePrimes(int N)
{
    bool[] isComposite = new bool[N + 1];

    for (int i = 2; i * i <= N; i++)
    {
        if (!isComposite[i])
        {
            for (int j = i * i; j <= N; j += i)
            {
                isComposite[j] = true;
            }
        }
    }

    List<int> primes = new List<int>();
    for (int i = 2; i <= N; i++)
    {
        if (!isComposite[i])
        {
            primes.Add(i);
        }
    }

    return primes;
}

static bool IsTruncatablePrime(int num, List<int> primes)
{
    string numStr = num.ToString();

    for (int i = 1; i < numStr.Length; i++)
    {
        int leftTruncate = int.Parse(numStr.Substring(i));
        int rightTruncate = int.Parse(numStr.Substring(0, numStr.Length - i));

        if (!primes.Contains(leftTruncate) || !primes.Contains(rightTruncate))
        {
            return false;
        }
    }

    return true;
}