using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame3 : MonoBehaviour
{
    public GameObject box;
    public GameObject box2; 
    public GameObject box3; 
    public bool winTrd;
    void Update(){
    if(Vector3.Distance(transform.position, box.transform.position) < .2f || Vector3.Distance(transform.position, box2.transform.position) < .2f
    || Vector3.Distance(transform.position, box3.transform.position) < .2f){
        Debug.Log("collided with endgame2");
        winTrd = true;
    }
    else {
        winTrd = false; 
    }
   
   
    }

    

}
