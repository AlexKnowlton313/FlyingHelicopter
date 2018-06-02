using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetBehavior : MonoBehaviour {
    
    private GameController gameController;
    public int scoreValue = 100;
    
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "WaterDrop(Clone)")
        {
            Debug.Log("target colided with water");
            gameController.AddScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
