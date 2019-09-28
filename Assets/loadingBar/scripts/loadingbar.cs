using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour {

    public static loadingbar instance;
    private RectTransform rectComponent;
    private Image imageComp,parentImage;
    public float speed = 0.0f;
    GameObject pickedItem;

    // Use this for initialization
    void Start () {
        
        instance = this;
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        parentImage = this.transform.parent.gameObject.GetComponent<Image>();
        parentImage.gameObject.SetActive(false);
        imageComp.gameObject.SetActive(false);
        imageComp.fillAmount = 0.0f;
    }

    public void load(float speed , GameObject item){
        print("loading");
        PlayerAnimator.instance.SetPickingAnimation();
        pickedItem=item;
        imageComp.gameObject.SetActive(true);
        parentImage.gameObject.SetActive(true);
        imageComp.fillAmount = 0.0f;
        StartCoroutine(loading(speed));
    }
    public void stop(){
        print("Stopped");
        imageComp.gameObject.SetActive(false);
        parentImage.gameObject.SetActive(false);
        imageComp.fillAmount = 0.0f;
    }
    void finished(){
        print("finished");
        stop();
        PlayerAnimator.instance.SetIdle();
        previewSelected.instance.RemoveImage(pickedItem.GetComponent<ObjectStatus>().getName());
        //previewSelected.instance.HidePreview();
        Equipments.instance.AddItem(pickedItem.GetComponent<ObjectStatus>().getName());
        Destroy(pickedItem);
    }
    IEnumerator loading(float speed)
    {
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount +  speed;
            
        }
        else
        {
            finished();
            
        }
        yield return new WaitForSeconds(.1f);
        StartCoroutine(loading(speed));
    }
    /*
    
        void Update()
        {
            if (imageComp.fillAmount != 1f)
            {
                imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
                
            }
            else
            {
                imageComp.fillAmount = 0.0f;
                
            }
        }
     */
}
