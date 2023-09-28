using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInputActions playerControls;
    private InputAction move;
    private InputAction look;
    private InputAction fire;
    private InputAction fire2;
    private InputAction fire3;
    private InputAction fire4;
    private InputAction jump;
    private InputAction defend;
    private InputAction menu;
    private Vector3 moveDirection;

    private Vector2 movement;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float gravity = -20f;
    public float speed = 10f;
    public float runSpeed = 15f;
    private bool isGrounded;
    private bool isDefending;
    public float jumpHeight = 6f;
    private Animator animator;
    private PlayerLook looking;

    public int swordStrength = 1;
    public int maxHP = 10;
    public int currentHP;
    public Image hpBar;
    public GameObject MainMenu;
    public AudioSource destroy;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        looking = GetComponent<PlayerLook>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        currentHP = maxHP;
        isDefending = false;
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        look = playerControls.Player.Look;
        look.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();

        fire2 = playerControls.Player.Fire2;
        fire2.Enable();

        fire3 = playerControls.Player.Fire3;
        fire3.Enable();

        fire4 = playerControls.Player.Fire4;
        fire4.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();

        defend = playerControls.Player.Defend;
        defend.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        fire.Disable();
        fire2.Disable();
        fire3.Disable();
        fire4.Disable();
        jump.Disable();
        defend.Disable();
    }

    // Update is called once per frame
    private void Update()
    {
        hpBar.fillAmount = currentHP / 10f;

        if (currentHP <= 0)
        {
            Actions.diePoints();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        isGrounded = controller.isGrounded;

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (MainMenu.activeInHierarchy)
            {
                MainMenu.SetActive(false);
            }

            else if (!MainMenu.activeInHierarchy)
            {
                MainMenu.SetActive(true);
            }
        }

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        if (!MainMenu.activeInHierarchy && !DialogueManager.Instance.dialogueIsPlaying)
        {
            if (!defend.IsPressed())
            {
                animator.SetBool("isDefending", false);
                isDefending = false;

                if (move.IsPressed())
                {
                    animator.SetBool("isWalk", true);
                }

                if (move.IsPressed() && Input.GetKey(KeyCode.LeftShift))
                {
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isRun", true);
                }

                if (!move.IsPressed())
                {
                    animator.SetBool("isWalk", false);
                    animator.SetBool("isRun", false);
                }

                if (jump.IsPressed())
                {
                    animator.SetBool("isWalk", false); // not working if removed
                    animator.SetBool("isRun", false); // not working if removed
                    animator.SetBool("isJump", true);
                    Jump();
                }

                if (!jump.IsPressed())
                {
                    animator.SetBool("isJump", false);
                }

                if (fire.IsPressed())
                {
                    animator.SetTrigger("fire");
                    destroy.Play();
                }

                if (fire2.IsPressed())
                {
                    animator.SetTrigger("fire2");
                }

                if (fire3.IsPressed())
                {
                    animator.SetTrigger("fire3");
                }

                if (fire4.IsPressed())
                {
                    animator.SetTrigger("fire4");
                }
            }

            if (defend.IsPressed())
            {
                animator.SetBool("isDefending", true);
                isDefending = true;
            }
        }
    }

    private void LateUpdate()
    {
        looking.ProcessLook(look.ReadValue<Vector2>());
    }

    void FixedUpdate()
    {
        if (!MainMenu.activeInHierarchy && !DialogueManager.Instance.dialogueIsPlaying && !defend.IsPressed())
        {
            movement = move.ReadValue<Vector2>();
            moveDirection = Vector3.zero;
            moveDirection.x = movement.x;
            moveDirection.z = movement.y;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(transform.TransformDirection(moveDirection) * runSpeed * Time.deltaTime);
            }

            else
            {
                controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            }

            playerVelocity.y += gravity * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            print("jumping");
        }
    }

    void OnTriggerStay(Collider collider) // attacking script
    {
        GameObject objectCollided = collider.gameObject;  // Get a reference to the object hit
        Damageable damageableComponent = objectCollided.GetComponent<Damageable>();

        if (damageableComponent && fire.IsPressed()) // If the object is damageable
        {
            damageableComponent.doDamage(swordStrength); // Here you damage the object, without knowing which type it is
        }

        if (damageableComponent && fire2.IsPressed())
        {
            damageableComponent.doDamage(swordStrength * 2);
        }

        if (damageableComponent && fire3.IsPressed())
        {
            damageableComponent.doDamage(swordStrength * 3);
        }

        if (damageableComponent && fire4.IsPressed())
        {
            damageableComponent.doDamage(swordStrength * 4);
        }

        if (collider.gameObject.tag == "Mud")
        {
            speed = 5f;
            runSpeed = 7.5f;
            jumpHeight = 3f;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        speed = 10f;
        runSpeed = 15f;
        jumpHeight = 6f;
    }

    public void takeDamage(int damage)
    {
        if (isDefending == false)
        {
            currentHP -= damage;
            animator.SetTrigger("hit");
        }

        if (isDefending == true)
        {
            animator.SetTrigger("defendHit");
        }

        if (currentHP <= 0)
        {
            animator.SetTrigger("dead");
        }
    }
}
