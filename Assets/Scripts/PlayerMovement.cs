using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

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
    private Transform hitBoxT;
    private CapsuleCollider2D mCollider;
    private SwordAttack swordAttack;
    private Slider mSlider;
    private TextMeshProUGUI mText;
    public bool isTransformed = false;

    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mPlayerInput = GetComponent<PlayerInput>();
        hitBox = transform.Find("Hitbox");
        hitBoxT = transform.Find("TransfHitBox");
        ConversationManager.Instance.OnConversationStop += OnConversationStopDelegate;
        GameManager.Instance.OnPlayerHitBoss += OnPlayerHitBossDelegate;
        swordAttack = GetComponent<SwordAttack>();
        mText = transform.Find("CanvaText").Find("TransformationText").GetComponent<TextMeshProUGUI>();
        mText.gameObject.SetActive(false);
    }

    private void OnPlayerHitBossDelegate(object sender, EventArgs e)
    {
        isTransformed = true;
        mText.gameObject.SetActive(true);
    }

    private void OnConversationStopDelegate()
    {
        mPlayerInput.SwitchCurrentActionMap("Player");
    }

    private void Update()
    {
        if (mDirection != Vector3.zero)
        {
            mAnimator.SetBool("IsMoving", true);
            mAnimator.SetFloat("Horizontal", mDirection.x);
            mAnimator.SetFloat("Vertical", mDirection.y);
        }
        else
        {
            mAnimator.SetBool("IsMoving", false);
        }

        Transformacion();
    }

    public void FixedUpdate()
    {
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
        if (value.isPressed)
        {
            ConversationManager.Instance.NextConverstaion();
        }
    }

    public void OnCancel(InputValue value)
    {
        if (value.isPressed)
        {
            ConversationManager.Instance.StopConversation();
        }
    }

    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            mAnimator.SetTrigger("Attack");
            hitBox.gameObject.SetActive(true);
            swordAttack.StartAttack();
            Debug.Log("Attack");
        }
        else
        {
            swordAttack.StopAttack();
        }
    }

    public void DisableHitBox()
    {
        hitBox.gameObject.SetActive(false);
    }

    public void DisableTHitBox()
    {
        hitBoxT.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Conversation conversation;
        if (other.transform.TryGetComponent<Conversation>(out conversation))
        {
            mPlayerInput.SwitchCurrentActionMap("Conversation");
            ConversationManager.Instance.StartConverstaion(conversation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Playerr"))
        {
            Debug.Log("LE PEGUE AL PLAYER MANITO");
            GameManager.Instance.PlayerDamage();
        }
        else if (isTransformed && collision.CompareTag("Boss"))
        {
            GameManager.Instance.PlayerHitBoss();
            GameManager.Instance.PlayerHitBoss(); 
            Debug.Log("LE PEGUE AL BOSS PERO x2");
        }
        
    }

    private void Transformacion()
    {
        if (Keyboard.current.leftCtrlKey.wasPressedThisFrame)
        {
            isTransformed = !isTransformed;
            swordAttack.StartAttack();
            mText.gameObject.SetActive(isTransformed);
            mAnimator.SetBool("Tranformation", isTransformed);
            Debug.Log("Transformacion");
        }
    }
}




