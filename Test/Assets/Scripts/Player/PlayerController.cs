using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMoveable
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        if (direction.x < 0)
            _sr.flipX= true;
        else if (direction.x > 0)
            _sr.flipX = false;
        _rb.velocity = direction * _moveSpeed ;
       // _rb.AddForce(direction * _moveSpeed);
    }


}
