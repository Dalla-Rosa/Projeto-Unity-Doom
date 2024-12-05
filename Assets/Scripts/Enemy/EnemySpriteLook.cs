using UnityEngine;

public class EnemySpriteLook : MonoBehaviour
{

    private Transform target;
    public bool CanLookVertically;

    void Start()
    {
        target = FindFirstObjectByType<PlayerMovement>().transform;
    }


    void Update()
    {
        if (CanLookVertically)
        {
            transform.LookAt(target);
        }
        else
        {
            Vector3 modifiedTarget = target.position;
            modifiedTarget.y = transform.position.y;

            transform.LookAt(modifiedTarget);
        }
    }
}
