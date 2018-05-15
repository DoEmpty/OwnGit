using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParameterTemp.Models
{
    /// <summary>
    /// 使用DataAnnotations特性来确定对属性的验证规则
    /// </summary>
    public class Student
    {
        [Required(ErrorMessage ="Name为必填项")]
        public string Name { get; set; }
        [Range(1,100,ErrorMessage ="年龄为1到100之间")]
        public int Age { get; set; }
        [RegularExpression("^male|female$",ErrorMessage ="性别不合法")]
        public string Sex { get; set; }
    }
}