using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button exitGame;
    // Start is called before the first frame update
    void Start()
    {
        exitGame.onClick.AddListener(exitLevel);
    }

    public void exitLevel()
    {
        Application.Quit();
    }
}
