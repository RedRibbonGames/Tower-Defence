using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserbeamScript : MonoBehaviour
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
        if(Target != null)
        {
            CreateBullet();
        }
    }

    public void LocateTarget()
    {
        if (Target == null)
        {


            StopShooting();
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
                StopShooting();
                return;
            }
            LookAtTarget();
            ShootAtTarget();
            InvokeDamage();
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
            InvokeRepeating("CreateBullet", 0f, 0.0001f);
        }
    }

    public void StopShooting()
    {
        CancelInvoke("CreateBullet");
        CancelInvoke("DoDamage");
        gameObject.GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);
        gameObject.GetComponent<LineRenderer>().SetPosition(1, gameObject.transform.position);
    }
    public void CreateBullet()
    {
        if (Target == null)
        {
            StopShooting();
            return;
        }
        gameObject.GetComponent<LineRenderer>().SetPosition(0, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1));
        gameObject.GetComponent<LineRenderer>().SetPosition(1, new Vector3(Target.transform.position.x, Target.transform.position.y, -1));
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

    public void DoDamage()
    {
        if(Target == null)
        {
            return;
        }
        Target.gameObject.GetComponent<EnemyScript>().TakeDamage(1);
    }

    public void InvokeDamage()
    {
        if (!IsInvoking("DoDamage"))
        {
            InvokeRepeating("DoDamage", 0f, 0.1f);
        }

    }

    public void Upgrade()
    {
        // TODO: Implement Upgrades for towers
    }
}
