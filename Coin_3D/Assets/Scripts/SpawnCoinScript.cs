using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinScript : MonoBehaviour
{

    public GameObject coinPrefab;


    // Update is called once per frame
    void Update()
    {
       gameObject.transform.Rotate(0f, 1f, 0f, Space.Self);
    }

    /* private void OnTriggerEnter(Collider other)
     
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 randomPosition = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
            Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        }
    }

    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            
            Vector3 randomPosition = new Vector3(Random.Range(-4, 4), 0.5f, Random.Range(-4, 4));
            Instantiate(coinPrefab, randomPosition, Quaternion.identity);

            Score.scoreCount += 1;

            Destroy(gameObject);
        }
    }
}
