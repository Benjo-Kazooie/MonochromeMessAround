using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour {

    #region FindPlayer

    public static FindPlayer instance;

    void Awake ()
    {
        instance = this;
    }

    #endregion

    public GameObject player;   
}
