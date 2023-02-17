using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;

    private float _currentHealth;
    private bool _isAlive = true;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (_isAlive)
        {
            _currentHealth -= damage;
            if(_currentHealth <= 0)
            {
                _currentHealth = 0;
                _isAlive = false;
            }
        }
        _healthBar.UpdateHpBar(_currentHealth);
    }
    
}
