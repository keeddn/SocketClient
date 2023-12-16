using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketProto;
using UnityEngine;

namespace Assets.Scripts.Requests
{
    internal class CreateRoomReq : BaseRequest
    {
        private static CreateRoomReq instance;
        public static CreateRoomReq Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreateRoomReq();
                }
                return instance;
            }
        }
        private CreateRoomReq()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.CreateRoom;
        }
        public override void HandleResponse(MainPack pack)
        {
            switch (pack.Returncode)
            {
                case ReturnCode.Succeed:
                    GameFace.Instance.ShowMessage("创建成功", true);
                    GameFace.Instance.ChangeUI(UIPanelType.Room);
                    GameFace.Instance.roomPanel.HandleRefresh(pack);
                    break;
                case ReturnCode.Fail:
                    GameFace.Instance.ShowMessage("创建失败", true);
                    break;
                case ReturnCode.NotFound:
                    GameFace.Instance.ShowMessage("房间名已存在,创建失败", true);
                    break;
                default:
                    Debug.Log("def");
                    break;
            }
        }
        
        public void SendRequest(string name,int maxplayer)
        {
            MainPack pack = new MainPack();
            pack.Requestcode = requestCode;
            pack.Actioncode = actionCode;
            RoomPack roomPack = new RoomPack();
            roomPack.Roomname = name;
            roomPack.Maxplayer = maxplayer;
            pack.Roompack.Add(roomPack);
            GameFace.Instance.SendMessage(pack);
        }
    }
}
