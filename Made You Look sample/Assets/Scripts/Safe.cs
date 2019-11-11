using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour {
	public bool usesKey = false;

	private Animator ani;
	private AudioSource audioS;

	private void Awake()
	{
		ani = GetComponent<Animator>();
		audioS = GetComponent<AudioSource>();
	}

	private void OnMouseUp()
	{
		if(Vector3.Distance(RoomManager.Instance.playerCharacter.transform.position, transform.position) < 1.5f) {
			if(usesKey) {
				if (InventoryManager.Instance.InventoryContains("Key"))
                {
                    ani.SetTrigger("OpenSafe");
                    audioS.Play();
                    InventoryManager.Instance.RemoveInventoryItem("Key", InventoryButton.ItemType.None);
                    RoomManager.Instance.hasOpenedSafe = true;
                }
				else
				{
					RoomManager.Instance.PlayErrorSound();
				}
			}
		}
	}
	public void OpenSafeViaPasscode() {
		ani.SetTrigger("OpenSafe");
		audioS.Play();
		RoomManager.Instance.hasOpenedSafeInRoomThree = true;
	}
}
