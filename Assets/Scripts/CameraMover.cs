using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform player;
    Vector3 differance;
    [SerializeField]
    bool followPlayer = false;
    [SerializeField]
    float mouseSensitivity,camSpeed;
    CharacterController camController;
    void Awake()
    {
        if(!followPlayer){
            LockCursor();
        }
    }
    void Start()
    {
        differance = this.transform.position - player.transform.position;
        camController = this.gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        if(followPlayer){
            this.transform.position = player.transform.position+differance;
        }
        else
        {
            RotateCameraWithMouse();
            MoveCameraWithKeyboard();   
        }
    }
    void RotateCameraWithMouse(){
        float mouseX , mouseY;
        Vector3 mousePosToCamera ;
        
        mouseX= Input.GetAxis("Mouse X")*mouseSensitivity;
        mouseY= Input.GetAxis("Mouse Y")*mouseSensitivity;
        
        mousePosToCamera.x= this.transform.eulerAngles.x-mouseY;
        mousePosToCamera.y= this.transform.eulerAngles.y+mouseX;
        mousePosToCamera.z= this.transform.eulerAngles.z;
        
        this.transform.rotation = Quaternion.Euler(mousePosToCamera);
    }
    void MoveCameraWithKeyboard(){
        float verticalInput =  Input.GetAxis("Vertical")*camSpeed;
        float horizontalInput =  Input.GetAxis("Horizontal")*camSpeed;

        //this.transform.position = new Vector3(transform.position.x - verticalInput , transform.position.y , transform.position.z+ horizontalInput);


        Vector3 forwardMove = transform.forward * verticalInput;
        Vector3 rightMove = transform.right * horizontalInput;

        camController.SimpleMove(forwardMove + rightMove);
    }
    void LockCursor(){
        Cursor.lockState = CursorLockMode.Locked;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        print("Collided with : "+collisionInfo);
    }
}
