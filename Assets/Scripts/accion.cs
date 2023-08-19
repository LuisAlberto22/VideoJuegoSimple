using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accion : MonoBehaviour
{
    public GameObject[] Trunks;
	AudioSource Audio;
	ParticleSystem ParticleSystem;

	private void Start()
	{
		Audio = GetComponent<AudioSource>();
		ParticleSystem = GetComponentInParent<ParticleSystem>();
	}
	// Update is called once per frame
	void Update()
    {
		transform.Rotate(new Vector3(200, 200, 200) * Time.deltaTime);
	}
	public void reproducir(float inicio , float final)
	{
		Audio.PlayDelayed(inicio);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Audio.time = 1f;
			if (!Audio.isPlaying)
			{
				Audio.Play();
			}
			foreach (var item in Trunks)
			{
				item.SetActive(true);
			}
			ParticleSystem.Stop();
			GetComponent<SphereCollider>().enabled = false;
			GetComponent<Renderer>().enabled = false;
		}
	}
}
