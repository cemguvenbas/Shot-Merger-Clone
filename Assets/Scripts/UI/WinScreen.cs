using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private Button _nextLevelButton;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(NextLevelButtonClicked);
    }
    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(NextLevelButtonClicked);
    }

    private void NextLevelButtonClicked()
    {
        GameInstance.Instance.LoadCurrentLevel();
    }
}
