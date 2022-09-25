using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("生成するプレハブ")]
    [SerializeField] GameObject _enemyPrefab;
    [Header("生成位置")]
    [SerializeField] Transform _transform;
    [Header("クールタイム")]
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
