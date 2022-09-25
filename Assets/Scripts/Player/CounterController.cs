using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [Header("カウンターのクールタイム")]
    [SerializeField] float _counterInterval = 3f;
    float _counterTimer;

    [SerializeField] bool isGenerateOnStart = true;

    bool _good = false;
    bool _perfect = false;
    bool _out = false;

    private PlayerController _player;
    private EnemyController _enemy;
    void Start()
    {
        if (isGenerateOnStart)
        {
            _counterTimer = _counterInterval;
        }
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
    }

    void Update()
    {
        _counterTimer += Time.deltaTime;
        if (_counterTimer > _counterInterval)
        {
            if (Input.GetMouseButtonDown(2))
            {
                if (_good == true)
                {
                    _enemy.Hp -= 2;
                    Debug.Log("good");
                    Destroy(this.gameObject);
                }
                else if (_perfect == true)
                {
                    _enemy.Hp -= 4;
                    Debug.Log("perfect");
                    Destroy(this.gameObject);
                }
                else if (_out == true)
                {
                    _player.HP--;
                    Debug.Log("out");
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Out")
        {
            _good = false;
            _perfect = false;
            _out = true;
        }
        else if (collision.gameObject.tag == "Perfect")
        {
            _good = false;
            _perfect = true;
            _out = false;
        }
        else if (collision.gameObject.tag == "Good")
        {
            _good = true;
            _perfect = false;
            _out = false;
        }
    }
}
