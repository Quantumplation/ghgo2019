using System;

public static class SimonFlexing
{
    public static void ForEach<T>(this T[,,] array, Action<T, int, int, int> action)
    {
        for (var x = 0; x < array.GetLength(0); ++x)
        {
            for (var y = 0; y < array.GetLength(1); ++y)
            {
                for (var z = 0; z < array.GetLength(2); ++z)
                {
                    action(array[x, y, z], x,  y, z);
                }
            }
        }
    }
}