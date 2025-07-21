using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<WeightedPrefab> coins;

    // Start is called before the first frame update
    void Start()
    {
        GameObject prefabToSpawn = GetRandomPrefab();
        if (prefabToSpawn != null)
        {
            GameObject c = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, transform);
            
        }
    }

    private GameObject GetRandomPrefab()
    {
        float totalWeight = 0;
        foreach (var coin in coins)
        {
            totalWeight += coin.weight;
        }

        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0;

        foreach (var coin in coins)
        {
            cumulativeWeight += coin.weight;
            if (randomValue <= cumulativeWeight)
            {
                return coin.prefab;

            }

        }

        return coins[0].prefab;
    }
}

[System.Serializable]
public class WeightedPrefab
{
    public GameObject prefab;
    public float weight;
}
