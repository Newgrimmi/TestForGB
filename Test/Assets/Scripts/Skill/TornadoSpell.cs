using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TornadoSpell", menuName = "TornadoSpell", order = 51)]
public class TornadoSpell : Spells
{
    [SerializeField] private float _beginDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _startRadius;
    [SerializeField] private int _amountBul;
    [SerializeField] private float _startDuration;
    [SerializeField] private float _attackSpeed;

    private float _currentDuration;
    private float _currentRadius;
    private float _currentDamage;
    private int _currentAmountBul;

    public float CurrentSpeedAttack => _attackSpeed;
    public float CurrentDuration => _currentDuration;
    public float CurrentRadius => _currentRadius;
    public float BulletSpeed => _bulletSpeed;
    public float CurrentDamage => _currentDamage;
    public int CurrentAmountBul => _currentAmountBul;

    public override void ResetValue()
    {
        _currentDuration = _startDuration;
        _currentAmountBul = _amountBul;
        _currentRadius = _startRadius;
        _currentDamage = _beginDamage;
        CurSpellLevel = BeginSpellLevel;
    }

    public override string TakeDescription()
    {
        switch (CurSpellLevel)
        {
            case 0:
                SpellDescription = "Запускает торнадо, притягивает близжайших врагов";
                return SpellDescription;
            case 1:
                SpellDescription = "Увеличивает урон торнадо на 20%";
                return SpellDescription;
            case 2:
                SpellDescription = "Увеличивает радиус торнадо на 50%";
                return SpellDescription;
            case 3:
                SpellDescription = "Увеличивает урон торнадо на 50%";
                return SpellDescription;
            case 4:
                SpellDescription = "Увеличивает радиус торнадо на 100% и урон на 100%";
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
                _currentDamage = _beginDamage + _beginDamage * 0.2f;
                break;
            case 3:
                _currentRadius = _startRadius * 1.5f;
                break;
            case 4:
                _currentDamage = _beginDamage + _beginDamage * 0.5f;
                break;
            case 5:
                _currentDamage = 2 * _beginDamage;
                _currentRadius = 2 * _startRadius;
                break;
        }
    }
}
