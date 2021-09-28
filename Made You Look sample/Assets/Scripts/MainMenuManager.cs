using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public enum Menus {
		Main,
        RoomSelection,
        Settings,
        ControlSettings,
        QualitySettings,
        SoundSettings
	}
    
	public GameObject mainButtons;
	public GameObject roomSelectObject;
	public GameObject settingsObject;
	public GameObject backButton;
	public GameObject controlSettings, qualitySettings, soundSettings;

	public Text currentQualityLevelText;

	private int backButtonId;

	private Menus currentMenu;

	public Menus CurrentMenu {
		get {
			return currentMenu;
		}
		set {
			currentMenu = value;

			OnMenuSwitched(currentMenu);
		}
	}
	private Menus previousMenu;

	private void Start()
	{
		if(PlayerPrefs.HasKey(GameSettings.LookSensitivityKey)) {
			GameSettings.LookSensitivity = PlayerPrefs.GetFloat(GameSettings.LookSensitivityKey);
		}
		controlSettings.transform.Find("Sensitivity/Slider").GetComponent<Slider>().value = GameSettings.LookSensitivity;

		if(PlayerPrefs.HasKey(GameSettings.SFXVolumeKey)) {
			GameSettings.SFXVolume = PlayerPrefs.GetFloat(GameSettings.SFXVolumeKey);
		}
		soundSettings.transform.Find("SFX/Slider").GetComponent<Slider>().value = GameSettings.SFXVolume;


		GameSettings.GetUnlockedRooms();
		CurrentMenu = Menus.Main;

		Debug.Log("Unlocked rooms count: " + GameSettings.unlockedRooms);
	}

	public void LoadGameLevel(int i)
	{
		SceneManager.LoadScene(i);
	}
	public void MainMenuToRoomSelect()
	{
		CurrentMenu = Menus.RoomSelection;
	}
	public void RoomSelectToMainMenu()
	{
		CurrentMenu = Menus.Main;
	}
    public void MainMenuToSettings()
	{
		CurrentMenu = Menus.Settings;
	}
    public void SettingsToMainMenu()
	{
		CurrentMenu = Menus.Main;
	}
	public void SettingsToControls() {
		CurrentMenu = Menus.ControlSettings;
	}

	public void SettingsToQuality()
    {
		CurrentMenu = Menus.QualitySettings;
    }
	public void SettingsToSound()
    {
		CurrentMenu = Menus.SoundSettings;
    }

	public void OnLookSensitivityChanged(float f) {
		GameSettings.LookSensitivity = f;
		PlayerPrefs.SetFloat(GameSettings.LookSensitivityKey, GameSettings.LookSensitivity);
	}

	public void OnSFXValueChanged(float f) {
		GameSettings.SFXVolume = f;
		PlayerPrefs.SetFloat(GameSettings.SFXVolumeKey, GameSettings.SFXVolume);
	}
	public void ChangeQualitySetting(bool b) {
		if(b) {
			QualitySettings.IncreaseLevel();
		}
		else {
			QualitySettings.DecreaseLevel();
		}
		currentQualityLevelText.text = QualitySettings.GetQualityLevel().ToString();
	}

	public void ExecuteBackButton() {
		switch(backButtonId) {
			case 0:
				break;
			case 1:
				CurrentMenu = Menus.Main;
				break;
			case 2:
				CurrentMenu = Menus.Main;
				break;
			case 3:
				CurrentMenu = Menus.Settings;
				break;
			case 4:
				CurrentMenu = Menus.Settings;
				break;
			case 5:
				CurrentMenu = Menus.Settings;
				break;
		}
	}
	private void OnMenuSwitched(Menus newMenu) {
		switch(newMenu) {
			case Menus.Main:
				backButton.SetActive(false);
				mainButtons.SetActive(true);
				roomSelectObject.SetActive(false);
				settingsObject.SetActive(false);

				backButtonId = 0;
				break;
			case Menus.RoomSelection:
				backButton.SetActive(true);
				mainButtons.SetActive(false);
                roomSelectObject.SetActive(true);
                settingsObject.SetActive(false);

				backButtonId = 1;
				break;
			case Menus.Settings:
				backButton.SetActive(true);
				mainButtons.SetActive(false);
                roomSelectObject.SetActive(false);
                settingsObject.SetActive(true);
				qualitySettings.SetActive(false);
				controlSettings.SetActive(false);
				soundSettings.SetActive(false);
                
				backButtonId = 2;
				break;
			case Menus.ControlSettings:
				backButton.SetActive(true);
				settingsObject.SetActive(false);
				controlSettings.SetActive(true);
				qualitySettings.SetActive(false);
				soundSettings.SetActive(false);
				backButtonId = 3;
				break;
			case Menus.QualitySettings:
				backButton.SetActive(true);
				settingsObject.SetActive(false);
                controlSettings.SetActive(false);
                qualitySettings.SetActive(true);
                soundSettings.SetActive(false);

				backButtonId = 4;
				break;
			case Menus.SoundSettings:
				backButton.SetActive(true);
				settingsObject.SetActive(false);
                controlSettings.SetActive(false);
                qualitySettings.SetActive(false);
                soundSettings.SetActive(true);

				backButtonId = 5;
				break;
		}
	}
}
