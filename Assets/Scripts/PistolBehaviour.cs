using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrel") || other.CompareTag("Obstacle"))
        {
            PistolBreakIntoPieces();
            GameInstance.Instance.GameFailed();
        }
    }

    private void PistolBreakIntoPieces()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Rigidbody>() == null && child.GetComponent<BoxCollider>() == null)
            {
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.AddComponent<BoxCollider>();
            }
        }
    }
}
