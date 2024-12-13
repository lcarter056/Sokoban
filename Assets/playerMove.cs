

/*
using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour {
    private PlayerInputActions inputActions; 
    private Vector2 movementInput;
    public bool insideBoat = false;
    public Vector3 islandPlayerPosition;
    public Vector3 islandBoatPosition;

    public Transform targetPosition;

    private bool hasMovedRecently = false; // Track if the player has moved recently
    private float movementCooldown = 0.2f; // Time before the player can move again
    private float movementTimer = 0f; // Timer for cooldown

    private void Awake() {
        targetPosition.position = transform.position;
        inputActions = new PlayerInputActions();
        Debug.Log(inputActions);
        inputActions.Player.Enable();
    }

    private void Update() {
        // Update the cooldown timer
        movementTimer -= Time.deltaTime;

        if (insideBoat) {
            Debug.Log("Inside Boat");
            //MoveBoat();
        } else {
            Vector2 moveDir = inputActions.Player.Movement.ReadValue<Vector2>();
            Debug.Log(moveDir.x);

            if (!hasMovedRecently && moveDir != Vector2.zero) {
                Vector3 newTargetPosition = targetPosition.position + new Vector3(moveDir.x/3.1f, moveDir.y/3.1f, 0f);

                // Check if the target position is valid
                if (!Physics2D.OverlapCircle(newTargetPosition, .1f, LayerMask.GetMask("Unwalkable"))) {
                    // Move the player
                    targetPosition.position = newTargetPosition;
                   
                    // Handle pushing boxes but needs to be oncollision enter2d 
                   // PushBox(newTargetPosition, moveDir);

                    // Set movement state and reset timer
                    hasMovedRecently = true;
                    movementTimer = movementCooldown;
                }
            }
            // Move the player towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, 0f);
        }

        // Reset movement state if cooldown has elapsed
        if (hasMovedRecently && movementTimer <= 0) {
            hasMovedRecently = false;
        }
    }
/*
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Box")) {
            Debug.Log("player colliding with box ");

            // but u need to move one unit over and check if that is possible, if not possible dont move 
            other.gameObject.transform.position = targetPosition.position + new Vector3(movementInput.x, movementInput.y, 0f);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Boat")) {
            Debug.Log("player collided with boat");
            if (Input.GetKey(KeyCode.Space)) {
                if (!insideBoat) {
                    Debug.Log("Entered Boat");
                    insideBoat = true;
                   // GameObject.FindGameObjectWithTag("Player").transform.position += new Vector3(0f, 0f, 0f);
                   // transform.position = new Vector3(0f, 0f, 0f); //Adjust position if necessary is this the boat or player

                } else {
                    insideBoat = false;
                    transform.position = islandPlayerPosition; //Move to the island position
                }
            }
        }
        if (other.gameObject.CompareTag("Box")){
                Debug.Log("begin pushing box");
                Vector3 moveDir = inputActions.Player.Movement.ReadValue<Vector2>();
                GameObject box = other.gameObject;

                 // Calculate potential new position for the box
                Vector2 newBoxPosition = box.transform.position + new Vector3(moveDir.x/3.1f, moveDir.y/3.1f, 0f);

                // Check if the new position is valid (e.g., not colliding with other objects)
                if (!Physics2D.OverlapCircle(newBoxPosition, 0.1f, LayerMask.GetMask("Unwalkable"))) {
                    box.transform.position = newBoxPosition;
                    Debug.Log("moved to new position");
                } else {
                    Debug.Log("Box cannot move there");
                }
            
            }
    }

}

*/