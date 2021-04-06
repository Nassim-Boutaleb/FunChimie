using System.Collections;
using UnityEngine;
 
class DDOxy : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor; 
    private bool dragging = false;
    private float distance;
    private bool placed = false; // placé qq part ?
    private bool good = false;  // bien placé ?

    //private Vector3 pos;

    public void Start() {
        originalColor = GetComponent<Renderer>().material.color;
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
        //pos= transform.position;
        //Debug.Log("pos is " + pos);
    }

    void OnTriggerEnter(Collider other) 
	{
		placed = true;
        Debug.Log("Chekc");
        if (other.gameObject.CompareTag ("Oxy") && gameObject.CompareTag ("OxyAtome"))
		{
			Debug.Log("OxyOK");
            good = true;
		}
        //pos= transform.position;
        //Debug.Log("pos is " + pos);
	}

    void OnTriggerExit(Collider other) 
	{
		Debug.Log("Exit");
        good=false;
        placed=false;
	}
}
