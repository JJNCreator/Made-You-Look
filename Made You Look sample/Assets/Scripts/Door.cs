using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	private void OnMouseUp()
	{
		if(Vector3.Distance(RoomManager.Instance.playerCharacter.transform.position, transform.position) < 1.5f) {
			if (InventoryManager.Instance.InventoryContains("Final Key"))
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    SceneManager.LoadScene(2);
                }
                else if (SceneManager.GetActiveScene().buildIndex == 2)
                {
					//Change this to 3 once level 3 is ready
                    SceneManager.LoadScene(3);
                }
				else if (SceneManager.GetActiveScene().buildIndex == 3)
				{
					SceneManager.LoadScene(0);
				}
            }
		}
	}
}
