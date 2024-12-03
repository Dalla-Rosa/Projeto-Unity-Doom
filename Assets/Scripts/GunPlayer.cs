using Unity.VisualScripting;
using UnityEngine;

public class GunPlayer : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;

    public float fireRate = 1;
    public float bigDamage = 2f;
    public float smallDamage = 1f;
    public LayerMask raycastLayerMask;

    private float nextTimeToFire;

    public int maxAmmo;
    private int ammo = 20;

    private BoxCollider gunTrigger;

    public EnemyManager enemyManager;

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);

        
        CanvasManager.Instance.updateAmmo(ammo);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire && ammo > 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        //Collider[] enemyColliders;
        //enemyColliders = physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if (dist > range * 0.5f)
                    {
                        
                        enemy.GetDamage(smallDamage);
                    }
                    else
                    {
                        
                        enemy.GetDamage(bigDamage);
                    }

                    Debug.DrawRay(transform.position, dir, Color.green);
                }
            }
        }

        nextTimeToFire = Time.time + fireRate;

        
        ammo--;
        CanvasManager.Instance.updateAmmo(ammo);
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        
        if (pickup == null)
        {
            Debug.LogError("Pickup não está definido! Não pode adicionar munição.");
            return; 
        }

        
        if (ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);  
        }

        
        if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        
        CanvasManager.Instance.updateAmmo(ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy)
        {
            enemyManager.AddEnemy(enemy);  
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemyManager.RemoveEnemy(enemy);  
        }
    }
}


