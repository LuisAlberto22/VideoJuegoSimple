using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controller : MonoBehaviour
{
    public personaje player;
    public health health;
    public int MaxCoins;
    public cont cont;
    public Text countText;
    public GameObject canvas;

    void Update()
    {
		if (cont.count == MaxCoins)
		{
            player.enabled = false;
            health.enabled = false;
            canvas.SetActive(true);
		} 
    }

    public void dificult(int coins)
    {
        player.enabled = true;
        MaxCoins = coins;
        countText.text = "0/" + MaxCoins;
    }

}
