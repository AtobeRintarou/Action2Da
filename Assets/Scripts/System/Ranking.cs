using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{

    [Header("���l")] float point;

    string[] ranking = { "�����L���O1��", "�����L���O2��", "�����L���O3��", "�����L���O4��", "�����L���O5��" };
    float[] rankingValue = new float[5];

    [SerializeField, Header("�\��������e�L�X�g")]
    Text[] rankingText = new Text[5];

    string _line;

    void Start()
    {
        _line = TimeController.ResultTime.ToString("F1");
        point = float.Parse(_line);

        GetRanking();
        SetRanking(point);

        for (int i = 0; i < rankingText.Length; i++)
        {
            int num = i + 1;
            rankingText[i].text = num + "�ʁF" +  rankingValue[i].ToString() + "�b";
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
            rankingValue[i] = PlayerPrefs.GetFloat(ranking[i]);
        }
    }
    /// <summary>
    /// �����L���O��������
    /// </summary>
    void SetRanking(float _value)
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
            PlayerPrefs.SetFloat(ranking[i], rankingValue[i]);
        }
    }
}
