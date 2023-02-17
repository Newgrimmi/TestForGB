using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseActivator : MonoBehaviour
{
    [SerializeField] private List<IPauseable> _pausedEntity = new List<IPauseable>();

    public void Paused()
    {
        foreach (var item in _pausedEntity)
        {
            item.Pause();
        }
    }

    public void UnPaused()
    {
        foreach (var item in _pausedEntity)
        {
            item.UnPause();
        }
    }

    public void AddPauseEntity(IPauseable pauseEntity)
    {
        _pausedEntity.Add(pauseEntity);
    }
    public void RemovePauseEntity(IPauseable pauseEntity)
    {
        _pausedEntity.Remove(pauseEntity);
    }
}
