using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 一定間隔で壁を生成するコンポーネント
public class WallGenerator : MonoBehaviour
{
    // 壁として生成するプレハブ
    [SerializeField] GameObject[] m_wallPrefabs = null;
    // 壁を生成する間隔（秒）
    [SerializeField] float m_wallGenerateInterval = 2f;
    // 壁生成間隔を計るためのタイマー（秒）
    float m_timer = 0;

    void Start()
    {
        m_timer = m_wallGenerateInterval;
    }

    void Update()
    {
        m_timer += Time.deltaTime;
        if (SceneManager.GetActiveScene().name == "Stage1" || SceneManager.GetActiveScene().name == "Endress")
        {
            // タイマーの値が生成間隔を超えたら
            if (m_timer > m_wallGenerateInterval)
            {
                m_timer = 0f;   // タイマーをリセットする
                int index = Random.Range(0, m_wallPrefabs.Length);
                GameObject go = Instantiate(m_wallPrefabs[index]);
                go.transform.position = new Vector2(10f, 0f);
            }
        }
    }
}
