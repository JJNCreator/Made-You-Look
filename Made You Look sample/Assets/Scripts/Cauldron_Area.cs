using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron_Area : MonoBehaviour {

	private void OnMouseUp()
	{
		Debug.Log("OnMouseUp");

		if(RoomManager.Instance.hasGottenCauldron) {
			if(Vector3.Distance(RoomManager.Instance.playerCharacter.transform.position, transform.position) < 2f) {
				RoomManager.Instance.cauldron2.SetActive(true);
				InventoryManager.Instance.RemoveInventoryItem("Cauldron", InventoryButton.ItemType.Cauldron);
			}
		}
	}
}
