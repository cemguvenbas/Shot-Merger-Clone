using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private ObjectPool objectPool;

    [Header("Elements")]
    [SerializeField] private float timer = 0;
    public static float spawnRate;


    private void Start()
    {
        spawnRate = 2f;      
    }

    private void Update()
    {
        if (GameInstance.Instance.IsGameStart() == true && GameInstance.Instance.IsGameOver() == false)
        {
            SpawnBullets();
        }
    }

    // I should have used coroutine, but for some reason I got errors while using coroutine, so I did it this way.
    private void SpawnBullets()
    {
        if (!this.CompareTag("Collectable"))
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                GameObject bullet = objectPool.GetPooledObject(0);
                bullet.transform.position = this.transform.position;
                timer = spawnRate;
            }
        }
    }
}
