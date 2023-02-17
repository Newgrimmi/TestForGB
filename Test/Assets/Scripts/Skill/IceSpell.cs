using UnityEngine;

[CreateAssetMenu(fileName = "New IceSpell", menuName = "IceSpell", order = 51)]
public class IceSpell : Spells
{
    [SerializeField] private float _beginDamage;
    [SerializeField] private int _amountBul;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _startRadius;

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
        _currentAmountBul = _amountBul;
        CurSpellLevel = BeginSpellLevel;
    }

    public override string TakeDescription()
    {
        switch (CurSpellLevel)
        {
            case 0:
                SpellDescription = "Запускает ледяной патрон в цель, взрывается и замораживает всех вокруг";
                return SpellDescription;
            case 1:
                SpellDescription = "Увеличивает урон ледяного патрона на 20%";
                return SpellDescription;
            case 2:
                SpellDescription = "Увеличивает радиус взрыва ледяного патрона на 50%";
                return SpellDescription;
            case 3:
                SpellDescription = "Увеличивает урон ледяного патрона на 50%";
                return SpellDescription;
            case 4:
                SpellDescription = "Увеличивает радиус взрыва ледяного патрона на 100% и урон ледяного патрона на 100%";
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
                _currentRadius =_startRadius * 1.5f;
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
