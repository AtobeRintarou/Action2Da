using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveStraight : MonoBehaviour
{
    [Header("スピード")]
    [SerializeField] float _speed = 3f;

    void Start()
    {

    }

    void Update()
    {
        // ある程度左に行ったら
        if (this.transform.position.x < -10f || this.transform.position.y < -10f)
        {
            // 自分自身を破棄する
            Destroy(this.gameObject);
        }

        // 一定速度で左に動かす
        this.transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
