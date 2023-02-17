using System.Collections;
using UnityEngine;

public class Minotawr : Enemy
{
    private bool _IsPush;

    private Transform _player;

    private Vector2 direction;

    private void FixedUpdate()
    {
        if (!IsPaused)
        {
            direction = _player.position - transform.position;
            _rb.velocity = direction.normalized * _currentSpeed;
            if (_rb.velocity.x < 0)
                _spriteRenderer.flipX = true;
            else _spriteRenderer.flipX = false;

            if (_rb.velocity.x < _rb.velocity.y && (_rb.velocity.x < _currentSpeed / 2 && (_rb.velocity.x > -_currentSpeed / 2)))
            {
                _anim.SetBool("IsUp", true);
                _anim.SetBool("IsDown", false);
                _anim.SetBool("IsHor", false);
            }
            else if (_rb.velocity.x > _rb.velocity.y && (_rb.velocity.x < _currentSpeed / 2 && (_rb.velocity.x > -_currentSpeed / 2)))
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
