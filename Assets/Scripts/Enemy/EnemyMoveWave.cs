using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveWave : MonoBehaviour
{
    [Header("�g�̐U�蕝")]
    [SerializeField] float m_amplitude = 1.5f;
    [Header("�g�ł���")]
    [SerializeField] float m_speedY = 3f;
    [Header("�ړ����x")]
    [SerializeField] float m_speedX = 1f;
    /// <summary>�ǂ����o���邽�߂� line �̃I�t�Z�b�g</summary>
    Vector2 _lineForWall = Vector2.left;
    /// <summary>�ǂ̃��C���[�i���C���[�̓I�u�W�F�N�g�ɐݒ肳��Ă���j</summary>
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>�ړ�����</summary>
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
        Vector2 velo = Vector2.zero;    // velo �͑��x�x�N�g��


        if (hit.collider)
        {
            Debug.Log("Hit");
            _lineForWall *= -1;
            _moveDirection *= -1;
        }

        // X ���W���O�p�֐��ŕ\�����邱�Ƃɂ��u�g�łE��������v�ړ����s��
        m_timer += Time.deltaTime;
        float posX = (_moveDirection) * m_timer * m_speedX; // X �����͂܂������ړ�����
        float posY = Mathf.Sin(m_timer * m_speedY) * m_amplitude;

        Vector2 pos = m_initialPosition + new Vector2(posX, posY);
        transform.position = pos;   // ���W�𒼐ڑ�����邱�Ƃňړ�������
        _rb.velocity = velo;
    }
}
