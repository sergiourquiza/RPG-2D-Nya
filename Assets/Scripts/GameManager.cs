
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event EventHandler OnPlayerDamage;
    public event EventHandler OnPlayerDied;
    public event EventHandler OnBossDamage;
    public event EventHandler OnBossHitPlayer;
    public event EventHandler OnPlayerHitBoss;

    public float PlayerHealth = 100f;
    public float BossHealth = 500f;


    public void Awake()
    {
        Instance = this;
    }

    public void PlayerDamage()
    {
        OnPlayerDamage?.Invoke(this, EventArgs.Empty);
        PlayerHealth -= 5f;
        if (PlayerHealth <= 0f)
        {
            OnPlayerDied?.Invoke(this, EventArgs.Empty);
        }
    }
    
    public void PlayerHitBoss()
    {
        BossHealth -= 10f;
        if (BossHealth <= 0f)
        {
            Destroy(GameObject.FindWithTag("Boss"));
        }
    }

    
}
