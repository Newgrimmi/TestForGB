using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private float _moveSpeed;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector2 direction)
    {
        if (direction.x < 0)
            _sr.flipX= true;
        else if (direction.x > 0)
            _sr.flipX = false;
        _rb.velocity = direction * _moveSpeed ;
    }


}
