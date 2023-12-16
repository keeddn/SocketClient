using Assets.Scripts.Managers;
using Assets.Scripts.Requests;
using Assets.Scripts.UIPanel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIPanel
{
    public class PlayerInfoPanel : BasePanel
    {
        public Text playerIdentity,name,state;
        public void SetPlayerInfo(string name, int k, int state)
        {
            this.name.text = name;
            if (k == 1) playerIdentity.text = "房主";
            else playerIdentity.text = "成员"+k;

            switch (state)
            {
                case 0:
                    this.state.text = "未准备";
                    break;
                case 1:
                    this.state.text = "已准备";
                    break;
            }
        }
        

    }
}

