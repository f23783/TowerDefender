using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemySO enemySO;
    public float health;

    private void Start() {
        health = enemySO.maxHealth;
    }
}
