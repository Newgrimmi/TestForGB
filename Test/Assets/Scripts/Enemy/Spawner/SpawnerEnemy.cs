using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Transform _player;

    private SpawnPosition _spawnPosition;
    private Enemy _curEnemy;

    private void Start()
    {
        _spawnPosition = GetComponent<SpawnPosition>();
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        //while (true)
        //{
            _curEnemy = Instantiate(_enemies[0], _spawnPosition.PositionCalculated(_player.position), Quaternion.identity);
            _curEnemy.Initialized(_player);
            yield return new WaitForSeconds(5);
        //}
    }
}
