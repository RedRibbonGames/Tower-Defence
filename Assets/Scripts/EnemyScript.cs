using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private int Health { get; set; }
    public List<Vector3> pathList;
    private int movementSpeed;

    // Use this for initialization
    void Start () {
        movementSpeed = 5;
        Health = 20;
        pathList = new List<Vector3>();
        SetPath();
	}
	
	// Update is called once per frame
	void Update () {
        LookAtWaypoint();
        Movement();

    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Movement()
    {
        transform.Translate(Vector2.right * Time.deltaTime * movementSpeed);
    }
    public void LookAtWaypoint()
    {
        // if waypoit reached remove from list

        if(Vector3.Distance(transform.position, pathList[0]) < 0.1f && pathList.Count > 0)
        {
            pathList.RemoveAt(0);
        }
        if(pathList.Count == 0)
        {

            DestroyThisObject();
            return;
        }
        Vector3 dir = pathList[0] - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    public void SetPath()
    {

        pathList.Add(new Vector2(3, 6));
        pathList.Add(new Vector2(3, 13));
        pathList.Add(new Vector2(6, 13));
        pathList.Add(new Vector2(6, 7));
        pathList.Add(new Vector2(12, 7));
        pathList.Add(new Vector2(12, 9));
        pathList.Add(new Vector2(8, 9));
        pathList.Add(new Vector2(8, 12));
        pathList.Add(new Vector2(16, 12));
        pathList.Add(new Vector2(16, 8));
        pathList.Add(new Vector2(19, 8));
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
