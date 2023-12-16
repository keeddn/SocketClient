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
    internal class SendMessageReq : BaseRequest
    {
        private static SendMessageReq instance;
        public static SendMessageReq Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SendMessageReq();
                }
                return instance;
            }
        }
        private SendMessageReq()
        {
            requestCode = RequestCode.Room;
            actionCode = ActionCode.SendMessage;
        }
        public override void HandleResponse(MainPack pack)
        {
            switch (pack.Returncode)
            {
                case ReturnCode.Succeed:
                    Debug.Log(pack.Str);
                    GameFace.Instance.roomPanel.GetMessage(pack.Str);
                    break;
                case ReturnCode.Fail:
                    GameFace.Instance.ShowMessage("发送失败", true);
                    break;
                case ReturnCode.NotFound:
                    GameFace.Instance.ShowMessage("没有找到房间!", true);
                    break;
                default:
                    Debug.Log("def");
                    break;
            }
        }
        public void SendRequest(string s,string name)
        {
            MainPack pack = new MainPack();
            pack.Requestcode = requestCode;
            pack.Actioncode = actionCode;
            pack.Roompack.Add(new RoomPack());
            pack.Roompack[0].Roomname = name;
            pack.Str = s;
            GameFace.Instance.SendMessage(pack);
        }
    }
}
