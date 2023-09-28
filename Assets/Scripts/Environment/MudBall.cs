using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBall : MonoBehaviour
{
    public GameObject mudPuddle;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("bumped");
            Instantiate(mudPuddle, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
