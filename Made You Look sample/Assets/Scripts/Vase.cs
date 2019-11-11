using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour {

	private void OnMouseUp()
	{
		if(RoomManager.Instance.hasHammerEquipped) {
			if (Vector3.Distance(RoomManager.Instance.playerHammer.transform.position, transform.position) < 1.5f)
            {
                if (InventoryManager.Instance.InventoryContains("Hammer"))
                {
                    RoomManager.Instance.vaseAudio.Play();
                    gameObject.SetActive(false);
                }
            }
		}
		else {
			RoomManager.Instance.PlayErrorSound();
		}
	}
}
