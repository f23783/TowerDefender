using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]private Vector2 towerPos;
    private EnemyStats enemyStats;
    [SerializeField]private LayerMask attackLayer;
    [SerializeField]private float attackCooldown;                 
    [SerializeField]private float attackTimer = 0f;  

    private void Start() {
        towerPos = TowerStats.instance.towerPos;
        enemyStats = gameObject.GetComponent<EnemyStats>();
        attackCooldown = 1f / enemyStats.enemySO.attackSpeed;
    }
    private void Update() {
        attackTimer += Time.deltaTime;
        Attack();
    }

    private void Attack()
    {
        Collider2D hitEnemies = Physics2D.OverlapCircle(transform.position, enemyStats.enemySO.attackRange, attackLayer);

        if (hitEnemies.CompareTag("Tower") && attackTimer >= attackCooldown)
        {
            TowerStats.instance.towerHealth -= enemyStats.enemySO.attackDamage;
            attackTimer = 0f;
        }
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyStats.enemySO.attackRange);
    }
}
