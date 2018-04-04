using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] blockSprites;
    public int maxHits = 1;

    private int timesHit;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        int random = Random.Range(0, blockSprites.Length);
        GetComponent<SpriteRenderer>().sprite = blockSprites[random];
        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionExit2D(Collision2D collision) {
        timesHit++;
        if (timesHit >= maxHits) {
            Destroy(gameObject);
        }
    }

    void SimulateWin() {
        gameManager.LoadNextScene();
    }

}
