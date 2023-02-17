using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    private string HorizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";
    private Vector2 _direction;

    //public Action _isEsc; 

    private void Update()
    {
        float horizontal = Input.GetAxis(HorizontalAxis);
        float vertical = Input.GetAxis(VerticalAxis);

        _direction = new Vector2(horizontal, vertical);

        //if (Input.GetKeyDown(KeyCode.Escape))
        //    _isEsc?.Invoke();
    }

    private void FixedUpdate()
    {
        _player.Move(_direction);
    }

}
