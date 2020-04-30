using System;

public static class RandomHandler
{
    private static readonly Random random = new Random();

    public static double EnemyRandomShoot()
    {
        return random.NextDouble() * 10.92756195672f;
    }

    public static double AsteroidRandomAppear()
    {
        return random.NextDouble() * 20.92756195672f;
    }
}