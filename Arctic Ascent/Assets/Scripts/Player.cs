using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 13f;
    [SerializeField] private Animator animate;
    [SerializeField] private Vector3 checkpoint;
    [SerializeField] private AudioSource respawn;
    [SerializeField] private AudioSource jumping;
    [SerializeField] private AudioSource collect;
    [SerializeField] private PenguinCounter pc;

    private float moveX;
    private bool grounded;
    private Rigidbody2D body;
    private SpriteRenderer sr;

    private string runAnim = "Run";
    private string jumpAnim = "Jump";

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animate = GetComponent<Animator>();
        checkpoint = transform.position;
    }

    // Update is called once per frame
    void Update() {
        keyboardPress();
        jump();
        animatePlayer();
    }

    void keyboardPress() {
        moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void jump() {
        if (Input.GetButtonDown("Jump") && grounded) {
            checkpoint = transform.position;
            jumping.Play();
            grounded = false;
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    
    void animatePlayer() {
        // Animate the direction the player is facing
        // Facing right
        if (moveX > 0) {
            sr.flipX = false;
        }
        // Facing left
        else if (moveX < 0) {
            sr.flipX = true;
        }

        // Animate actions
        // Jump and lands running
        if (!grounded)
        {
            animate.SetBool(jumpAnim, true);
        }
        // Moving left or right
        else if (grounded && moveX != 0)
        {
            animate.SetBool(runAnim, true);
            animate.SetBool(jumpAnim, false);
        }
        // Idle
        else {
            animate.SetBool(runAnim, false);
            animate.SetBool(jumpAnim, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            grounded = true;
        }
        else if (collision.gameObject.CompareTag("Hazard")) {
            respawn.Play();
            transform.position = checkpoint;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Penguin")) { 
            collect.Play();
            Destroy(other.gameObject);
            pc.penguinCount++;
        }
    }
}
