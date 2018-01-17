using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Coin_Change
{
    class Program
    {
        private static int A;
        private static int N = 4;
        private static int INF = 9999;

        public static int Reader()
        {
            int input = 0;
            try
            {
                using (StreamReader read = new StreamReader("C:\\input.txt"))
                {
                    input = int.Parse(read.ReadLine());
                    Console.WriteLine("input from file:{0}", input);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return input;
        }
        static void coinChange(int[] d, int[] C, int[] S)
        {

            int i, p, min, coin = 0;

            //when amount is 0
            //then min coin required is 0
            C[0] = 0;
            S[0] = 0;

            for (p = 1; p <= A; p++)
            {
                min = INF;
                for (i = 1; i <= N; i++)
                {
                    if (d[i] <= p)
                    {
                        if (1 + C[p - d[i]] < min)
                        {
                            min = 1 + C[p - d[i]];
                            coin = i;
                        }
                    }
                }
                C[p] = min;
                S[p] = coin;
            }
        }

        static void coinSet(int[] d, int[] S)
        {
            int a = A;
            while (a > 0)
            {
                Console.WriteLine("Use coin of denomination: " + d[S[a]]);
                a = a - d[S[a]];
            }
        }

        static void display(int[] arr)
        {
            int c;
            for (c = 0; c <= A; c++)
            {
                Console.Write("{0}  ", arr[c]);//%5d

            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            A = Reader();


            //denomination d of the coins
            //we will start from index 1
            //so, index 0 is set to 0
            int[] d = { 0, 1, 2, 5, 10 };

            //Minimum number of coins required to make change
            int[] C = new int[A + 1];

            //S contain the index of the coin to be included
            //in the optimal solution
            int[] S = new int[A + 1];

            //compute minimum number of coins required
            coinChange(d, C, S);

            //display the content of the C array
            //Console.WriteLine("\nC[p]\n");
            //display(C);

            //display the content of the S array
            //Console.WriteLine("\nS[p]\n");
            //display(S);

            //display the minimum number of coins required to
            //make change for amount A
            Console.WriteLine("\nMin. no. of coins required to make change for amount {0} = {1}\n", A, C[A]);

            //display the coins used in the optimal solution
            Console.WriteLine("\nCoin Set\n");
            coinSet(d, S);
            Console.Read();

        }
    }

}
