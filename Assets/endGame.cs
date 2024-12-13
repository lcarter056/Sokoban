using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public GameObject box;
    public GameObject box2;
    public GameObject box3;

    public bool winFirst = false;
    // Start is called before the first frame update
   void Update() {
    if(Vector3.Distance(transform.position, box.transform.position) < .2f || Vector3.Distance(transform.position, box2.transform.position) < .2f
    || Vector3.Distance(transform.position, box3.transform.position) < .2f){
        winFirst = true;
        Debug.Log("collided with endgame1");
    }
    else {
        winFirst = false; 
    }
   }
}
