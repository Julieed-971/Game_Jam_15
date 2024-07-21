using System;

public class SeededRNG {
    private Random random;

    // Constructor that takes a seed value
    public SeededRNG(int seed) {
        random = new Random(seed);
    }

    // Generate a random integer between min (inclusive) and max (exclusive)
    public int Next(int min, int max) {
        return random.Next(min, max);
    }
    public int Next(int max) {
        return random.Next(max);
    }
    public float NextFloat(float min, float max) {
        // Use Unity's Random.Range with the seeded integer value
        int intSeed = random.Next();
        UnityEngine.Random.InitState(intSeed);
        return UnityEngine.Random.Range(min, max);
    }
    // Generate a random float between 0 (inclusive) and 1 (exclusive)
    public float NextFloat() {
        return (float)random.NextDouble();
    }
}