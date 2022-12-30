using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Actions : MonoBehaviour
{
       public void StartGame(){
           
           SceneManager.LoadScene(1); //refereed to game in build and setting

    }
    public void ExistGame(){
           
           Application.Quit();

    }
    public void RetryGame(){
           
           SceneManager.LoadScene(1); //refereed to game in build and setting

    }
}
