using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [Header("�\������Panel")]
    [SerializeField] public GameObject _panel;
    [Header("�\�����鎞��")]
    [SerializeField] float _time = 3.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _panel.SetActive(true);
            Invoke(nameof(Method), _time);
            Debug.Log("�u�Y�b�o�[���I�I�v");
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
