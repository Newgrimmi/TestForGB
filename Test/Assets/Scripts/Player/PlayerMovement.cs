using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable, IPauseable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private PauseActivator _pauseActivator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    private bool _isPaused;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _pauseActivator.AddPauseEntity(this);
    }

    public void Move(Vector2 direction)
    {
        if (!_isPaused)
        {
            if (direction.x < 0)
                _sr.flipX = true;
            else if (direction.x > 0)
                _sr.flipX = false;
            _rb.velocity = direction * _moveSpeed;
        }   
    }

    public void Pause()
    {
        _rb.velocity = Vector2.zero;
        _isPaused = true;
    }

    public void UnPause()
    {
        _isPaused = false;
    }
}
