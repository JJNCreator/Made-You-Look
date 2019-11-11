using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDoorShelf : MonoBehaviour {
	private Animator ani;
	private AudioSource audioS;

	private void Awake()
	{
		ani = GetComponent<Animator>();
		audioS = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		RoomManager.Instance.inputFieldForTwoDoorShelf.SetActive(true);
	}
	private void OnTriggerExit(Collider other)
	{
		RoomManager.Instance.inputFieldForTwoDoorShelf.SetActive(false);
	}

	public void OpenAnimation() {
		GetComponent<SphereCollider>().enabled = false;

		audioS.Play();

		ani.SetTrigger("OpenDoors");
	}
}
