using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Bag;
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
        Bag.SetActive(true);
        ButtonShow.SetActive(false);
    }

     public void HideShop(){
        Bag.SetActive(false);
        ButtonShow.SetActive(true);
    }
}
