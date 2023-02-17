using UnityEngine;

[CreateAssetMenu(fileName = "New SimpleSpell", menuName = "SimpleSpell", order = 51)]
public class SimpleSpell : Spells
{
    [SerializeField] private float _beginDamage;
    [SerializeField] private int _amountBul;
    [SerializeField] private float _bulletSpeed; 

    private float _currentDamage;
    private int _currentAmountBul;

    public float BulletSpeed => _bulletSpeed;
    public float CurrentDamage => _currentDamage;
    public int CurrentAmountBul => _currentAmountBul;

    public override void ResetValue()
    {
        _currentDamage = _beginDamage;
        _currentAmountBul = _amountBul;
        CurSpellLevel = BeginSpellLevel;
}

    public override string TakeDescription()
    {
        switch (CurSpellLevel)
        {
            case 0:
                SpellDescription = "Запускает магический патрон прямо в цель";
                return SpellDescription;
            case 1:
                SpellDescription = "Увеличивает урон магического патрона на 20%";
                return SpellDescription;
            case 2:
                SpellDescription = "Увеличивает количество магических патронов на 1"; 
                return SpellDescription;
            case 3:
                SpellDescription = "Увеличивает урон магического патрона на 40%";
                return SpellDescription;
            case 4:
                SpellDescription = "Увеличивает количество магических патронов на 1 и увеличивает урон магического патрона на 100%";
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
                _currentAmountBul = 1;
                break;
            case 2:
                _currentDamage = _beginDamage + _beginDamage * 0.2f;
                break;
            case 3:
                _currentAmountBul++; 
                break;
            case 4:
                _currentDamage = _beginDamage + _beginDamage * 0.4f;
                break;
            case 5:
                _currentDamage = 2 * _beginDamage;
                _currentAmountBul ++;
                break;

        }
    }
}
