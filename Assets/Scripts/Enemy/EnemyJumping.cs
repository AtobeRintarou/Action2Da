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
    float _timer;
    Rigidbody2D m_rb = default;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _fireInterval)
        {
            m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            _timer = 0f;
        }
        this.transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
