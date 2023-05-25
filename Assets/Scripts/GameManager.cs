
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public event EventHandler OnPlayerDamage;
    public event EventHandler OnPlayerDied;
    public event EventHandler OnBossDamage;
    public event EventHandler OnPlayerHitBoss;
    public event EventHandler OnPlayerHitNPC;


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
            SceneManager.LoadScene("Scenes/MainScene");
        }
    }
    
    public void PlayerHitBoss()
    {
        BossHealth -= 20f;
        if (BossHealth <= 0f)
        {
            Destroy(GameObject.FindWithTag("Boss"));
            
            SceneManager.LoadScene("Scenes/MainScene");
        }
    }
}
