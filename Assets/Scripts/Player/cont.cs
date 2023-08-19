using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cont : MonoBehaviour
{
    public Text CoinCont;
    private int _count;
    public controller c;

    public int count
	{
        get
        {
            return _count;
        }
		set
		{
            _count += value;
            CoinCont.text = _count.ToString()+"/"+c.MaxCoins;
		}
	}
}
