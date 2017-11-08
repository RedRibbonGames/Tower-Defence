using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Target { get; set; }
    private bool canShoot { get; set; }
    public int rateOfFire { get; set; }
    // Use this for initialization
    void Start()
    {
        LocateTarget();

    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
    }

    public void LocateTarget()
    {
        if (Target == null)
        {
            CancelInvoke("ShootAtTarget");
            canShoot = true;
            Target = GameObject.FindGameObjectWithTag("Enemy");
        }

        
        ShootAtTarget();
        canShoot = false;

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
        if (canShoot)
        {
            InvokeRepeating("CreateBullet", 1f, 1f);
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
