using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace InfoSpace 
{
    /// <summary>
    ///Proinfo 的摘要说明
    /// </summary>
    ///     
    public class ProInfo
    {
	    public ProInfo()
	    {
		    //
		    //TODO: 在此处添加构造函数逻辑
		    //
	    }

        //属性
        public int NIndex { get; set; }                 //序号
        public string SSerial { get; set; }             //报验号
        public string SInputMan { get; set; }           //录入人
        public string SInputTime { get; set; }          //录入时间
        public string SApplyChkType { get; set; }       //报验类型
        public string SCorpRep { get; set; }            //报验单位
        public string SCorpSend { get; set; }           //送样单位
        public string SChkDemand { get; set; }          //检验要求
        public string SGetMan { get; set; }             //接样人
        public string SRecvMan { get; set; }            //收样人
        public string SApplyStand { get; set; }         //报验标准
        public string SSampleType { get; set; }         //样品类型
        public string SProType { get; set; }            //规格型号
        public int NProAmount { get; set; }             //数量单位
        public string SChkStand { get; set; }           //检测标准
        public bool BRetreat { get; set; }              //是否退样
        public string SReTime { get; set; }             //退样时间
        public string SConNum { get; set; }             //合同编号
        public string SRemark { get; set; }             //备注信息


        //属性_费用
        public string SAccount { get; set; }            //账户名称
        public string SDoller { get; set; }             //货币单位
        public float FCostNative { get; set; }          //原始价格
        public float FCostFine { get; set; }            //优惠价格
        public float FCostOther { get; set; }           //其他价格
        public float FCostAll { get; set; }             //合计价格
        public bool BPay { get; set; }                  //是否到账

        //属性_报告
        public string SRepDemand { get; set; }          //报告要求
        public string SRepType { get; set; }            //报告类型
        public int NTestPeriod { get; set; }            //测试周期
        public string SDateBegin { get; set; }          //测试开始日期
        public string SDateEnd { get; set; }            //测试结束日期
        public string SFileName { get; set; }           //报告名称
        public bool BTestEnd { get; set; }              //测试完成    
    }

    //检测方法与数据表对应内容
    public class EleTableInfo
    {
        public string SBaseLinName { get; set; }
        public string STableName { get; set; }
    }

    //人员名单
    public class UserInfo
    {
        public string SLoginName { get; set; }
        public string SUserName { get; set; }
    }

}
