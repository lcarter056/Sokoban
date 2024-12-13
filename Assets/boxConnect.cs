using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxConnect : MonoBehaviour
{
    public bool insideBoatFromBox = false;
    public bool onTile = false; 
    public GameObject thePanel;
    public bool boxtOneDone = false;
    public Vector3 endGame1 = new Vector3(13,12,0);

    void Update(){
       
       if (onTile == true && !insideBoatFromBox){
            Debug.Log("Entering boat");
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-4.1f, 0.55f, 0f);
            GameObject.FindGameObjectWithTag("Box").transform.position = new Vector3(-4.2f, 0.55f, 0f); 
            GameObject.FindGameObjectWithTag("Boat").GetComponent<BoxCollider2D>().isTrigger = false;
            transform.GetComponent<BoxCollider2D>().isTrigger = true;
            insideBoatFromBox = true;
            onTile = false;
         } 
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Box")){
            Debug.Log("ENTER BOAT COLLISION");
            onTile = true;
            insideBoatFromBox = true;
            }
    }
    
   
   
        public void LoadNewLevel(){
            SceneManager.LoadScene("Level 2 or 3");
        }
    }


        