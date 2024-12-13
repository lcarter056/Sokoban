using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playNow : MonoBehaviour
{
   public GameObject rulesPanel;
    // Start is called before the first frame update
   public void StartGame(){
    SceneManager.LoadScene("LevelOne");
   }

   public void OpenRules(){
    rulesPanel.SetActive(true);
   }
   public void CloseRules(){
    rulesPanel.SetActive(false);
   }
}
