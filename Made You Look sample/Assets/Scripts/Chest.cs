using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour {
	public bool isFake;

	private Animator ani;
	private AudioSource audioS;

	private void Awake()
	{
		ani = GetComponent<Animator>();
		audioS = GetComponent<AudioSource>();
	}

	private void OnMouseUp()
	{
		if(isFake) {
			Open();
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if(SceneManager.GetActiveScene().name == "Level 1") {
			RoomManager.Instance.finalChestInputField.SetActive(true);
		}
		else if (SceneManager.GetActiveScene().name == "Level 2") {
			//Put level 2 room manager code here
			RoomManager.Instance.finalChestInputField.SetActive(true);
		}
		else {
			//Put level 3 room manager code here
			RoomManager.Instance.finalChestInputField.SetActive(true);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (SceneManager.GetActiveScene().name == "Level 1")
		{
			RoomManager.Instance.finalChestInputField.SetActive(false);
		}
		else if (SceneManager.GetActiveScene().name == "Level 2")
		{
			//Put level 2 room manager code here
			RoomManager.Instance.finalChestInputField.SetActive(false);
		}
		else
		{
			//Put level 3 room manager code here
			RoomManager.Instance.finalChestInputField.SetActive(false);
		}

	}
	public void Open() {
		if(!isFake) {
			GetComponent<SphereCollider>().enabled = false;

            audioS.Play();

            ani.SetTrigger("OpenChest");
		}
		else {
			GetComponent<BoxCollider>().enabled = false;

            audioS.Play();

            ani.SetTrigger("OpenChest");
		}

	}
}
