using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAcceptance : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene("Acceptance", LoadSceneMode.Single);
    }
}
