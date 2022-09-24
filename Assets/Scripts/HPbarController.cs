using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarController : MonoBehaviour
{
    [SerializeField] float _maxHp = 5;
    [SerializeField] Image _image;
    float currentHp;
    [SerializeField] Slider slider;
    private PlayerController _player;
    //int Time = default;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        slider.value = 1;
        _maxHp = _player.HP;
        currentHp = _maxHp;
    }

    private void Update()
    {
        /*if (slider.value > currentHp / _maxHp)
        {
            _image.color = Color.red;
            Time = 0;
        }
        if (Time == 30)
        {
            _image.color = Color.green;
        }*/

        UpdateHp(_player.HP);


        slider.value = currentHp / _maxHp;
        /*if (Time % 200 == 0)
        {
            currentHp -= 1;
        }*/
        if (slider.value < 0.5f)
        {
            _image.color = Color.yellow;
        }

        if (slider.value < 0.25f)
        {
            _image.color = Color.red;
        }
        //pastHp = currentHp
        
    }

    public void UpdateHp(int hp)
    {
        currentHp = hp;
    }
}
