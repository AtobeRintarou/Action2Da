using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [Tooltip("スコアを表示するテキスト")]
    [SerializeField] Text _scoreText;
    void Start()
    {
        _scoreText.text = "得点 :" + GameManager.Score.ToString("F0") + "点";
    }
}
