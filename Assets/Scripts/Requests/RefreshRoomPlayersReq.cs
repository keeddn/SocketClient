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
    internal class RefreshRoomPlayersReq : BaseRequest
    {
        private static RefreshRoomPlayersReq instance;
        public static RefreshRoomPlayersReq Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RefreshRoomPlayersReq();
                }
                return instance;
            }
        }
        private RefreshRoomPlayersReq()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.RefreshPlayer;
        }
        public override void HandleResponse(MainPack pack)
        {
            switch (pack.Returncode)
            {
                case ReturnCode.Succeed:
                    
                    GameFace.Instance.roomPanel.HandleRefresh(pack);
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
