using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay;

    private float mousePosInBlocks;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (autoPlay) {
            MoveWithBall();
        } else {
            MoveWithMouse();
        }
    }

    void MoveWithBall() {
        float ballXPosition = ball.transform.position.x;
        //mousePosInBlocks = Mathf.Clamp((Input.mousePosition.x / Screen.width * 16) - 8, -7.5f, 7.5f);
        Vector3 paddlePos = new Vector3(ballXPosition, this.transform.position.y, 0f);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse() {
        mousePosInBlocks = Mathf.Clamp((Input.mousePosition.x / Screen.width * 16) - 8, -7.5f, 7.5f);
        Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, 0f);
        this.transform.position = paddlePos;
    }

}
