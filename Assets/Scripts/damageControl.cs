using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageControl : MonoBehaviour
{

    [SerializeField] private PlayerHealth playerHealth;

    public AudioSource DamageSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") & playerHealth.invincible == false)
        {
            playerHealth.TakeDamage();
            DamageSound.Play();
            playerHealth.invincible = true;
            playerHealth.spanTime = 3;
        }
    }
}
