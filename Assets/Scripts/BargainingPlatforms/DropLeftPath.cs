using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLeftPath : MonoBehaviour
{
    public GameObject leftPath;
    public float fallSpeed = 100f;
    private Vector3 startingPos;
    public float threshold = -500f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            leftPath.SetActive(false);
        }
    }
}
