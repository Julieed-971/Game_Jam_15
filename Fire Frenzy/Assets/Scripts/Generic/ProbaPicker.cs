using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProbaPicker {
    public TEnum GetRandomEnumValue<TEnum>(Dictionary<TEnum, int> weights) where TEnum : Enum {
        int totalWeight = weights.Values.Sum();
        int randomValue = UnityEngine.Random.Range(0, totalWeight);
        int currentWeight = 0;

        foreach (var kvp in weights) {
            currentWeight += kvp.Value;
            if (randomValue < currentWeight) {
                return kvp.Key;
            }
        }

        throw new InvalidOperationException("The weights provided do not cover the range of random values.");
    }
    public int GetRandomNumber(Dictionary<int, int> weights) {
        int totalWeight = 0;
        foreach (int weight in weights.Values) {
            totalWeight += weight;
        }

        int randomNumber = UnityEngine.Random.Range(0, totalWeight);
        int cumulativeWeight = 0;
        foreach (var kvp in weights) {
            cumulativeWeight += kvp.Value;
            if (randomNumber < cumulativeWeight) {
                return kvp.Key;
            }
        }

        return -1; // Fallback in case of an error, should not happen with correct setup
    }
}