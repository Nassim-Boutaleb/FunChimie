using System.Collections;
using UnityEngine;
 
class NewDD : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor;
    private bool dragging = false;
    private float distance;
    private bool placed=false;
    private bool good = false;

 
    public void Start() {
        originalColor = GetComponent<Renderer>().material.color;
        //Debug.Log("color:"+originalColor);
    }
   public bool getGood () {
       return good;
   }

   public bool getPlaced() {
        return placed;
    }
    
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
            //Debug.Log("rp"+rayPoint.x);
            //transform.position = rayPoint;
            Vector3 newPos = new Vector3 (rayPoint.x,0.0f,rayPoint.z);
            transform.position = newPos;
        }
    }

    void OnTriggerEnter(Collider other) 
	{
		placed = true;
        Debug.Log("Trigger");
        // ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Hydro") && gameObject.CompareTag ("HydroAtome"))
		{
			Debug.Log("HHOK");
            good = true;
            // envoyer le signal
		}
        
	}

    void OnTriggerExit(Collider other) 
	{
		Debug.Log("NotOK");
        good=false;
        placed=false;
        
	}
}
