using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Safe_Area : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if(SceneManager.GetActiveScene().name == "Level 3") {
			RoomManager.Instance.inputFieldForSafe.SetActive(true);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (SceneManager.GetActiveScene().name == "Level 3")
        {
            RoomManager.Instance.inputFieldForSafe.SetActive(false);
        }
	}
}
