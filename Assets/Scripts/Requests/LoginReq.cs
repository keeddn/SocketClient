using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketProto;
using UnityEngine;

namespace Assets.Scripts.Requests
{
    internal class LoginReq:BaseRequest
    {
        private static LoginReq instance;
        public static LoginReq Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginReq();
                }
                return instance;
            }
        }
        private LoginReq()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Login;
        }
        public override void HandleResponse(MainPack pack)
        {
            Debug.Log(pack.Requestcode);
            switch (pack.Returncode)
            {
                case  ReturnCode.Succeed:
                    GameFace.Instance.ChangeUI(UIPanelType.Roomlist);
                    GameFace.Instance.ShowMessage("登录成功", true);
                    GameFace.Instance.clientManager.username = pack.Loginpack.Name;
                    break;
                case ReturnCode.Fail:
                    GameFace.Instance.ShowMessage("登录失败", true);
                    break;
                default:
                    Debug.Log("def");
                    break;
            }
        }
        public void SendRequest(string username,string password)
        {
            MainPack pack = new MainPack();
            pack.Requestcode = requestCode;
            pack.Actioncode = actionCode;
            LoginPack loginPack = new LoginPack();
            loginPack.Name = username;
            loginPack.Password = password;
            pack.Loginpack = loginPack;
            GameFace.Instance.SendMessage(pack);
        }
    }
}
