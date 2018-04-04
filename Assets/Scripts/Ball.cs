using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public AudioClip wallBounce;
    public AudioClip breakableBlockBounce;
    public AudioClip unbreakableBlockBounce;
    public AudioClip loseFloorFall;
    public AudioClip paddleBounce;

    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButton(0)) {
                hasStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        switch(collision.gameObject.tag) {
            case "Wall":
                audioSource.clip = wallBounce;
                break;
            case "Breakable":
                audioSource.clip = breakableBlockBounce;
                break;
            case "Unbreakable":
                audioSource.clip = unbreakableBlockBounce;
                break;
            case "LoseFloor":
                audioSource.clip = loseFloorFall;
                break;
            case "Paddle":
                audioSource.clip = paddleBounce;
                break;
        }
        if (hasStarted) {
            audioSource.Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

}
