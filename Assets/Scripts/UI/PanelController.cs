using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [Header("表示するPanel")]
    [SerializeField] public GameObject _panel;
    [Header("表示する時間")]
    [SerializeField] float _time = 3.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _panel.SetActive(true);
            Invoke(nameof(Method), _time);
            Debug.Log("「ズッバーン！！」");
            if (_panel.activeSelf == false)
            {
                CancelInvoke();
            }
        }
    }

    void Method()
    {
        _panel.SetActive(false);
    }
}
