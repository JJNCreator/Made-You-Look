using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour {
	public static RoomManager Instance;

	public enum RoomState {
		InProgress,
        Finished
	}

	private RoomState cState;
	public RoomState currentState {
		get {
			return cState;
		}
		set {
			cState = value;

			if(cState == RoomState.Finished) {
				OnRoomCompleted();
			}
		}
	}
	[Header("Universal")]
	public Light finishedLight;
    public GameObject finalChestInputField;
    public GameObject inventoryUI;
    public GameObject inventoryButtonPrefab;
	public string finalCode;
	public GameObject finalChest;
	public GameObject playerCharacter;
	public AudioSource errorAudio;

	[Header("Room One")]
	public GameObject rugObject;
	public AudioSource vaseAudio;
	public GameObject playerHammer;
	public GameObject secondPowerCord;
	public bool hasOpenedSafe = false;
	public bool hasPluggedIn = false;
	public bool hasHammerEquipped;

	[Header("Room Two")]
	public GameObject cauldron;
	public GameObject cauldron2;
	public GameObject fakeChest;
	public string codeToOpenTwoDoorShelf;
	public GameObject twoDoorShelf;
	public GameObject scrollClueObject;
	public GameObject inputFieldForTwoDoorShelf;
	public bool hasGottenScroll = false;
	public bool hasOpenedDesk = false;
	public bool hasGottenCauldron = false;

	[Header("Room Three")]
	public GameObject pitChest;
	public GameObject TVWithoutText;
	public GameObject TVWithText;
	public GameObject trapDoor;
	public GameObject safe;
	public GameObject inputFieldForSafe;
	public GameObject playerRemote;
	public GameObject finalCodeScrollUIObject;
	public string passcodeForSafe;
	public bool hasOpenedSafeInRoomThree = false;
	public bool isInTrapDoorArea = false;
	public bool hasTVRemoteEquipped;
	public bool hasJumpingBootsEquipped;


	private void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		currentState = RoomState.InProgress;

		finishedLight.color = Color.red;

	}
	
	public void EnterFinalChestCode() {
		InputField input = finalChestInputField.transform.Find("InputField").GetComponent<InputField>();
        
		if(input.text == finalCode) {
			input.text = string.Empty;
			finalChest.GetComponent<Chest>().Open();
			finalChestInputField.SetActive(false);
		}
		else {
			if (input.text != string.Empty)
            {
                PlayErrorSound();
            }		
		}
	}
    
	public void EnterTwoDoorShelfCode() {
		if(SceneManager.GetActiveScene().name == "Level 2") {
			InputField input = inputFieldForTwoDoorShelf.transform.Find("InputField").GetComponent<InputField>();

			if(input.text == codeToOpenTwoDoorShelf) {
				input.text = string.Empty;
				twoDoorShelf.GetComponent<TwoDoorShelf>().OpenAnimation();
				inputFieldForTwoDoorShelf.SetActive(false);
			}
			else {
				if(input.text != string.Empty) {
					PlayErrorSound();
				}
			}
		}
	}
	public void EnterPasscodeForSafe() {
		if(SceneManager.GetActiveScene().name == "Level 3") {
			InputField input = inputFieldForSafe.transform.Find("InputField").GetComponent<InputField>();

			if(input.text == passcodeForSafe) {
				input.text = string.Empty;
				safe.GetComponent<Safe>().OpenSafeViaPasscode();
				inputFieldForSafe.SetActive(false);
			}
			else {
				if (input.text != string.Empty)
                {
                    PlayErrorSound();
                }			
			}
		}
	}

	public IEnumerator FallIntoPit() {
		TVWithoutText.SetActive(false);
		TVWithText.SetActive(true);

		yield return new WaitForSeconds(1.5f);

		trapDoor.SetActive(false);
	}
    
	public void EquipHammer() {
		if(SceneManager.GetActiveScene().buildIndex == 1) {
			playerHammer.SetActive(true);
		}
	}
	public void EquipTVRemote() {
		if(SceneManager.GetActiveScene().name == "Level 3") {
			playerRemote.SetActive(true);
		}
	}
	void OnRoomCompleted() {
		GameSettings.UpdateUnlockedRooms();
        
		finishedLight.color = Color.green;
	}
	public void UpdateRugTransparency() {
		if(SceneManager.GetActiveScene().buildIndex == 1) {
			rugObject.GetComponent<Renderer>().material.color = new Color(0.4811321f, 0f, 0f, 0.3f);
		}
	}
	public void PlayErrorSound() {
		errorAudio.volume = GameSettings.SFXVolume;
		errorAudio.Play();
	}
	public void ReturnToMainMenu() {
		SceneManager.LoadScene(0);
	}
}
