using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BargainingThreshold : MonoBehaviour
{
    public float threshold = -75f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < threshold)
        {
            Actions.diePoints();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
