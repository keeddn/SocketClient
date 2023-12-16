using Assets.Scripts.Managers;
using Assets.Scripts.Requests;
using Assets.Scripts.UIPanel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIPanel
{
    public class OutRoomPanel : BasePanel
    {
        public Text name, roominfo, state;
        public Button joinRoom;
        private void Start()
        {
            joinRoom.onClick.AddListener(JoinRoom);
        }
        public void SetRoomInfo(string name,int nowplayer,int maxpalyer,int state)
        {
            this.name.text = name;
            roominfo.text = nowplayer + "/" + maxpalyer;
            switch (state)
            {
                case 0:
                    this.state.text = "未开始";
                    break;
                case 1:
                    this.state.text = "已开始";
                    break;
            }
        }
        public void JoinRoom()
        {
            JoinRoomReq.Instance.SendRequest(name.text);
            
        }

    }
}

