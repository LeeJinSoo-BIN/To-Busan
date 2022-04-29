using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{


    public float dayTime = 30f;
    public float nightTime = 40f;
    private float time = 0f;
    public bool nowDay = true;
    public GameObject clock;
    public GameObject sight;
    public float extensSight = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        if(nowDay){
            clock.transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200*(time/dayTime));
            if(time >= dayTime){
                time = 0f;
                clock.transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
                nowDay = false;
            }
            
            //partList.localScale = new Vector3(partList.localScale.x, Mathf.Lerp(start, dest, timer), partList.localScale.z);


        }
        else{
            if(time >= nightTime){
                time = 0f;
                nowDay = true;
                clock.transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
                clock.transform.GetChild(2).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
            }
            clock.transform.GetChild(2).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200*(time/dayTime));
        }

        
    }

    void update_sight(){
        if(nowDay){
            //sight.GetComponent<Light2D>().InnerRadius += extensSight;
            //sight.GetComponent<Light2D>().OutterRadius += extensSight;
        }
    }
}
