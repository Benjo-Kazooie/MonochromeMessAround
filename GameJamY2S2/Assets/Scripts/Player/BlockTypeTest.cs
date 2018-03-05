using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockTypeTest : MonoBehaviour {

    public GameObject rayHolder;
    public float distance = 1.5f;

    public string foorMat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;
        RaycastHit FHit;

        if (Physics.Raycast(rayHolder.transform.position, Vector3.down, out hit, 1f))
        {
            //print("Found an under object - distance: " + hit.distance + "  ///  " + hit.collider.gameObject.name + "  ///  " + hit.collider.gameObject.GetComponent<Renderer>().material);
            //print("Under " + hit.collider.gameObject.name + "  ///  " + hit.collider.gameObject.GetComponent<Renderer>().material);
        }
        if (Physics.Raycast(rayHolder.transform.position, Vector3.forward, out FHit, distance))
        {
            //print("Found an  forward object - distance: " + FHit.distance + "  ///  " + FHit.collider.gameObject.name + "  ///  " + FHit.collider.gameObject.GetComponent<Renderer>().material);
            //print("Foward " + FHit.collider.gameObject.name + "  ///  " + FHit.collider.gameObject.GetComponent<Renderer>().material);
        }

        foorMat = hit.collider.gameObject.GetComponent<Renderer>().material.name;

        //// -------------------------------------------------------Creates a lazer that outlines the raycast
        ////init ray to save the start and direction values
        //Ray ray = new Ray(rayHolder.transform.position, rayHolder.transform.forward);
        ////varible to hold the detection info
        //RaycastHit hit;
        ////the end Pos which defaults to the startPos + distance 
        //Vector3 endPos = rayHolder.transform.position + (distance * rayHolder.transform.forward);
        //if (Physics.Raycast(ray, out hit, distance))
        //{
        //    //if we detect something
        //    endPos = hit.point;
        //    print("Foward " + hit.collider.gameObject.name + "  ///  " + hit.collider.gameObject.GetComponent<Renderer>().material);
        //}
        //// 2 is the duration the line is drawn, afterwards its deleted
        //Debug.DrawLine(rayHolder.transform.position, endPos, Color.green, 2);

        switch (foorMat)
        {
            case "yellow_colour (Instance)":
                if (SceneManager.GetActiveScene().name == "Testing1")
                {
                    SceneManager.LoadScene("Level_Test");
                }
                else if (SceneManager.GetActiveScene().name == "Level_Test")
                {
                    SceneManager.LoadScene("Level_1");
                }
                else if (SceneManager.GetActiveScene().name == "Level_1")
                {
                    SceneManager.LoadScene("Level_2");
                }
                else if (SceneManager.GetActiveScene().name == "Level_2")
                {
                    SceneManager.LoadScene("Level_3");
                }
                else if (SceneManager.GetActiveScene().name == "Level_3")
                {
                    SceneManager.LoadScene("Level_4");
                }
                else if (SceneManager.GetActiveScene().name == "Level_4")
                {
                    SceneManager.LoadScene("EndScene");
                }
                break;
            case "darkRed_colour (Instance)":
                //yield return new WaitForSeconds(2);
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene);
                break;
            case "red_colour (Instance)":
                //yield return new WaitForSeconds(2);
                int scene2 = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene2);
                break;
            case "orange_colour (Instance)":
                FPSController control = GetComponent<FPSController>();
                control.Bounce();
                break;
        }
    }
}
