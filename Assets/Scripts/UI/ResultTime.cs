using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour
{
    [Tooltip("�������Ԃ�\������e�L�X�g")]
    [SerializeField] Text _timeText;
    void Start()
    {
        _timeText.text = "����:" + TimeController.ResultTime.ToString("F1") + "�b";
    }
}
