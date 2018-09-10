namespace Labs3
{
    public static class MyMath
    {
        public static int GreatestCommonDivisor(int x, int y)
        {
            while (x != 0 && y != 0)
            {
                if (x > y)
                    x %= y;
                else
                    y %= x;
            }

            return x == 0 ? y : x;
        }
        public static int LeastCommonMultiply(int x, int y) => x * y / GreatestCommonDivisor(x, y);
    }
}
