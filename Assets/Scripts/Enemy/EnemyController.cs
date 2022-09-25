using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy‚Ì‘Ì—Í")]
    [SerializeField] int _hp = 10;
    private PlayerController _player;

    public int Hp { get { return _hp; } set { _hp = value; } }
    void Start()
    {
        Hp = _hp;
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
        if (collision.gameObject.tag == "Attack")
        {
            _hp--;
            Debug.Log("‚®‚Í‚Á‚Á");
        }
        else if (collision.gameObject.tag == "ChargeAttack")
        {
            _hp -= 3;
            Debug.Log("‚°‚Ú‚Î‚Ñ‚¡‚¡‚¡");
        }
        else if (collision.gameObject.tag == "Skill")
        {
            _hp -= 6;
            Debug.Log("‚ ‚Á");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _hp--;
            Debug.Log("‚®‚Í‚Á‚Á");
        }
        else if (collision.gameObject.tag == "ChargeBullet")
        {
            _hp -= 3;
            Debug.Log("‚°‚Ú‚Î‚Ñ‚¡‚¡‚¡");
        }
    }
}
