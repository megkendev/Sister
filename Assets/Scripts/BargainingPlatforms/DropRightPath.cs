using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRightPath : MonoBehaviour
{
    public GameObject rightPath;

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            rightPath.SetActive(false);
        }
    }
}
