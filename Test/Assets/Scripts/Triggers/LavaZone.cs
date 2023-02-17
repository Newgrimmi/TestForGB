using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaZone : MonoBehaviour
{
    [SerializeField] private float _damage;

    private PlayerHealth _playerHP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHP))
        {
            _playerHP = playerHP;
            StartCoroutine(FireHit());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHP))
        {
            _playerHP = null;
            StopCoroutine(FireHit());
        }
    }

    private IEnumerator FireHit()
    {
        while (_playerHP!=null)
        {
            _playerHP.TakeDamage(_damage);
            yield return new WaitForSeconds(1);
        }
    }
}
