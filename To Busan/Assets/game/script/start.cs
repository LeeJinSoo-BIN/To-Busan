using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public int part_num = 10;
    public int item_num = 5;

    private int chest_num;
    public GameObject chests;

    private List<string> parts = new List<string>();
    private List<string> items = new List<string>();

    private string[] part_names = new string[]{ "gear", "oil", "driver", "screw", "iron" };
    private string[] item_names = new string[] { "kit", "night_vision", "scan"};
    void Start()
    {
        
        chest_num = chests.transform.childCount;
        hide_parts_items();
        

    }

    void hide_parts_items()
    {

        for (int k = 0; k < part_num; k++)
        {
            int rand = Random.Range(0, part_names.Length);
            string part_name = part_names[rand];

            rand = Random.Range(0, chest_num);
            GameObject part = new GameObject(part_name);
            part.transform.SetParent(chests.transform.GetChild(rand));
        }
        for (int k = 0; k < item_num; k++)
        {
            int rand = Random.Range(0, item_names.Length);
            string item_name = item_names[rand];

            rand = Random.Range(0, chest_num);
            GameObject item = new GameObject(item_name);
            item.transform.SetParent(chests.transform.GetChild(rand));
        }


    }
 

    
    
}
