using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	public enum ItemType {
		Key,
        FinalKey,
        XRayGoggles,
        PowerCord,
        Hammer,
        Scroll,
        Cauldron,
        TVRemote,
        JumpingBoots
	}

	public ItemType type;

	private void OnMouseUp()
    {
		switch(type) {
			case ItemType.FinalKey:
				InventoryManager.Instance.AddInventoryItem("Final Key", InventoryButton.ItemType.FinalKey);
                RoomManager.Instance.currentState = RoomManager.RoomState.Finished;
                gameObject.SetActive(false);
				break;
			case ItemType.Hammer:
				InventoryManager.Instance.AddInventoryItem("Hammer", InventoryButton.ItemType.Hammer);
				gameObject.SetActive(false);
				break;
			case ItemType.Key:
				InventoryManager.Instance.AddInventoryItem("Key", InventoryButton.ItemType.Key);
				gameObject.SetActive(false);
				break;
			case ItemType.PowerCord:
				InventoryManager.Instance.AddInventoryItem("Power Cord", InventoryButton.ItemType.PowerCord);
				gameObject.SetActive(false);
				break;
			case ItemType.XRayGoggles:
				if(RoomManager.Instance.hasOpenedSafe) {
					InventoryManager.Instance.AddInventoryItem("X-Ray Goggles", InventoryButton.ItemType.XRayGoggles);
                    gameObject.SetActive(false);
				}
				break;
			case ItemType.Scroll:
				InventoryManager.Instance.AddInventoryItem("Scroll", InventoryButton.ItemType.Scroll);
				RoomManager.Instance.hasGottenScroll = true;
				gameObject.SetActive(false);
				break;
			case ItemType.Cauldron:
				if(RoomManager.Instance.hasOpenedDesk) {
					InventoryManager.Instance.AddInventoryItem("Cauldron", InventoryButton.ItemType.Cauldron);
                    gameObject.SetActive(false);
					RoomManager.Instance.hasGottenCauldron = true;
				}
				break;
			case ItemType.TVRemote:
				if(RoomManager.Instance.hasOpenedSafeInRoomThree) {
					InventoryManager.Instance.AddInventoryItem("TV Remote", InventoryButton.ItemType.TVRemote);
                    gameObject.SetActive(false);
				}
				break;
			case ItemType.JumpingBoots:
				if(RoomManager.Instance.hasOpenedSafeInRoomThree) {
					InventoryManager.Instance.AddInventoryItem("Jumping Boots", InventoryButton.ItemType.JumpingBoots);
                    gameObject.SetActive(false);
				}
				break;
		}
    }
}
