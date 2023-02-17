using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArray : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyInZone = new List<Enemy>();

    public List<Enemy> AllEnemy => _enemyInZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy _curEnemy))
            _enemyInZone.Add(_curEnemy);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy _curEnemy))
            _enemyInZone.Remove(_curEnemy);
    }

}
