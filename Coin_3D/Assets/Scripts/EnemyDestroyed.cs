using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyDestroyed : MonoBehaviour
{
    public TextMeshProUGUI enemyDestroyedText;
       
    // Update is called once per frame
    void Update()
    {
        enemyDestroyedText.text = "Enemy Destroyed: " + GameManager.Instance.KillCount.ToString();
    }

}

