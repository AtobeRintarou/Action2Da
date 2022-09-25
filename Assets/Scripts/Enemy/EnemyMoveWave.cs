using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveWave : MonoBehaviour
{
    [Header("�g�̐U�蕝")]
    [SerializeField] float m_amplitude = 1.5f;
    [Header("�g�ł���")]
    [SerializeField] float m_speedX = 3f;
    [Header("�ړ����x")]
    [SerializeField] float m_speedY = 1f;

    Vector2 m_initialPosition;
    float m_timer;

    void Start()
    {
        m_initialPosition = this.transform.position;
    }
    void Update()
    {
        // X ���W���O�p�֐��ŕ\�����邱�Ƃɂ��u�g�łE��������v�ړ����s��
        m_timer += Time.deltaTime;
        float posX = (-1) * m_timer * m_speedY; // Y �����͂܂������ړ�����
        float posY = Mathf.Sin(m_timer * m_speedX) * m_amplitude;

        Vector2 pos = m_initialPosition + new Vector2(posX, posY);
        transform.position = pos;   // ���W�𒼐ڑ�����邱�Ƃňړ�������
    }
}
