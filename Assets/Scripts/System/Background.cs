using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 背景を横スクロールするためのコンポーネント
[RequireComponent(typeof(SpriteRenderer))]
public class Background : MonoBehaviour
{
    // 背景のスクロール速度
    [SerializeField] float m_scrollSpeed = -1f;
    SpriteRenderer m_sprite = default;

    private void Start()
    {
        m_sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 背景画像をスクロールする
        m_sprite.transform.Translate(-1 * m_scrollSpeed * Time.deltaTime, 0f, 0f);

        // 背景画像がある程度左に動いたら、右に戻す
        if (m_sprite.transform.position.x < -1 * m_sprite.bounds.size.x)
        {
            m_sprite.transform.Translate(m_sprite.bounds.size.x * 2, 0f, 0f);
        }
    }
}