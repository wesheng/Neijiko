using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Chances/Game Object")]
public class GameObjectChances : ScriptableObject
{
    [Serializable]
    public struct ObjectChance
    {
        public GameObject Object;
        [Range(0, 100)]
        public float Chance;
    }

    [Tooltip("Should be a value between 0 and 100")]
    [Range(0, 100)]
    public float ChanceSpawn;
    [Tooltip("Objects, Percentage chance of spawning")]
    public List<ObjectChance> Objects;


    /// <summary>
    /// Rolls for object.
    /// </summary>
    /// <returns>Null if nothing rolled</returns>
    public GameObject RollForObject()
    {
        float shouldSpawn = Random.Range(0.0f, 100.0f);
        if (shouldSpawn < ChanceSpawn)
        {
            float currentPossible = 0;
            float[] chances = new float[Objects.Count];
            for (var i = 0; i < Objects.Count; i++)
            {
                currentPossible += Objects[i].Chance;
                chances[i] = currentPossible;
            }

            float roll = Random.Range(0, currentPossible);
            for (var i = 0; i < Objects.Count; i++)
            {
                if (roll < chances[i])
                {
                    return Objects[i].Object;
                }
            }
        }
        return null;
    }
}
