using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 取得したら回復するアイテム
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class Recovery : ItemBase
{
    [Header("アイテムを取ったら回復するHP量")]
    [SerializeField] int _recoveryHp = 1;

    PlayerController _player;
    SpriteRenderer _sprite;

    public override void Activate()
    {
        Debug.Log("Active");
        var playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj)
        {
            _player = playerObj.GetComponent<PlayerController>();
            if (_player)
            {
                Debug.Log("回復した");

                if (_player.HP == _player.HpMax)
                {
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    _player.HP += _recoveryHp;

                    if (_player.HP > _player.HpMax)
                    {
                        _player.HP = _player.HpMax;
                    }
                }
                Destroy(gameObject);
            }
        }
    }
}
