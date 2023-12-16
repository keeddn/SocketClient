using Assets.Scripts.Managers;
using Assets.Scripts.Requests;
using Assets.Scripts.UIPanel;
using SocketProto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIPanel
{
    public class RoomListPanel : BasePanel
    {
        public GameObject outRoom;
        public Transform liftPart;
        public Button back, create, refresh;
        public InputField input;
        public Slider maxPlayer;
        private MainPack pack=null;
        void Start()
        {
            back.onClick.AddListener(Back);
            create.onClick.AddListener(CreateRoom);
            refresh.onClick.AddListener(RefreshRoom);
        }
        private void Update()
        {
            if (pack != null)
            {
                HandleRefresh();
                pack = null;
            }
        }
        private void Back()
        {
            GameFace.Instance.ChangeUI(UIPanelType.Login);
        }
        private void CreateRoom()
        {
            string name = GameFace.Instance.clientManager.username;
            int players = (int)maxPlayer.value;
            CreateRoomReq.Instance.SendRequest(name, players);
        }
        private void RefreshRoom()
        {
            RefreshRoomReq.Instance.SendRequest();
        }
        public void HandleRefresh(MainPack pack)
        {
            this.pack = pack;
        }
        private void HandleRefresh()
        {
            for (int i = 0; i < liftPart.childCount; i++)
            {
                Destroy(liftPart.GetChild(i).gameObject);
            }
            Debug.Log("handlerefresh" + pack.Roompack[0]);
            foreach (RoomPack pack1 in pack.Roompack)
            {
                GameObject go = Instantiate(outRoom, liftPart);
                Debug.Log(111+go.name);
                go.GetComponent<OutRoomPanel>().SetRoomInfo(pack1.Roomname,pack1.Nowplayer,pack1.Maxplayer,pack1.State);
            }
        }

    }
}

