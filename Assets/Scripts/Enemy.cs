using UnityEngine;

public class Enemy : MonoBehaviour

{
    public EnemyManager enemyManager;
    public float Health;
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
        Health -= Damage;

    }

}
