using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAnger : MonoBehaviour
{
public void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene("AngerLevelOne", LoadSceneMode.Single);
    }
}
