using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �w�i�����X�N���[�����邽�߂̃R���|�[�l���g
[RequireComponent(typeof(SpriteRenderer))]
public class Background : MonoBehaviour
{
    // �w�i�̃X�N���[�����x
    [SerializeField] float m_scrollSpeed = -1f;
    SpriteRenderer m_sprite = default;

    private void Start()
    {
        m_sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // �w�i�摜���X�N���[������
        m_sprite.transform.Translate(-1 * m_scrollSpeed * Time.deltaTime, 0f, 0f);

        // �w�i�摜��������x���ɓ�������A�E�ɖ߂�
        if (m_sprite.transform.position.x < -1 * m_sprite.bounds.size.x)
        {
            m_sprite.transform.Translate(m_sprite.bounds.size.x * 2, 0f, 0f);
        }
    }
}