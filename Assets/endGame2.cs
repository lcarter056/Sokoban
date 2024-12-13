using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame2 : MonoBehaviour
{
    public GameObject box;
    public GameObject box2; 
    public GameObject box3; 

    public GameObject endGame;
     public GameObject endGame3;
    public bool winSnd;
    public GameObject winPanel;
    void Update(){
    if(Vector3.Distance(transform.position, box.transform.position) < .2f || Vector3.Distance(transform.position, box2.transform.position) < .2f
    || Vector3.Distance(transform.position, box3.transform.position) < .2f){
        Debug.Log("collided with endgame2");
        winSnd = true;
    }
    else {
        winSnd = false; 
    }
   
    if(winSnd && endGame.GetComponent<endGame>().winFirst && endGame3.GetComponent<endGame3>().winTrd){
     SceneManager.LoadScene("WinGame");
    }

    }

    

}
