using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour, IPauseable
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Transform _player;
    [SerializeField] private PauseActivator _pauseActivator;

    private bool _isPaused;

    private SpawnPosition _spawnPosition;
    private Enemy _curEnemy;

    private void Start()
    {
        _pauseActivator.AddPauseEntity(this);
        _spawnPosition = GetComponent<SpawnPosition>();
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (!_isPaused)
        {
            _curEnemy = Instantiate(_enemies[0], _spawnPosition.PositionCalculated(_player.position), Quaternion.identity);
            _curEnemy.Initialized(_player);
            yield return new WaitForSeconds(2);
        }
    }

    public void Pause()
    {
        _isPaused = true;
        StopAllCoroutines();
    }

    public void UnPause()
    {
        _isPaused = false;
        StartCoroutine(Spawner());
    }
}
