using System;
using static RNG;

public class RNG : Singleton<RNG> {

    public enum SeedType {
        RandomSeed, DirectSeed//, SeedData
    }
    public SeedType seedType;
    public int seed;
    // public SeedData seedData;
    private SeededRNG seededRNG;
    private void Start() {
        switch (seedType) {
            case SeedType.RandomSeed:
                seed = UnityEngine.Random.Range(-100000, 100000);
                seededRNG = new SeededRNG(seed);
                break;
            case SeedType.DirectSeed: seededRNG = new SeededRNG(seed);
                break;
            // case SeedType.SeedData: seededRNG = new SeededRNG(seedData.seed);
            //     break;
        }
    }
    public int GetInt(int min, int max) {
        return seededRNG.Next(min, max);
    }
    public int GetInt(int max) {
        return seededRNG.Next(max);
    }
    public float GetFloat() {
        return seededRNG.NextFloat();
    }
    public float GetFloat(float min, float max) {
        return seededRNG.NextFloat(min, max);
    }
}
