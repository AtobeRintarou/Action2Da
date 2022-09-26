using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]Text _text = default;
    int _score = default;
    void Start()
    {
        _text.text = "���_:" + 0 + "�_";
    }

    void Update()
    {
        _score = GameManager.Score;

        _text.text = "���_:" + _score + "�_";
    }
}
