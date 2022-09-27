using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy‚Ì‘Ì—Í")]
    [SerializeField] int _hp = 10;
    [Header("“¾“_")]
    [SerializeField] int _point = 100;
    private PlayerController _player;
    Animator _anim;
    public int Hp { get { return _hp; } set { _hp = value; } }
    void Start()
    {
        Hp = _hp;
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (_hp < 1)
        {
            _anim.SetTrigger("isDeath");
            GameManager.Score += _point;
            _player.Kill++;
            Destroy(gameObject,0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            _anim.SetTrigger("isDamage");
            _hp--;
            Debug.Log("‚®‚Í‚Á‚Á");
        }
        else if (collision.gameObject.tag == "ChargeAttack")
        {
            _anim.SetTrigger("isDamage");
            _hp -= 3;
            Debug.Log("‚°‚Ú‚Î‚Ñ‚¡‚¡‚¡");
        }
        else if (collision.gameObject.tag == "Skill")
        {
            _anim.SetTrigger("isDamage");
            _hp -= 6;
            Debug.Log("‚ ‚Á");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _anim.SetTrigger("isDamage");
            _hp--;
            Debug.Log("‚®‚Í‚Á‚Á");
        }
        else if (collision.gameObject.tag == "ChargeBullet")
        {
            _anim.SetTrigger("isDamage");
            _hp -= 3;
            Debug.Log("‚°‚Ú‚Î‚Ñ‚¡‚¡‚¡");
        }
    }
}
