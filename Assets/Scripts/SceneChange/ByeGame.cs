using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ByeGame : MonoBehaviour
{
    public void ExitGame(string ExitGame)
    {
        Application.Quit();
        Debug.Log("game has been exited.");
    }
}
