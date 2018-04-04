using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public Sprite oneHitSprite;
    public Sprite twoHitsSprite;
    public Sprite threeHitsSprite;
    public int currentHP = 1;

    public static int breakableBricksCount = 0;

    private bool isBreakable = false;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        isBreakable = this.tag == "Breakable";
        if (isBreakable) {
            breakableBricksCount++;
        }
        if (currentHP < 1) {
            currentHP = 1;
        } else if (currentHP > 3) {
            currentHP = 3;
        }
        RefreshSprite();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RefreshSprite() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        switch (currentHP) {
            case 1:
                if (oneHitSprite) {
                    spriteRenderer.sprite = oneHitSprite;
                }
                break;
            case 2:
                if (twoHitsSprite) {
                    spriteRenderer.sprite = twoHitsSprite;
                }
                break;
            case 3:
                if (threeHitsSprite) {
                    spriteRenderer.sprite = threeHitsSprite;
                }
                break;
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (this.tag == "Breakable") {
            HandleHit();
        }
    }

    void HandleHit() {
        currentHP--;
        if (currentHP <= 0) {
            breakableBricksCount--;
            if (breakableBricksCount <= 0) {
                gameManager.LoadNextScene();
            }
            Destroy(gameObject);
        } else {
            RefreshSprite();
        }
    }

}
