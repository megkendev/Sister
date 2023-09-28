using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePoints : MonoBehaviour
{
    public AudioSource collected;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("bumped");
            Actions.updatePoints();
            gameObject.SetActive(false);
            collected.Play();
        }
    }
}
