using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementLevel1 : MonoBehaviour {
    private PlayerInputActions inputActions;
    public GameObject boxConnect; 
    public Transform targetPosition;
    private bool hasMovedRecently = false; 
    private float movementCooldown = 0.2f; 
    public bool shouldMoveBox = false; 
    private float movementTimer = 0f; 
    public float distanceTrial = 0.15f;
    public LayerMask UnwalkableLayer;
    public GameObject box;
    public Vector3 newBoxPosition;

    public void Start() {
       // targetPosition.position = transform.position;
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
    }
    public void Update() {
          movementTimer -= Time.deltaTime;
            Vector2 moveDir = inputActions.Player.Movement.ReadValue<Vector2>();
        
            if (!hasMovedRecently && moveDir != Vector2.zero) {
                
                targetPosition.position = transform.position;
                Vector3 newTargetPosition = targetPosition.position + new Vector3(moveDir.x, moveDir.y, 0f) *.32f;

                // Check if walkable 
                if (!Physics2D.OverlapCircle(newTargetPosition, .1f, UnwalkableLayer)) {
                    //Move player
                    targetPosition.position = newTargetPosition;
                    //Check for box collision and move box
                    GameObject box1 = GameObject.FindGameObjectWithTag("Box");
                    Collider2D playerCollider = targetPosition.GetComponent<Collider2D>();
                    Collider2D boxCollider1 = box1.GetComponent<Collider2D>();
              
                    if (boxCollider1.IsTouching(playerCollider)) {
                            box = box1;
                        }
                    if(box){
                    newBoxPosition = box.transform.position + new Vector3(moveDir.x, moveDir.y, 0f) *.32f;
                    if (!Physics2D.OverlapCircle(newBoxPosition, 0.1f, UnwalkableLayer)) {
                            float distY = GameObject.FindGameObjectWithTag("Player").transform.position.y - box.transform.position.y;
                            float distX = GameObject.FindGameObjectWithTag("Player").transform.position.x - box.transform.position.x;
                            if (moveDir.x > 0f && playerCollider.transform.position.x < box.transform.position.x && distY < .1f && distY > -0.1f){
                                if (distX >= -.2f){
                                shouldMoveBox = true;
                               }
                            }
                            else if (moveDir.x < 0f && playerCollider.transform.position.x > box.transform.position.x
                            && distY <.1f && distY > -0.1f){
                            if (distX <= .2f){
                                shouldMoveBox = true;
                               }
                            }
                            else if (moveDir.y < 0f && playerCollider.transform.position.y > box.transform.position.y && distX <.1f && distX > -0.1f){
                             if (distY <= .2f){
                                shouldMoveBox = true;
                               }
                            }
                            else if (moveDir.y > 0f && playerCollider.transform.position.y < box.transform.position.y && distX <.1f && distX > -0.1f){
                            if (distY >= -.2f){
                                shouldMoveBox = true;
                            }
                            }
                            else {
                            shouldMoveBox = false;
                            }
                        }
                       
                    if (shouldMoveBox){
                        if (!Physics2D.OverlapCircle(newBoxPosition, 0.1f, UnwalkableLayer)){
                       box.transform.position = newBoxPosition;
                        }
                    }
                
              }
            
            // Move player towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, 0f);
                hasMovedRecently = true;
                movementTimer = movementCooldown;
        }
        }

        // Reset movement timer bool
        if (hasMovedRecently && movementTimer <= 0) {
            hasMovedRecently = false;
        }
    }
}
