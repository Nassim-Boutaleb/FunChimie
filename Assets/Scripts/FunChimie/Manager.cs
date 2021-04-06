using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    // Atoms
    private GameObject HydroAtome1;
    private GameObject HydroAtome2;
    private GameObject OxyAtome;

    // Borders
    private GameObject WallE;
    private GameObject WallW;
    private GameObject WallN;
    private GameObject WallS;
    private Color red = Color.red;
    private Color white = Color.white;
    private Color green = Color.green;

    // Booleans
    private bool good1 = false;
    private bool good2 = false;
    private bool good3 = false;

    private bool placedHydro1 = false;
    private bool placedOxy = false;
    private bool placedHydro2 = false;

    private bool win = false;  // win
    private bool timesUp = false;  // no more time 

    //Chrono
    private float time = 55f;

    // spaces
    private GameObject HydroSpace1;
    private GameObject HydroSpace2;
    private GameObject OxySpace;
    private bool HydroSpace1Triggered = false;
    private bool HydroSpace2Triggered = false;
    private bool OxySpaceTriggered = false;

    // Links
    public GameObject Link1;
    public GameObject Link2;

    
    // Start is called before the first frame update
    void Start()
    {
        HydroAtome1 = GameObject.Find("Hydro");
        good1 = HydroAtome1.GetComponent<NewDD>().getGood();
        placedHydro1 = HydroAtome1.GetComponent<NewDD>().getPlaced();

        OxyAtome = GameObject.Find("Oxy");
        good2 = OxyAtome.GetComponent<DDOxy>().getGood();
        placedOxy = OxyAtome.GetComponent<DDOxy>().getPlaced();

        HydroAtome2 = GameObject.Find("Hydro (2)");
        good3 = HydroAtome2.GetComponent<NewDD>().getGood();
        placedHydro2 = HydroAtome2.GetComponent<NewDD>().getPlaced();

        //Borders
        WallE= GameObject.Find("Border_E");
        WallW= GameObject.Find("Border_W");
        WallN= GameObject.Find("Border_N");
        WallS= GameObject.Find("Border_S");

        // spaces
        HydroSpace1 = GameObject.Find("HydroPlace");
        HydroSpace1Triggered = HydroSpace1.GetComponent<Space>().getTriggered();

        HydroSpace2 = GameObject.Find("HydroPlace (1)");
        HydroSpace2Triggered = HydroSpace2.GetComponent<Space>().getTriggered();

        OxySpace = GameObject.Find("OxyPlace");
        OxySpaceTriggered = OxySpace.GetComponent<Space>().getTriggered();

        

    }

    // Update is called once per frame
    void Update()
    {
        // Chrono
        if (!win) {
            time -= Time.deltaTime;
        }

        if (time <=0) {
            time=0;
            timesUp = true;
            WallE.GetComponent<Renderer>().material.color=red;
            WallN.GetComponent<Renderer>().material.color=red;
            WallS.GetComponent<Renderer>().material.color=red;
            WallW.GetComponent<Renderer>().material.color=red;
        }

        
        good1 = HydroAtome1.GetComponent<NewDD>().getGood();
        placedHydro1 = HydroAtome1.GetComponent<NewDD>().getPlaced();

        good2 = OxyAtome.GetComponent<DDOxy>().getGood();
        placedOxy = OxyAtome.GetComponent<DDOxy>().getPlaced();

        good3 = HydroAtome2.GetComponent<NewDD>().getGood();
        placedHydro2 = HydroAtome2.GetComponent<NewDD>().getPlaced();

        //Debug.Log("1:"+placedHydro1+""+placedHydro2+""+placedOxy);
        if (placedHydro1 && placedHydro2 && placedOxy && time > 0) {
            if (good1 && good2 && good3) {
                Debug.Log("WIN");
                WallE.GetComponent<Renderer>().material.color=green;
                WallN.GetComponent<Renderer>().material.color=green;
                WallS.GetComponent<Renderer>().material.color=green;
                WallW.GetComponent<Renderer>().material.color=green;
                win = true;
                
            }
            else {
                Debug.Log("Not OK-RED");
                WallE.GetComponent<Renderer>().material.color=red;
                WallN.GetComponent<Renderer>().material.color=red;
                WallS.GetComponent<Renderer>().material.color=red;
                WallW.GetComponent<Renderer>().material.color=red;
            }
        }
        else if (time > 0) {
            // Walls in white
            WallE.GetComponent<Renderer>().material.color=white;
            WallS.GetComponent<Renderer>().material.color=white;
            WallW.GetComponent<Renderer>().material.color=white;
            WallN.GetComponent<Renderer>().material.color=white;
        }

        ManageLink();
    }


    void OnGUI()
    {
        GUIStyle guiStyle = new GUIStyle(); //create a new variable
        guiStyle.fontSize = 50; //change the font size
        guiStyle.normal.textColor = white;
        GUI.Label(new Rect(40,310,50,25), "Temps restant: "+time.ToString(),guiStyle);

        if (win) {
            guiStyle.fontSize = 50; //change the font size
            guiStyle.normal.textColor = green;
            GUI.Label(new Rect(40,60,50,25), "VOUS AVEZ GAGNE",guiStyle);
        }
        else if (timesUp){
            guiStyle.fontSize = 50; //change the font size
            guiStyle.normal.textColor = red;
            GUI.Label(new Rect(40,60,50,25), "TEMPS ECOULE! VOUS AVEZ PERDU!",guiStyle);
        }
    }

    public void ManageLink() {
        // update triggers
        HydroSpace1Triggered = HydroSpace1.GetComponent<Space>().getTriggered();
        HydroSpace2Triggered = HydroSpace2.GetComponent<Space>().getTriggered();
        OxySpaceTriggered = OxySpace.GetComponent<Space>().getTriggered();
        
        //Debug.Log("Trigg: ");
        if (HydroSpace1Triggered && OxySpaceTriggered) {
            Debug.Log("AZERTY");
            Link1.SetActive(true);
        }
        else {
            Link1.SetActive(false);
        }
        if (HydroSpace2Triggered&&OxySpaceTriggered) {
            Link2.SetActive(true);
        }
        else {
            Link2.SetActive(false);
        }
    }




    
}
