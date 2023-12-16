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
            if (k == 1) playerIdentity.text = "����";
            else playerIdentity.text = "��Ա"+k;

            switch (state)
            {
                case 0:
                    this.state.text = "δ׼��";
                    break;
                case 1:
                    this.state.text = "��׼��";
                    break;
            }
        }
        

    }
}

