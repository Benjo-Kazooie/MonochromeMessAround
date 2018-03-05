using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourEffect : MonoBehaviour {

    
    [SerializeField]
    float modifyer = 5;
    [SerializeField]
    // Color32 orange = new Color32(0, 0, 59, 1);
    Color blue = new Color(0.000f, 0.000f, 0.235f, 0.004f);    
    [SerializeField]
    // Color32 blue = new Color32(255, 99, 0, 0);
    Color orange = new Color(1.000f, 0.392f, 0.000f, 0.000f);
    int noOfHits;
   // [SerializeField]
    // Color32 grey = new Color32(0, 0, 0, 150);
  //  Color grey = new Color(0.000f, 0.000f, 0.000f, 0.392f);

    Transform player;
    //PlayerMovement movement;          //put back in later if needed
    Color colour;
    private Material material;
    string terrainType;
    bool activate = false;  
    // Use this for initialization
    void Start ()
    {
        //speed of player is movement
        //player = FindPlayer.instance.player.transform;
        //movement = player.GetComponent<PlayerMovement>();               //put back in later if needed
        material = gameObject.GetComponent<Renderer>().material;
        //Debug.Log(material.name);
        noOfHits = 0;
	}
	
    void Update()
    { }

    void ModifyClimb()
    {
        //insert Blue here!
        // movement.speed += modifyer;                     //put back in later if needed
        //GetComponent<Collider>().GetComponent<FPSController>().SetClimbing();
    }

    void Normality(Collider collider)
    {
        //activate = false;
        //movement.speed -= modifyer;                      //put back in later if needed
        collider.SendMessage("SetClimbing", false);
    }
    
    
    void OnTriggerEnter (Collider hit)
    {
        noOfHits++;
        Debug.Log(noOfHits + material.name);
        Debug.Log("Trigger On");

        if (material.name == "Orange (Instance)")
        {
            activate = true;
            Debug.Log("Stepped on an orange");
            GetComponent<Collider>().GetComponent<FPSController>().Bounce();
            terrainType = "bounce";
        }
        else if (material.name == "blue_colour (Instance)")
        {
            activate = true;
            Debug.Log("Gotta go fast!");
            //ModifyClimb();
            hit.SendMessage("SetClimbing", true);
            terrainType = "climb";
        }
        else
        {
            Debug.Log("We ain't found shit!");
        }

        //if (hit.collider.material.name == "blue_colour (Instance)")
        //{
        //    Debug.Log("We've hit blue!");
        //    GetComponent<FPSController>().Bounce();
        //}
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log("Trigger Off");
        Normality(collider);
    }

    void ColourReaction()
    {
        if (activate == true)
        {
            switch (terrainType)
            {
                case ("bounce"):
                    Debug.Log("I am a potato!");
                    break;

                case ("climb"):
                    Debug.Log("I am not a potato");
                    ModifyClimb();
                    break;
            }
        }
    }

    Material GetMaterial()
    {
        return material;
    }

    void SetMaterial(Material newMaterial)
    {
        material = newMaterial;
        gameObject.GetComponent<Renderer>().material = newMaterial;
    }
}
