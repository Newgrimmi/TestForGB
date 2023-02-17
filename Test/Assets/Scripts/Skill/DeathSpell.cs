using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeathSpell", menuName = "DeathSpell", order = 51)]
public class DeathSpell : Spells
{
    [SerializeField] private float _beginDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _startRadius;
    [SerializeField] private float _startIncreaseDamage;

    private float _currentIncreaseDamage;
    private float _currentRadius;
    private float _currentDamage;

    public float CurrentIncreaseDamage => _currentIncreaseDamage;
    public float CurrentRadius => _currentRadius;
    public float BulletSpeed => _bulletSpeed;
    public float CurrentDamage => _currentDamage;

    public override void ResetValue()
    {
        _currentIncreaseDamage = _startIncreaseDamage;
        _currentRadius = _startRadius;
        _currentDamage = _beginDamage;
        CurSpellLevel = BeginSpellLevel;
    }

    public override string TakeDescription()
    {
        switch (CurSpellLevel)
        {
            case 0:
                SpellDescription = "��������� c����� ������, ��� ������ ����������� ���� �� ������ �� 50%";
                return SpellDescription;
            case 1:
                SpellDescription = "����������� ���� ������ ������ �� 50%";
                return SpellDescription;
            case 2:
                SpellDescription = "����������� ������ ������ ������ ������ �� 50%";
                return SpellDescription;
            case 3:
                SpellDescription = "����������� ���������� ����� �� ������ �� 100%";
                return SpellDescription;
            case 4:
                SpellDescription = "����������� ������ ������ ������ ������ �� 100% � ���� �� 100%";
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
                _currentIncreaseDamage = _startIncreaseDamage;
                break;
            case 2:
                _currentDamage = _beginDamage + _beginDamage * 0.5f;
                break;
            case 3:
                _currentRadius = _startRadius * 1.5f;
                break;
            case 4:
                _currentIncreaseDamage = 2 * _startIncreaseDamage;
                break;
            case 5:
                _currentDamage = 2 * _beginDamage;
                _currentRadius = 2 * _startRadius;
                break;
        }
    }
}
