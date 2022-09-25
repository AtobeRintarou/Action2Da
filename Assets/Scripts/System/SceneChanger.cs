using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void  MainTown()
    {
        SceneManager.LoadScene("MainTown");
    }
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
    public void Result()
    {
        SceneManager.LoadScene("Result");
    }
    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Infinity()
    {
        SceneManager.LoadScene("Infinity");
    }
    public void InfinitRun()
    {
        SceneManager.LoadScene("InfinitRun");
    }
    public void InfinitBattle()
    {
        SceneManager.LoadScene("InfinitBattle");
    }
}
