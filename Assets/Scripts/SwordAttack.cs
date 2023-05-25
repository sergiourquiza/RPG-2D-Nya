using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int damageAmount = 10;
    private bool isAttacking = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking && collision.CompareTag("Boss"))
        {
            GameManager.Instance.PlayerHitBoss();
            Debug.Log("LE PEGUE AL BOSS");
        }
        if (isAttacking && collision.CompareTag("NPC"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void StartAttack()
    {
        isAttacking = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
    }
}