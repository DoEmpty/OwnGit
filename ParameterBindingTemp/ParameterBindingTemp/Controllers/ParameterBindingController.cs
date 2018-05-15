using ParameterTemp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParameterTemp.Controllers
{
    /// <summary>
    /// 通常情况下，Web API参数绑定参照以下规则
    /// 1.如果参数为简单类型，web api会尝试从uri中获取。简单参数类型包含.net原生类型(int,bool,double...)，以及timespan,datetime,guid,decimal,string，以及加上任何包含string转化器的类型
    /// 2.对复杂类型来说，web api尝试从message body中读取，使用media-type类型(Content-Type:application/json,text/html,image/png等等)来解析
    /// </summary>
    [Route("ParameterBinding/{Action}")]
    public class ParameterBindingController : ApiController
    {
        #region 迫使复杂类型从URI中获取参数
        /// <summary>
        /// 给参数添加[FromUri]特性，迫使web URI中读取复杂类型
        /// 调用url?Latitude=47.88&Longitude=122.34
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public GeoPoint1 ParaInUri1([FromUri]GeoPoint1 location)
        {
            return location;
        }

        /// <summary>
        /// 创建一个TypeConvert，并为参数类型添加一个TypeConverter特性并提供一个字符串转化方法
        /// </summary>
        /// <see cref="GeoPoint2"/>
        /// <param name="location"></param>
        /// <returns></returns>
        public GeoPoint2 ParaInUri2(GeoPoint2 location)
        {
            return location;
        }
        #endregion

        #region 迫使简单类型从Request Body中获取参数
        /// <summary>
        /// 给参数添加[FromBody]特性，迫使从request body中读取
        /// 当一个参数标记为[FromBody]后，web api通过httpheader中的Content-Type来选择数据传输格式
        /// 在requestbody中只有一个参数会被读取，([FromBody]int id,[FromBody]string name)不会成功，因为request body可能存储在一个只能读取一次的非缓冲的数据流中
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public string ParaInBody([FromBody]string name)
        {
            return name;
        }
        #endregion
    }
}
