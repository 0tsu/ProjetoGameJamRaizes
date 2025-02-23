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

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        point = transform.position;
        playerScale = transform.localScale.x;

        // Find Elefantezinho_0 and get its Animator component
        Transform elefantezinho_0 = transform.Find("Elefantezinho/Elefantezinho_0");
        if (elefantezinho_0 != null)
        {
            animator = elefantezinho_0.GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Animator component is missing on Elefantezinho_0!");
            }
        }
        else
        {
            Debug.LogError("Elefantezinho_0 not found! Please check the name in the hierarchy.");
        }
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

        // Update the animator's Speed parameter based on movement
        UpdateMovementAnimation();
    }

    void UpdateMovementAnimation()
    {
        // Get the magnitude of the agent's velocity
        float speed = agent.velocity.magnitude;

        // Log the speed value for debugging purposes
        Debug.Log("Speed (magnitude): " + speed);         // Logs the magnitude (speed)

        // Update the Speed parameter in the Animator based on movement
        animator.SetFloat("Speed", speed);

        if (speed < 0.1f)
        {
            animator.SetFloat("Speed", 0);  // Set to 0 to ensure the transition to Idle happens
        }
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
