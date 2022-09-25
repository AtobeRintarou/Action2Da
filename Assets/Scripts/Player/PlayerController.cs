using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player の動きに関するスクリプト
/// Player になる Object にアタッチして使う
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("発射する弾のプレハブ")]
    [SerializeField] GameObject _bulletPrefab = default;
    [Header("溜め攻撃時に発射する弾のプレハブ")]
    [SerializeField] GameObject _chargeBulletPrefab = default;
    [Header("マズルのプレハブ")]
    [SerializeField] Transform _muzzle = default;
    [Header("プレイヤーの移動速度")]
    [SerializeField] float _speed = 25.0f;
    [Header("プレイヤーのジャンプ力")]
    [SerializeField] float _force = 70.0f;
    [Header("近接攻撃の当たり判定用オブジェクト")]
    public GameObject _attack;
    [Header("近接溜攻撃の当たり判定用オブジェクト")]
    public GameObject _chargeAttack;
    [Header("遠距離攻撃のクールタイム")]
    [SerializeField] float _longLangeInterval = 1f;
    float _longLangeTimer;
    [Header("近接攻撃のクールタイム")]
    [SerializeField] float _meleeInterval = 1f;
    float _meleeTimer;

    [Header("近接攻撃の溜め時間")]
    public float _meleeChargeDuretion;
    float _meleeChargeTime = 1.5f;

    [Header("遠距離攻撃の溜め時間")]
    public float _longLangeChargeDuretion;
    float _longLangeChargeTime = 1.5f;

    [Header("プレイヤーの体力")]
    [SerializeField] int _hp = 10;

    [Header("必殺に必要なKILL数")]
    [SerializeField] int _killCount = 10;
    int _kill;

    [Header("必殺技の当たり判定用オブジェクト")]
    public GameObject _skill;

    [SerializeField] bool isGenerateOnStart = true;
    [SerializeField] public bool isReturn = false;

    public float Speed => _speed;
    // プレイヤーの Rigidbody
    Rigidbody2D m_rb = default;
    // 二段ジャンプの真偽
    bool _doubleJump = false;
    // 地面に立っているかの真偽
    bool _isGround = true;
    // 最初に出現した座標
    Vector3 m_initialPosition;
    // 左右を反転させるかの真偽
    bool _flipX = true;
    // 水平方向の入力値
    float m_h;
    float _scaleX;

    public int HpMax { get; private set; }
    public int HP { get { return _hp; } set { _hp = value; } }
    public bool IsMuteki { get; set; } = false;
    public int Kill { get; set; }

    private void Start()
    {
        HpMax = _hp;
        Kill = _kill;

        m_rb = GetComponent<Rigidbody2D>();
        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;

        if (isGenerateOnStart)
        {
            _longLangeTimer = _longLangeInterval;
            _meleeTimer = _meleeInterval;
        }
    }

    void Update()
    {
        _longLangeTimer += Time.deltaTime;
        _meleeTimer += Time.deltaTime;
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");
        // スペースキーでジャンプ
        if (Input.GetButtonDown("Jump"))
        {
            // Ground に触れているとき
            if (_isGround)
            {
                _isGround = false;
                _doubleJump = true;

                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                Debug.Log("さらば大地");
            }
            // 2段ジャンプしてたらジャンプできない
            else if (_doubleJump)
            {
                _doubleJump = false;
                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                Debug.Log("跳べない豚");
            }
        }

        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
            Debug.Log("判決、地獄行き");
        }

        if (_longLangeTimer > _longLangeInterval)
        {
            // 右クリックをしたら
            if (Input.GetButtonDown("Fire2"))
            {
                // 弾を発射する処理
                GameObject bullet = Instantiate(_bulletPrefab);
                bullet.transform.position = _muzzle.position;
                Debug.Log("「バーン」");
                _longLangeTimer = 0;
            }
        }

        if (Input.GetButton("Fire2"))
        {
            _longLangeChargeTime += Time.deltaTime;
        }
        else if (_longLangeChargeTime < _longLangeChargeDuretion)
        {
            _longLangeChargeTime = 0;
        }

        if (_longLangeChargeTime >= _longLangeChargeDuretion)
        {
            Debug.Log("遠距離溜まったよ");
            if (Input.GetButtonUp("Fire2"))
            {
                GameObject chargeBullet = Instantiate(_chargeBulletPrefab);
                chargeBullet.transform.position = _muzzle.position;
                Debug.Log("「ドカーン！！」");
                _longLangeChargeTime = 0;
            }
        }

        if (_meleeTimer > _meleeInterval)
        {
            // 左クリックをしたら
            if (Input.GetButtonDown("Fire1"))
            {
                if (_chargeAttack.activeSelf == false)
                {
                    // 近接攻撃をする処理
                    _attack.SetActive(true);
                    Invoke(nameof(DelayMethod), 0.8f);
                    Debug.Log("「ズバッ」");
                    if (_attack.activeSelf == false)
                    {
                        CancelInvoke();
                    }
                }
                _meleeTimer = 0;
            }
        }

        if (Input.GetButton("Fire1"))
        {
            _meleeChargeTime += Time.deltaTime;
        }
        else if (_meleeChargeTime < _meleeChargeDuretion)
        {
            _meleeChargeTime = 0;
        }

        if (_meleeChargeTime >= _meleeChargeDuretion)
        {
            Debug.Log("近接溜まったよ");
            if (Input.GetButtonUp("Fire1"))
            {
                _chargeAttack.SetActive(true);
                Invoke(nameof(ChargeDelayMethod), 1.5f);
                Debug.Log("「ズッバーン！！」");
                if (_chargeAttack.activeSelf == false)
                {
                    CancelInvoke();
                }
                _meleeChargeTime = 0;
            }
        }

        if (Kill >= _killCount)
        {
            if (Input.GetButtonDown("E"))
            {
                GameObject skill = Instantiate(_skill);
                skill.transform.position = _muzzle.position;
                Debug.Log("「お前はもう死んでいる」");
                Kill = 0;
            }
        }

        // 設定に応じて左右を反転させる
        if (_flipX)
        {
            FlipX(m_h);
        }

        if (_hp < 1)
        {

        }
    }

    void DelayMethod()
    {
        _attack.SetActive(false);
    }
    void ChargeDelayMethod()
    {
        _chargeAttack.SetActive(false);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground に触れているとき
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
            Debug.Log("地面にこんにちは");
        }

        if (IsMuteki)
        {
            return;
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            _hp--;
            Debug.Log("いてっ");
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (collision.gameObject.tag == "Wall")
            {
                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            m_initialPosition = collision.gameObject.transform.position;
        }
    }
    void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * _speed, ForceMode2D.Force);
    }

    // Player の向きに関するメソッド
    void FlipX(float horizontal)
    {
        _scaleX = this.transform.localScale.x;


        // Player が右を向いているとき
        if (horizontal > 0)
        {
            isReturn = false;
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        // Player が左を向いているとき
        else if (horizontal < 0)
        {
            isReturn = true;
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    
}
