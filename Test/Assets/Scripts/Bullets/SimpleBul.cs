using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBul : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    private Animator _anim;
    private Rigidbody2D _bulletRb;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _bulletRb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        
    }

    public void LaunchBullet(Vector2 direction)
    {
        _bulletRb.velocity = direction.normalized * _bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _bulletRb.velocity = Vector2.zero;
        _anim.SetBool("IsHit", true);
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
