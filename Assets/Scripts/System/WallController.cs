using UnityEngine;

// 壁を制御するコンポーネント
// 壁を一定速度で左に動かし、ある程度左に行ったら破棄する。
public class WallController : MonoBehaviour
{
    // 左に動く速さ
    [SerializeField] float m_moveSpeed = 1f;

    void Update()
    {
        // ある程度左に行ったら
        if (this.transform.position.x < -15f)
        {
            // 自分自身を破棄する
            Destroy(this.gameObject);
        }

        // 一定速度で左に動かす
        this.transform.Translate(Vector2.left * m_moveSpeed * Time.deltaTime);
    }
}
