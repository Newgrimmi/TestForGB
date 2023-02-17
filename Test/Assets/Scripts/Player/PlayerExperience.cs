using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private ExperienceBar _expBar;
    [SerializeField] private LevelHolder _curLevel;
    [SerializeField] private UpgradeBehavior _upgradeBehavior;
    private float _maxExp;
    private float _currentExp;

    private readonly int _maxLevel = 20;

    private void Start()
    {
        _curLevel.ResetData();
        _maxExp = _curLevel.SetNeedExpToUp();
        _expBar.SetMaxExp(_currentExp,_maxExp);
    }

    public void TakeExperience(float exp)
    {
        
        if (_curLevel.CurrentPlayerLevel <= _maxLevel)
        {
            _currentExp += exp;
            if (_currentExp == _maxExp)
            {
                _currentExp = 0;
                UpdateData();
            }
            else if (_currentExp > _maxExp)
            {
                float difExp = _currentExp - _maxExp;
                _currentExp = difExp;
                UpdateData();
            }
            _expBar.UpdateExpBar(_currentExp);
        } 
    }

    public void SubscribeAction(Action<float> action)
    {   
        action += TakeExperience;
        Debug.Log(action);
    }

    public void UnSubscribeAction(Action<float> action)
    {
        Debug.Log(action);
        action -= TakeExperience;
    }

    private void UpdateData()
    {
        _curLevel.LevelUp();
        _maxExp = _curLevel.SetNeedExpToUp();
        _expBar.SetMaxExp(_currentExp,_maxExp);
        _upgradeBehavior.LevelUp();
    }
}
