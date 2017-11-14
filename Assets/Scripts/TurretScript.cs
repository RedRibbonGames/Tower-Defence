using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

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
        LocateTarget();
        
    }

    public void LocateTarget()
    {
        if (Target == null)
        {
            CancelInvoke("CreateBullet");
            Target = GameObject.FindGameObjectWithTag("Enemy");
        }

        if (Target != null)
        {
            LookAtTarget();
            ShootAtTarget();
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

    public void ShootAtTarget()
    {
        if (IsInvoking("CreateBullet") == false)
        {
            InvokeRepeating("CreateBullet", 0f, 1f);
            //Debug.Log("Starting to fire");
        }
    }

    public void CreateBullet()
    {
        GameObject BulletObject = new GameObject();
        BulletObject.AddComponent<Bullet>().Target = Target;
        BulletObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bullet");
        BulletObject.AddComponent<BoxCollider2D>().isTrigger = true;
        BulletObject.transform.position = transform.position;
    }
}
