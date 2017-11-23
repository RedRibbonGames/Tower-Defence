using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{

    protected GameObject Turret;
    protected GameObject TurretBase;
    protected GameObject TurretGun;

    public Tower()
    {
        Turret = new GameObject("Machinegun");
        Turret.AddComponent<BoxCollider2D>();

        TurretBase = new GameObject("TurretBase");
        TurretGun = new GameObject("TurretGun");

        TurretBase.AddComponent<SpriteRenderer>();
        TurretGun.AddComponent<SpriteRenderer>();
        TurretBase.transform.SetParent(Turret.transform);
        TurretBase.transform.localPosition = new Vector2(0, 0);


        TurretGun.transform.SetParent(Turret.transform);
        TurretGun.transform.localPosition = new Vector2(0, 0);


        TurretBase.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Towers";
        TurretGun.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Towers";
        TurretGun.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        Turret.tag = "Tower";
        TurretBase.tag = "Tower";
        TurretGun.tag = "Tower";
    }
}
