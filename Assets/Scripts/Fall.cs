using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject Player;
    public PlayerHealth PlayerHealth;

    [SerializeField] private string SceneToLoad;
    public AudioSource fallSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fallSound.Play();

        if(collision.tag == "Player")
        {
            Player.transform.position = SpawnPoint.position;
            if (PlayerHealth.Health != 0)
            {
                PlayerHealth.TakeDamage();
            }
        }
    }

}
