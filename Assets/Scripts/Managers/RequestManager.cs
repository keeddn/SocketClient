using Assets.Scripts.Requests;
using SocketProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Managers
{
    internal class RequestManager : BaseManager
    {
        Dictionary<ActionCode, BaseRequest> requestDic = new Dictionary<ActionCode, BaseRequest>();
        public RequestManager(GameFace gameFace) : base(gameFace)
        {
            requestDic.Add(ActionCode.Register, RegisterReq.Instance);
            requestDic.Add(ActionCode.Login, LoginReq.Instance);
            requestDic.Add(ActionCode.CreateRoom, CreateRoomReq.Instance);
            requestDic.Add(ActionCode.FindRoom, RefreshRoomReq.Instance);
            requestDic.Add(ActionCode.RefreshPlayer, RefreshRoomPlayersReq.Instance);
            requestDic.Add(ActionCode.LeaveRoom,LeaveRoomReq.Instance);
            requestDic.Add(ActionCode.JoinRoom, JoinRoomReq.Instance);
            requestDic.Add(ActionCode.SendMessage, SendMessageReq.Instance);
        }
        public void HandleResponse(MainPack pack)
        {
            if(requestDic.TryGetValue(pack.Actioncode,out BaseRequest baseRequest))
            {
                baseRequest.HandleResponse(pack);
            }
        }
    }
}
