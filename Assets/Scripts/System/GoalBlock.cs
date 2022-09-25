using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class GoalBlock : ItemBase
{
    SpriteRenderer _sprite;
    [SerializeField] string _SceneName;
    public override void Activate()
    {
        Debug.Log("Active");
        var playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj)
        {
            SceneManager.LoadScene(_SceneName);
        }
    }
}
