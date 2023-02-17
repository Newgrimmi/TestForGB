using UnityEngine;

[CreateAssetMenu(fileName = "New LevelHolder", menuName = "LevelHolder", order = 51)]
public class LevelHolder : ScriptableObject
{
    [SerializeField] private int _beginPlayerLevel;

    private int _currentPlayerLevel;
    private float _expToUp;
    private float _expToFirstUp = 10;

    private readonly int _levelToUpExp = 5;
    public int CurrentPlayerLevel => _currentPlayerLevel;

    public void LevelUp()
    {
        _currentPlayerLevel++;
    }

    public float SetNeedExpToUp()
    {
        _expToUp = _currentPlayerLevel * _expToFirstUp + (_currentPlayerLevel/_levelToUpExp * _currentPlayerLevel * _expToFirstUp);
        return _expToUp;
    }

    public void ResetData()
    {
        _currentPlayerLevel = _beginPlayerLevel;
    }
}
