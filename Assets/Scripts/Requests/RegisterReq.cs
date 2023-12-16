using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocketProto;
using UnityEngine;

namespace Assets.Scripts.Requests
{
    internal class RegisterReq:BaseRequest
    {
        private static RegisterReq instance;
        public static RegisterReq Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RegisterReq();
                }
                return instance;
            }
        }
        private RegisterReq()
        {
            requestCode = RequestCode.User;
            actionCode = ActionCode.Register;
        }
        public void HandleResponse()
        {

        }
        public override void HandleResponse(MainPack pack)
        {
            switch (pack.Returncode)
            {
                case  ReturnCode.Succeed:
                    GameFace.Instance.ShowMessage("注册成功", true);
                    GameFace.Instance.ChangeUI(UIPanelType.Login);
                    break;
                case ReturnCode.Fail:
                    GameFace.Instance.ShowMessage("注册失败", true);
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
