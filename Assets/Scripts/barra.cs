using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barra : MonoBehaviour
{
	public int damage = 10;
	public float rotation = 220f;
	AudioSource Audio;

	void Start()
	{
		Audio = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(0, rotation, 0) * Time.deltaTime);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			health player = collision.gameObject.GetComponent<health>();
			player.takeDamage(damage);
			if (!Audio.isPlaying)
			{
				Audio.Play();
			}
		}
	}
}
