using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
	public MeshRenderer[] MeshRenderer;
	public BoxCollider[] BoxCollider;

	MeshRenderer Mesh;
	BoxCollider Box;

	private void Start()
	{
		Mesh = GetComponent<MeshRenderer>();
		Box = GetComponent<BoxCollider>();
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "MainCamera")
		{
			foreach (var item in MeshRenderer)
			{
				item.enabled = !item.enabled;
			}
			foreach (var item in BoxCollider)
			{
				item.isTrigger = !item.isTrigger;

			}
			Mesh.enabled = !Mesh.enabled;
			Box.isTrigger = !Box.isTrigger;
		}
	}
}
