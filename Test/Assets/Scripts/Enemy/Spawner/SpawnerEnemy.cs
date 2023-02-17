using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour, IPauseable
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Transform _player;
    [SerializeField] private PauseActivator _pauseActivator;

    private bool _isPaused;
    private float _spawnSpeed;
    private float _timer;
    private SpawnPosition _spawnPosition;
    private Enemy _curEnemy;

    private int countWave;
    private readonly float _timeSpawnBoss = 120f;

    private void Start()
    {
        countWave = 0;
        _spawnSpeed = 2f;
        _pauseActivator.AddPauseEntity(this);
        _spawnPosition = GetComponent<SpawnPosition>();
        StartCoroutine(Spawner());
        StartCoroutine(BossSpawner());
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 60)
        {
            countWave++;
            _timer = 0;
        }
            
    }

    private IEnumerator Spawner()
    {
        while (!_isPaused)
        {
            WaveSpawn();
            yield return new WaitForSeconds(_spawnSpeed);
        }
    }

    public void Pause()
    {
        _isPaused = true;
        StopCoroutine(Spawner());
    }

    public void UnPause()
    {
        _isPaused = false;
        StartCoroutine(Spawner());
    }

    private void WaveSpawn()
    {
        
        switch (countWave)
        {    
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                for (int i = 0; i < countWave+1; i++)
                {
                    int rnd = Random.Range(0, _enemies.Count - 1);
                    _curEnemy = Instantiate(_enemies[rnd], _spawnPosition.PositionCalculated(_player.position), Quaternion.identity);
                    _curEnemy.Initialized(_player);
                }
                break;
            default:
                for (int i = 0; i < 10; i++)
                {
                    int rnd = Random.Range(0, _enemies.Count - 1);
                    _curEnemy = Instantiate(_enemies[rnd], _spawnPosition.PositionCalculated(_player.position), Quaternion.identity);
                    _curEnemy.Initialized(_player);
                }
                break;
        }
    }

    private IEnumerator BossSpawner()
    {
        yield return new WaitForSeconds(_timeSpawnBoss);
        _curEnemy = Instantiate(_enemies[4], _spawnPosition.PositionCalculated(_player.position), Quaternion.identity);
        _curEnemy.Initialized(_player);
    }
}
