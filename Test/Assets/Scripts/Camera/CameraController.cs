using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        if ((_player.position.x <= BoardMap.LeftMaxPos || _player.position.x >= BoardMap.RightMaxPos)
            && (_player.position.y <= BoardMap.DownMaxPos || _player.position.y >= BoardMap.TopMaxPos))
        {
            Vector3 curPosXY = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.position = curPosXY;
        }
        else if(_player.position.x <= BoardMap.LeftMaxPos || _player.position.x >= BoardMap.RightMaxPos)
        {
            Vector3 curPosY = new Vector3(gameObject.transform.position.x, _player.position.y, gameObject.transform.position.z);
            gameObject.transform.position = curPosY;
        }
        else if ( _player.position.y <= BoardMap.DownMaxPos || _player.position.y >= BoardMap.TopMaxPos)
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
