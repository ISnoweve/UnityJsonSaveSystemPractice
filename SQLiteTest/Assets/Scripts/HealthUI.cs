using System;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Action<int> InitMaxHealthView;
    public Action<int> InitCurrentHealthView;
    public Action<int> HealthChanged;
    public TMP_Text maxHealthText;
    public TMP_Text currentHealthText;

    private void Awake()
    {
        InitMaxHealthView += InitMaxHealth;
        InitCurrentHealthView += InitCurrentHealth;
        HealthChanged += HealthViewChanged;
    }
    

    private void InitMaxHealth(int healthValue)
    {
        maxHealthText.text = $"MaxHealth:{healthValue}";
    }

    private void InitCurrentHealth(int healthValue)
    {
        currentHealthText.text = $"CurrentHealth:{healthValue}";
    }

    private void HealthViewChanged(int newHealthValue)
    {
        currentHealthText.text = $"CurrentHealth:{newHealthValue}";
    }
}
