using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartLevel1 : MonoBehaviour
{
    public GameObject player;
    public GameObject box1;
    public Vector3 playerClone;
    public Vector3 box1Clone;

   void Start(){
    playerClone = player.transform.position;
    box1Clone = box1.transform.position;
   }
   public void RestartLevel(){
    player.transform.position = playerClone;
    box1.transform.position = box1Clone;
    player.GetComponent<PlayerMovementLevel1>().shouldMoveBox = false;
   }

   public void playNextLevel(){
     SceneManager.LoadScene("LevelTwo");
   }
}
