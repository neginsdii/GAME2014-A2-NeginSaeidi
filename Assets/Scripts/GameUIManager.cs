/*
 * Full Name        : Negin Saeidi
 * Student ID       : 101261395
 * Date Modified    : December 12, 2021
 * File             : GameUIManager.cs
 * Description      : This is the GameUIManager script - Displays the score and gameovet label in gameover scene
 * Version          : V01
 * Revision History : Added text elements 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text gameoverText;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
      ScoreText.text = "Score: "+ PlayerPrefs.GetInt("Score").ToString();
        if (PlayerPrefs.GetInt("Neros") >= 7)
            gameoverText.text = "You won!";
        else
            gameoverText.text = "Game Over";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
