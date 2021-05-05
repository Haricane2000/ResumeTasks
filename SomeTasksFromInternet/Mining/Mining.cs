using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace _6th_homework
{
    public class Mining
    {
        public static List<BigInteger> Factorization(BigInteger N)
        {
            if (N < 2)
                throw new ArgumentException("Must be > 2");

            List<BigInteger> s = new List<BigInteger>();

            while ((N % 2) == 0)
            {
                N /= 2;
                s.Add(2);
            }

            int b = 3; int c = (int)Math.Pow(Math.E, BigInteger.Log(N) / 2) + 1;
            while (b < c)
            {
                if ((N % b) == 0)
                {
                    if (N / b * b - N == 0)
                    {
                        s.Add(b);
                        N /= b;
                        c = (int)Math.Pow(Math.E, BigInteger.Log(N) / 2) + 1;
                    }
                    else
                        b += 2;
                }
                else
                    b += 2;
            }
            s.Add(N);
            return s;
        }

        public static Task<List<BigInteger>> FactorizationAsync(BigInteger n)
        {
            var tcs = new TaskCompletionSource<List<BigInteger>>();
            new Thread(Calculation).Start();
            return tcs.Task;

            void Calculation()
            {
                try
                {
                    List<BigInteger> result = Factorization(n);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }
        public static async Task<BigInteger> CalculateGcd(BigInteger a, BigInteger b)
        {
            List<BigInteger> firstList = await FactorizationAsync(a);
            List<BigInteger> secondList = await FactorizationAsync(b);

            Task<BigInteger> task = new Task<BigInteger>( ()=>
            {
                BigInteger res = 1;
                foreach (var l in new List<BigInteger>(firstList.Intersect(secondList)))
                {
                    res *= l;
                }

                return res;
            });
            task.Start();

            return await task;
        }
    }
}