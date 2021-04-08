using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject calibrationMenu;
    
    public void PlayButtonListener()
    {
        Debug.Log ("Play");   
    }
}
