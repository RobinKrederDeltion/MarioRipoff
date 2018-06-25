using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

    public static CoinManager instance;
    public Text coinPanel;
    public int totalCoins;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void IncreaseCoins(int value)
    {
        totalCoins += value;
        coinPanel.text = totalCoins.ToString();
    }
    public void DecreaseCoins(int value)
    {
        totalCoins -= value;
    }

}

