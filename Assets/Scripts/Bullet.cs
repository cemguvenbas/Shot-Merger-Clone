using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 10f;

    private void Update()
    {
        BulletMovementHandler();
    }

    private void BulletMovementHandler()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed)); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrel"))
        {
            gameObject.SetActive(false);
        }
    }
}
