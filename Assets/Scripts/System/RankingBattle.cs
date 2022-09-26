using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingBattle : MonoBehaviour
{
    [Header("数値")] int point;

    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    int[] rankingValue = new int[5];

    [SerializeField, Header("表示させるテキスト")]
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
            rankingText[i].text = num + "位：" + rankingValue[i].ToString() + "点";
        }
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
    }
}
