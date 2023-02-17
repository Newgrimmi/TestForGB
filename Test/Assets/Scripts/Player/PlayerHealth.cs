using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private HealthBar _healthBar;

    private Animator _anim;

    private float _currentHealth;
    private bool _isAlive = true;

    private void Start()
    {
        _anim = GetComponent<Animator>();
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
                _anim.SetBool("IsDead", true);
                _currentHealth = 0;
                _isAlive = false;
            }
        }
        _healthBar.UpdateHpBar(_currentHealth);
    }
    
    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
