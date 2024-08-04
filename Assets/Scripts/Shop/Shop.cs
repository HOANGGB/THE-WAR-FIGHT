using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Items")]
    public List<Gun> ListGun = new List<Gun>();
    [SerializeField] Transform ShopListItem;
    [SerializeField] GameObject item;
    Gold gold;
    Bag bag;
    void Start()
    {
        
        gold = FindObjectOfType<Gold>();
        bag = FindObjectOfType<Bag>();
        ADD();
    }
    // void AddItem(){
    //     ListItem.Add(new Item("Glock-17", 3, 0.2f,100, ListSprite[0])); 
    //     ListItem.Add(new Item("Magnum", 10, 0.5f,200, ListSprite[1]));
    //     ListItem.Add(new Item("Uzi", 5, 0.1f,500, ListSprite[2]));
    //     ListItem.Add(new Item("Mp5", 10, 0.15f,550, ListSprite[3]));
    //     ListItem.Add(new Item("Scar", 15, 0.3f,1000, ListSprite[4]));
    //     ListItem.Add(new Item("Ak-47", 20, 0.3f,1100, ListSprite[5]));
    //     ListItem.Add(new Item("M82", 30, 1f,5000, ListSprite[6]));
    //     ListItem.Add(new Item("AWM", 50, 2f,6000, ListSprite[7]));
    //     ListItem.Add(new Item("M60", 10, 0.15f,9000, ListSprite[8]));
    //     ListItem.Add(new Item("Gatting Gun", 7, 0.12f,10000, ListSprite[9]));
    // }
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            foreach(var gun in ListGun){
                gun.Status = 0;
            }
        }
    }
    public void ADD(){
        for(int i = 0; i<ListGun.Count; i++){
            var itemObject = Instantiate(item, ShopListItem);
            if(ListGun[i].Status == 1){
                var imagee = itemObject.GetComponentInChildren<Image>();
                imagee.sprite = ListGun[i].FrameGun;

                var buttonn = itemObject.GetComponentInChildren<Button>();
                buttonn.GetComponentInChildren<TextMeshProUGUI>().text = "Bought";
                continue;
            }


            var image = itemObject.GetComponentInChildren<Image>();
            image.sprite = ListGun[i].FrameGun;

            var price = itemObject.GetComponentInChildren<TextMeshProUGUI> ();
            price.text = ListGun[i].Price.ToString();

            int index = i;
            var button = itemObject.GetComponentInChildren<Button>();
            button.onClick.AddListener(()=> AddOnclick(button,ListGun[index],index));

        }
    }
    void AddOnclick(Button button,Gun item,int index){
        if(ListGun[index].Status == 1) return;
        if(PlayerPrefs.GetInt(Data.Gold) >= item.Price){
            ListGun[index].Status = 1;
            gold.SubtracGold(item.Price);
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Bought";
            bag.ListGunBought();
        }
    }
}
