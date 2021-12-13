/*
 * Full Name        : Negin Saeidi
 * Student ID       : 101261395
 * Date Modified    : December 12, 2021
 * File             : GameSceneManager.cs
 * Description      : This is the GameSceneManager script - Is used to load scenes
 * Version          : V01
 * Revision History : Added load scene functions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
  public void LoadMainMneu()
	{
		SceneManager.LoadScene("MenuScene");
	}
	public void LoadGameScene()
	{
		SceneManager.LoadScene("MainScene");
	}
	public void LoadTurorialScene()
	{
		SceneManager.LoadScene("Tutorial");
	}
	public void LoadGameOverScene()
	{
		SceneManager.LoadScene("GameOver");
	}

}
