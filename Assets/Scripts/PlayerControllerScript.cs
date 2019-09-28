using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControllerScript : MonoBehaviour
{
    Camera cam; 
    [SerializeField]
    LayerMask walkableLayer;
    PlayerMotor playerMotor; 
    Interactable focus;
    void Start()
    {
        cam = Camera.main;
        playerMotor = GetComponent<PlayerMotor>();
    }
    void Update()
    {
        if(Input.GetMouseButton(1)){
            MoveOnClick();
        }else if (Input.GetMouseButton(0)){
            InteractOnClick();
        }   
    }
    void MoveOnClick(){
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit , 100 , walkableLayer)){
            print("Hit "+ hit.collider.gameObject.name + " pos is "+Input.mousePosition);
            playerMotor.MoveToPoint(hit.point);
            RemoveFocus();
        }
    }
    void InteractOnClick(){
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit , 100 )){
            print("Interacted "+ hit.collider.gameObject.name );
            
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if(interactable != null ){
                SetFocus(interactable);
            }
        }
    }
    void SetFocus(Interactable newFocus){
        if(focus != newFocus){
            if(focus != null){
                focus.OnDeFocus();
            }
            focus = newFocus;
        }
        newFocus.OnFocus(transform);
        //playerMotor.MoveToPoint(newFocus.transform.position);
    }
    void RemoveFocus(){
        if(focus != null){
            focus.OnDeFocus();
        }
        focus = null;
    }
}
