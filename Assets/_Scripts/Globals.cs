﻿using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour 
{
	public static bool focusTank = false;
	public static bool roundActive = true;
	public static GameObject end;
	public static int Gold = 300;
	public static int waveNumber;
	public static bool paused = false;
	public static int Score;
	public static bool BuildMode = true;
	public static int rows = 25;
	public static int lines = 25;
	public static int BaseLives = 1000;
	public static int PlayerLives = 100;
	public static int FocusValue = 0;
	public static int CurrentFocus = 1;
	public static uint enemiesSpawned =0;
	public static bool upgradeShow = false;
	public static int price;
}
