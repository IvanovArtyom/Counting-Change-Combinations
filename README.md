## Description:
Write a function that counts how many different ways you can make change for an amount of money, given an array of coin denominations. For example, there are 3 ways to give change for 4 if you have coins with denomination 1 and 2:

```1+1+1+1, 1+1+2, 2+2.```

The order of coins does not matter:

```1+1+2 == 2+1+1```

Also, assume that you have an infinite amount of coins.

Your function should take an amount to change and an array of unique denominations for the coins:
```C#
CountCombinations(4, new[] {1,2}) // => 3
CountCombinations(10, new[] {5,2,3}) // => 4
CountCombinations(11, new[] {5,7}) //  => 0
```
### My solution
```C#
using System.Collections.Generic;

public static class Kata
{
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
```
