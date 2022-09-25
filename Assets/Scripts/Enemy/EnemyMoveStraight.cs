using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveStraight : MonoBehaviour
{
    [Header("�X�s�[�h")]
    [SerializeField] float _speed = 3f;

    void Start()
    {

    }

    void Update()
    {
        // ������x���ɍs������
        if (this.transform.position.x < -10f || this.transform.position.y < -10f)
        {
            // �������g��j������
            Destroy(this.gameObject);
        }

        // ��葬�x�ō��ɓ�����
        this.transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
