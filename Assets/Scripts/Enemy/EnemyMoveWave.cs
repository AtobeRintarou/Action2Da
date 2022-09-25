using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveWave : MonoBehaviour
{
    [Header("波の振り幅")]
    [SerializeField] float m_amplitude = 1.5f;
    [Header("波打つ速さ")]
    [SerializeField] float m_speedX = 3f;
    [Header("移動速度")]
    [SerializeField] float m_speedY = 1f;

    Vector2 m_initialPosition;
    float m_timer;

    void Start()
    {
        m_initialPosition = this.transform.position;
    }
    void Update()
    {
        // X 座標を三角関数で表現することにより「波打つ・往復する」移動を行う
        m_timer += Time.deltaTime;
        float posX = (-1) * m_timer * m_speedY; // Y 方向はまっすぐ移動する
        float posY = Mathf.Sin(m_timer * m_speedX) * m_amplitude;

        Vector2 pos = m_initialPosition + new Vector2(posX, posY);
        transform.position = pos;   // 座標を直接代入することで移動させる
    }
}
