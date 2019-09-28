using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    Outline outlineScript;
   void Start(){

       if(this.gameObject.GetComponent<Outline>() != null){
            
            outlineScript = this.gameObject.GetComponent<Outline>() ;
            outlineScript.enabled = false;
       }
   }
   void OnMouseEnter()
   {
       //print("mouse Entered !");
        if(outlineScript !=null){
            outlineScript.enabled = true;
        }
        //else{
          //  print("Weird but it's null");
        //}  
   }
   void OnMouseExit()
   {
       if(outlineScript !=null){
            outlineScript.enabled =false;
        }

   }
}
