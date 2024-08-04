using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{

    [SerializeField] RectTransform BagGrid;
    [SerializeField] GameObject GunPrefab;
    [SerializeField] GameObject SlotGun;
    public int slotNumber;

    Shop shop;
    Player player;
    PointFireSpawn pointFireSpawn;
    void Start()
    {
        shop = FindObjectOfType<Shop>();
        player = FindObjectOfType<Player>();
        pointFireSpawn = FindAnyObjectByType<PointFireSpawn>();
        ListGunBought();
    }
     void UpdateContentSize(int numberGun)
    {
        // Giả sử kích thước của một item là (itemWidth, itemHeight)
        float itemWidth = GunPrefab.GetComponent<RectTransform>().rect.xMax;
        // Debug.Log("xMax = "+itemWidth);
        // float currentWidth = BagGrid.GetComponent<RectTransform>().rect.xMax;
        // Debug.Log("xMaxCurren = "+currentWidth);
        float spacing = BagGrid.GetComponent<HorizontalLayoutGroup>().spacing;
        
        // Tính tổng chiều rộng của content dựa trên số lượng item
        float contentWidth = (itemWidth*1.5f +spacing) * numberGun - itemWidth*2;
        BagGrid.sizeDelta = new Vector2(contentWidth, BagGrid.sizeDelta.y);
    }
    void ClearChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
    public void ListGunBought(){
        ClearChildren(BagGrid);
        int coutGunBought = 0;
        for(int i = 0; i<shop.ListGun.Count; i++){
            if(shop.ListGun[i].Status ==1){
                coutGunBought ++;
                var itemObject = Instantiate(GunPrefab, BagGrid);

                var image = itemObject.GetComponentInChildren<Image>();
                image.sprite = shop.ListGun[i].FrameGun;

                int index = i;
                var button = itemObject.GetComponentInChildren<Button>();
                button.onClick.AddListener(()=> AddOnclickSelectGun(button,shop.ListGun[index],index));
            }
        }
        UpdateContentSize(coutGunBought);
    }

    void AddOnclickSelectGun(Button button, Gun item, int index)
    {
        Debug.Log("Selected GUN :"+item.name);
        player.GunCurrent = item;
        player.GunSprite.GetComponent<SpriteRenderer>().sprite = item.Sprite;
        pointFireSpawn.UpdatePointFire(item.Lenght);
        
        if(slotNumber > 0){
            SlotGun.transform.GetChild(slotNumber).GetComponent<Image>().sprite = item.FrameGun;
            SlotGun.transform.GetChild(slotNumber).GetComponent<SlotGun>().Gun = item;
        }else{
            int tempN = 0;
            for(int i = 0;i< SlotGun.transform.childCount; i++){
                if(SlotGun.transform.GetChild(i).GetComponent<SlotGun>().Gun == null){
                    tempN = i;
                    break;
                }
            }
            SlotGun.transform.GetChild(tempN).GetComponent<Image>().sprite = item.FrameGun;
            SlotGun.transform.GetChild(tempN).GetComponent<SlotGun>().Gun = item;

        }


    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
