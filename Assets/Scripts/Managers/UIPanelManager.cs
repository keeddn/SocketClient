using Assets.Scripts.UIPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    internal class UIPanelManager : BaseManager
    {
        private MessagePanel messagePanel;
        public UIPanelManager(GameFace gameFace) : base(gameFace)
        {
            nowPanel = UIPanelType.Empty;
            UITF = gameFace.UITF;
            messagePanel = gameFace.messagePanel.GetComponent<MessagePanel>();
            CreatePanel();
            ShowPanel(UIPanelType.Start);
        }
        public Transform UITF;
        private UIPanelType nowPanel;
        Dictionary<UIPanelType, BasePanel> panelDic = new Dictionary<UIPanelType, BasePanel>();
        private void CreatePanel()
        {
            foreach(UIPanelType type in Enum.GetValues(typeof(UIPanelType)))
            {
                if (type == UIPanelType.Empty) continue;
                CreatePanel(type);
                panelDic.TryGetValue(type, out BasePanel basePanel);
                if (basePanel is RoomListPanel)
                {
                    GameFace.Instance.CatchRoomListPanel(basePanel as RoomListPanel);
                }
                if (basePanel is RoomPanel)
                {
                    GameFace.Instance.CatchRoomPanel(basePanel as RoomPanel);
                }
            }
        }
        public void ShowPanel(UIPanelType panelType)
        {
            if (nowPanel == panelType) return;
            //if (!panelDic.TryGetValue(panelType, out BasePanel value))
            //{
            //    CreatePanel(panelType);
            //}
            panelDic.TryGetValue(panelType, out BasePanel basePanel);
            basePanel.gameObject.SetActive(true);
            panelDic.TryGetValue(nowPanel, out BasePanel nowBasePanel);
            if(nowPanel!=UIPanelType.Empty)nowBasePanel.gameObject.SetActive(false);
            nowPanel = panelType;
        }
        private void CreatePanel(UIPanelType panelType)
        {
            string panel = panelType.ToString();
            GameObject go = Resources.Load("Perfabs/Panel/" + panel) as GameObject;
            GameObject go2=GameObject.Instantiate(go, UITF);
            go2.SetActive(false);
            panelDic.Add(panelType, go2.GetComponent<BasePanel>());
        }
        public void ShowMessage(string s,bool sync = false)
        {
            messagePanel.ShowMessage(s, sync);
        }
    }
}
