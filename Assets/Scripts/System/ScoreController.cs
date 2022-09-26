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
        _text.text = "得点:" + 0 + "点";
    }

    void Update()
    {
        _score = GameManager.Score;

        _text.text = "得点:" + _score + "点";
    }
}
