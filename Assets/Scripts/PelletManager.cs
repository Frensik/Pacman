using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PelletManager : MonoBehaviour
{
    //This makes the variable which can be referenced in the pacman script
    public int pelletScore;
    public Text score;
    public Text gameEndScore;
    //This allows the UI to read what the current pellet count is and display it on the canvas
    //There's one for the game view and one for the gameover screen

    public AudioSource source;
    public AudioClip clip;

    void Update()
    {
        score.text = "Score: " + pelletScore.ToString();
        gameEndScore.text = "Score: " + pelletScore.ToString();

        //If the player gets all the pellets the victory sound plays
        if (pelletScore == 60)
        {
            //Lowers the volume so it doesn't shatter my eardrums
            source.volume = 0.1f;
            source.PlayOneShot(clip);
        }
    }


}
