using Assets.Scripts.Managers;
using Assets.Scripts.Requests;
using Assets.Scripts.UIPanel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIPanel
{
    public class StartPanel : BasePanel
    {
        public Button startGame;
        
        void Start()
        {
            startGame.onClick.AddListener(StartGame);
        }
        private void StartGame()
        {
            GameFace.Instance.ChangeUI(UIPanelType.Login);
        }


    }
}

