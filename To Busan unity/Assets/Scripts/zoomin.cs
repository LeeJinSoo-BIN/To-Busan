using UnityEngine;

public class zoomin : MonoBehaviour


{
   
    public Camera Cam1;
    public Camera Cam2;
    public Camera Cam3;

    void Start()
    {
       
    }

    void Update()
    {
        
        var scroll = Input.mouseScrollDelta.y * Time.deltaTime * 10;
        Debug.Log(scroll);

        if (Cam1.orthographicSize > 0)
        {
            float k = Cam1.orthographicSize + scroll;
            if (k > 1&&k<3)
            {
                Cam1.orthographicSize += scroll;
                Cam2.orthographicSize += scroll;
                Cam3.orthographicSize += scroll;

            }

        }
    }
}