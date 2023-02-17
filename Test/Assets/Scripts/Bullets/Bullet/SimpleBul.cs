using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBul : MonoBehaviour
{
    [SerializeField] private SimpleSpell _curSpell;

    private Animator _anim;
    private Rigidbody2D _bulletRb;

    private int _amountAttack = 1;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _bulletRb = GetComponent<Rigidbody2D>();
    }

    public void LaunchBullet(Vector2 direction)
    {
        _bulletRb.velocity = direction.normalized * _curSpell.BulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy curEnemy) && _amountAttack == 1)
        {
            curEnemy.TakeDamage(_curSpell.CurrentDamage);
            _amountAttack--;
        }
            
        _bulletRb.velocity = Vector2.zero;
        _anim.SetBool("IsHit", true);
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
