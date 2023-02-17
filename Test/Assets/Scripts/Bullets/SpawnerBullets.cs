using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullets : MonoBehaviour
{    
    [SerializeField] private GameObject _simpleBuller;
    [SerializeField] private Transform _SpawnPoint;

    private GameObject _curBul;

    private void Start()
    {
        StartCoroutine(SimpleBulAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SimpleBulAttack()
    {
        while (true)
        {
            float rndX = Random.Range(-1f, 1f);
            float rndY = Random.Range(-1f, 1f);
            Vector2 direction = new Vector2(rndX, rndY);
            float curEuler;
            if (rndY>0)
                curEuler = Vector2.Angle(Vector2.right, direction);
            else curEuler = Vector2.Angle(Vector2.right, direction) *-1;
            _curBul = Instantiate(_simpleBuller, _SpawnPoint.position, Quaternion.Euler(0,0, curEuler));
            if (_curBul.TryGetComponent<SimpleBul>(out SimpleBul simpleBul))
                simpleBul.LaunchBullet(direction);
            yield return new WaitForSeconds(2);
        }

    }
}
