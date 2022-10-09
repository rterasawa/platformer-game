using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{

    public static int fish;
    public static float time;

    public Text timeTextBox;
    public Text fishTextBox;
    public Text functionTextBox;
    public Text scoreTextBox;

    // Start is called before the first frame update
    void Start()
    {
        time = Mathf.Round(time);
        timeTextBox.text = time.ToString();
        fishTextBox.text = fish.ToString();
        functionTextBox.text = time.ToString() + " + " + fish.ToString() + " x 10";
        scoreTextBox.text = (fish * 10 + time).ToString();
    }

}
