using UnityEngine;


[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObjects/EnemySO", order = 0)]
public class EnemySO : ScriptableObject 
{
    public int maxHealth;
    public int speed;
    public float armor;
    public float attackSpeed;
    public float attackDamage;
    public float attackRange;
    public int coinValue;
    
}

