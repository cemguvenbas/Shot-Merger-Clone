using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
	private static GameInstance _instance;
	public static GameInstance Instance
	{
		get
		{
			if (!_instance)
			{
				_instance = FindObjectOfType<GameInstance>();
			}

			return _instance;
		}
	}

	public event Action Won;
	public event Action Lost;

	public bool isGameStarted { get; private set; }
	public bool isGameOver { get; private set; }

	private void Awake()
	{
		if (_instance && _instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	public void LoadCurrentLevel()
    {
		SceneManager.LoadScene("Level");
    }

	public bool IsGameStart()
    {
		return isGameStarted;
    }

	public void GameStart()
    {
		isGameStarted = true;
    }

	public bool IsGameOver()
    {
		return isGameOver;
    }

	public void GameFailed()
    {
		isGameOver = true;
		Lose();
    }

	public void GameFinish()
    {
		isGameOver = true;
		Win();
    }

	public void Win()
    {
		Won?.Invoke();
    }
	
	public void Lose()
    {
		Lost?.Invoke();
    }
	
}
