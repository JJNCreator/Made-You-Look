using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorTriggerArea : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		RoomManager.Instance.isInTrapDoorArea = true;
	}

	private void OnTriggerExit(Collider other)
	{
		RoomManager.Instance.isInTrapDoorArea = false;
	}
}
