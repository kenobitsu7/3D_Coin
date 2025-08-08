using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // Liste des pr�fabriqu�s de pi�ces avec leurs poids respectifs pour chaque pi�ce
    [SerializeField] private List<WeightedPrefab> coins;

    // Cette fonction est appel�e au d�but, lorsque l'objet est initialis�
    void Start()
    {
        // Obtenir un pr�fabriqu� al�atoire bas� sur le poids
        GameObject prefabToSpawn = GetRandomPrefab();

        // Si un pr�fabriqu� valide a �t� obtenu, alors on l'instancie
        if (prefabToSpawn != null)
        {
            // Instancier la pi�ce � la position de l'objet actuel, avec une rotation nulle (Quaternion.identity)
            // Le parent de l'instanciation est l'objet qui contient ce script
            GameObject c = Instantiate(prefabToSpawn, transform.position, Quaternion.identity, transform);
        }
    }

    // Fonction pour obtenir un pr�fabriqu� al�atoire en fonction des poids
    private GameObject GetRandomPrefab()
    {
        // Calculer le poids total de tous les pr�fabriqu�s
        float totalWeight = 0;
        foreach (var coin in coins)
        {
            totalWeight += coin.weight;
        }

        // G�n�rer une valeur al�atoire dans la plage [0, totalWeight]
        float randomValue = Random.Range(0, totalWeight);
        float cumulativeWeight = 0;

        // Parcourir les pr�fabriqu�s et d�terminer lequel doit �tre s�lectionn� en fonction du poids
        foreach (var coin in coins)
        {
            cumulativeWeight += coin.weight;

            // Si la valeur al�atoire est inf�rieure ou �gale � la somme cumulative des poids, on retourne ce pr�fabriqu�
            if (randomValue <= cumulativeWeight)
            {
                return coin.prefab;
            }
        }

        // Par d�faut, si aucune pi�ce n'est choisie (ce qui ne devrait jamais arriver), on retourne le premier pr�fabriqu�
        return coins[0].prefab;
    }
}

// Classe repr�sentant un pr�fabriqu� avec un poids associ� pour la s�lection al�atoire
[System.Serializable]
public class WeightedPrefab
{
    public GameObject prefab;  // Le pr�fabriqu� � instancier
    public float weight;       // Le poids associ� � ce pr�fabriqu� pour la s�lection
}
