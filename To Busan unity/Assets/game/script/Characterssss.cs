using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterssss : MonoBehaviour
{
   /* public Camera Cam1;
    public Camera Cam2;
    public Camera Cam3;
 
    private bool state;


    void Start()
    {
        state = true;
    }


    void Update()
    {
       if (Input.GetMouseButtonDown(1))
        {
            if (state == true)
            {
               
               light1.intensity += 1;
              // light2.OuterRadiusSize += 1;
                Cam1.orthographicSize += 1;
                Cam2.orthographicSize += 1;
                Cam3.orthographicSize += 1;
                state = false;
            }
            else
            {
                //light1.InnerRadiusSize -= 1;
               // light2.OuterRadiusSize -= 1;
                Cam1.orthographicSize -= 1;
                Cam2.orthographicSize -= 1;
                Cam3.orthographicSize -= 1;
                state = true;
            }

        }
        
     }
   */

         private bool state;
         public GameObject Target;

         void Start()
         {
             state = true;
         }


         void Update()
         {
             if(Input.GetMouseButtonDown(1))
             {
                 if(state==true)
                 {
                     Target.SetActive(false);
                     state = false;
                 }
                 else
                 {
                     Target.SetActive(true);
                     state = true;
                 }
             }


         }
    }
