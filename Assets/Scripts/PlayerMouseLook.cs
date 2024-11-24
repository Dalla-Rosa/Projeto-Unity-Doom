using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{

    public float sensitivity = 1.5f;
    public float smoothing = 10f;
    private float xMousePosition;
    private float smoothedMousePos;

    private float currentLookingPos;


    private void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    void Update()
    {
        
        GetInput();
        ModifyInput();
        MovePlayer();

    }

    void GetInput()
    {

        xMousePosition = Input.GetAxisRaw("Mouse X");

    }

    void ModifyInput()
    {

        xMousePosition *= sensitivity * smoothing;
        smoothedMousePos = Mathf.Lerp(smoothedMousePos, xMousePosition, 1f / smoothing);

    }

    void MovePlayer()
    {

        currentLookingPos += smoothedMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);

    }


}
