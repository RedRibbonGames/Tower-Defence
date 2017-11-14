using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject Target { get; set; }
    public int damage { get; set; }
    public int moveSpeed { get; set; }
    // Use this for initialization
    void Start()
    {
        damage = 2;
        moveSpeed = 10;
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
            
            transform.position += transform.right * Time.deltaTime * moveSpeed;
            //Debug.Log("Boom I got Destroyed");
            Destroy(gameObject, 3f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * moveSpeed);
        }
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
        if(hitObject.gameObject == Target)
        {
            hitObject.GetComponent<EnemyScript>().TakeDamage(damage);
            Destroy(gameObject);
        }

    }
}
