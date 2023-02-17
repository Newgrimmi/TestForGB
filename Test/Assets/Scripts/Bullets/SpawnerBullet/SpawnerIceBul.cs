using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerIceBul : MonoBehaviour, IPauseable
{
    [SerializeField] private GameObject _iceBuller;
    [SerializeField] private Transform _SpawnPoint;
    [SerializeField] private EnemyArray _allEnemyInZone;
    [SerializeField] private PauseActivator _pauseActivator;
    [SerializeField] private IceSpell _iceSpell;

    private bool _isActive;
    private bool _isPaused;
    private GameObject _curBulletPrefab;
    private readonly float _speedAttack = 2;

    private void Start()
    {
        _iceSpell.ResetValue();
        _pauseActivator.AddPauseEntity(this);
    }

    private void OnEnable()
    {
        _iceSpell.OnUpgrade += CheckLevel;
    }

    private void OnDisable()
    {
        _iceSpell.OnUpgrade -= CheckLevel;
    }
    private IEnumerator SimpleBulAttack()
    {
        while (!_isPaused)
        {
            Vector2 direction;
            float curEuler = 0;
            if (_allEnemyInZone.AllEnemy.Count > 0)
            {
                int rndEnemy = Random.Range(0, _allEnemyInZone.AllEnemy.Count);

                direction = (_allEnemyInZone.AllEnemy[rndEnemy].transform.position - _SpawnPoint.position).normalized;
                if (direction.y > 0)
                    curEuler = Vector2.Angle(Vector2.right, direction);
                else curEuler = Vector2.Angle(Vector2.right, direction) * -1;
            }
            else
            {
                float rndX = Random.Range(-1f, 1f);
                float rndY = Random.Range(-1f, 1f);
                direction = new Vector2(rndX, rndY);
                if (rndY > 0)
                    curEuler = Vector2.Angle(Vector2.right, direction);
                else curEuler = Vector2.Angle(Vector2.right, direction) * -1;
            }

            _curBulletPrefab = Instantiate(_iceBuller, _SpawnPoint.position, Quaternion.Euler(0, 0, curEuler));
            if (_curBulletPrefab.TryGetComponent<IceBul>(out IceBul iceBul))
                iceBul.LaunchBullet(direction);
            
            yield return new WaitForSeconds(_speedAttack);
        }

    }

    private void CheckLevel()
    {
        if (_iceSpell.CurrentSpellLevel > 0)
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
