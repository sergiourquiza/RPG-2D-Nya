using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class SwordBoss : MonoBehaviour
{
    public int damageAmount = 10;
    private bool isAttacking = false;

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Playerr"))
        {
            Debug.Log("LE PEGUE AL PLAYER MANITO");
            GameManager.Instance.PlayerDamage();
        }
        else if (collision.CompareTag("NPC"))
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