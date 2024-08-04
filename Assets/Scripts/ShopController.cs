using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    [SerializeField] GameObject ShopG;
    [SerializeField] GameObject ButtonShow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowShop(){
        ShopG.SetActive(true);
        ButtonShow.SetActive(false);
    }

     public void HideShop(){
        ShopG.SetActive(false);
        ButtonShow.SetActive(true);
    }
}
