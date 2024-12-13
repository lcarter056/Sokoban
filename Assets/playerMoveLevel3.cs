
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMoveLevel3 : MonoBehaviour {
    private PlayerInputActions inputActions;
    public GameObject boxConnect; 
    public bool insideBoat;
    public Transform targetPosition;
    private bool hasMovedRecently = false; 
    private bool boatMovedRecently = false;
    private float movementCooldown = 0.2f; 
    public bool shouldMoveBox = false; 
    private float movementTimer = 0f; 
    public float distanceTrial = 0.15f;
    public bool exitedBoat = false; 
    public LayerMask UnwalkableLayer;
    public Vector3 targetPositionBoat;
    public GameObject exitBox;
    public GameObject box;

    public Vector3 newBoxPosition;
    public void Start() {
       // targetPosition.position = transform.position;
        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();

    }
    public void Update() {
         insideBoat = boxConnect.GetComponent<boxConnect>().insideBoatFromBox;
         movementTimer -= Time.deltaTime;
         if (insideBoat && !exitBox.GetComponent<ExitBoxConnect>().jumpOutBoat) {
                MoveBoat();
         }
        else {
            if(exitBox.GetComponent<ExitBoxConnect>().jumpOutBoat && insideBoat && !exitedBoat){
                transform.position =  new Vector3(3.854f,-1.68f,0);
                box.transform.position = new Vector3(3.546f,-1.68f,0);
                insideBoat = false;
                exitedBoat = true;
                Debug.Log("reseting location"); 
            }

            Vector2 moveDir = inputActions.Player.Movement.ReadValue<Vector2>();

            if (!hasMovedRecently && moveDir != Vector2.zero) {
                
                targetPosition.position = transform.position;
                Vector3 newTargetPosition = targetPosition.position + new Vector3(moveDir.x, moveDir.y, 0f)*.32f;

                // Check if walkable 
                if (!Physics2D.OverlapCircle(newTargetPosition, .1f, UnwalkableLayer)) {
                    //Move player
                    targetPosition.position = newTargetPosition;
                    //Check for box collision and move box
                    GameObject box1 = GameObject.FindGameObjectWithTag("Box");
                    GameObject box2 = GameObject.FindGameObjectWithTag("Box2");
                    GameObject box3 = GameObject.FindGameObjectWithTag("Box2");
                    Collider2D playerCollider = targetPosition.GetComponent<Collider2D>();
                    Collider2D boxCollider1 = box1.GetComponent<Collider2D>();
                    Collider2D boxCollider2 = box2.GetComponent<Collider2D>();
                    Collider2D boxCollider3 = box3.GetComponent<Collider2D>();
                    if (boxCollider1.IsTouching(playerCollider)) {
                        Debug.Log("coolide1");
                            box = box1;
                        }
                    else if (boxCollider2.IsTouching(playerCollider)){
                            box = box2;
                               Debug.Log("coolide2");
                        }
                    else if (boxCollider3.IsTouching(playerCollider)){
                        Debug.Log("collide3");
                            box = box3;
                        }
                    if(box){
                    newBoxPosition = box.transform.position + new Vector3(moveDir.x, moveDir.y, 0f)*.32f;
                    if (!Physics2D.OverlapCircle(newBoxPosition, 0.1f, UnwalkableLayer)) {
                            float distY = GameObject.FindGameObjectWithTag("Player").transform.position.y - box.transform.position.y;
                            float distX = GameObject.FindGameObjectWithTag("Player").transform.position.x - box.transform.position.x;
                            if (moveDir.x > 0f && playerCollider.transform.position.x < box.transform.position.x && distY < .1f && distY > -0.1f){
                                Debug.Log((distX, distY));
                             if (distX >= -.2f){
                                shouldMoveBox = true;
                               }
                            }
                            else if (moveDir.x < 0f && playerCollider.transform.position.x > box.transform.position.x && distY <.1f && distY > -0.1f){
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
        if (boatMovedRecently && movementTimer <= 0) {
            boatMovedRecently = false;
        }
    }

    public void MoveBoat() {
        Vector2 moveDir = inputActions.Player.Movement.ReadValue<Vector2>();
        GameObject boat = GameObject.FindGameObjectWithTag("Boat");

        if (boat != null) {
            targetPositionBoat = boat.transform.position + new Vector3(moveDir.x / 30.1f, moveDir.y / 30.1f, 0f);

            if (!boatMovedRecently && moveDir != Vector2.zero) {
                if (!Physics2D.OverlapCircle(targetPositionBoat, .295f, LayerMask.GetMask("UnwalkableBoat"))) {
                    boat.transform.position = targetPositionBoat;
                    boatMovedRecently = true;
                }
            }

            //Keep the player on top of the boat player transform
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(boat.transform.position.x + distanceTrial, boat.transform.position.y - 0.15f, boat.transform.position.z);
            box.transform.position = new Vector3(boat.transform.position.x -.15f, boat.transform.position.y - 0.15f, boat.transform.position.z);
        }
    }
}
