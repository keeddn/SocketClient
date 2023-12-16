using Assets.Scripts.Managers;
using Assets.Scripts.Requests;
using Assets.Scripts.UIPanel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIPanel
{
    public class RegisterPanel : BasePanel
    {
        public InputField userName,passWord;
        public Button register,back;
        private string username, password;
        // Start is called before the first frame update
        void Start()
        {
            panelType = UIPanelType.Register;
            register.onClick.AddListener(Register);
            back.onClick.AddListener(Back);
        }
        private void Back()
        {
            GameFace.Instance.ChangeUI(UIPanelType.Login);
        }
        private void Register()
        {
            username = userName.text;
            password = passWord.text;
            RegisterReq.Instance.SendRequest(username, password);
        }


    }
}

