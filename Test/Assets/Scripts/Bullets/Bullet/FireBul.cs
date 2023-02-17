using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBul : MonoBehaviour
{
    [SerializeField] private FireSpell _curSpell;

    private CircleCollider2D _collider;
    private Animator _anim;
    private Rigidbody2D _bulletRb;

    private int _amountAttack = 1;

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
        _anim = GetComponent<Animator>();
        _bulletRb = GetComponent<Rigidbody2D>();
    }

    public void LaunchBullet(Vector2 direction)
    {
        _bulletRb.velocity = direction.normalized * _curSpell.BulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_amountAttack == 1)
        {
            Collider2D[] _allEnemy = Physics2D.OverlapCircleAll(transform.position, _curSpell.CurrentRadius);
            foreach (var enemy in _allEnemy)
            {
                if (enemy.gameObject.TryGetComponent<Enemy>(out Enemy curEnemy))
                {
                    curEnemy.TakeDamage(_curSpell.CurrentDamage);
                }
            }
        }

        _amountAttack--;
        _bulletRb.velocity = Vector2.zero;
        _anim.SetBool("IsHit", true);
        transform.rotation = Quaternion.identity;
        _collider.enabled = false;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
