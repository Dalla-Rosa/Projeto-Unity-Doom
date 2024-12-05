using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isAmmo;
    public bool isArmor;
    public bool isHealth;
    public int amount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Stop();
                audioSource.Play();
            }
            if (isAmmo)
            {
                GunPlayer gunPlayer = other.GetComponentInChildren<GunPlayer>();
                if (gunPlayer != null)
                {
                    gunPlayer.GiveAmmo(amount, this.gameObject);
                }

            }

           
            if (isArmor)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.GiveArmor(amount, this.gameObject);
                }

            }

            
            if (isHealth)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.GiveHealth(amount, this.gameObject);
                }

            }

            Destroy(gameObject);
        }
    }
}
