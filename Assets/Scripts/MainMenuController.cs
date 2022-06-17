using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject exitPanel;

    public void PlayGame()
    {
        Debug.Log("Dwi Wahyu Aji - 149251970101-242");
        SceneManager.LoadScene("Game");
    }

    public void OpenAuthor()
    {
        Debug.Log("Dwi Wahyu Aji - 149251970101-242");
    }

    public void OpenCredit()
    {
        Debug.Log("Dwi Wahyu Aji - 149251970101-242");
        SceneManager.LoadScene("Credit");
    }

    public void ExitGame()
    {
        exitPanel.SetActive(true);
    }

    public void ExitYes() 
    {
        Application.Quit();
    }

    public void ExitNo() 
    {
        exitPanel.SetActive(false);
    }

}
