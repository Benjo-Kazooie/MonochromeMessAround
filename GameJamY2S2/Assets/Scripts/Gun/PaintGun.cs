using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PaintGun : MonoBehaviour {

    public Camera playerCam;
    public Material currentGunMat;
    public Material currentShootMat;

    public Material[] gunMatColours = new Material[10];
    public Material[] colours = new Material[10];

    public Material oldGunMat;
    public Material oldblockMat;

    public Material sky1;
    public Material sky2;

    void Start ()
    {
        currentGunMat = gunMatColours[8];           // set currentGunMat to white
        currentShootMat = colours[8];               // set currentShootMat to white

        RenderSettings.skybox = sky1;               // set skybox to a bright sunny day

        gameObject.GetComponent<Renderer>().material = currentGunMat;                   // sets the guns material to white at the start
    }

	void Update ()
    {
        //FireMode1();
        FireMode2();
    }

    // replaces colours
    void FireMode1()
    {
        // if left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
            {
                if (currentGunMat != gunMatColours[8])
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material = currentShootMat;    //changes block hit colour
                    //gameObject.GetComponent<Renderer>().material = gunMatColours[8];                //sets gun mterial to white after fireing\
                }
                else
                {
                    Debug.Log("Can't shoot paint, guns empty");
                }
            }
        }

        // if right mouse button is pressed
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
            {
                SwitchMaterial(hit.collider.gameObject.GetComponent<Renderer>().material.name);
                gameObject.GetComponent<Renderer>().material = currentGunMat;                           //changes the material to the current gun material colour
                //hit.collider.gameObject.GetComponent<Renderer>().material = colours[8];                 // sets block hit to white
            }
        }
    }

    // swaps colours
    void FireMode2()
    {
        // if left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit))
            {
                Debug.Log("what " + hit.collider.gameObject.GetComponent<Renderer>().material);
                if (hit.collider.gameObject.name == "SunTrigger")
                {
                    Debug.Log("You got... the sun?");
                    if (RenderSettings.skybox == sky2)
                    {
                        Debug.Log("Mate, you already got it");
                        if (gameObject.GetComponent<Renderer>().material.name == "yellow_gun (Instance)")
                        {
                            RenderSettings.skybox = sky1;
                            gameObject.GetComponent<Renderer>().material = gunMatColours[8];
                        }
                    }
                    else
                    {
                        if (gameObject.GetComponent<Renderer>().material.name == "yellow_gun (Instance)")
                        {
                            Debug.Log("Can't put more sun in the sun");
                        }
                        else if (gameObject.GetComponent<Renderer>().material.name != "white_gun (Instance)")
                        {
                            Debug.Log("You can't do that");
                        }
                        else
                        {
                            RenderSettings.skybox = sky2;
                            gameObject.GetComponent<Renderer>().material = gunMatColours[9];
                        }
                    }

                }
                else if (hit.collider.gameObject.GetComponent<Renderer>().material.name == "black_colour (Instance)" || hit.collider.gameObject.GetComponent<Renderer>().material.name == "darkRed_colour (Instance)")
                {
                    Debug.Log("You can't do that");
                }
                else
                {
                    string[] gunMatNameParts = gameObject.GetComponent<Renderer>().material.name.Split('_');
                    string[] blockMatNameParts = hit.collider.gameObject.GetComponent<Renderer>().material.name.Split('_');

                    oldblockMat = hit.collider.gameObject.GetComponent<Renderer>().material;
                    oldGunMat = gameObject.GetComponent<Renderer>().material;

                    if (gunMatNameParts[0] == blockMatNameParts[0])
                    {
                        Debug.Log("Objects are the same material, can't swicth");
                    }
                    else
                    {
                        for (int i = 0; i < gunMatColours.Length; i++)
                        {
                            if (gunMatColours[i].name.Contains(blockMatNameParts[0]))
                            {
                                gameObject.GetComponent<Renderer>().material = gunMatColours[i];
                            }
                        }

                        for (int j = 0; j < colours.Length; j++)
                        {
                            if (colours[j].name.Contains(gunMatNameParts[0]))
                            {
                                hit.collider.gameObject.GetComponent<Renderer>().material = colours[j];
                            }
                        }
                    }
                }
            }
        }
    }

    void SwitchMaterial(string colourName)      //part of fire mode 1
    {
        switch (colourName)
        {
            case "black_colour (Instance)":
                currentGunMat = gunMatColours[0];
                currentShootMat = colours[0];
                break;
            case "blue_colour (Instance)":
                currentGunMat = gunMatColours[1];
                currentShootMat = colours[1];
                break;
            case "green_colour (Instance)":
                currentGunMat = gunMatColours[2];
                currentShootMat = colours[2];
                break;
            case "orange_colour (Instance)":
                currentGunMat = gunMatColours[3];
                currentShootMat = colours[3];
                break;
            case "pink_colour (Instance)":
                currentGunMat = gunMatColours[4];
                currentShootMat = colours[4];
                break;
            case "purple_colour (Instance)":
                currentGunMat = gunMatColours[5];
                currentShootMat = colours[5];
                break;
            case "red_colour (Instance)":
                currentGunMat = gunMatColours[6];
                currentShootMat = colours[6];
                break;
            case "skyblue_colour (Instance)":
                currentGunMat = gunMatColours[7];
                currentShootMat = colours[7];
                break;
            case "white_colour (Instance)":
                currentGunMat = gunMatColours[8];
                currentShootMat = colours[8];
                break;
            case "yellow_colour (Instance)":
                currentGunMat = gunMatColours[9];
                currentShootMat = colours[9];
                break;
        }
    }
}
