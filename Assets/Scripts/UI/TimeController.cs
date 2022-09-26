using UnityEngine;
using UnityEngine.UI;
public class TimeController : MonoBehaviour
{
    [SerializeField] Text _text = default;
    bool isMove = true;

    public static float ResultTime { get; set; }
    void Start()
    {
        ResultTime = 0;
        isMove = true;
    }
    void Update()
    {
        if (isMove)
        {
            ResultTime += Time.deltaTime;
            _text.text = "ŽžŠÔ:" + ResultTime.ToString("f1") + "•b";
        }
    }

    public void TimeStop()
    {
        isMove = false;
    }
}