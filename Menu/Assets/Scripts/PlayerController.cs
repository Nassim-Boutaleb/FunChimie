using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{

    public float speed = 800.0f;
    public Text scoreText, winText;
    private int count=0;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other){ //quand la balle entre dans le déclencheur de collision
    	if(other.gameObject.tag == "PickUp"){//si l'objet entrant est le tag PickUp
            other.gameObject.SetActive(false);//alors rendons l'objet inactif
    	    count+=1;
            scoreText.text="Score: "+count; // mise à jour de text property de scoreText
        if(count >= 8){
            winText.gameObject.SetActive(true);
        }
        }
    }

}