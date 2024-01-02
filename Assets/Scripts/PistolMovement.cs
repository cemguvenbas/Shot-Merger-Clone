using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Control")]
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;
                    
    private void Update()
    {
        MoveForward();
        ManageControl();
    }

    private void MoveForward()
    {
        if (GameInstance.Instance.IsGameStart() == true && GameInstance.Instance.IsGameOver() == false)
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.forward;
        }
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameInstance.Instance.GameStart();
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if(Input.GetMouseButton(0))
        {
            var xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 pos = transform.position;
            pos.x = clickedPlayerPosition.x + xScreenDifference;
            pos.x = Mathf.Clamp(pos.x, -4, 4);
            transform.position = pos;
        }
    }
}
