using System.Collections.Generic;

public static class Kata
{
    public static void Main()
    {
        // Test
        var t = CountCombinations(10, new[] { 5, 2, 3 });
        // ...should return 4
    }

    public static int CountCombinations(int money, int[] coins)
    {
        Queue<(int, int)> queue = new();
        queue.Enqueue((0, 0));
        int combinationsCount = 0;

        while (queue.Count != 0) 
        { 
            var currentElement = queue.Dequeue();

            foreach (int coin in coins)
            {
                if (coin >= currentElement.Item2 && currentElement.Item1 + coin <= money)
                {
                    if (currentElement.Item1 + coin == money)
                    {
                        combinationsCount++;
                        continue;
                    }

                    queue.Enqueue((currentElement.Item1 + coin, coin));
                }
            }
        }

        return combinationsCount;
    }
}