using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text livesRemaining;
    public Text goldDisplay;
    public static int lives;
    public static int gold;
	// Use this for initialization
	void Start () {
        lives = 20;
        gold = 0;
	}
	
	// Update is called once per frame
	void Update () {
        livesRemaining.text = "Lives: " + lives;
        goldDisplay.text = "Gold: " + gold;
    }

    public static void ReducesLives()
    {
        lives--;
    }
    public static void IncreaseGold(int goldIncrease)
    {
        gold += goldIncrease;
    }
}
