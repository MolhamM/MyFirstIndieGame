using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseDownScript : MonoBehaviour
{
    void Start()
    {
        print("Started");
    }
   void OnMouseDown()
   {
       print("Down");
   }
   void OnMouseUp()
   {
       print("Up");
   }
   void OnMouseEnter()
   {
       print("Enter");
   }
   void OnMouseExit()
   {
       print("Exit");
   }
}
