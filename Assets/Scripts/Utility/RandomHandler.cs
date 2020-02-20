public static class RandomHandler
{
    private static readonly System.Random random = new System.Random();

    public static double GetRandomNumber()
    {
        return random.NextDouble() * 10.92756195672f;
    }
    public static double GetRandomNumber2()
    {
        return random.NextDouble() * 20.92756195672f;
    }
}