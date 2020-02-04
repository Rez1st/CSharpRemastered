using System;

namespace Runner
{
    public static class Extensions
    {
        public static void Fill(this int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
                arr[i] = i + 1;
        }

        public static void FillRandom(this int[] arr)
        {
            var rnd = new Random();

            for (var i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(1, 100);
        }
    }
}