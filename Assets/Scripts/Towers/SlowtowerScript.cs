using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowtowerScript : MonoBehaviour {

    public GameObject Target;
    public int SlowMaginitude { get; set; }
    // Use this for initialization
    void Start()
    {
        SlowMaginitude = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D hitObject)
    {
        if(hitObject.gameObject.tag == "Enemy")
        {
            //Debug.Log("Entering slowzon" + hitObject.gameObject.name);
            hitObject.gameObject.GetComponent<EnemyScript>().SlowMovement(SlowMaginitude);
        }
    }
    public void OnTriggerExit2D(Collider2D hitObject)
    {
        if (hitObject.gameObject.tag == "Enemy")
        {
            //Debug.Log("Exiting slowzon" + hitObject.gameObject.name);
            hitObject.gameObject.GetComponent<EnemyScript>().ResetSpeed();
        }
    }


    public void Upgrade()
    {

    }
}
