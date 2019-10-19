using System.Collections;
using System.Collections.Generic;
using System;

public class HSRandom
{
    private static Random rnd = null;

    private static int seed = 0;
    //private static int seed = (new System.Random()).Next();

    private static HSRandom instance = null;
    private static object padLock = new Object();

    /// <summary>
    /// Constructor to create a new CCRandom
    /// </summary>
    /// <param name="seed">The seed to start the randomizer with</param>
    private HSRandom(int seed)
    {
        rnd = new Random(seed);
    }

    /// <summary>
    /// Gets an instance of the random singleton. Makes sure that only one instance
    /// of Random actually exists.
    /// </summary>
    /// <returns>The Random Object stored in this CCRandom</returns>
    private static Random GetRandom()
    {
        if (instance == null)
        {
            lock (padLock)
            {
                if (instance == null)
                {
                    instance = new HSRandom(seed);
                }
            }
        }
        return instance.GetRandomObj();
    }

    /// <summary>
    /// Gets the actual Object stored in the CCRandom Object
    /// </summary>
    /// <returns>The Random Object Stored inside the CCRandom Object</returns>
    private Random GetRandomObj()
    {
        return rnd;
    }

    /// <summary>
    /// Returns a non-negative random integer.
    /// </summary>
    /// <returns>A 32-bit signed integer that is greater than or equal to 0 and less than Integer.MaxValue</returns>
    public static int Next()
    {
        lock (padLock)
        {
            return GetRandom().Next();
        }

    }

    /// <summary>
    /// Returns a non-negative random integer that is less than the specified maximum.
    /// </summary>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated. <c>maxValue</c> must be greater than or equal to 0.</param>
    /// <returns>A 32-bit signed integer that is greater than or equal to 0, and less than <c>maxValue</c>; that is, the range of return values ordinarily includes 0 but not <c>maxValue</c>. However, if <c>maxValue</c> equals 0, <c>maxValue</c> is returned.</returns>
    public static int Next(int maxValue)
    {
        lock (padLock)
        {
            return GetRandom().Next(maxValue);
        }

    }

    /// <summary>
    /// Returns a random integer that is within a specified range.
    /// </summary>
    /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number returned. <c>maxValue</c> must be greater than or equal to <c>minValue</c>.</param>
    /// <returns>A 32-bit signed integer greater than or equal to <c>minValue</c> and less than <c>maxValue</c>; that is, the range of return values includes <c>minValue</c> but not <c>maxValue</c>. If <c>minValue</c> equals <c>maxValue</c>, <c>minValue</c> is returned.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><c>minValue</c> is greater than <c>maxValue</c>.</exception>
    public static int Next(int minValue, int maxValue)
    {
        lock (padLock)
        {
            return GetRandom().Next(minValue, maxValue);
        }

    }

    /// <summary>
    /// Returns a random floating-point number that is greater than or equal to 0.0, and less than 1.0.
    /// </summary>
    /// <returns>A double-precision floating point number that is greater than or equal to 0.0, and less than 1.0.</returns>
    public static double NextDouble()
    {
        lock (padLock)
        {
            return GetRandom().NextDouble();
        }

    }

    /// <summary>
    /// Fills the elements of a specified array of bytes with random numbers.
    /// </summary>
    /// <param name="buffer">An array of bytes to contain random numbers.</param>
    /// <exception cref="ArgumentNullException"><c>buffer</c> is <c>null</c>.</exception>
    public static void NextBytes(byte[] buffer)
    {
        lock (padLock)
        {
            GetRandom().NextBytes(buffer);
        }

    }

    /// <summary>
    /// Resets the randomizer using the seed
    /// </summary>
    public static void ResetRandomizer()
    {
        lock (padLock)
        {
            instance = new HSRandom(seed);
        }
    }
}
