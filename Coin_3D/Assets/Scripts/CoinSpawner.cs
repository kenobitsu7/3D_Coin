using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // Liste des préfabriqués de pièces avec leurs poids respectifs pour chaque pièce
    [SerializeField] private List<WeightedPrefab> coins;

    // Cette fonction est appelée au début, lorsque l'objet est initialisé
    void Start()
    {
        // Obtenir un préfabriqué aléatoire basé sur le poids
        GameObject prefabToSpawn = GetRandomPrefab();

        // Si un préfabriqué valide a été obtenu, alors on l'instancie
        if (prefabToSpawn != null)
        {
            // Instancier la pièce à la position de l'objet actuel, avec une rotation nulle (Quaternion.identity)
            // Le parent de l'instanciation est l'objet qui contient ce script
            GameObject c = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, transform);
        }
    }

    // Fonction pour obtenir un préfabriqué aléatoire en fonction des poids
    private GameObject GetRandomPrefab()
    {
        // Calculer le poids total de tous les préfabriqués
        float totalWeight = 0;
        foreach (var coin in coins)
        {
            totalWeight += coin.weight;
        }

        // Générer une valeur aléatoire dans la plage [0, totalWeight]
        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0;

        // Parcourir les préfabriqués et déterminer lequel doit être sélectionné en fonction du poids
        foreach (var coin in coins)
        {
            cumulativeWeight += coin.weight;

            // Si la valeur aléatoire est inférieure ou égale à la somme cumulative des poids, on retourne ce préfabriqué
            if (randomValue <= cumulativeWeight)
            {
                return coin.prefab;
            }
        }

        // Par défaut, si aucune pièce n'est choisie (ce qui ne devrait jamais arriver), on retourne le premier préfabriqué
        return coins[0].prefab;
    }
}

// Classe représentant un préfabriqué avec un poids associé pour la sélection aléatoire
[System.Serializable]
public class WeightedPrefab
{
    public GameObject prefab;  // Le préfabriqué à instancier
    public float weight;       // Le poids associé à ce préfabriqué pour la sélection
}
