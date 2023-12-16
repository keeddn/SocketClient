using Assets.Scripts;
using Assets.Scripts.Managers;
using Assets.Scripts.UIPanel;
using SocketProto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFace : MonoBehaviour
{
    public Transform UITF;
    public GameObject messagePanel;
    public ClientManager clientManager;
    UIPanelManager uiPanelManager;
    RequestManager requestManager;
    public RoomListPanel roomListPanel;
    public RoomPanel roomPanel;
    private static GameFace gameFace;
    private UIPanelType panelType;

    public static GameFace Instance
    {
        get
        {
            if (gameFace == null)
            {
                gameFace = GameObject.Find("GameFace").GetComponent<GameFace>();
            }
            return gameFace;
        }
    }
    public void CatchRoomListPanel(RoomListPanel roomListPanel)
    {
        this.roomListPanel = roomListPanel;
    }
    public void CatchRoomPanel(RoomPanel roomPanel)
    {
        this.roomPanel = roomPanel;
    }
    void Awake()
    {
        clientManager = new ClientManager(this);
        requestManager = new RequestManager(this);
        uiPanelManager = new UIPanelManager(this);

        clientManager.OnAwake();

    }

    private void Update()
    {
        if (panelType != UIPanelType.Empty)
        {
            ChangeUI();
            panelType = UIPanelType.Empty;
        }
    }
    private void OnDestroy()
    {
        clientManager.OnDestroy();
    }
    public void HandleMessage(MainPack pack)
    {
        requestManager.HandleResponse(pack);
    }
    public void SendMessage(MainPack pack)
    {
        clientManager.Send(pack);
    }
    private void ChangeUI()
    {
        uiPanelManager.ShowPanel(panelType);
    }
    public void ChangeUI(UIPanelType panelType)
    {
        this.panelType = panelType;
    }
    public void ShowMessage(string s, bool sync = false)
    {
        uiPanelManager.ShowMessage(s, sync);
    }
}
