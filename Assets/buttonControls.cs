using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonControls : MonoBehaviour {
   public GameObject rulesPanel;
   
   public void StartGame(){
    SceneManager.LoadScene("LevelOne");
   }

   public void openRules(){
      rulesPanel.SetActive(true);
   }

   public void closeRules(){
      rulesPanel.SetActive(false);
   }
}
