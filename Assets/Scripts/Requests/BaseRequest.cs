using SocketProto;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Requests
{
   
    internal class BaseRequest
    {
        protected RequestCode requestCode;
        protected ActionCode actionCode;
        public BaseRequest()
        {
            requestCode = RequestCode.RequestNone;
            actionCode = ActionCode.ActionNone;
        }
        public virtual void HandleResponse(MainPack pack)
        {

        }
    }
}
