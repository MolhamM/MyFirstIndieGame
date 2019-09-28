using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipments : MonoBehaviour
{
    public static Equipments instance;
    Dictionary<string,int> items = new Dictionary<string,int>();
    int limit ;
    List<Image> allImages = new List<Image>(); 
    List<Image> availableImages = new List<Image>();
    void Start()
    {
        instance = this;
        InitializeImages();
    }
    public void AddItem(string itemName){
        if(items.Count < limit){
            if(items.ContainsKey(itemName)){
                items[itemName]++;
            }else{
                Sprite itemSprite;
                itemSprite = Resources.Load<Sprite>("Sprites/"+itemName);
                if(itemSprite !=null ){
                    if(availableImages.Count > 0){
                        availableImages[0].sprite = itemSprite;
                        availableImages[0].gameObject.SetActive(true);
                        availableImages.RemoveAt(0);
                    }else{
                        print("something weird there is no avaialable images ");
                    }
                }else{
                    print("cannot load the sprite with name : "+itemName);
                }
                items.Add(itemName,1);
            }
            SetText(itemName , items[itemName]);
        }else{
            print("the bag is full");
        }
        ShowItems();
    }
    void SetText(string itemName , int counts){
        foreach (Image item in allImages)
        {
            if(item.sprite != null){
                print ("sprite not null its name is "+item.sprite.name);
                print("we;re searching for + "+ itemName);
                if(item.sprite.name == itemName){
                    print("found the same sprite name : "+item.sprite.name );
                    foreach (Transform child in item.gameObject.transform)
                    {
                        if(child.gameObject.GetComponent<Text>() != null ){
                            child.gameObject.GetComponent<Text>().text = counts.ToString();
                        }
                    } 
                    break;
                }
            }
        }
    }
    void ShowItems(){
        print("showing items");
        foreach (var item in items)
        {
            print(item.Key+" : "+item.Value);
        }
    }
    void InitializeImages(){
        GameObject itemsBag;
        itemsBag = GameObject.Find("Canvas/Items");
        if(itemsBag != null ){
            
            limit = 0;
            foreach (Transform child in itemsBag.transform)
            {
                if(child.gameObject.GetComponent<Image>() != null ){
                    allImages.Add(child.gameObject.GetComponent<Image>()) ;
                    availableImages.Add(child.gameObject.GetComponent<Image>());
                    child.gameObject.SetActive(false);
                    limit ++;
                }
            }
        }else{
            print("couldn't load Items game object");
        }
    }
}
