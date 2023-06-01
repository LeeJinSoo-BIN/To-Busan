using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public int part_num = 20;
    public int item_num = 5;

    private int chest_num;
    public GameObject chests;

    private List<string> parts = new List<string>();
    private List<string> items = new List<string>();

    private string[] part_names = new string[] { "gear", "oil", "driver", "screw", "iron" };
    private string[] item_names = new string[] { "kit", "night_vision", "scan" };

    public int require_part_num = 10;
    public GameObject mission_list;


    void Start()
    {

        chest_num = chests.transform.childCount;
        hide_parts_items();
        make_mission();

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
            parts.Add(part_name);
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

    void fill_ui()
    {
        for (int k = 0; k < mission_list.transform.childCount; k++)
        {
            mission_list.transform.GetChild(k).GetChild(0).GetComponent<TextMeshProUGUI>().text = " 0 / 0";
            mission_list.transform.GetChild(k).GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(64, 255, 64, 255);
        }

    }

    void make_mission()
    {
        if (require_part_num > part_num) require_part_num = part_num;

        fill_ui();
        for (int k = 0; k < require_part_num; k++)
        {
            int rand = Random.Range(0, parts.Count);

            TextMeshProUGUI current_text = mission_list.transform.Find(parts[rand]).GetChild(0).GetComponent<TextMeshProUGUI>();


            int goal = int.Parse(current_text.text.Split('/')[1]) + 1;
            current_text.text = string.Format(" 0 / {0,-2}", goal);
            current_text.color = new Color32(255, 255, 255, 255);


            parts.RemoveAt(rand);

        }


    }


}
