using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons : MonoBehaviour
{
	public health player;
	public controller controller;
	
	public void easy()
	{
		player.enabled = true;
		controller.MaxCoins = 7;
	}

	public void hard()
	{
		player.enabled = true;
		controller.MaxCoins = 12;
	}
}
