using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [Header("発射する弾のスピード")]
    [SerializeField] float _speed = 3f;
    [Header("発射する弾のライフタイム")]
    [SerializeField] float _lifeTime = 5f;

    void Start()
    {

    }
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // 一定速度で左に動かす
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
