using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    public float thresold; //threshold est definie sur Y-value de Transform


    // Update run on a fixed time 
    void FixedUpdate()
    {
        if(transform.position.y < thresold)
        {
            transform.position = new Vector3(0.01f, 0.951f, 0.04f);
        }
    }
}
