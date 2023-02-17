using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTornadoBul : MonoBehaviour, IPauseable
{
    [SerializeField] private GameObject _tornadoBullet;
    [SerializeField] private Transform _SpawnPoint;
    [SerializeField] private EnemyArray _allEnemyInZone;
    [SerializeField] private PauseActivator _pauseActivator;
    [SerializeField] private TornadoSpell _tornadoSpell;

    private bool _isActive;
    private bool _isPaused;
    private GameObject _curBulletPrefab;

    private readonly float _speedAttack = 4;

    private void Start()
    {
        _tornadoSpell.ResetValue();
        _pauseActivator.AddPauseEntity(this);
    }

    private void OnEnable()
    {
        _tornadoSpell.OnUpgrade += CheckLevel;
    }

    private void OnDisable()
    {
        _tornadoSpell.OnUpgrade -= CheckLevel;
    }

    private IEnumerator SimpleBulAttack()
    {
        while (!_isPaused)
        {
            for (int i = 0; i < _tornadoSpell.CurrentAmountBul; i++)
            {
                Vector2 direction;
                if (_allEnemyInZone.AllEnemy.Count > 0)
                {
                    int rndEnemy = Random.Range(0, _allEnemyInZone.AllEnemy.Count);
                    direction = (_allEnemyInZone.AllEnemy[rndEnemy].transform.position - _SpawnPoint.position).normalized;
                }
                else
                {
                    float rndX = Random.Range(-1f, 1f);
                    float rndY = Random.Range(-1f, 1f);
                    direction = new Vector2(rndX, rndY);
                }
                
                _curBulletPrefab = Instantiate(_tornadoBullet, _SpawnPoint.position, Quaternion.Euler(0,0,0));
                if (_curBulletPrefab.TryGetComponent<TornadoBul>(out TornadoBul tornadoBul))
                {
                    tornadoBul.LaunchBullet(direction);
                }
                yield return new WaitForSeconds(_speedAttack);
            }
        }
    }

    private void CheckLevel()
    {
        if (_tornadoSpell.CurrentSpellLevel > 0)
        {
            _isActive = true;
        }
    }

    public void Pause()
    {
        if (_isActive)
        {
            _isPaused = true;
            StopAllCoroutines();
        }
    }

    public void UnPause()
    {
        if (_isActive)
        {
            _isPaused = false;
            StartCoroutine(SimpleBulAttack());
        }
    }
}
