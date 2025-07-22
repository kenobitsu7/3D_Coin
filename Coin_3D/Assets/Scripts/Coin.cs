using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.Rotate(0f, 1f, 0f, Space.Self);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Score.scoreCount += value;

            Destroy(gameObject);
        }
    }
}
