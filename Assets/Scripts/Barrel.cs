using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barrel : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float barrelHealth;

    private void Start()
    {
        GetInitialHealth();
    }

    private void GetInitialHealth()
    {
        barrelHealth = int.Parse(GetComponentInChildren<TMP_Text>().text);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            ApplyDamage();

            if (barrelHealth <= 0)
            {
                BarrelDestroy();
            }
        }
    }

    private void BarrelDestroy()
    {
        Destroy(gameObject);
        // Some particle effects
    }

    public void ApplyDamage()
    {
        barrelHealth--;
        BarrelHealthTextUpdate();
    }

    private void BarrelHealthTextUpdate()
    {
        GetComponentInChildren<TMP_Text>().text = barrelHealth.ToString();
    }
}
