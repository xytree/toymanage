using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoSpace
{
    //自定义类用来为报检项目查询提供参数
    public class Itempara
    {
        public Itempara()
        {

        }

        public string 报检号 { get; set; }
        public string 录入人 { get; set; }
        public string 录入时间 { get; set; }
        public string 报检类型 { get; set; }
        public string 报检单位 { get; set; }
        public string 收样人 { get; set; }
        public string 样品类型 { get; set; }
        public string 规格型号 { get; set; }
        public int 样品数量 { get; set; }
        public string 检测标准1 { get; set; }
        public string 检测标准2 { get; set; }
        public string 检测标准3 { get; set; }
        public string 备注信息 { get; set; }

    }

    //登录人员信息
    public class Staffpara
    {
        public Staffpara()
        {
            
        }

        public string 登录名 { get; set; }
        public string 用户名 { get; set; }
        public string 密码 { get; set; }
        public string 部门 { get; set; }
        public string 岗位 { get; set; }
        public string 管理权限 { get; set; }
        public string 使用权限 { get; set; }
        public string 性别 { get; set; }
        public string 年龄 { get; set; }
        public string 注册时间 { get; set; }
        public string 登录时间 { get; set; }
    }

    //元素信息
    public class ElementInfo
    {
        public ElementInfo()
        {
            
        }

        public string 数据表名 { get; set; }
        public string 序号 { get; set; }
        public string 元素名称 { get; set; }
        public string 检测上限 { get; set; }
        public string 检测下限 { get; set; } 
    }

}
