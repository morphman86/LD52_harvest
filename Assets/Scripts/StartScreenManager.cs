using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public void StartGame() {
        SoundHandler soundHandler = GameObject.Find("game").GetComponent<SoundHandler>();
        soundHandler.PlaySound("success");
        SceneManager.LoadScene("ludum_harvest");
    }

    public void HideInstructions() {
        GameObject instructions = GameObject.Find("Tutorial");
        instructions.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
