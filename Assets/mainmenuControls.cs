using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuControls : MonoBehaviour
{
    // Start is called before the first frame update
public void GoMainMenu(){
    SceneManager.LoadScene("MainMenu");
}
}
