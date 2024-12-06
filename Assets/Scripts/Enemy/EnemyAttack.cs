using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int dano = 20; 
    public float intervaloDeAtaque = 1.5f; 

    private float proximoAtaque; 

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            if (Time.time >= proximoAtaque)
            {
                
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    
                    playerHealth.damagePlayer(dano);
                    Debug.Log($"Inimigo causou {dano} de dano ao jogador.");
                }

                
                proximoAtaque = Time.time + intervaloDeAtaque;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jogador entrou no alcance do inimigo.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jogador saiu do alcance do inimigo.");
        }
    }
}
