using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoviment : MonoBehaviour
{
    private Vector3 point;
    private NavMeshAgent agent;
    private float playerScale;
    private Animator animator; // Add Animator reference
    private GameObject sala;

    private float previousXPosition; // Store the previous x position
    private Camera mainCamera; // Reference to the camera

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        point = transform.position;
        playerScale = transform.localScale.x;
    }

    void Update()
    {
        // Detect right mouse button click and update the target point
        if (Input.GetMouseButtonDown(1))
        {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 0; // Ensure z is 0 for 2D movement
            SetFlip();  
        }

        // Move the player to the target point
        if (!transform.position.Equals(point))
        {
            agent.SetDestination(new Vector3(point.x, transform.position.y, point.z));
        }
            animator.SetBool("Walk", agent.velocity.magnitude > 0f);

    }

    void SetFlip()
    {
        // Flip the player sprite based on movement direction
        if (point.x < transform.position.x)
            transform.localScale = new Vector3(-1 * playerScale, playerScale, playerScale);
        else if (point.x > transform.position.x)
            transform.localScale = new Vector3(playerScale, playerScale, playerScale);
    }

}
