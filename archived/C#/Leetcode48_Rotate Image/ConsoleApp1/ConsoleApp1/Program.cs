using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ////var array2D = new int[][]
            ////{
            ////    new int[] { 1, 2,3 },
            ////    new int[] { 4,5,6 },
            ////    new int[] { 7,8,9 }
            ////};

            //var array2D = new int[][]
            //{
            //    new int[] {5,1,9,11 },
            //    new int[] { 2,4,8,10 },
            //    new int[] { 13,3,6,7},
            //    new int[] { 15, 14, 12, 16 }
            //};

            //var s = new Solution();
            //s.Rotate(array2D);
            //Console.WriteLine(array2D);

            //var str = string.Join("\n", array2D.Select(x => String.Join(",", x.Select(y => String.Join("\n", y)))));
            //Console.WriteLine(str);

            Box0 box0 = null;
            Box1 box1 = new Box2();
            box0 = box1;
            string result = box0.GetText();
            Console.WriteLine(result);

            Console.ReadLine();
        }

        public class Animal
        {
            public string Name;

            public Animal(string name)
            {
                Name = name;
            }

            public virtual void Barking()
            { }
        }

        public class Dog : Animal
        {
            public Dog(string name) : base(name)
            {
            }

            public override void Barking()
            {
                Console.WriteLine("bow");
            }
        }

        public class Box0
        {
            public virtual string GetText()
            {
                return "Box0";
            }
        }

        public abstract class Box1 : Box0
        {
            public override string GetText()
            {
                return "Box1";
            }
        }

        public class Box2 : Box1
        {
            public override string GetText()
            {
                return "Box2";
            }
        }

        public class Solution
        {
            public void Rotate(int[][] matrix)
            {
                var length = matrix[0].Length;
                var n = length - 1;

                for (var i = 0; i < length / 2; i++)
                {
                    for (var j = 0; j < length - (2 * i) - 1; j++)
                    {
                        //Swap(ref matrix[0 + i + a][j + i + a], ref matrix[n - j][0]);
                        //Swap(ref matrix[n - j][0], ref matrix[n][n - j]);
                        //Swap(ref matrix[n][n - j], ref matrix[j][n]);

                        Swap(ref matrix[i][j + i], ref matrix[n - j - i][0 + i]);
                        Swap(ref matrix[n - j - i][0 + i], ref matrix[n - i][n - j - i]);
                        Swap(ref matrix[n - i][n - j - i], ref matrix[j + i][n - i]);

                        //Swap(ref matrix[i][i], ref matrix[i][n - i]);
                        //Swap(ref matrix[n - i][i], ref matrix[i][i]);
                        //Swap(ref matrix[n - i][n - i], ref matrix[n - i][i]);
                    }
                }
            }

            private void Swap(ref int a, ref int b)
            {
                var x = a;
                a = b;
                b = x;
            }
        }
    }
}