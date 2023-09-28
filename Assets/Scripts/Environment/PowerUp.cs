using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PlayerMovement PlayerMovement;

    float powerUpCooldown = 5f;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("bumped");
            StartCoroutine(PoweredUp());
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }

    IEnumerator PoweredUp()
    {
        PlayerMovement.speed = PlayerMovement.speed * 2;
        PlayerMovement.runSpeed = PlayerMovement.runSpeed * 2;
        PlayerMovement.jumpHeight = PlayerMovement.jumpHeight * 2;
        yield return new WaitForSeconds(powerUpCooldown);
        PlayerMovement.speed = 10f;
        PlayerMovement.runSpeed = 15f;
        PlayerMovement.jumpHeight = 6f;
        print("regular'd up");
        gameObject.SetActive(false);
    }
}
