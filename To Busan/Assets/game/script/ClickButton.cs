using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickButton : MonoBehaviour
{

    // Start is called before the first frame update
    public Sprite gear;
    public Sprite oil;
    public Sprite driver;
    public Sprite screw;
    public Sprite iron;
    public Sprite kit;
    public Sprite night_vision;
    public Sprite scan;
    public int maxInventory = 5;

    public GameObject mission_list;

    private List<string> part_names = new List<string>(new string[] { "gear", "oil", "driver", "screw", "iron" });

    private bool isOpenMiniMap = false;
    
    public void onClickFindButton()
    {
        charactermove Move = GameObject.Find("character").GetComponent<charactermove>();
        Move.isMoveable = false;
        GameObject foundChest = GameObject.Find("character").GetComponent<charactermove>().foundChest;
        GameObject chestui = GameObject.Find("Canvas").transform.Find("chest ui").gameObject;
        fillChest(foundChest, chestui);
        chestui.SetActive(true);

    }
    private void fillChest(GameObject foundChest, GameObject chestui)
    {
        Transform chest = chestui.transform.Find("chest");

        for (int k = 0; k < foundChest.transform.childCount; k++)
        {

            switch (foundChest.transform.GetChild(k).name)
            {
                case "gear":
                    chest.GetChild(k).GetComponent<Image>().sprite = gear;
                    break;
                case "oil":
                    chest.GetChild(k).GetComponent<Image>().sprite = oil;
                    break;
                case "driver":
                    chest.GetChild(k).GetComponent<Image>().sprite = driver;
                    break;
                case "screw":
                    chest.GetChild(k).GetComponent<Image>().sprite = screw;
                    break;
                case "iron":
                    chest.GetChild(k).GetComponent<Image>().sprite = iron;
                    break;
                case "kit":
                    chest.GetChild(k).GetComponent<Image>().sprite = kit;
                    break;
                case "night_vision":
                    chest.GetChild(k).GetComponent<Image>().sprite = night_vision;
                    break;
                case "scan":
                    chest.GetChild(k).GetComponent<Image>().sprite = scan;
                    break;

            }

            chest.GetChild(k).gameObject.SetActive(true);
        }
    }

    public void onClickCloseButton()
    {

        charactermove Move = GameObject.Find("character").GetComponent<charactermove>();
        Move.isMoveable = true;

        close_chest_ui();
        GameObject chestui = GameObject.Find("Canvas").transform.Find("chest ui").gameObject;
        chestui.SetActive(false);
    }

    public void close_chest_ui()
    {
        Transform chest = GameObject.Find("Canvas").transform.Find("chest ui").Find("chest");

        for (int k = 0; k < chest.childCount; k++)
        {
            chest.GetChild(k).gameObject.SetActive(false);
        }

    }

    public void close_inventory_ui()
    {
        Transform inventory = GameObject.Find("Canvas").transform.Find("game ui").Find("inventory");


        for (int k = 0; k < inventory.childCount; k++)
        {
            inventory.GetChild(k).gameObject.SetActive(false);
        }
    }


    public void onClickComponentButton()
    {

        GameObject foundChest = GameObject.Find("character").GetComponent<charactermove>().foundChest;
        int num_comp = int.Parse(transform.name);

        if (GameObject.Find("character").transform.Find("Inventory").childCount < maxInventory)
        {
            foundChest.transform.GetChild(num_comp).SetParent(GameObject.Find("character").transform.Find("Inventory"));
            close_chest_ui();
            onClickFindButton();

            fill_inventory();
        }
    }

    public void fill_inventory()
    {
        close_inventory_ui();
        GameObject character_inventory = GameObject.Find("character").transform.Find("Inventory").gameObject;
        GameObject inventory_ui = GameObject.Find("Canvas").transform.Find("game ui").Find("inventory").gameObject;

        for (int k = 0; k < character_inventory.transform.childCount; k++)
        {
            switch (character_inventory.transform.GetChild(k).name)
            {
                case "gear":
                    inventory_ui.transform.GetChild(k).GetComponent<Image>().sprite = gear;
                    break;
                case "oil":
                    inventory_ui.transform.GetChild(k).GetComponent<Image>().sprite = oil;
                    break;
                case "driver":
                    inventory_ui.transform.GetChild(k).GetComponent<Image>().sprite = driver;
                    break;
                case "screw":
                    inventory_ui.transform.GetChild(k).GetComponent<Image>().sprite = screw;
                    break;
                case "iron":
                    inventory_ui.transform.GetChild(k).GetComponent<Image>().sprite = iron;
                    break;
                case "kit":
                    inventory_ui.transform.GetChild(k).GetComponent<Image>().sprite = kit;
                    break;
                case "night_vision":
                    inventory_ui.transform.GetChild(k).GetComponent<Image>().sprite = night_vision;
                    break;
                case "scan":
                    inventory_ui.transform.GetChild(k).GetComponent<Image>().sprite = scan;
                    break;

            }
            inventory_ui.transform.GetChild(k).gameObject.SetActive(true);
        }

    }

    void update_mission_ui(string name)
    {



        Transform current_part = mission_list.transform.Find(name);
        int goal = int.Parse(current_part.GetChild(0).GetComponent<TextMeshProUGUI>().text.Split('/')[1]);
        int now = int.Parse(current_part.GetChild(0).GetComponent<TextMeshProUGUI>().text.Split('/')[0]);
        current_part.GetChild(0).GetComponent<TextMeshProUGUI>().text = string.Format("{0,2} / {1,-2}", now + 1, goal);
        if (now + 1 >= goal)
            current_part.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(64, 255, 64, 255);

    }

    public void onClickPartsButton()
    {

        GameObject character_inventory = GameObject.Find("character").transform.Find("Inventory").gameObject;
        GameObject inventory_ui = GameObject.Find("Canvas").transform.Find("game ui").Find("inventory").gameObject;
        GameObject partsArea = GameObject.Find("character").GetComponent<charactermove>().foundChest;

        int num_comp = int.Parse(transform.name);
        if (partsArea.gameObject.layer == 9)
        {
            string part_name = character_inventory.transform.GetChild(num_comp).name;
            if (part_names.Contains(part_name))
            {
                character_inventory.transform.GetChild(num_comp).SetParent(partsArea.transform);


                update_mission_ui(part_name);
                fill_inventory();
            }
        }


    }


    public void onClickMiniMapButton()
    {
        isOpenMiniMap = !isOpenMiniMap;
        
        GameObject minimapui = GameObject.Find("Canvas").transform.Find("game ui").transform.Find("minimap ui").gameObject;        
        minimapui.SetActive(isOpenMiniMap);



    }
}


