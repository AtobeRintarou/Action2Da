using UnityEngine;
using UnityEngine.UI;
public class TimeController : MonoBehaviour
{
    [SerializeField] Text _text = default;
    float _timer = default;

    void Update()
    {
        _timer += Time.deltaTime;
        _text.text = "�^�C��:" + _timer.ToString("f1");
    }
}