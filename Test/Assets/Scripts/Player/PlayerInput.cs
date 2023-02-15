using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";
    private Vector2 _direction;

    private void Update()
    {
        float horizontal = Input.GetAxis(HorizontalAxis);
        float vertical = Input.GetAxis(VerticalAxis);

        _direction = new Vector2(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        _player.Move(_direction);
    }

}
