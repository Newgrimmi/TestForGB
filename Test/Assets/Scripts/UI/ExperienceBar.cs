using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] private Image _image;

    private float _maxExp;

    /// <summary>
    /// Set maximum health and update current health to maximum.
    /// </summary>
    /// <param name="maxHealth">Maximum health value.</param>
    public void SetMaxExp(float curExp,float maxExp)
    {
        _maxExp = maxExp;
        UpdateExpBar(curExp);
    }

    /// <summary>
    /// Update current health value.
    /// </summary>

    public void UpdateExpBar(float currentExp)
    {
        _image.fillAmount = currentExp / _maxExp;
    }
}
