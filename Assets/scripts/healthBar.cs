using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Slider slider;

    public int maxHealth = 100;
    public int currentHealth;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

    }

    public void SethHealth(int health)
    {
        slider.value = health;

    }
}