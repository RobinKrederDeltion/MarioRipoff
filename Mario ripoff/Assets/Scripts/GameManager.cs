using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static public bool isDead;
    public static GameManager instance;
    public GameObject gameOverPanel;
  



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

        gameOverPanel.SetActive(!true);
    }

    public void Death()
    {
        gameOverPanel.SetActive(true);
    }
}
