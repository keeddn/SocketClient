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
    public class RoomPanel : BasePanel
    {
        public string roomName;
        public GameObject playerInfo;
        public Transform liftPart;
        public Button back, send, begin;
        public InputField input;
        private MainPack pack=null;
        public Text RoomName,messageText;
        private string getMessage = null;
        void Start()
        {
            back.onClick.AddListener(Back);
            send.onClick.AddListener(SendMessage);
            begin.onClick.AddListener(Reday);


        }
        private void OnEnable()
        {
            messageText.text = "";
        }
        private void Update()
        {
            if (pack != null)
            {
                HandleRefresh();
                pack = null;
            }
            if (getMessage != null)
            {
                HandleMessage();
                getMessage = null;
            }
        }
        private void Back()
        {
            LeaveRoomReq.Instance.SendRequest(roomName);
        }
        private void SendMessage()
        {
            SendMessageReq.Instance.SendRequest(input.text,roomName);
            input.text = "";
        }
        private void Reday()
        {
            StartGameReq.Instance.SendRequest(roomName);
        }
        public void GetMessage(string s)
        {
            getMessage = s;
        }
        private void HandleMessage()
        {
            messageText.text += getMessage;
        }
        public void HandleRefresh(MainPack pack)
        {
            Debug.Log(pack.Roompack[0].Playerinfos[0]);
            this.pack = pack;
        }
        private void HandleRefresh()
        {
            for (int i = 0; i < liftPart.childCount; i++)
            {
                Destroy(liftPart.GetChild(i).gameObject);
            }
            Debug.Log("handlerefresh");
            int k = 0;
            foreach (PlayerInfo pack1 in pack.Roompack[0].Playerinfos)
            {
                k++;
                if (k == 1)
                {
                    roomName = pack1.Playername;
                    Debug.Log("roomName=" + roomName);
                    RoomName.text = roomName+"µÄ·¿¼ä";
                }
                GameObject go = Instantiate(playerInfo, liftPart);
                Debug.Log(111 + go.name);
                go.GetComponent<PlayerInfoPanel>().SetPlayerInfo(pack1.Playername,k,pack1.Playerstate);
            }
        }

    }
}

