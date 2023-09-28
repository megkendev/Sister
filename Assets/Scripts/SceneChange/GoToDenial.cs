using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToDenial : MonoBehaviour
{
    public Button restartGame;
    // Start is called before the first frame update
    void Start()
    {
        restartGame.onClick.AddListener(restartTheGame);
    }

    // Update is called once per frame
    void restartTheGame()
    {
        SceneManager.LoadScene("DenialTutorial", LoadSceneMode.Single);
    }
}
