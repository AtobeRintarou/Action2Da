using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [Tooltip("�X�R�A��\������e�L�X�g")]
    [SerializeField] Text _scoreText;
    void Start()
    {
        _scoreText.text = "���_ :" + GameManager.Score.ToString("F0") + "�_";
    }
}
