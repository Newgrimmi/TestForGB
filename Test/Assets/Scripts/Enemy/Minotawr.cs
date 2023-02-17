using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotawr : Enemy
{
    
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _enemyDamage;
    [SerializeField] private float _attackSpeed;

    private bool _IsPush;

    private Transform _player;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    private Rigidbody2D _rb;
    private Vector2 direction;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        _rb.velocity = PathFinder.FindRoad(_player.position, transform.position).normalized * _enemySpeed;
        if (_rb.velocity.x < 0)
            _spriteRenderer.flipX = true;
        else _spriteRenderer.flipX = false;

        if (_rb.velocity.x < _rb.velocity.y && (_rb.velocity.x < _enemySpeed/2 && (_rb.velocity.x > -_enemySpeed / 2)))
        {
            _anim.SetBool("IsUp", true);
            _anim.SetBool("IsDown", false);
            _anim.SetBool("IsHor", false);
        }
        else if(_rb.velocity.x > _rb.velocity.y && (_rb.velocity.x < _enemySpeed / 2 && (_rb.velocity.x > -_enemySpeed / 2)))
        {
            _anim.SetBool("IsUp", false);
            _anim.SetBool("IsDown", true);
            _anim.SetBool("IsHor", false);
        }
        else
        {
            _anim.SetBool("IsUp", false);
            _anim.SetBool("IsDown", false);
            _anim.SetBool("IsHor", true);   
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHP))
        {
            _IsPush = true;
            StartCoroutine(Attack(playerHP));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHP))
        {
            StopCoroutine(Attack(playerHP));
            _IsPush = false;
        }
    }

    private IEnumerator Attack(PlayerHealth playerHealth)
    {
        while (_IsPush)
        {   
            playerHealth.TakeDamage(_enemyDamage);
            yield return new WaitForSeconds(_attackSpeed);
        }
    }

    public override void Initialized(Transform player)
    {
        _player = player;
    }
}
