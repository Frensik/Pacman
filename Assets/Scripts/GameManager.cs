using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Can be called in the pacman script to make the game over UI visible
    //youtu.be/pKFtyaAPzYo?si=lzFF8S5IFcEM5JrZ
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
}
