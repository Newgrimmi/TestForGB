using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _hpText;

    private float _maxHp;

    /// <summary>
    /// Set maximum health and update current health to maximum.
    /// </summary>
    /// <param name="maxHealth">Maximum health value.</param>
    public void SetMaxHealth(float maxHealth)
    {
        _maxHp = maxHealth;
        UpdateHpBar(maxHealth);
    }

    /// <summary>
    /// Update current health value.
    /// </summary>

    public void UpdateHpBar(float currentHealth)
    {
        _hpText.text = currentHealth + "/" + _maxHp;
        _image.fillAmount = currentHealth / _maxHp;
    }

}
