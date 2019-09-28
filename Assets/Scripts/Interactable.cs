using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 5f;
    CapsuleCollider collider;
    bool isFocused = false,isTriggered = false;
    Transform player;

    void Start()
    {
        collider = this.GetComponent<CapsuleCollider>();
    }
    /*
        void Update()
        {
            if(isFocused){
                float distance = Vector3.Distance(player.position , transform.position);
                print("focused distance is "+distance);
                print("collider off set is "+ (collider.radius+0.5f));
                if(collider != null){
                    if(distance <= (collider.radius+.5f)){
                        print("GetSomething from "+this.gameObject.name);  
                    }
                }
            }
        }
    */
    void OnTriggerEnter(Collider other)
    {
        print("triggered");
        isTriggered = true;
        ObjectStatus obStatus = this.GetComponent<ObjectStatus>();
        if(obStatus != null){
            previewSelected.instance.AddImage(obStatus.getName());
            //previewSelected.instance.ShowPreview(obStatus.getName());
        }else{
            print("please Attach objectstatus to the object");
        }
    }
    void OnTriggerExit(Collider other)
    {
        print("out of triggering");
        loadingbar.instance.stop();
        ObjectStatus obStatus = this.GetComponent<ObjectStatus>();
        if(obStatus != null){
            previewSelected.instance.RemoveImage(obStatus.getName());
            //previewSelected.instance.ShowPreview(obStatus.getName());
        }else{
            print("please Attach objectstatus to the object");
        }
        //previewSelected.instance.HidePreview();
        isTriggered = false;
    }
    
    public void OnFocus(Transform playerTransform) {
        isFocused = true;
        print("focusing me "+this.gameObject.name);
        player = playerTransform;
        if(isTriggered){
           print("GetSomething from "+this.gameObject.name);
           ObjectStatus objStatus = this.gameObject.GetComponent<ObjectStatus>();
           if(objStatus != null ){
               if(objStatus.isObjectPickable()){
                    loadingbar.instance.load(objStatus.pickingRateSpeed(),this.gameObject);
                }
           }else{
               print("please make sure that the clicked object contains ObjectStatus script");
           }
             
        }
    }
    public void OnDeFocus(){
        isFocused = false;
        player = null;
    }
    /*
     void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,radius);    
    }
    */
}
