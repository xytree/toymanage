using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*命名空间用来管理数据*/
namespace managerspace
{
    /*该类用来产生和管理报检号*/
    public class CIndexManage
    {
        public enum eType
        {
            EDuotai=1,          /*多泰*/
            EJietong,           /*捷通*/
            ECore,              /*轻工中心*/
            EToy                /*玩具所*/
        }

	    public CIndexManage()
	    {
        }

        public string CurIndex { get; set; }        /*当前使用的报检号*/

        public string GetIndex(eType type)
        {
            switch (type)
            {
                case eType.EDuotai:
                    {
                        
                    }
                    break;
                case eType.EJietong:
                    {
                        
                    }
                    break;
                case eType.ECore:
                    {
                        
                    }
                    break;
                case eType.EToy:
                    {
                        
                    }
                    break;
                default:
                    break;
            }

            return CurIndex;
        }


    }

}
