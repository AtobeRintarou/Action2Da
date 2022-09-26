using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumping : MonoBehaviour
{
    [Header("移動速度")]
    [SerializeField] float _speed = 2.0f;
    [Header("ジャンプ力")]
    [SerializeField] float _force = 70.0f;
    [Header("インターバル")]
    [SerializeField] float _fireInterval = 1f;
    /// <summary>壁を検出するための line のオフセット</summary>
    Vector2 _lineForWall = Vector2.left;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>移動方向</summary>
    Vector2 _moveDirection = Vector2.left;
    Rigidbody2D _rb = default;
    float _timer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _fireInterval)
        {
            _rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            _timer = 0f;
        }
        MoveWithTurn();
    }

    void MoveWithTurn()
    {
        Vector2 start = this.transform.position;
        Debug.DrawLine(start, start + _lineForWall);
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForWall, _wallLayer);
        Vector2 velo = Vector2.zero;    // velo は速度ベクトル


        if (hit.collider)
        {
            Debug.Log("Hit");
            _lineForWall *= -1;
            _moveDirection *= -1;
        }

        velo = _moveDirection.normalized * _speed;
        velo.y = _rb.velocity.y;
        _rb.velocity = velo;
    }
}
