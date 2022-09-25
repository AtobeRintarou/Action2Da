using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("��������v���n�u")]
    [SerializeField] GameObject _enemyPrefab;
    [Header("�����ʒu")]
    [SerializeField] Transform _transform;
    [Header("�N�[���^�C��")]
    [SerializeField] float _Interval = 2f;
    float _Timer;
    void Start()
    {
        _Timer = _Interval;
    }

    void Update()
    {
        _Timer += Time.deltaTime;
        if (_Timer > _Interval)
        {
            GameObject enemy = Instantiate(_enemyPrefab);
            enemy.transform.position = _transform.position;
            _Timer = 0;
        }
    }
}
