using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event Action OnBeingHit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnBeingHit?.Invoke();
        gameObject.SetActive(false);
    }
}
