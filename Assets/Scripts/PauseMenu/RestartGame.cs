using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public Button restartGame;

    // Start is called before the first frame update
    void Start()
    {
        restartGame.onClick.AddListener(restartTheGame);
    }

    // Update is called once per frame
    public void restartTheGame()
    {
        Actions.clearPoints();
        SceneManager.LoadScene("DenialTutorial", LoadSceneMode.Single);
    }
}
