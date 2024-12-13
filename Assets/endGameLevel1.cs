using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameLevel1 : MonoBehaviour
{
   public GameObject box;
   public GameObject winPanel;
   void Update() {
    if(Vector3.Distance(transform.position, box.transform.position) < .2f){
     winPanel.SetActive(true);
   }
}
}
