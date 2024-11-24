using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float playerSpeed = 10f;
    public float momentumDamping = 5f;
    private CharacterController CC;
    private Vector3 inputVector;
    private Vector3 movementVector;
    private float myGravity = -10f;
    public Animator camAnimation;  
    private bool isWalking;


    void Start()
    {
        CC = GetComponent<CharacterController>();

    }

    void Update()
    {
        
        GetInput();
        MovePlayer();
        camAnimation.SetBool("isWalking", isWalking);

    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical") );
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);

            isWalking = true;

        }
        else
        {

            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);
            isWalking = false;

        }
        
        


        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer() 
    {

        CC.Move(movementVector * Time.deltaTime);

    }
}


