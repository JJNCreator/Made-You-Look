using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour {

	private void OnMouseUp() {
		if(RoomManager.Instance.hasTVRemoteEquipped) {
			if (RoomManager.Instance.isInTrapDoorArea)
            {
                if (InventoryManager.Instance.InventoryContains("TV Remote") &&
                   InventoryManager.Instance.InventoryContains("Jumping Boots"))
                {
                    StartCoroutine(RoomManager.Instance.FallIntoPit());
                }
            }
		}
		else {
			RoomManager.Instance.PlayErrorSound();
		}
	}
}
