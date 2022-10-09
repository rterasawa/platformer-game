using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    public float startTime = 60;
    public Text textBox;
    public int gameOvreSceneIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = startTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime < 0)
        {
            startTime = 0;
            LoadSceneByIndex(gameOvreSceneIndex);
        }
        else
        {
            startTime -= Time.deltaTime;
        }
        textBox.text = Mathf.Round(startTime).ToString();

    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

}
