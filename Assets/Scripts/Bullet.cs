using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject Target { get; set; }
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
        Movement();
    }    
    public void Movement()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            Debug.Log("Boom I got Destroyed");
        }
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * 2);
    }
    public void LookAtTarget()
    {
        if (Target == null)
        {
            return;
        }
        Vector3 dir = Target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        Debug.Log(hitObject.tag);
    }
}
