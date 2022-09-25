using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [Header("���˂���e�̃X�s�[�h")]
    [SerializeField] float _speed = 3f;
    [Header("���˂���e�̃��C�t�^�C��")]
    [SerializeField] float _lifeTime = 5f;

    void Start()
    {

    }
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // ��葬�x�ō��ɓ�����
        rb.velocity = Vector2.right * _speed * -1;
        //this.transform.Translate(Vector2.left * _speed);
        Destroy(this.gameObject, _lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
