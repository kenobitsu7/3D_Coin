using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    private bool isKnockback;

    public void ApplyKnockback (Vector3 direction)
    {
        if (!isKnockback)
        {
            StartCoroutine(KnockBackRoutine(direction, 0.2f, 10f));
        }
    }

    IEnumerator KnockBackRoutine(Vector3 direction, float duration, float strength)
    {
        isKnockback = true;
        float timer = 0f;

        while (timer < duration)
        {
            controller.Move (direction * strength * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        isKnockback=false;
    }
}
