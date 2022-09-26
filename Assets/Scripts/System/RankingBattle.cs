using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingBattle : MonoBehaviour
{
    [Header("���l")] int point;

    string[] ranking = { "�����L���O1��", "�����L���O2��", "�����L���O3��", "�����L���O4��", "�����L���O5��" };
    int[] rankingValue = new int[5];

    [SerializeField, Header("�\��������e�L�X�g")]
    Text[] rankingText = new Text[5];

    string _line;

    void Start()
    {
        _line = GameManager.Score.ToString("F0");
        point = int.Parse(_line);

        GetRanking();
        SetRanking(point);

        for (int i = 0; i < rankingText.Length; i++)
        {
            int num = i + 1;
            rankingText[i].text = num + "�ʁF" + rankingValue[i].ToString() + "�_";
        }
    }

    /// <summary>
    /// �����L���O�Ăяo��
    /// </summary>
    void GetRanking()
    {
        //�����L���O�Ăяo��
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// �����L���O��������
    /// </summary>
    void SetRanking(int _value)
    {
        //�������ݗp
        for (int i = 0; i < ranking.Length; i++)
        {
            //�擾�����l��Ranking�̒l���r���ē���ւ�
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }

        //����ւ����l��ۑ�
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
    }
}
