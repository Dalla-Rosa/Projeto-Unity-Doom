using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{

    public Material aggromat;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {

            GetComponent<MeshRenderer>().material = aggromat;

        }
    }
}
