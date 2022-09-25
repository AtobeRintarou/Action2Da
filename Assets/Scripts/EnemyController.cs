using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy�̗̑�")]
    [SerializeField] int _hp = 10;
    private PlayerController _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (_hp < 1)
        {
            _player.Kill++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack" || collision.gameObject.tag == "Bullet")
        {
            _hp--;
            Debug.Log("���͂���");
        }
        else if (collision.gameObject.tag == "ChargeAttack" || collision.gameObject.tag == "ChargeBullet")
        {
            _hp -= 3;
            Debug.Log("���ڂ΂т�����");
        }
        else if (collision.gameObject.tag == "Skill")
        {
            _hp -= 6;
            Debug.Log("����");
        }
    }
}
