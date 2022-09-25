using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy‚Ì‘Ì—Í")]
    [SerializeField] int _hp = 10;

    public int EnemyHpMax { get; private set; }
    public int EnemyHp { get { return _hp; } set { _hp = value; } }
    void Start()
    {
        EnemyHpMax = _hp;
    }

    void Update()
    {
        if (_hp < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack" || collision.gameObject.tag == "Bullet")
        {
            _hp--;
            Debug.Log("‚®‚Í‚Á‚Á");
        }
        else if (collision.gameObject.tag == "ChargeAttack" || collision.gameObject.tag == "ChargeBullet")
        {
            _hp -= 3;
            Debug.Log("‚°‚Ú‚Î‚Ñ‚¡‚¡‚¡");
        }
    }
}
