using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    [SerializeField] private string SceneToLoad;
    public CharacterControl player;
    public TimeControl time;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResultUI.fish = player.fish;
        ResultUI.time = time.startTime;
        SceneManager.LoadScene(SceneToLoad);
        
    }
}
