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
