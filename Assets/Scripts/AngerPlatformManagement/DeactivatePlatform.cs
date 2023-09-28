using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePlatform : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        gameObject.SetActive(false);
    }
}
