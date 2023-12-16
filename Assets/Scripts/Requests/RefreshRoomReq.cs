using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.UIPanel;
using SocketProto;
using UnityEngine;

namespace Assets.Scripts.Requests
{
    internal class RefreshRoomReq : BaseRequest
    {
        private static RefreshRoomReq instance;
        public static RefreshRoomReq Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RefreshRoomReq();
                }
                return instance;
            }
        }
        private RefreshRoomReq()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.FindRoom;
        }
        public override void HandleResponse(MainPack pack)
        {
            switch (pack.Returncode)
            {
                case ReturnCode.Succeed:
                    GameFace.Instance.ShowMessage("刷新成功", true);
                    Debug.Log(111111111);
                    GameFace.Instance.roomListPanel.HandleRefresh(pack);
                    break;
                case ReturnCode.Fail:
                    GameFace.Instance.ShowMessage("刷新失败", true);
                    break;
                case ReturnCode.NotFound:
                    GameFace.Instance.ShowMessage("没有找到房间!", true);
                    break;
                default:
                    Debug.Log("def");
                    break;
            }
        }
        public void SendRequest()
        {
            MainPack pack = new MainPack();
            pack.Requestcode = requestCode;
            pack.Actioncode = actionCode;
            GameFace.Instance.SendMessage(pack);
        }
    }
}
