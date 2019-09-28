using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    
    GameObject selection;
    void OnMouseEnter()
    {
        print("TheMouse Is Entered on me !" );
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            selection = hit.transform.gameObject;
            print(selection.name);
            if(selection.GetComponent<Outline>() != null ) {
                selection.GetComponent<Outline>().enabled = true;
            }
        }
    }
    void OnMouseExit()
    {
        if(selection.GetComponent<Outline>() != null ) {
            selection.GetComponent<Outline>().enabled = false;
        }
    }
}
