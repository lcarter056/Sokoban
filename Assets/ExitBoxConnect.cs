using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBoxConnect : MonoBehaviour
{
     
     public GameObject boxConnect;
     public bool jumpOutBoat = false; 
     public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Boat") || other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Player")){

                jumpOutBoat = true;
              
                boxConnect.GetComponent<boxConnect>().insideBoatFromBox = false;
            
            }
        }
  
}
