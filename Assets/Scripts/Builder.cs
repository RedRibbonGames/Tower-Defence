using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

    // Use this for initialization
    GameObject[] tiles;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

            if (hit.collider != null)
            {
                Debug.Log("Target Position: " + (int)hit.transform.position.x + "-" + (int)hit.transform.position.y);
                BuildTurret((int)hit.transform.position.x, (int)hit.transform.position.y);
            }
        }
    }

    public void BuildTurret(int x, int y)
    {
        Turret turret = new Turret(x, y);

    }
}
