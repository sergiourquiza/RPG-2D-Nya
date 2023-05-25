using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Slider mSlider;

    private void Start()
    {
        mSlider = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();
        mSlider.value = GameManager.Instance.PlayerHealth;
        // Inscribirnos como observadores del evento OnPlayerDamage
        GameManager.Instance.OnPlayerDamage += OnPlayerDamageDelegate; 
    }

    private void Update()
    {
        mSlider.value = GameManager.Instance.PlayerHealth;
    }

    private void OnPlayerDamageDelegate(object sender, EventArgs e)
    {
        mSlider.value = GameManager.Instance.PlayerHealth;
    }
}