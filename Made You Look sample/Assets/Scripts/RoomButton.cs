using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour {
	public int roomId = 0;

	private Button button;

	private void Awake()
	{
		button = GetComponent<Button>();
	}

	// Use this for initialization
	void Start () {
		button.interactable = (GameSettings.unlockedRooms >= roomId);
	}
}
