using System.Collections;
using UnityEngine;
 
class NewDD : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    public bool good = false;
 
   
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
        //Debug.Log("OPD");
    }
 
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }
 
    void OnMouseDown()
    {
        //Debug.Log("OPDD");
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
 
    void OnMouseUp()
    {
        dragging = false;
    }
 
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }

    void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Hydro") && gameObject.CompareTag ("HydroAtome"))
		{
			Debug.Log("HHOK");
            good = true;
		}
        if (other.gameObject.CompareTag ("Oxy") && gameObject.CompareTag ("OxyAtome"))
		{
			Debug.Log("HHOK");
            good = true;
		}
	}

    void OnTriggerExit(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Hydro") &&  gameObject.CompareTag ("HydroAtome"))
		{
			Debug.Log("Not OK");
            good=false;
            // désactiver (ou détruire éventuellment) le pick up 
            //other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			//count = count + 1;

			// Run the 'SetCountText()' function (see below)
			//SetCountText ();
		}
        if (other.gameObject.CompareTag ("Oxy") &&  gameObject.CompareTag ("OxyAtome"))
		{
			Debug.Log("Not OK");
            good=false;
		}
	}
}
