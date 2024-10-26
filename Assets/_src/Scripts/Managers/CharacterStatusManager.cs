using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterStatusManager : MonoBehaviour, IDamageable
{
    public Status status;

    public event Action OnTakeDamage;

    public void InitStatus(Status pStatus)
    {
        status.Health = pStatus.Health;
        status.Armor = pStatus.Armor;
        status.MagicResist = pStatus.MagicResist;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("TOMANDO " + amount + " DE DANO");

        status.Health -= amount;

        OnTakeDamage?.Invoke();

        // EVENTO AO TOMAR DANO
        // Saia sangue
        // animacao de tomar dano
        // boneco piscando
        // numero do dano
        // coisas relacionadas a tomar dano

        if (status.Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
