using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEndGame : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        Actions.clearPoints();
        SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
    }
}
