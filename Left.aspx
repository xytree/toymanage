<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="CSS/1.css" rel="stylesheet" />
    
    <script src="JQuery/jquery-1.9.1.js" type="text/javascript"></script>
    <script language="javascript" >
        $(document).ready(function () {
            $("dd").css("display", "none");
            $("dt span").addClass("imgdt2");
            $("dt span:first").removeClass("imgdt2");
            $("dt span:first").addClass("imgdt1");
            $("dd:first").css("display", "block");
            $("dt").click(function () {
                $(" dd").css("display", "none");
                $(this).next("dd").css("display", "block");
                $(" dt span").removeClass();
                $(" dt span").addClass("imgdt2");
                $(this).children("span").removeClass();
                $(this).children("span").addClass("imgdt1");
            });
            $("#container").css("height", "100%");
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="ceng1">
        
    </div>
    <div class="ceng2">
        <dl >
        <dt class="dttype"><span></span>报验流程<a class="content"></a></dt>
        <dd style="display:block;">
        <ul>
        <li><a href="NewItem.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 报验输入 </a></li>
        <li><a href="AddRecheck.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 复检输入 </a></li>
        <li><a href="AddSample.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 样品输入 </a></li>        
        </ul>
        </dd>
        <dt class="dttype"><span></span>申请确认单<a class="content"></a></dt>
        <dd>
        <ul>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 申请确认单输入 </a></li>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 申请确认单查询 </a></li>
        </ul>
        </dd>
        <dt class="dttype"><span></span>生成检验单<a class="content"></a></dt>
        <dd>
        <ul>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 物理检验单 </a></li>
        <li><a href="AddChemChkDoc.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 化学检验单 </a></li>
        </ul>
        </dd>
        <dt class="dttype"><span></span>收费管理<a class="content"></a></dt>
        <dd>
        <ul>
        <li><a href="AddFee.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 费用情况输入 </a></li>
        <li><a href="HandleCost.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 收费查询 </a></li>
        </ul>
        </dd>
        <dt class="dttype"><span></span>归档管理<a class="content"></a></dt>
        <dd>
        <ul>
        <li><a href="FindItem.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 归档查询 </a></li>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 即将到期档案 </a></li>
        </ul>
        </dd>
        <dt class="dttype"><span></span>结果统计<a class="content"></a></dt>
        <dd>
        <ul>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 结果查询 </a></li>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 纯委托统计 </a></li>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 每日报检统计 </a></li>
        </ul>
        </dd>
        <dt class="dttype"><span></span>化学检验<a class="content"></a></dt>
        <dd>
        <ul>
        <li><a href="LabChemistry.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 化学检验 </a></li>
        <li><a href="ChemBaseline.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 检验标准 </a></li>
        </ul>
        </dd>
        <dt class="dttype"><span></span>物理检验<a class="content"></a></dt>
        <dd>
        <ul>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 物理检验 </a></li>
        </ul>
        </dd>
        <dt class="dttype"><span></span>基本数据管理<a class="content"></a></dt>
        <dd>
        <ul>
        <li><a href="AddCorp.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 报检单位输入 </a></li>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 代码管理 </a></li>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 检验标准库管理 </a></li>
        </ul>
        </dd>
        <dt class="dttype"><span></span>系统设定<a class="content"></a></dt>
        <dd>
        <ul>
        <li><a href="staffmanger.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 管理员设定 </a></li>
        <li><a href="AddUser.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 添加用户 </a></li>
        <li><a href="MangerDepart.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 部门管理 </a></li>
        <li><a href="ErrPage.aspx" target="showframe"><img src="images/tubiao1.png" border="0"/> 工作委托 </a></li>
        </ul>
        </dd>
        </dl>
    </div>
    </form>
</body>
</html>
