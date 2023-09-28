using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject LevelCam;
    public GameObject MainCamera;
    public PlayerMovement PlayerMovement;

    void Update()
    {
        PlayerMovement.jumpHeight = 0f;
    }
    public void OnTriggerEnter(Collider collider)
    {
        LevelCam.SetActive(false);
        MainCamera.SetActive(true);
    }
}
