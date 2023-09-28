using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject visualCue;
    private bool playerInRange;
    public TextAsset inkJson;
    public PlayerInputActions playerControls;
    private InputAction interact;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        playerControls = new PlayerInputActions();
    }

    private void OnEnable() //Must be used for the new input system to work properly
    {
        interact = playerControls.Player.Interact;
        interact.Enable();
    }

    private void OnDisable() //Must be used for the new input system to work properly
    {
        interact.Disable();
    }

    private void Update()
    {
        if (playerInRange)
        {
            //print("in range");
        }
        
        if (playerInRange && !DialogueManager.Instance.dialogueIsPlaying)
        {
            visualCue.SetActive(true);

            if (interact.IsPressed())
            {
                DialogueManager.Instance.EnterDialogueMode(inkJson);
            }
        }

        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        playerInRange = false;
    }
}
