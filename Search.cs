using System;

public class Search
{
    public static void BinarySearch(int[] array, int key)
    {
        int high = array.Length - 1;
        int low = 0;
        int flag = 0;

        while (low < high)
        {
            int i = low + (high - low) / 2;
            int find = array[i];
            if (find == key)
            {
                Console.WriteLine("The element {0} at position: {1}", key, i);
                flag = 1;
                break;
            }

            if (key > find)
                low = i + 1;
            else high = i - 1;
        }

        if (flag == 0) Console.WriteLine("No element {0}", key);

    }


    public static void InterpolSearch(int[] array, int key)
    {
        int n = array.Length;
        int low = 0;
        int high = n - 1;
        int flag = 0;

        while (array[low] <= key && key <= array[high] && high > low)
        {
            int interp = (key - array[low]) * (high - low) / (array[high] - array[low]) + low;
            if (array[interp] == key)
            {
                Console.WriteLine("The element {0} at position: {1}", key, interp);
                flag = 1;
                break;
            }

            if (array[interp] < key) low = interp + 1;
            else high = interp - 1;

        }
        if (flag == 0) Console.WriteLine("No element {0}", key);
    }


    public static void Boyer_MooreSearch(string s, string key)
    {
        int[] shift_table = new int[256];
        for (int i = 0; i < 256; i++)
            shift_table[i] = key.Length;

        for (int i = 0; i < key.Length - 1; i++)
            shift_table[key[i]] = key.Length - i - 1;

        int i2 = key.Length - 1;
        int flag = 0;
        while (i2 < s.Length)
        {
            int k = 0;
            while (k < key.Length && key[key.Length - 1 - k] == s[i2 - k])
            {
                k++;
            }

            if (k == key.Length)
            {
                Console.WriteLine("The element {0} at position: {1}", key, i2 - key.Length + 1);
                flag = 1;
            }

            i2 += shift_table[s[i2]];
        }

        if (flag == 0) Console.WriteLine("No element {0}", key);
    }

}
