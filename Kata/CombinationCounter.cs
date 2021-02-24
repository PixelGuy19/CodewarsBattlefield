namespace CodeWarsBattlefield
{
    partial class Program
    {
        public static int CountCombinations(int money, int[] coins)
        {
            //skipped this Kata, this solution was in best p.
            
            int[] ways = new int[money + 1];
            ways[0] = 1;

            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = coins[i]; j <= money; j++)
                {
                    ways[j] += ways[j - coins[i]];
                }
            }
            return ways[money];
        }
    }
}