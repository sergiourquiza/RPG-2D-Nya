using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]


public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    private float speed = 4f;
    private Rigidbody2D mRb;
    private Vector3 mDirection = Vector3.zero;
    private Animator mAnimator;
    private PlayerInput mPlayerInput;
    private Transform hitBox;
    public Slider healthBar;

    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>(); 
        mPlayerInput = GetComponent<PlayerInput>(); 
        hitBox = transform.Find("Hitbox");
        ConversationManager.Instance.OnConversationStop += OnConversationStopDelegate;     
    
    }

    private void OnConversationStopDelegate()
    {
        mPlayerInput.SwitchCurrentActionMap("Player");
    }

    private void Update(){

        if(mDirection != Vector3.zero)
        {
            mAnimator.SetBool("IsMoving", true);
            mAnimator.SetFloat("Horizontal", mDirection.x);
            mAnimator.SetFloat("Vertical", mDirection.y);
        }
        else
        {
            mAnimator.SetBool("IsMoving", false);
        }


    }

    public void FixedUpdate(){

        mRb.MovePosition(
            transform.position + (mDirection * speed * Time.fixedDeltaTime)
        );
    }
    public void OnMove(InputValue movementValue)
    {
        
        mDirection = movementValue.Get<Vector2>().normalized;

    }

    public void OnNext(InputValue value)
    {
        if(value.isPressed)
        {
            ConversationManager.Instance.NextConverstaion();
        }
    }

    public void OnCancel(InputValue value)
    {
        if(value.isPressed)
        {
            ConversationManager.Instance.StopConversation();
            
        }
    }
    public void OnAttack(InputValue value)
        {
            if(value.isPressed)
            {
                mAnimator.SetTrigger("Attack");
                hitBox.gameObject.SetActive(true);
            }
        }

        public void DisableHitBox(){
            hitBox.gameObject.SetActive(false);
        }
    private void OnCollisionEnter2D(Collision2D other) {
            Conversation conversation;
           if (other.transform.TryGetComponent<Conversation>(out conversation)){

                mPlayerInput.SwitchCurrentActionMap("Conversation");
                ConversationManager.Instance.StartConverstaion(conversation);
           } 
        }

// HACERLE DAÑO A LOS MOCOS
    

}



