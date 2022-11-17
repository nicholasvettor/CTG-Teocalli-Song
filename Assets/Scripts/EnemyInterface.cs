using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyInterface
{
    // Start is called before the first frame update

    public static int CurrentHealth;

    public static int MaxHealth;

    public static int MinHealth;


    public void Attack(int health, GameObject player);

    public void Damaged(int damage);

    public void Move(Vector3 to);
    
}
