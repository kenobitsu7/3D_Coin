using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnchorer : MonoBehaviour
{
    private Transform originalparent;

    private void Start()
    {
        originalparent = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            transform.parent = other.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            transform.parent = originalparent;
        }

    }
}
