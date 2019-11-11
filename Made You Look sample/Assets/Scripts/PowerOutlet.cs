using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOutlet : MonoBehaviour {

	private void OnMouseUp()
	{
		if(Vector3.Distance(RoomManager.Instance.playerCharacter.transform.position, transform.position) < 1.5f) {
			if(InventoryManager.Instance.InventoryContains("Power Cord")) {
				RoomManager.Instance.hasPluggedIn = true;
				RoomManager.Instance.secondPowerCord.SetActive(true);
				InventoryManager.Instance.RemoveInventoryItem("Power Cord", InventoryButton.ItemType.None);
				InventoryManager.Instance.RemoveInventoryItem("X-Ray Goggles", InventoryButton.ItemType.None);
				RoomManager.Instance.UpdateRugTransparency();
			}
			else {
				RoomManager.Instance.PlayErrorSound();
			}
		}
	}
}
