using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bullet の動きに関するスクリプト
/// Bullet にしたい Prefab にアタッチして使う
/// </summary>
public class BulletController : MonoBehaviour
{
    [Header("発射する弾のスピード")]
    [SerializeField] float _speed = 3f;
    [Header("発射する弾のライフタイム")]
    [SerializeField] float _lifeTime = 5f;

    public PlayerController _playerControllerScript = null;
    void Start()
    {
        // Player という名前の Object から PlayerController スクリプトの情報を取得
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Player が左を向いているとき
        if (_playerControllerScript.isreturn)
        {
            rb.velocity = Vector2.right * _speed * -1;
            Debug.Log("左だよ");
        }
        // Player が右を向いているとき
        else
        {
            rb.velocity = Vector2.right * _speed;
            Debug.Log("右だよ");
        }
        // 生存時間が経過したら自分自身を破壊する
        Destroy(this.gameObject, _lifeTime);
    }
}
