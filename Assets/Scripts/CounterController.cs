using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    bool _good = false;
    bool _perfect = false;
    bool _out = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            if (_good == true)
            {
                Debug.Log("good");
                Destroy(this.gameObject);
            }
            else if (_perfect == true)
            {
                Debug.Log("perfect");
                Destroy(this.gameObject);
            }
            else if (_out == true)
            {
                Debug.Log("out");
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Out")
        {
            _good = false;
            _perfect = false;
            _out = true;
        }
        else if (collision.gameObject.tag == "Perfect")
        {
            _good = false;
            _perfect = true;
            _out = false;
        }
        else if (collision.gameObject.tag == "Good")
        {
            _good = true;
            _perfect = false;
            _out = false;
        }
    }
}
