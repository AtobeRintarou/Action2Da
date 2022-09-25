using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  // DOTween を使うため

public class GaugeController : MonoBehaviour
{
    /// <summary>ゲージを変化させる秒数</summary>
    [SerializeField] float _changeValueInterval = 0.5f;
    Slider _slider = default;

    [SerializeField] float _maxHp = 5;
    [SerializeField] Image _image;
    float currentHp;
    private PlayerController _player;
    float _Heal;
    float value;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _slider.value = 1;
        _maxHp = _player.HP;
        currentHp = _maxHp;
    }

    private void Update()
    {
        UpdateHp(_player.HP);
        ChangeValue();
        //slider.value = currentHp / _maxHp;
        if (_slider.value <= 1f && _slider.value > 0.53f)
        {
            _image.color = Color.green;
        }
        else if (_slider.value <= 0.53f && _slider.value > 0.25f)
        {
            _image.color = Color.yellow;
        }
        else
        {
            _image.color = Color.red;
        }
    }
    /// <summary>
    /// ゲージを減らす
    /// </summary>
    /// <param name="value">増減させる量（割合）</param>
    public void Change(float value)
    {
        UpdateHp(_slider.value + value);
    }

    /// <summary>
    /// ゲージを満タンにする
    /// </summary>
    public void Heal()
    {
        UpdateHp(1f);
    }

    /// <summary>
    /// 指定された値までゲージを滑らかに変化させる
    /// </summary>
    /// <param name="hp"></param>
    public void UpdateHp(float hp)
    {
        currentHp = hp;
    }

    public void ChangeValue()
    {
        value = currentHp / _maxHp;
        // DOTween.To() を使って連続的に変化させる
        DOTween.To(() => _slider.value, // 連続的に変化させる対象の値
            x => _slider.value = x, // 変化させた値 x をどう処理するかを書く
            value, // x をどの値まで変化させるか指示する
            _changeValueInterval);   // 何秒かけて変化させるか指示する
    }
}
