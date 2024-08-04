using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class HealBar : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI HealNumber;
    [SerializeField] Image Heal;

    void Start()
    {
    }

    // Update is called once per frame
    public void UpdateHealBar(int healCurrent, int healMax){
        Heal.fillAmount =(float) healCurrent/healMax;
        HealNumber.text = healCurrent.ToString()+" / "+ healMax.ToString();
    }
}
