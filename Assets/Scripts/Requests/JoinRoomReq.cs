using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketProto;
using UnityEngine;

namespace Assets.Scripts.Requests
{
    internal class JoinRoomReq : BaseRequest
    {
        private static JoinRoomReq instance;
        public static JoinRoomReq Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JoinRoomReq();
                }
                return instance;
            }
        }
        private JoinRoomReq()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.JoinRoom;
        }
        public override void HandleResponse(MainPack pack)
        {
            Debug.Log(pack.Returncode);
            switch (pack.Returncode)
            {
                case ReturnCode.Succeed:
                    GameFace.Instance.ShowMessage("加入成功", true);
                    GameFace.Instance.ChangeUI(UIPanelType.Room);
                    GameFace.Instance.roomPanel.HandleRefresh(pack);
                    break;
                case ReturnCode.Fail:
                    GameFace.Instance.ShowMessage("加入失败已满员", true);
                    break;
                case ReturnCode.NotFound:
                    GameFace.Instance.ShowMessage("加入出问题", true);
                    break;
                default:
                    Debug.Log("def");
                    break;
            }
        }
        public void SendRequest(string name)
        {
            MainPack pack = new MainPack();
            pack.Requestcode = requestCode;
            pack.Actioncode = actionCode;
            RoomPack roomPack = new RoomPack();
            roomPack.Roomname = name;
            pack.Roompack.Add(roomPack);
            Debug.Log("name=="+name);
            GameFace.Instance.SendMessage(pack);
        }
    }
}
