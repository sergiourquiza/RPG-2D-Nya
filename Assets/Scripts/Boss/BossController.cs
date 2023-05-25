
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    #region Public Properties
    public float WakeUpDistance = 1f;
    public float Speed = 5f;
    public float AttackDistance = 0.5f;
    

    #endregion

    #region Public Components
    public Transform Player;
    public SpriteRenderer spriteRenderer { get; private set; }

    public Rigidbody2D rb { get; private set; }

    public Animator animator { get; private set; }
    public bool AttackingEnd { get; set; } = false;
    public Transform hitBox { get; set; }

    #endregion

    #region Private Properties
    private FSM<BossController> mFSM;

    #endregion

    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hitBox = transform.Find("Hitbox");

        // Creo la maquina de estado finita
        mFSM = new FSM<BossController>(new Boss.BossIdleState(this));
        mFSM.Begin();
        
    }

    private void FixedUpdate(){
        mFSM.Tick(Time.fixedDeltaTime);
    }

    public void SetAttackingEnd(){
        AttackingEnd = true;
    }

    public void OnTriggerEnter2D(Collider2D other){
        
    }

    
}
