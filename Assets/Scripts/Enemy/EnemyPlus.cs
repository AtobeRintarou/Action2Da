using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlus : MonoBehaviour
{
    private EnemyController _enemy;
    [SerializeField] float _speed = 3f;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _transform;
    void Start()
    {
        _enemy = GameObject.FindGameObjectWithTag("Enemy6").GetComponent<EnemyController>();

    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Vector2 v = player.transform.position - this.transform.position;
            v = v.normalized * _speed;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }

        if (_enemy.Hp < 1)
        {
            for (int i = 1; i <= 3; i++)
            {
                GameObject bullet = Instantiate(_enemyPrefab);
                bullet.transform.position = _transform.position;
            }
        }
    }
}
