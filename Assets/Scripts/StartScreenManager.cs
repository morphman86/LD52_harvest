using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("ludum_harvest");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
