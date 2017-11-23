using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : Tower
{
    public Machinegun(int x, int y)
    {
        Turret.transform.position = new Vector2(x, y);

        TurretBase.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TurretBase");
        TurretGun.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("TurretGun");

        TurretGun.AddComponent<MachinegunScript>();
    }

}
