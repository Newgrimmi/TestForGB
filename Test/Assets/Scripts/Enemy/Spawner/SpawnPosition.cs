using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    [SerializeField] private float _distanceFromPlayer;

    public Vector3 PositionCalculated(Vector3 _playerPosition)
    {
        float rndX = Random.Range(-1f, 1f);
        float rndY;
        if (rndX > 0)
            rndY = Mathf.Sqrt(1 * 1 - rndX * rndX);
        else rndY = -Mathf.Sqrt(1 * 1 - rndX * rndX);

        Vector3 spawnPos = new Vector3(rndX * _distanceFromPlayer + _playerPosition.x, rndY * _distanceFromPlayer + _playerPosition.y, 0);

        if (spawnPos.x > BoardMap.RightMaxPos) spawnPos.x = BoardMap.RightMaxPos;
        if (spawnPos.x < BoardMap.LeftMaxPos) spawnPos.x = BoardMap.LeftMaxPos;
        if (spawnPos.y > BoardMap.TopMaxPos) spawnPos.y = BoardMap.TopMaxPos;
        if (spawnPos.y < BoardMap.DownMaxPos) spawnPos.y = BoardMap.DownMaxPos;

        return spawnPos;
    }
}
