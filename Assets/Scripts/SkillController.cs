using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{

    [Header("�X�s�[�h")]
    [SerializeField] float _speed = 3f;
    [Header("���C�t�^�C��")]
    [SerializeField] float _lifeTime = 5f;

    public PlayerController _playerControllerScript = null;
    void Start()
    {
        // Player �Ƃ������O�� Object ���� PlayerController �X�N���v�g�̏����擾
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Player �����������Ă���Ƃ�
        if (_playerControllerScript.isReturn)
        {
            rb.velocity = Vector2.right * _speed * -1;
        }
        // Player ���E�������Ă���Ƃ�
        else
        {
            rb.velocity = Vector2.right * _speed;
        }
        // �������Ԃ��o�߂����玩�����g��j�󂷂�
        Destroy(this.gameObject, _lifeTime);
    }
}
