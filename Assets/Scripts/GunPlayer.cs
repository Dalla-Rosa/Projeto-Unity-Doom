using UnityEngine;

public class GunPlayer : MonoBehaviour
{

    public float range;
    public float verticalRange;

    private BoxCollider gunTrigger;

    public EnemyManager enemyManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if(enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

        private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if(enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}