using Assets.Scripts.Managers;
using Assets.Scripts.Requests;
using Assets.Scripts.UIPanel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIPanel
{
    public class LoginPanel : BasePanel
    {
        public InputField userName,passWord;
        public Button login,register;
        private string username, password;
        // Start is called before the first frame update
        void Start()
        {
            panelType = UIPanelType.Register;
            register.onClick.AddListener(Register);
            login.onClick.AddListener(Login);
        }
        private void Login()
        {
            username = userName.text;
            password = passWord.text;
            LoginReq.Instance.SendRequest(username, password);
        }
        private void Register()
        {
            GameFace.Instance.ChangeUI(UIPanelType.Register);
        }


    }
}

