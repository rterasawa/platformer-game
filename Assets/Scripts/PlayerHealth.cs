using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth instance;

    public int maxHealth;
    int health;

    public event Action DamageTaken;
    public event Action HealthUpgraded;

    public int gameOvreSceneIndex;

    public bool invincible = false;
    public float spanTime = 0;


    public void Update()
    {
        if (spanTime == 0) {
            return;
        };
        spanTime -= Time.deltaTime;
        if(Mathf.Round(spanTime) == 0)
        {
            spanTime = 0;
            invincible = false;
        }
    }


    public int Health
    {
        get
        {
            return health;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage()
    {
        //if(health <= 0)
        //{
        //    return;
        //}
        health -= 1;
        if(DamageTaken != null)
        {
            DamageTaken();
        }
        if(health == 0)
        {
            LoadSceneByIndex(gameOvreSceneIndex);
        }
    }

    public void Heal()
    {
        if (health >= maxHealth)
        {
            return;
        }
        health += 1;
        if (DamageTaken != null)
        {
            DamageTaken();
        }
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
