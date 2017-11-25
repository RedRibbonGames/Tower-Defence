using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunScript : MonoBehaviour
{

    public GameObject Target;
    public float rateOfFire { get; set; }
    public int damage;
    // Use this for initialization
    void Start()
    {
        rateOfFire = 0.5f;
        damage = 18;
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
            //Target = GameObject.FindGameObjectWithTag("Enemy");
            float distance = 5f;

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float goDistance = Vector3.Distance(go.transform.position, transform.position);
                if (goDistance < distance)
                {
                    Target = go;
                    distance = goDistance;
                }

            }


        }

        if (Target != null)
        {
            if (IsInRange() == false)
            {
                return;
            }
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
            InvokeRepeating("CreateBullet", 1f, rateOfFire);
        }
    }

    public void CreateBullet()
    {
        GameObject BulletObject = Pool.GetBulletFromPool();

        if(BulletObject == null)
        {
            BulletObject = new GameObject("Bullet");
            BulletObject.AddComponent<Bullet>().Target = Target;
            BulletObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Bullet");
            BulletObject.AddComponent<BoxCollider2D>().isTrigger = true;
            BulletObject.GetComponent<SpriteRenderer>().sortingLayerName = "Bullets";
            BulletObject.transform.position = transform.position;
            BulletObject.transform.rotation = transform.rotation;
            BulletObject.GetComponent<Bullet>().SetDamage(damage);
        }
        else
        {
            BulletObject.GetComponent<Bullet>().Target = Target;
            BulletObject.GetComponent<Bullet>().SetDamage(damage);
            BulletObject.transform.position = transform.position;
            BulletObject.transform.rotation = transform.rotation;         
            BulletObject.SetActive(true);
        }

    }


    // Check to see if the target is still in range
    // if it's not in range set the current target to null and 
    // stop shooting the current target
    public bool IsInRange()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) > 5f)
        {
            if (IsInvoking("CreateBullet"))
            {
                CancelInvoke("CreateBullet");
                Target = null;
            }
            return false;
        }
        return true;

    }
    public void Upgrade()
    {

    }
}
