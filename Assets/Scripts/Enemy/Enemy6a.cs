using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6a : MonoBehaviour
{
    [SerializeField] float _speed = 3f;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            Vector2 v = player.transform.position - this.transform.position;
            v = v.normalized * _speed;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }
    }
}
