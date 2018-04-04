using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        print("Trigger");
        gameManager.LoadScene("Lose");
    }

    void OnCollisionEnter2D(Collision2D collision) {
        print("Collision");
    }
	
}
