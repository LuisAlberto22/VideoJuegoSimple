using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badPart : MonoBehaviour
{
	AudioSource audio;
	health player;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
	}

	private void OnTriggerStay(Collider other)
	{
		player = other.gameObject.GetComponent<health>();
		if (player != null)
		{
			player.takeDamage(1);
			if (!audio.isPlaying)
			{
				audio.Play();
			}
		}
	}
}
