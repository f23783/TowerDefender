using UnityEngine;

public class TowerStats : MonoBehaviour
{
    public static TowerStats instance;
    public float towerMaxHealth;
    public float towerHealth;
    public Vector2 towerPos;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        towerHealth = towerMaxHealth;
        towerPos = transform.position;
    }
}
