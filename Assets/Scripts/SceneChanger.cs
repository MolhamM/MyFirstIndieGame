using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneEditor(string name)
    {
        if(name == "Quit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(name);
        }
    }
    public static void ChangeScene(string name)
    {
        if(name == "Quit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(name);
        }
    }
}