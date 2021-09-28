using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour {
	private Animator ani;
	private AudioSource audioS;

	private void Awake()
	{
		ani = GetComponent<Animator>();
		audioS = GetComponent<AudioSource>();
	}

	private void OnMouseUp()
	{
		float distance = 0f;
        
		distance = Vector3.Distance(RoomManager.Instance.playerCharacter.transform.position, transform.Find("Desk_Door").position);

		//Debug.Log("Distance between objects: " + distance);

		if(distance < 2f) {
			if(RoomManager.Instance.hasGottenScroll) {
				Open();
				RoomManager.Instance.hasOpenedDesk = true;
			}
			else {
				//Debug.LogWarning("You don't have the scroll.  This can't be opened yet.");
			}
		}
	}
	private void Open() {
		audioS.Play();

		ani.SetTrigger("OpenDesk");
	}
}
