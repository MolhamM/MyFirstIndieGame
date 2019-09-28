using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStatus : MonoBehaviour
{
    [SerializeField]
    bool isPickable;
    [SerializeField]
    float pickingRate;
    [SerializeField]
    string itemName;
    public bool isObjectPickable(){
        return isPickable;
    }
    public float pickingRateSpeed(){
        return pickingRate;
    }
    public string getName(){
        return itemName;
    }
}
