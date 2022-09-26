using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymplePlayer : MonoBehaviour
{
    [Header("�v���C���[�̈ړ����x")]
    [SerializeField] float _speed = 25.0f;
    [Header("�v���C���[�̃W�����v��")]
    [SerializeField] float _force = 70.0f;

    // �v���C���[�� Rigidbody
    Rigidbody2D m_rb = default;
    // ��i�W�����v�̐^�U
    bool _doubleJump = false;
    // �n�ʂɗ����Ă��邩�̐^�U
    bool _isGround = true;
    // ���E�𔽓]�����邩�̐^�U
    bool _flipX = true;
    // ���������̓��͒l
    float m_h;
    float _scaleX;

    public bool isReturn = false;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ���͂��󂯎��
        m_h = Input.GetAxisRaw("Horizontal");
        // �X�y�[�X�L�[�ŃW�����v
        if (Input.GetButtonDown("Jump"))
        {
            // Ground �ɐG��Ă���Ƃ�
            if (_isGround)
            {
                _isGround = false;
                _doubleJump = true;

                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                Debug.Log("����Α�n");
            }
            // 2�i�W�����v���Ă���W�����v�ł��Ȃ�
            else if (_doubleJump)
            {
                _doubleJump = false;
                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                Debug.Log("���ׂȂ���");
            }
        }

        // ���ɍs���������珉���ʒu�ɖ߂�
        if (this.transform.position.y < -10f)
        {
            GameManager gm = GameObject.FindObjectOfType<GameManager>();
            if (gm)
            {
                gm.PlayerDead();
            }
            Debug.Log("�����A�n���s��");
        }

        if (_flipX)
        {
            FlipX(m_h);
        }
    }

    void FixedUpdate()
    {
        // �͂�������̂� FixedUpdate �ōs��
        m_rb.AddForce(Vector2.right * m_h * _speed, ForceMode2D.Force);
    }

    // Player �̌����Ɋւ��郁�\�b�h
    void FlipX(float horizontal)
    {
        _scaleX = this.transform.localScale.x;


        // Player ���E�������Ă���Ƃ�
        if (horizontal > 0)
        {
            isReturn = false;
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        // Player �����������Ă���Ƃ�
        else if (horizontal < 0)
        {
            isReturn = true;
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground �ɐG��Ă���Ƃ�
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
            Debug.Log("�n�ʂɂ���ɂ���");
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (collision.gameObject.tag == "Wall")
            {
                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            }
        }
    }
}
