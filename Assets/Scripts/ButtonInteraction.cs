using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] GameObject MenuCanvas;
    [SerializeField] GameObject InstructionsCanvas;
    public void OnPlayPress()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSettingPress()
    {
        MenuCanvas.SetActive(false);
        InstructionsCanvas.SetActive(true);
    }

    public void OnQuitPress()
    {
        Application.Quit();
    }

    public void ReturnPress()
    {
        MenuCanvas.SetActive(true);
        InstructionsCanvas.SetActive(false);
    }
}
