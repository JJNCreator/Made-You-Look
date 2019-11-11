using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour {
	public ParticleSystem greenSmoke;

	private void OnEnable()
	{
		greenSmoke.Play();
	}
}
