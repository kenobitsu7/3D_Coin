using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] private HealthManager healthManager;
    public int Playerhealth = 3;
    int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        print(Playerhealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Playerhealth -= damage;
            print ("damage" + Playerhealth);

            healthManager.ManageHealth(-1);

        }
    }
}
