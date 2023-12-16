using Assets.Scripts.Managers;
using Assets.Scripts.Requests;
using Assets.Scripts.UIPanel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIPanel
{
    public class MessagePanel : BasePanel
    {
        public Text text;
        private string mes;
        private void Start()
        {
            text.CrossFadeAlpha(0, 0, false);
        }
        private void Update()
        {
            if (mes != null)
            {
                ShowText();
            }
        }
        public void ShowMessage(string s,bool sync=false)
        {
            if (sync)
            {
                mes = s;
            }
            else
            {
                ShowText();
            }
        }
        private void ShowText()
        {
            this.transform.SetAsLastSibling();
            text.text = mes;
            text.CrossFadeAlpha(1, 0.5f, false);
            mes = null;
            Invoke("HideText", 1.5f);
        }
        private void HideText()
        {
            text.CrossFadeAlpha(0, 0.5f, false);
        }
    }
}

