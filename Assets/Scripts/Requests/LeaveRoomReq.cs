using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketProto;
using UnityEngine;

namespace Assets.Scripts.Requests
{
    internal class LeaveRoomReq : BaseRequest
    {
        private static LeaveRoomReq instance;
        public static LeaveRoomReq Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LeaveRoomReq();
                }
                return instance;
            }
        }
        private LeaveRoomReq()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.LeaveRoom;
        }
        public override void HandleResponse(MainPack pack)
        {
            switch (pack.Returncode)
            {
                case ReturnCode.Succeed:
                    GameFace.Instance.ShowMessage("退出成功", true);
                    GameFace.Instance.ChangeUI(UIPanelType.Roomlist);
                    break;
                case ReturnCode.Fail:
                    GameFace.Instance.ShowMessage("退出失败", true);
                    break;
                case ReturnCode.NotFound:
                    GameFace.Instance.ShowMessage("退出出错", true);
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
            Debug.Log("LeaveROom"+name);
            GameFace.Instance.SendMessage(pack);
        }
    }
}
