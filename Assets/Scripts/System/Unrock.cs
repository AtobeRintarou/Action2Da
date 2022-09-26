using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unrock : MonoBehaviour
{
    [SerializeField] GameObject _object;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(_object);
        }
    }
}
