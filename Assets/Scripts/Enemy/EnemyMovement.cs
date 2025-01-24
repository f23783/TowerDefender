using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private Vector3 towerTransform;
    private Rigidbody2D rb;
    private float speed;
    private Vector3 towerPos;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;   
    }

    void Start()
    {
        towerPos = TowerStats.instance.towerPos;
        speed = GetComponent<EnemyStats>().enemySO.speed;
    }

    private void Update() {
        towerTransform =  towerPos - transform.position;
        towerTransform.Normalize();
    }

    void FixedUpdate() 
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        transform.position += towerTransform * speed * Time.deltaTime;
    }
}
