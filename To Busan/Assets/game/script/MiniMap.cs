using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform mapLeft;
    public Transform mapRight;
    public Transform mapTop;
    public Transform mapBottom;


    public Transform playerCharacterTransform;

    public RectTransform miniMapCharacterRectTransform;
    public RectTransform miniMapImage;

    private Vector2 mapPosition;
    void Start()
    {
        mapPosition = new Vector2(Vector3.Distance(mapLeft.position, mapRight.position),
                                  Vector3.Distance(mapTop.position, mapBottom.position));        

    }
    // Update is called once per frame
    void Update()
    {

        Vector2 charPosition = new Vector2((playerCharacterTransform.position.x - mapLeft.position.x),
                                           Vector3.Distance(mapBottom.position, new Vector3(0f, playerCharacterTransform.position.y, 0f)));

        Vector2 relativePosition = new Vector2(charPosition.x / mapPosition.x, charPosition.y / mapPosition.y);

        Debug.Log(charPosition);
        miniMapCharacterRectTransform.anchoredPosition = new Vector2(miniMapImage.sizeDelta.x * relativePosition.x,
                                                                      miniMapImage.sizeDelta.y * relativePosition.y);


        
    }
}
