using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PelletManager : MonoBehaviour
{
    //This makes the variable which can be referenced in the pacman script
    public int pelletScore;
    //This affects the UI
    public Text score;

    private void Update()
    {
        score.text = "Score: " + pelletScore.ToString();
    }


}
