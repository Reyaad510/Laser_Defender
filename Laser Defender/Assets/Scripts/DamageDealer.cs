using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] int damage = 100;

    public int GetDamage()
    {
        return damage;
    }


    public void Hit()
    {
        Destroy(gameObject);
    }
}


// To fix enemy projectile killing enemies, etc. Go to setting, project settings and physics 2d. Go to layers and make enemy projectile, player projectile, enemy, and player. Then for the prefabs assign them accordingly. Then in physics 2d settings look how they are checked or not checked