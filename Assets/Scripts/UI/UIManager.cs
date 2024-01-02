using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _winScreen;

    [SerializeField]
    private GameObject _gameOverScreen;

    public void OnEnable()
    {
        GameInstance.Instance.Won += OnGameWon;
        GameInstance.Instance.Lost += OnGameLost;
    }

    public void OnDisable()
    {
        GameInstance.Instance.Won -= OnGameWon;
        GameInstance.Instance.Lost -= OnGameLost;
    }


    private void OnGameWon()
    {
        _winScreen.SetActive(true);
        _gameOverScreen.SetActive(false);
    }

    private void OnGameLost()
    {
        _winScreen.SetActive(false);
        _gameOverScreen.SetActive(true);
    }
}
