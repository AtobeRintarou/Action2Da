using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{

    [Header("スピード")]
    [SerializeField] float _speed = 3f;
    [Header("ライフタイム")]
    [SerializeField] float _lifeTime = 5f;

    public PlayerController _playerControllerScript = null;
    void Start()
    {
        // Player という名前の Object から PlayerController スクリプトの情報を取得
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Player が左を向いているとき
        if (_playerControllerScript.isReturn)
        {
            rb.velocity = Vector2.right * _speed * -1;
        }
        // Player が右を向いているとき
        else
        {
            rb.velocity = Vector2.right * _speed;
        }
        // 生存時間が経過したら自分自身を破壊する
        Destroy(this.gameObject, _lifeTime);
    }
}
