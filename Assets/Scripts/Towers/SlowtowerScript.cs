using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowtowerScript : MonoBehaviour {

    public GameObject Target;
    public int rateOfFire { get; set; }
    // Use this for initialization
    void Start()
    {
        rateOfFire = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OntriggerStayr2D(Collision2D hitObject)
    {
        if(hitObject.gameObject.tag == "Enemies")
        {
            Debug.Log(hitObject.gameObject.name);
        }
    }


    public void Upgrade()
    {

    }
}
