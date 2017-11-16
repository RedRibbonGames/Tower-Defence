using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun
{
    public Machinegun(int x, int y)
    {
        GameObject Turret = new GameObject("Machinegun");
        Turret.transform.position = new Vector2(x, y);
        GameObject TurretBase = new GameObject("TurretBase");
        GameObject TurretGun = new GameObject("TurretGun");

        TurretBase.transform.SetParent(Turret.transform);
        TurretBase.transform.localPosition = new Vector2(0, 0);
        

        TurretGun.transform.SetParent(Turret.transform);
        TurretGun.transform.localPosition = new Vector2(0, 0);

        TurretBase.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TurretBase");
        TurretGun.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TurretGun");

        TurretBase.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Towers";
        TurretGun.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Towers";
        TurretGun.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
        TurretGun.AddComponent<MachinegunScript>();
    }

}
