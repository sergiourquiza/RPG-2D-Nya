using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwordBoss : MonoBehaviour
{
    public int damageAmount = 10;
    private bool isAttacking = false;

   private void OnTriggerEnter2D(Collider2D collision)
{
    if (isAttacking && collision.CompareTag("Player"))
    {
        GameManager.Instance.PlayerDamage();
        Debug.Log("LE PEGUE AL PLAYER MANITO");
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