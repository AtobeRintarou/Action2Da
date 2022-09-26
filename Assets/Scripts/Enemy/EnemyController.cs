using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemyの体力")]
    [SerializeField] int _hp = 10;
    [Header("得点")]
    [SerializeField] int _point = 100;
    private PlayerController _player;
    private GameManager _gm;

    public int Hp { get { return _hp; } set { _hp = value; } }
    void Start()
    {
        Hp = _hp;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (_hp < 1)
        {
            _gm.Score += _point;
            _player.Kill++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            _hp--;
            Debug.Log("ぐはっっ");
        }
        else if (collision.gameObject.tag == "ChargeAttack")
        {
            _hp -= 3;
            Debug.Log("げぼばびぃぃぃ");
        }
        else if (collision.gameObject.tag == "Skill")
        {
            _hp -= 6;
            Debug.Log("あっ");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _hp--;
            Debug.Log("ぐはっっ");
        }
        else if (collision.gameObject.tag == "ChargeBullet")
        {
            _hp -= 3;
            Debug.Log("げぼばびぃぃぃ");
        }
    }
}
