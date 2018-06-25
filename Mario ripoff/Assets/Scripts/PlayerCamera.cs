using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Vector3 spawnVariance;
    public Vector2 exeeding;

    public GameObject player;
    private GameObject originalPlayerPosition;

    void Start()
    {
        transform.position = player.transform.position + spawnVariance;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            if (player.transform.position.x < transform.position.x + spawnVariance.x - exeeding.x)
            {
                MoveWithObject(player.GetComponent<Lopen>(), -1.0f);
            }
            else if (player.transform.position.x > transform.position.x - spawnVariance.x + exeeding.x)
            {
                MoveWithObject(player.GetComponent<Lopen>(), 1.0f);
            }
        }
    }

    public void MoveWithObject(Lopen toFollow, float movedir)
    {
        transform.Translate(new Vector3(movedir, 0, 0) * toFollow.speed * Time.deltaTime);
    }
}
