using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSettings
{
	public const string SFXVolumeKey = "SFXVolume";
	public const string LookSensitivityKey = "LookSensitivity";
    
	public static float SFXVolume = 1f;
	public static float LookSensitivity = 8f;

	public static int unlockedRooms = 1;

	public static void UpdateUnlockedRooms()
	{
		switch(SceneManager.GetActiveScene().buildIndex) {
			case 1:
				unlockedRooms = 2;
				break;
			case 2:
				unlockedRooms = 3;
				break;
			case 3:
				//unlockedRooms = 3;
				break;
		}

		PlayerPrefs.SetInt("UnlockedRooms", unlockedRooms);
	}
	public static void GetUnlockedRooms()
	{
		if (PlayerPrefs.HasKey("UnlockedRooms"))
		{
			unlockedRooms = PlayerPrefs.GetInt("UnlockedRooms");
		}
		else
		{
			unlockedRooms = 1;
		}
	}
}
