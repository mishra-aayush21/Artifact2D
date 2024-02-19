using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas howToPlayCanvas;

     public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void HowToPlay()
    {
        howToPlayCanvas.enabled = true;
    }

    public void BackToMain()
    {
        howToPlayCanvas.enabled = false;
    }











}//class
