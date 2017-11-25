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
        
        moveSpeed = 10;
    }
    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
        Movement();
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public void Movement()
    {
        if (Target == null)
        {
            
            transform.position += transform.right * Time.deltaTime * moveSpeed;
            //Debug.Log("Boom I got Destroyed");
            DestroyThisObject(this.gameObject, 1f);
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
            DestroyThisObject(this.gameObject, 0f);
        }
    }
    private void DestroyThisObject(GameObject bullet, float time)
    {
        Pool.DeactivateBulletAndAddToPool(bullet);
    }
}
