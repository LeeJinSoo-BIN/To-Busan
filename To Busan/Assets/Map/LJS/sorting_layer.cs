using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sorting_layer : MonoBehaviour
{
    public enum ESortingType
    {
        Static, Update
    }


    [SerializeField]
    private Transform Front;


    
    public Transform Back;

    

    [SerializeField]
    private ESortingType sortingType;



    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = GetSortingOrder(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (sortingType == ESortingType.Update)
        {
            spriteRenderer.sortingOrder = GetSortingOrder(gameObject);
        }
    }




    public int GetSortingOrder(GameObject obj)
    {
        float objDist = Mathf.Abs(Back.position.y - obj.transform.position.y);
        float totalDist = Mathf.Abs(Back.position.y - Front.position.y);

        return (int)(Mathf.Lerp(System.Int16.MinValue, System.Int16.MaxValue, objDist / totalDist));
    }
}
