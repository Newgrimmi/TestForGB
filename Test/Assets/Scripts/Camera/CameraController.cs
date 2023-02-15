using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    //private float _horizontal;
    //private float _vertical;

    private readonly float _leftMaxPos = -16f;
    private readonly float _rightMaxPos = 29.5f;
    private readonly float _topMaxPos = 15.5f;
    private readonly float _downMaxPos = -15f;

    private void Update()
    {
        if ((_player.position.x <= _leftMaxPos || _player.position.x >= _rightMaxPos)
            && (_player.position.y <= _downMaxPos || _player.position.y >= _topMaxPos))
        {
            Vector3 curPosXY = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = curPosXY;
        }
        else if(_player.position.x <= _leftMaxPos || _player.position.x >= _rightMaxPos)
        {
            Vector3 curPosY = new Vector3(gameObject.transform.position.x, _player.position.y, gameObject.transform.position.z);
            gameObject.transform.position = curPosY;
        }
        else if ( _player.position.y <= _downMaxPos || _player.position.y >= _topMaxPos)
        {
            Vector3 curPosX = new Vector3(_player.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = curPosX;
        }
        else
        {
            Vector3 curPos = new Vector3(_player.position.x, _player.position.y, gameObject.transform.position.z);
            gameObject.transform.position = curPos;
        }
        

    }
}
