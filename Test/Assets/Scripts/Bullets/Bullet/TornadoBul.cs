using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoBul : MonoBehaviour
{
    [SerializeField] private TornadoSpell _curSpell;

    private Rigidbody2D _bulletRb;

    private void Awake()
    {

        _bulletRb = GetComponent<Rigidbody2D>();
    }

    public void LaunchBullet(Vector2 direction)
    {
        _bulletRb.velocity = direction.normalized * _curSpell.BulletSpeed;
        StartCoroutine(Attack());
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_curSpell.CurrentDuration);
        Destroy(gameObject);
    }

    private IEnumerator Attack()
    {
        int tik = 0;
        while (true)
        {
            Collider2D[] _allEnemy = Physics2D.OverlapCircleAll(transform.position, _curSpell.CurrentRadius);
            foreach (var enemy in _allEnemy)
            {
                if (enemy.gameObject.TryGetComponent<Enemy>(out Enemy curEnemy))
                {
                    enemy.transform.position = transform.position;
                    if(tik%5 ==0)
                        curEnemy.TakeDamage(_curSpell.CurrentDamage);
                }
            }
            tik++;
            yield return new WaitForSeconds(_curSpell.CurrentSpeedAttack/5);
        }
    }

}
