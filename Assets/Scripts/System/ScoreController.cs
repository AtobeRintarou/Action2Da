using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]Text _text = default;
    int _score = default;
    private GameManager _gm;
    void Start()
    {
        _gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _text.text = "“¾“_:" + 0;
    }

    void Update()
    {
        _score = _gm.Score;

        _text.text = "“¾“_:" + _score;
    }
}
