using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   public float jumpForce = 10f;
   public float gravityModifier;
   public ParticleSystem particleSystem,dirtyParticle;
   public AudioClip jumpSound,CrashSound;
   public Button restartButton;

   private Rigidbody rb;
   private bool isOnGround;
  [HideInInspector] public bool gameOver;
   private Animator playerAnim;
   private AudioSource audioSource;

   private Vector3 defaultGravity;

   private void Start()
   {
      rb = GetComponent<Rigidbody>();
      playerAnim = GetComponent<Animator>();
      audioSource = GetComponent<AudioSource>();
      
      defaultGravity = Physics.gravity;
      
 
      Physics.gravity = defaultGravity * gravityModifier;
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
      {
         rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
         isOnGround = false;
         audioSource.PlayOneShot(jumpSound,1);
         playerAnim.SetTrigger("Jump_trig");
         dirtyParticle.Stop();
      }
   }

   private void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Ground"))
      {
         isOnGround = true;
         dirtyParticle.Play();

      }
      else if (other.gameObject.CompareTag("Obstacle"))
      {
         gameOver = true;
         Debug.Log("Game Over!");
         playerAnim.SetBool("Death_b",true);
         audioSource.PlayOneShot(CrashSound,1);
         playerAnim.SetInteger("DeathType_int",1);
         particleSystem.Play();
         dirtyParticle.Stop();
         restartButton.gameObject.SetActive(true);
         
      }
      
   }


   public void LoadScene()
   {
      Physics.gravity = defaultGravity;
      SceneManager.LoadScene(0);
   }
}
