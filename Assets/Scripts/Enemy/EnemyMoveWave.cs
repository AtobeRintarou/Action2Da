using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveWave : MonoBehaviour
{
    [Header("波の振り幅")]
    [SerializeField] float m_amplitude = 1.5f;
    [Header("波打つ速さ")]
    [SerializeField] float m_speedY = 3f;
    [Header("移動速度")]
    [SerializeField] float m_speedX = 1f;
    /// <summary>壁を検出するための line のオフセット</summary>
    Vector2 _lineForWall = Vector2.left;
    /// <summary>壁のレイヤー（レイヤーはオブジェクトに設定されている）</summary>
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>移動方向</summary>
    float _moveDirection = -1;
    Rigidbody2D _rb = default;
    Vector2 m_initialPosition;
    float m_timer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        m_initialPosition = this.transform.position;
    }
    void Update()
    {
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

        // X 座標を三角関数で表現することにより「波打つ・往復する」移動を行う
        m_timer += Time.deltaTime;
        float posX = (_moveDirection) * m_timer * m_speedX; // X 方向はまっすぐ移動する
        float posY = Mathf.Sin(m_timer * m_speedY) * m_amplitude;

        Vector2 pos = m_initialPosition + new Vector2(posX, posY);
        transform.position = pos;   // 座標を直接代入することで移動させる
        _rb.velocity = velo;
    }
}
