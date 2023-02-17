using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireSpell", menuName = "FireSpell", order = 51)]
public class FireSpell : Spells
{
    [SerializeField] private float _beginDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _startRadius;
    [SerializeField] private int _amountBul;

    private float _currentRadius;
    private float _currentDamage;
    private int _currentAmountBul;

    public float CurrentRadius => _currentRadius;
    public float BulletSpeed => _bulletSpeed;
    public float CurrentDamage => _currentDamage;
    public int CurrentAmountBul => _currentAmountBul;

    public override void ResetValue()
    {
        _currentRadius = _startRadius;
        _currentDamage = _beginDamage;
        CurSpellLevel = BeginSpellLevel;
    }

    public override string TakeDescription()
    {
        switch (CurSpellLevel)
        {
            case 0:
                SpellDescription = "Запускает огненную стрелу, обладает большим радиусом поражения";
                return SpellDescription;
            case 1:
                SpellDescription = "Увеличивает урон огненной стрелы на 50%";
                return SpellDescription;
            case 2:
                SpellDescription = "Увеличивает радиус взрыва огненной стрелы на 50%";
                return SpellDescription;
            case 3:
                SpellDescription = "Увеличивает радиус взрыва огненной стрелы на 100%";
                return SpellDescription;
            case 4:
                SpellDescription = "Увеличивает радиус взрыва стрелы смерти на 200% и урон на 100%";
                return SpellDescription;
            default:
                return SpellDescription;
        }

    }

    public override void UpgradeSpell()
    {
        switch (CurSpellLevel)
        {
            case 1:
                _currentDamage = _beginDamage;
                break;
            case 2:
                _currentDamage = _beginDamage + _beginDamage * 0.5f;
                break;
            case 3:
                _currentRadius = _startRadius * 1.5f;
                break;
            case 4:
                _currentRadius = _startRadius * 2f;
                break;
            case 5:
                _currentDamage = 2 * _beginDamage;
                _currentRadius = 3 * _startRadius;
                break;
        }
    }
}
