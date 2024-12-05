using UnityEngine;

public class Enemy : MonoBehaviour

{
    private EnemyManager enemyManager;
    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;


    public float Health;
    public GameObject gunHitEffect;
    void Start()
    {
        Health = 2f;
        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>();

        enemyManager = FindFirstObjectByType<EnemyManager>();
    }

    void Update()
    {




        if (Health <= 0)
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }





    }

    public void GetDamage(float Damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        Health -= Damage;

    }

}
