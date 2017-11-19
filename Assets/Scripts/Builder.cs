using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SalusGames.Utility;

public class Builder : MonoBehaviour
{

    // Use this for initialization
    GameObject[] tiles;
    private string selectedTower = null;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check to see if the pointer is over a UI element
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (selectedTower != null)
            {

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

                if (hit.collider != null && hit.collider.gameObject.tag != "Enemy" && hit.collider.gameObject.name != "Path")
                {

                    BuildTower((int)hit.transform.position.x, (int)hit.transform.position.y, selectedTower);
                }
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

                if (hit.collider != null)
                {
                    Debug.Log("Target Position: " + (int)hit.transform.position.x + "-" + (int)hit.transform.position.y);
                }
            }

        }
    }

    public void BuildTower(int x, int y, string name)
    {

        switch (name)
        {
            case "Machinegun":
            BuildTurret(x, y);
            break;
            case "Laserbeam":
            BuildLaserbeam(x, y);
            break;
            case "Slowtower":
            BuildSlowtower(x, y);
            break;

        }
    }

    public void BuildTurret(int x, int y)
    {
        new Machinegun(x, y);

    }

    public void BuildLaserbeam(int x, int y)
    {
        new Laserbeam(x, y);
    }
    public void BuildSlowtower(int x, int y)
    {
        new Slowtower(x, y);
    }
    // buttons
    public void SelectMachineGun()
    {
        selectedTower = "Machinegun";
        PlaceBuildingMode();
    }
    public void SelectLaserbeam()
    {
        selectedTower = "Laserbeam";
        PlaceBuildingMode();
    }
    public void SelectSlowtower()
    {
        selectedTower = "Slowtower";
        PlaceBuildingMode();
    }
    public void PlaceBuildingMode()
    {
        ToggleCanvasGroup.Show(GameObject.Find("DeselectTower").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Hide(GameObject.Find("Towers").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Hide(GameObject.Find("ExitBuildMenu").GetComponent<CanvasGroup>());
    }
    public void DeSelectTower()
    {
        selectedTower = null;
        ShowBuildMenu();
    }
    public void ShowBuildMenu()
    {
        ToggleCanvasGroup.Show(GameObject.Find("Towers").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Hide(GameObject.Find("BuildMenu").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Show(GameObject.Find("ExitBuildMenu").GetComponent<CanvasGroup>());
    }
    public void ExitBuildMenu()
    {
        DeSelectTower();
        ToggleCanvasGroup.Hide(GameObject.Find("Towers").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Show(GameObject.Find("BuildMenu").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Hide(GameObject.Find("ExitBuildMenu").GetComponent<CanvasGroup>());
    }
}
