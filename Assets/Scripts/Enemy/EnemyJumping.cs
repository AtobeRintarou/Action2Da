using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumping : MonoBehaviour
{
    [Header("�ړ����x")]
    [SerializeField] float _speed = 2.0f;
    [Header("�W�����v��")]
    [SerializeField] float _force = 70.0f;
    [Header("�C���^�[�o��")]
    [SerializeField] float _fireInterval = 1f;
    /// <summary>�ǂ����o���邽�߂� line �̃I�t�Z�b�g</summary>
    Vector2 _lineForWall = Vector2.left;
    /// <summary>�ǂ̃��C���[�i���C���[�̓I�u�W�F�N�g�ɐݒ肳��Ă���j</summary>
    [SerializeField] LayerMask _wallLayer = 0;
    /// <summary>�ړ�����</summary>
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
        Vector2 velo = Vector2.zero;    // velo �͑��x�x�N�g��


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
