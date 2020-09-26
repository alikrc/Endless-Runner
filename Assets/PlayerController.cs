using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    bool isPlayerOnGround = true;
    Animator animator;
    AudioSource playerAudio;
    public float jumpForce = 10;
    public bool gameOver;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameOver = false;
        isPlayerOnGround = true;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).tapCount > 0)) && isPlayerOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isPlayerOnGround = false;
            animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isPlayerOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1f);
            gameOver = true;
            dirtParticle.Stop();
        }
    }
}

