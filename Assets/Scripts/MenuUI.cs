using SalusGames.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour {

    GameObject buttongroup;
	// Use this for initialization
	void Start () {
        buttongroup = GameObject.Find("ButtonGroups");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauzeGame()
    {
        Time.timeScale = 0;
        ToggleCanvasGroup.Hide(GameObject.Find("Pause").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Show(GameObject.Find("Resume").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Show(GameObject.Find("Quit").GetComponent<CanvasGroup>());
        buttongroup.SetActive(false);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        ToggleCanvasGroup.Show(GameObject.Find("Pause").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Hide(GameObject.Find("Resume").GetComponent<CanvasGroup>());
        ToggleCanvasGroup.Hide(GameObject.Find("Quit").GetComponent<CanvasGroup>());
        buttongroup.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();

    }
}
