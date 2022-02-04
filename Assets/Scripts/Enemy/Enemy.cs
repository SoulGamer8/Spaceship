using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
            Die();
        }
        if (collider.CompareTag("Destroyr"))
        {
            Die();
        }  
    }


    private void Die()
    {
        Destroy(gameObject);
    }
}
