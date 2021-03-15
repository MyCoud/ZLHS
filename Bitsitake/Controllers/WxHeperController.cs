using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bitModel;
using bitDal;
using bitBLL;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Xml.Linq;
using bitibll;
using Newtonsoft.Json;
using Common;
using Microsoft.AspNetCore.Hosting;
using System.IO;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Builder;
using System.Text;
using System.Net;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography;
using Microsoft.Extensions.DependencyInjection;

namespace Bitsitake.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WxHeperController:ControllerBase
    {
        [EnableCors("kuayu")]
        [HttpGet("PageLoad")]
        public void PageLoad()
        {
            //验证token
            string poststring = string.Empty;
            string token = "aabbcc";   //验证token，随意填写  
            if (string.IsNullOrEmpty(token))
            {
                return;
            }
        
            string echostr = HttpContexts.Current.Request.Equals("echostr").ToString();
            string signature = HttpContexts.Current.Request.Equals("signature").ToString();
            string timestamp = HttpContexts.Current.Request.Equals("timestamp").ToString();
            string nonce = HttpContexts.Current.Request.Equals("nonce").ToString();
            if (checkSignature(token, signature, timestamp, nonce, nonce))
            {
                HttpContexts.Current.Response.WriteAsync(echostr);
                HttpContexts.Current.Response.Clear();
            }
            
        }
        [EnableCors("kuayu")]
        [HttpPost("checkSignature")]
        #region 微信接口对接验证代码
        public bool checkSignature(string token, string signature, string timestamp, string nonce, string echostr)
        {
            List<string> list = new List<string>();
            list.Add(token);
            list.Add(timestamp);
            list.Add(nonce);
            list.Sort();

            string res = string.Join("", list.ToArray());
            Byte[] dataToHash = Encoding.ASCII.GetBytes(res);
            byte[] hashvalue = ((HashAlgorithm)CryptoConfig.CreateFromName("SHA1")).ComputeHash(dataToHash);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashvalue)
            {
                sb.Append(b.ToString("x2"));
            }

            if (signature == sb.ToString())
                return true;
            else
                return false;
        }
        #endregion
        public static class HttpContexts
        {
            public static IServiceCollection serviceCollection;

            public static Microsoft.AspNetCore.Http.HttpContext Current
            {
                get
                {
                    object factory = serviceCollection.BuildServiceProvider().GetService(typeof(IHttpContextAccessor));
                    Microsoft.AspNetCore.Http.HttpContext context = ((HttpContextAccessor)factory).HttpContext;
                    return context;
                }
            }

        }
    }
}
