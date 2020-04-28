public static class RandomHandler
{
    private static readonly System.Random random = new System.Random();

    public static double EnemyRandomShoot()
    {
        return random.NextDouble() * 10.92756195672f;
    }

    public static double AsteroidRandomAppear()
    {
        return random.NextDouble() * 20.92756195672f;
    }
}
