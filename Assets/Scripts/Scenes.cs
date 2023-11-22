using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartLevel(int levelNumber)
    {
        SceneManager.LoadScene("Level0" + levelNumber.ToString());
    }
    public void Quit()
    {
        Application.Quit();
    }
}