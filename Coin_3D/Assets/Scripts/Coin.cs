using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Update is called once per frame
    void Update()
    {
       gameObject.transform.Rotate(0f, 1f, 0f, Space.Self);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            audioManager.PlaySFX(audioManager.coin);

            GameManager.Instance.Score += value;

            Destroy(gameObject);
        }
    }
}
