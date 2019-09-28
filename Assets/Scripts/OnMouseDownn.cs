using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class OnMouseDownn : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler  
{
    [SerializeField]
    UnityEngine.UI.Outline outerLine;
    UnityEngine.UI.Outline outerLine2;
    private float ratio = 1.2f;
    void Start(){
        outerLine.enabled = false;
        outerLine2 = this.gameObject.AddComponent(typeof(UnityEngine.UI.Outline)) as UnityEngine.UI.Outline;
        outerLine2.enabled = false;
        ConfigureOutLine();
    }
    void ConfigureOutLine(){
        outerLine2.effectColor  = outerLine.effectColor ;
    }
    public void ChangeRatio(float val)
    {
        ratio = val;
    }
    public void OnPointerEnter(PointerEventData eventData)
     {
        outerLine.enabled =outerLine2.enabled = true;
        Vector3 scale =gameObject.GetComponent<RectTransform>().localScale;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(scale.x* ratio, scale.y * ratio, scale.z );
     }
     public void OnPointerExit(PointerEventData pointerEventData)
    {
        outerLine.enabled =outerLine2.enabled = false;
        Vector3 scale = gameObject.GetComponent<RectTransform>().localScale;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(scale.x / ratio, scale.y / ratio, scale.z);
    }
    public void onMouseEnter()
    {
        outerLine.enabled =outerLine2.enabled = true;
        Vector3 scale =gameObject.GetComponent<RectTransform>().localScale;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(scale.x* ratio, scale.y * ratio, scale.z );
    }
    public void onMouseExit()
    {
        outerLine.enabled =outerLine2.enabled = false;
        Vector3 scale = gameObject.GetComponent<RectTransform>().localScale;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(scale.x / ratio, scale.y / ratio, scale.z);
    }
}
