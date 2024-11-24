using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;
    void Start()
    {
        Health = 100f;
        
        
    }

    void Update()
    {
        




    }

    public void GetDamage (float Damage) {
    
        Health -= Damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
