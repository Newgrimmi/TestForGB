using System;
using UnityEngine;

public abstract class Spells : ScriptableObject
{
    [SerializeField] protected int BeginSpellLevel;
    [SerializeField] private string _spellName;
    protected string SpellDescription;
    protected int CurSpellLevel;
    public int CurrentSpellLevel => CurSpellLevel;
    public string SpellName => _spellName;

    public event Action OnUpgrade;

    public readonly int MaxLevel = 5;
    public abstract string TakeDescription();

    public void LevelUp()
    {
        CurSpellLevel++;
        UpgradeSpell();
        OnUpgrade?.Invoke();
    }

    public abstract void UpgradeSpell();

    public abstract void ResetValue();

}
