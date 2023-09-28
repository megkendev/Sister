using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHP;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void doDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
