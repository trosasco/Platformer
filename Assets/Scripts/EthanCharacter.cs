using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]
public class EthanCharacter : MonoBehaviour
{
  private Animator animator;
  public Rigidbody rb;
  public float modifier = 1;
  private float baseModifier;
  public float jumpForce = 1;
  [Range(-2, 2)] public float speed = 0;
  private bool jump = false;
  public float turbo = 2f;

  public Text endGame;

  void Awake()
  {
    animator = GetComponent<Animator>();
    baseModifier = modifier;
  }

  void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    //
    jump = Input.GetKey(KeyCode.Space);
    animator.SetBool("Jump", jump);

    //horizontal = speed;

    //Set character rotation
    float y = (horizontal < 0) ? -90 : 90;
    Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z);
    transform.rotation = newRotation;

    //Set character animation
    animator.SetFloat("Speed", Mathf.Abs(horizontal));
    
    //Set modifier with turbo on shift
    if (Input.GetKey(KeyCode.LeftShift))
    {
      modifier = baseModifier * turbo;
    }
    else
    {
      modifier = baseModifier;
    }

    //move character
    transform.Translate(transform.right * -horizontal * modifier * Time.deltaTime);
    
  }

  void FixedUpdate()
  {
    if (jump) rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
  }


  private void OnTriggerEnter (Collider other)
  {
    if (other.gameObject.tag == "Water")
    {
      Debug.Log("WATER.");
      gameOver();
    }
  }

  private void gameOver()
  {
    Debug.Log("Level failed.");
    endGame.text = "Game Over!";
    StartCoroutine(showGameOver());

  }

  IEnumerator showGameOver()
  {
    endGame.enabled = true;
    yield return new WaitForSeconds(4f);

    endGame.enabled = false;
  }
}
