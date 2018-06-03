using System;
using System.Collections;
using System.Collections.Generic;

namespace PhonemikeServer.Core
{
    public class mJsonresult
    {
        public bool success = false;

        public string msg;

        public IEnumerable rows;

        public object obj;

        public int total;

        public EFailCode failCode;
    }

    public enum EFailCode
    {
        None = 0,

        /// <summary>
        /// 未登录
        /// </summary>
        UnAuth = 1,

        /// <summary>
        /// 
        /// </summary>
        ServerError = 2,
    }
}
