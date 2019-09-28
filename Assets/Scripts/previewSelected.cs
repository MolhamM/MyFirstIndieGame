using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class previewSelected : MonoBehaviour
{
    Image image,woodFrame;
    Text name;
    public static previewSelected instance;
    List<string> imagePreviewSaved = new List<string>(); 
    void Start()
    {
        instance = this;
        woodFrame = this.gameObject.GetComponent<Image>();
        initializeChildren();
        ResetAlpha(0);
     
    }
    void initializeChildren()
    {
        foreach (Transform child in transform){
            if(child.gameObject.name == "Image"){
                image = child.gameObject.GetComponent<Image>();
            }else if (child.gameObject.name == "Name"){
                name = child.gameObject.GetComponent<Text>();
            }
        }
    }
    void ChangeImage(string name){
        Sprite sprite;
        sprite = Resources.Load<Sprite>("Sprites/"+name);
        if(sprite != null){
            this.name.text = name;
            this.image.sprite = sprite;
        }else{
            print("error while loading "+name );
        }
    }
    public void ShowPreview(string name){
        StopAllCoroutines();
        //print("show transparency");
        ResetAlpha(0.0f);
        ChangeImage(name);
        StartCoroutine(ShowTranscparancy());
    }
    public void HidePreview(){
        StopAllCoroutines();
        StartCoroutine(HideTranscparancy());
    }
    IEnumerator ShowTranscparancy(){
        //print("show transparency in show");
        yield return new WaitForSeconds(0.05f);
        IncreaseTrancparancy();
        if(image.color.a < 1){
            StartCoroutine(ShowTranscparancy());
        }else{
            ResetAlpha(1);
        }
    }
    IEnumerator HideTranscparancy(){
        //print("hide transparency current alpha is "+image.color.a);
        yield return new WaitForSeconds(0.05f);
        DecreaseTrancparancy();
        //print("decrease after alpha function is "+image.color.a);
        if(image.color.a > 0){
            StartCoroutine(HideTranscparancy());
        }else{
            print("Alpha reseted ");
            ResetAlpha(0);
        }
    }
    void ResetAlpha(float value){
        image.color = new Color(image.color.r,image.color.g,image.color.b,value);
        name.color = new Color(name.color.r,name.color.g,name.color.b,value);
        woodFrame.color = new Color(woodFrame.color.r,woodFrame.color.g,woodFrame.color.b,value);
    }
    void IncreaseTrancparancy(){
        image.color = new Color(image.color.r,image.color.g,image.color.b,image.color.a+0.1f);
        name.color = new Color(name.color.r,name.color.g,name.color.b,name.color.a+0.1f);
        woodFrame.color = new Color(woodFrame.color.r,woodFrame.color.g,woodFrame.color.b,woodFrame.color.b+0.1f);
    }
    void DecreaseTrancparancy(){
        print("decrease before alpha is "+image.color.a);
        image.color = new Color(image.color.r,image.color.g,image.color.b,image.color.a-0.1f);
        print("decrease after alpha is "+image.color.a);
        name.color = new Color(name.color.r,name.color.g,name.color.b,name.color.a-0.1f);
        woodFrame.color = new Color(woodFrame.color.r,woodFrame.color.g,woodFrame.color.b,woodFrame.color.b-0.1f);
    }
    public void AddImage(string imgName){
        imagePreviewSaved.Add(imgName);
        print("in add showing preview of "+imgName);
        ShowPreview(imgName);
    }
    public void RemoveImage(string imgName){
        if(imagePreviewSaved.Contains(imgName)){
            imagePreviewSaved.Remove(imgName);
            print("in remove hiding preview of "+imgName);
            HidePreview();
            if(imagePreviewSaved.Count > 0){
                ShowPreview(imagePreviewSaved[imagePreviewSaved.Count-1]);
                print("in remove showing prev preview of "+imgName);
            }
        }
    }
}
