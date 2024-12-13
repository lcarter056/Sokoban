using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart3 : MonoBehaviour
{
    public GameObject player;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    public GameObject boat; 
    public Vector3 playerClone;
    public Vector3 box1Clone;
    public Vector3 box2Clone;
    public Vector3 box3Clone; 
    public Vector3 boatClone; 

   void Start(){
    playerClone = player.transform.position;
    box1Clone = box1.transform.position;
    box2Clone = box2.transform.position;
    box3Clone = box3.transform.position;
    boatClone = boat.transform.position;
   }
   public void RestartLevel(){
    SceneManager.LoadScene("LevelThree");
    /*
    player.transform.position = playerClone;
    box1.transform.position = box1Clone;
    box2.transform.position = box2Clone;
    box3.transform.position = box3Clone;
    boat.transform.position = boatClone; 


    player.GetComponent<PlayerMovement>().shouldMoveBox = false;
    */
   }

   public void playNextLevel(){
     SceneManager.LoadScene("WinGame");
   }
}
