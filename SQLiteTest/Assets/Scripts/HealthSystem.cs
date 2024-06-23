using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private HealthData healthData;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private int CurrentHealth
    {
        get => currentHealth;
        set
        {
            if (value >= maxHealth)
            {
                currentHealth = maxHealth;
                Debug.Log("over than maxHealth. so make it maxHealth");
            }
            else if (value <= 0)
            {
                currentHealth = 0;
                Debug.Log("You are dead. You dont have hp LUL");
            }
            else
            {
                currentHealth = value;
            }
            healthUI.HealthChanged(CurrentHealth);
        }
    }

    private void Start()
    {
        LoadCurrentHealthData();
        
        maxHealth = healthData.maxHealth;
        CurrentHealth = healthData.currentHealth;

        healthUI.InitMaxHealthView.Invoke(maxHealth);
        healthUI.InitCurrentHealthView.Invoke(CurrentHealth);
    }
    public void TakeDamage(int damageValue)
    {
        CurrentHealth -= damageValue;
    }
    public void GetHeal(int healValue)
    {
        CurrentHealth += healValue;
    }
    public void SaveCurrentHealthData()
    {
        HealthData newHealthData = new HealthData();
        newHealthData.maxHealth = maxHealth;
        newHealthData.currentHealth = CurrentHealth;

        SaveSystem.SaveDataWithInstanceJson(newHealthData);
    }
    public void LoadCurrentHealthData()
    {
        healthData = SaveSystem.LoadDataWithInstanceJson(healthData);
        
        maxHealth = healthData.maxHealth;
        CurrentHealth = healthData.currentHealth;

        healthUI.InitMaxHealthView.Invoke(maxHealth);
        healthUI.InitCurrentHealthView.Invoke(CurrentHealth);
    }
}

[Serializable]
public class HealthData
{
    public int maxHealth;
    public int currentHealth;
}
