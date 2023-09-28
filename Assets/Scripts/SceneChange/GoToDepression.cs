using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToDepression : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene("Depression", LoadSceneMode.Single);
    }
}
