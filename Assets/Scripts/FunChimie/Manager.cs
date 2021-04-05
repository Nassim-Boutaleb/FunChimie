using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private GameObject HydroAtome1;
    private GameObject HydroAtome2;
    private GameObject OxyAtome;

    private bool good1 = false;
    private bool good2 = false;
    private bool good3 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        HydroAtome1 = GameObject.Find("Hydro");
        good1 = HydroAtome1.GetComponent<NewDD>().good;

        OxyAtome = GameObject.Find("Oxy");
        good2 = OxyAtome.GetComponent<NewDD>().good;

        HydroAtome2 = GameObject.Find("Hydro (2)");
        good3 = HydroAtome2.GetComponent<NewDD>().good;
    }

    // Update is called once per frame
    void Update()
    {
        good1 = HydroAtome1.GetComponent<NewDD>().good;

        good2 = OxyAtome.GetComponent<NewDD>().good;

        good3 = HydroAtome2.GetComponent<NewDD>().good;
        //Debug.Log("OHEY");
        if (good1 && good2 && good3) {
            Debug.Log("WIN");
        }
    }
}
