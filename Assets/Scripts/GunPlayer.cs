using Unity.VisualScripting;
using UnityEngine;

public class GunPlayer : MonoBehaviour
{

    public float range;
    public float verticalRange;

    private BoxCollider gunTrigger;

    public EnemyManager enemyManager;

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
    }


    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.yellow);
        // Does the ray intersect any objects excluding the player layer
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))

            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy)
                {
                    enemy.GetDamage(10);
                }

                Debug.Log("Did Hit");
            }
            else
            {

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }   
}