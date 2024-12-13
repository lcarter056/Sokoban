using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public GameObject player;
    public GameObject box1;
    public GameObject box2;
    public GameObject boat; 
    public Vector3 playerClone;
    public Vector3 box1Clone;
    public Vector3 box2Clone;
    public Vector3 boatClone; 
    public GameObject boxConnect;


   void Start(){
    playerClone = player.transform.position;
    box1Clone = box1.transform.position;
    box2Clone = box2.transform.position;
    boatClone = boat.transform.position;
   }
   public void RestartLevel(){
    SceneManager.LoadScene("LevelTwo");
    /*
    player.transform.position = playerClone;
    box1.transform.position = box1Clone;
    box2.transform.position = box2Clone;
    boat.transform.position = boatClone; 

    player.GetComponent<PlayerMovement>().shouldMoveBox = false;
    //boxConnect.GetComponent<boxConnect>().insideBoatFromBox = false;
   // player.GetComponent<PlayerMovement>().exitedBoat = false;
*/
   }

   public void playNextLevel(){
     SceneManager.LoadScene("LevelThree");
   }
}
