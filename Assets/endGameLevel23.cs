using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGameLevel23 : MonoBehaviour
{
    public GameObject box;
    public GameObject box2; 

    public GameObject endGame;
    public GameObject winPanel;
    public bool winSnde;
    void Update(){
    if(Vector3.Distance(transform.position, box.transform.position) < .2f || Vector3.Distance(transform.position, box2.transform.position) < .2f){
        Debug.Log("collided with endgame2");
        winSnde = true;
    }
    else {
        winSnde = false; 
    }
   
    if(winSnde && endGame.GetComponent<endGameLevel2>().winFirst2 && winSnde){
      Debug.Log("YOU WIN");
      winPanel.SetActive(true);
    }

    }

    

}
