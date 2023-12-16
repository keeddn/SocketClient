using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketProto;
using UnityEngine;

namespace Assets.Scripts.Requests
{
    internal class StartGameReq:BaseRequest
    {
        private static StartGameReq instance;
        public static StartGameReq Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StartGameReq();
                }
                return instance;
            }
        }
        private StartGameReq()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.Ready;
        }
        public override void HandleResponse(MainPack pack)
        {
            switch (pack.Returncode)
            {
                case ReturnCode.Succeed:
                    GameFace.Instance.roomPanel.HandleRefresh(pack);

                    break;
                case ReturnCode.Fail:
                    GameFace.Instance.ShowMessage("准备失败", true);
                    break;
                case ReturnCode.NotFound:
                    GameFace.Instance.ShowMessage("准备出错", true);
                    break;
                default:
                    Debug.Log("def");
                    break;
            }
        }
        public void SendRequest(string roomName)
        {
            MainPack pack = new MainPack();
            pack.Requestcode = requestCode;
            pack.Actioncode = actionCode;
            RoomPack roomPack = new RoomPack();
            roomPack.Roomname = roomName;
            PlayerInfo playerInfo = new PlayerInfo();
            playerInfo.Playername = GameFace.Instance.clientManager.username;
            roomPack.Playerinfos.Add(playerInfo);
            pack.Roompack.Add(roomPack);
            Debug.Log("ready" + roomName + "  "+ GameFace.Instance.clientManager.username);
            GameFace.Instance.SendMessage(pack);
        }
    }
}
