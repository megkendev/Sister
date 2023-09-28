using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    private Animator npcAnimator;

    void Start()
    {
        npcAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, patrolPoints[0].position) < 2f)
            {
                transform.localScale = new Vector3(3f, 3f, 3f);
                patrolDestination = 1;
                transform.eulerAngles = new Vector3(0f, -90f, 0f);
            }
        }

        if (patrolDestination == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, patrolPoints[1].position) < 2f)
            {
                transform.localScale = new Vector3(3f, 3f, 3f);
                patrolDestination = 0;
                transform.eulerAngles = new Vector3(0f, 90f, 0f);
            }
        }
        npcAnimator.SetBool("Walk", true);
    }

}
