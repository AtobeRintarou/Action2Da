using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFly : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    private PlayerController _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Vector2 v = player.transform.position - this.transform.position;
            v = v.normalized * m_speed;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player.HP -= 8;
            Destroy(gameObject);
        }
    }
}
