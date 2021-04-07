using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager2 : MonoBehaviour
{
   public void PlayGame ()
   {
  
      Debug.Log("Play");
      SceneManager.LoadScene(1);
      //UnityEngine.SceneManagement.SceneManager.LoadScene("FunChimie", LoadSceneMode.Single);

   }

   public void QuitGame ()
   {
   	Debug.Log("QUIT!");
   	Application.Quit();
   }   
}
