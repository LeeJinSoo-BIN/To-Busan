using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField]
    private List<Button> zombieCountButtons;

    [SerializeField]
    private List<Button> maxPlayerCountButtons;

    private CreateRoomData roomData;
    // Start is called before the first frame update
    void Start()
    {
        roomData = new CreateRoomData() { zombieCount = 1, maxPlayerCount = 10 };
    }
    public void UpdateZombieCount(int count)
    {
        roomData.zombieCount = count;

        for (int i = 0; i < zombieCountButtons.Count; i++)
        {
            if (i == count - 1)
            {
                zombieCountButtons[i].image.color = new Color(0f, 1f, 0f, 1f);
            }
            else
            {
                zombieCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
        }

        int limitMaxPlayer = count == 1 ? 6 : count == 2 ? 8 : 9;
        if(roomData.maxPlayerCount < limitMaxPlayer)
        {
            UpdateMaxPlayerCount(limitMaxPlayer);
        }
        else
        {
            UpdateMaxPlayerCount(roomData.maxPlayerCount);
        }

        for(int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            var text = maxPlayerCountButtons[i].GetComponentInChildren<Text>();
            if (i < limitMaxPlayer - 6)
            {
                maxPlayerCountButtons[i].interactable = false;
                text.color = Color.gray;
            }
            else
            {
                maxPlayerCountButtons[i].interactable = true;
                text.color = Color.black;
            }
        }
    }

    public void UpdateMaxPlayerCount(int count)
    {
        roomData.maxPlayerCount = count;

        for(int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            if (i == count - 6)
            {
                maxPlayerCountButtons[i].image.color = new Color(0f, 1f, 0f, 1f);
            }
            else
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    public void CreateRoom()
    {
        var manager = ToBusanRoomManager.singleton;
        // 방 설정 작업 처리
        //
        //
        manager.StartHost();
    }
}

public class CreateRoomData
{
    public int zombieCount;
    public int maxPlayerCount;
}
