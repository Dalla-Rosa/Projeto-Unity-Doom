using UnityEngine;

public class Enemy : MonoBehaviour

{
    public EnemyManager enemyManager;
    public float Health;
    public GameObject gunHitEffect;
    void Start()
    {
        Health = 2f;


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
