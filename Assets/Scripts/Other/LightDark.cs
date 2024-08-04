using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightDark : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float speedRotation;
    [SerializeField] float speedLight;

    [SerializeField] Light2D GlobalLight;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, speedRotation * Time.deltaTime);
        // if(transform.rotation.z >= angle + 180){
        //         isIncrease = !isIncrease;
        //         angle += 180;
        //         Debug.Log("FLIP");
        // }

        if (transform.rotation.eulerAngles.z >=0 && transform.rotation.eulerAngles.z <=180){
            GlobalLight.intensity -= speedLight * Time.deltaTime;
        } 
        else{
            GlobalLight.intensity += speedLight * Time.deltaTime;
        }

    }

}
