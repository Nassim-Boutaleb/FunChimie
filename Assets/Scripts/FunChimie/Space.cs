using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    private bool isTriggered =false;
    
    void OnTriggerEnter(Collider other) 
	{
		isTriggered = true;
        Debug.Log("HAHAHAHAHA");
	}

    public void OnTriggerExit(Collider other) {
        isTriggered = false;
    }

    public bool getTriggered() {
        return isTriggered;
    }
}
