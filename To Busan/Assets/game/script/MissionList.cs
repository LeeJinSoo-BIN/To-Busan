using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MissionList : MonoBehaviour, IPointerClickHandler
{


    private float openSize = 1;
    public RectTransform partList;

    private bool isOpen = true;
    private float timer;


    public void OnPointerClick(PointerEventData evenData)
    {
        StopAllCoroutines();
        StartCoroutine(OpenList());
        Debug.Log("clicked");
    }



    private IEnumerator OpenList()
    {

        isOpen = !isOpen;
        if (timer != 0f)
        {
            timer = 1f - timer;
        }

        while (timer <= 1f)
        {
            timer += Time.deltaTime * 2f;

            float start = isOpen ? -partList.localScale.y : openSize;
            float dest = isOpen ? openSize : -partList.localScale.y;
            partList.localScale = new Vector3(partList.localScale.x, Mathf.Lerp(start, dest, timer), partList.localScale.z);

            yield return null;
        }


    }
}
