using System;
using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IPauseable, IFreezeable, IWeaknessable
{
    [SerializeField] private float _startSpeed;
    [SerializeField] protected float _enemyDamage;
    [SerializeField] protected float _attackSpeed;
    [SerializeField] protected float _maxHP;
    [SerializeField] protected float _gainExp;

    private float _currentHealth;
    private bool _isAlive = true;
    protected float _currentSpeed;

    private float _takenDamage;
    protected bool IsPaused => _isPaused;

    protected PauseActivator _pauseActivator;
    protected PlayerExperience _playerExperience;
    private bool _isPaused;
    private bool _isFreezing;
    private bool _isWeakness;

    protected SpriteRenderer _spriteRenderer;
    protected Animator _anim;
    protected Rigidbody2D _rb;

    private void Awake()
    {
        _playerExperience = FindObjectOfType<PlayerExperience>();
        _pauseActivator = FindObjectOfType<PauseActivator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _takenDamage = 1;
        _currentHealth = _maxHP;
        _currentSpeed = _startSpeed;
        _pauseActivator.AddPauseEntity(this);
    }
    private void OnDestroy()
    {
        _pauseActivator.RemovePauseEntity(this);
    }

    public abstract void Initialized(Transform player);

    public void TakeDamage(float damage)
    {
        if (_isAlive)
        {
            Debug.Log(_currentHealth);
            Debug.Log(damage);
            _currentHealth -= damage*_takenDamage;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                _isAlive = false;
                _playerExperience.TakeExperience(_gainExp);
                Destroy(gameObject);
            }
        }
    }

    public void UnPause()
    {
        _isPaused = false;
    }

    public void Pause()
    {
        _rb.velocity = Vector2.zero;
        _isPaused = true;
    }

    public void Freezing()
    {
        if (!_isFreezing)
        {
            _currentSpeed = _startSpeed * 0.5f;
            StartCoroutine(UnFreezing());
            _isFreezing = true;
        }     
    }

    public IEnumerator UnFreezing()
    {     
        yield return new WaitForSeconds(2);
        _currentSpeed = _startSpeed;
        _isFreezing = false;
    }

    public void Weakness(float persentIncreaseDamage)
    {
        if (!_isWeakness)
        {
            _takenDamage = 1 + persentIncreaseDamage;
            StartCoroutine(UnWeakness());
            _isWeakness = true;
        }
        
    }

    public IEnumerator UnWeakness()
    {
        yield return new WaitForSeconds(2);
        _takenDamage = 1;
        _isWeakness = false;
    }
}
