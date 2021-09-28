using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryButton : MonoBehaviour {
	public enum ItemType {
		XRayGoggles,
        FinalKey,
        Key,
        PowerCord,
        Hammer,
        Scroll,
        Cauldron,
        TVRemote,
        JumpingBoots,
        None
	}

	public ItemType typeOfItem;
	//public Text itemText;
	public Image itemIcon;
    
	private bool hasScrollOpen;

	public void UpdateButtonProperties(Sprite icon, ItemType type) {
		//itemText.text = text;
		itemIcon.sprite = icon;
		typeOfItem = type;
	}
	public void ExecuteItemFunction() {
		switch(typeOfItem) {
			case ItemType.XRayGoggles:
				if(RoomManager.Instance.hasPluggedIn) {
					RoomManager.Instance.UpdateRugTransparency();
				}
				break;
			case ItemType.Key:
				break;
			case ItemType.Hammer:
				RoomManager.Instance.hasHammerEquipped = !RoomManager.Instance.hasHammerEquipped;
				RoomManager.Instance.playerHammer.SetActive(RoomManager.Instance.hasHammerEquipped);
				break;
			case ItemType.PowerCord:
				break;
			case ItemType.FinalKey:
				break;
			case ItemType.Scroll:
				hasScrollOpen = !hasScrollOpen;
				if(SceneManager.GetActiveScene().name == "Level 2") {
                    RoomManager.Instance.scrollClueObject.SetActive(hasScrollOpen);
				}
				if(SceneManager.GetActiveScene().name == "Level 3") {
					RoomManager.Instance.finalCodeScrollUIObject.SetActive(hasScrollOpen);
				}
				break;
			case ItemType.TVRemote:
				RoomManager.Instance.hasTVRemoteEquipped = !RoomManager.Instance.hasTVRemoteEquipped;
				RoomManager.Instance.playerRemote.SetActive(RoomManager.Instance.hasTVRemoteEquipped);
				break;
			case ItemType.JumpingBoots:
				RoomManager.Instance.hasJumpingBootsEquipped = !RoomManager.Instance.hasJumpingBootsEquipped;

				if(RoomManager.Instance.hasJumpingBootsEquipped) {
					RoomManager.Instance.playerCharacter.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_JumpSpeed = 30f;
				}
				else {
					RoomManager.Instance.playerCharacter.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_JumpSpeed = 10f;
				}
				break;
		}
	}
}
