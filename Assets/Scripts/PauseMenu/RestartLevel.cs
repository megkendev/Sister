using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    public Button restartLevel;
    // Start is called before the first frame update
    void Start()
    {
        restartLevel.onClick.AddListener(restartTheLevel);
    }

    // Update is called once per frame
    void restartTheLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
