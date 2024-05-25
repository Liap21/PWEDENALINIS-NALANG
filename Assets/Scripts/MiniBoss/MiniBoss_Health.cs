using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBoss_Health : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] private int MinHealth;
    [SerializeField] private int Health;

    private Slider MB_HealthSlider;
    private bool canTakeDamage = true;

    private void Awake()
    {
        MB_HealthSlider = GameObject.FindWithTag("MB_HealthBar").GetComponent<Slider>();
        UpdateHealthBar();
    }

    // Method to update the health bar UI
    private void UpdateHealthBar()
    {
        float healthPercentage = (float)(Health - MinHealth) / (MaxHealth - MinHealth);
        MB_HealthSlider.value = healthPercentage;
    }

    // Method to take damage from the player
    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            Debug.Log("Boss has taken damage");
            Health -= damage;
            Health = Mathf.Clamp(Health, MinHealth, MaxHealth);
            UpdateHealthBar();
            if (Health <= MinHealth)
            {
                // Mini boss defeated, add your defeat logic here
                Debug.Log("Boss has been destroyed");
                Debug.Log("Still work in progress");
            }
        }
    }
}
