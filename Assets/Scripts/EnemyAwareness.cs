using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 8;
    public bool isAggro;
    public Material aggroMat;
    public Transform playerTransform;


    private void Start()
    {
        playerTransform = FindFirstObjectByType <PlayerMovement>().transform;
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, playerTransform.position); 

        if (dist < awarenessRadius)
        {
            isAggro = true;  
        }

        if (isAggro)
        { 
            GetComponent<MeshRenderer>().material = aggroMat;
        }



    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {

            isAggro = true;

        }
    }
}
