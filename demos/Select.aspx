<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Select.aspx.cs" Inherits="demos.Select1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Content/DLL/bootstrap/css/bootstrap-responsive.css" rel="stylesheet"
        type="text/css" />
    <link href="Content/DLL/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="Content/jquery-1.8.3.min.js" type="text/javascript"></script>  
     <script type="text/javascript" src="ld.aspx"></script>
    <script type="text/javascript">
        function selectstate(aid) {
            var selectstatelist = [];
            for (var i = 0; i < statelist_json.length; i++) {
                if (statelist_json[i].aid == aid)
                    selectstatelist.push(statelist_json[i]);
            }
            return selectstatelist;
        }
        function instate(aid) {
            var selectstatelist = selectstate(parseInt(aid));
            var options = "";
            for (var i = 0; i < selectstatelist.length; i++) {
                options += "<option value=" + selectstatelist[i].id + ">" + selectstatelist[i].statename + "</option>";
            }
            $("#state").html(options);
        }
        function format(select) {
            var aid = $(select).find("option:selected").val();
            instate(aid);
        }
        $(function () {
            var aid = $("#area").find("option:selected").val();
            instate(aid);
        });

    </script> 
</head>    
<body>
<form  runat="server">
    <div class="row">
        <div  class="span4">
        <span>选择区域</span>
        <select id="area" name="area" onchange="format(this)">
            <% ShowArea(); %>
        </select>
        </div>
        <div  class="span4">
        <span>选择产地</span>
        <select id="state" name="state">
            <option value="0">请选择</option>
            <% ShowState();%>
        </select>
        </div>
        <div  class="span4">
        <span>所属类别</span>
       <select id="retriecal" name="retriecal">
            <option value="0">请选择</option>
            <% ShowRetriecal(); %>
        </select>
        </div>
        </div><br />
        <div class="row">
            <div  class="span4">
&nbsp;<span >品牌名称</span>
<input type="text" id="Title" name="Title"/>
</div>
<div  class="span4">
        <span>品牌属性</span>
         <select id="attr" name="attr">
            <option value="0">请选择</option>
            <% ShowAttr(); %>
        </select>
        </div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server"  class="btn btn-primary" Text="查询" onclick="Unnamed1_Click"/>
        <a href="Insert.aspx"  class="btn btn-primary">添加</a>
    </div>
   </form>

   <div>
    <table class="table table-bordered " >
    <tr>
        <th>商品编号</th>
        <th>品牌商标</th>
        <th>品牌名称</th>
        <th>产地</th>
        <th>品牌属性</th>
        <th>所属栏目</th>
        <th>排名</th>
        <th></th>
    </tr>
   <asp:Repeater ID="Repeater1" runat="server" >
            <ItemTemplate>
                <tr style="background-color:#e8eff5;">
                    <td><%#Eval("Id")%></td>
                    <td><%#Eval("MarkUrl")%></td>
                    <td><%#Eval("MarkName")%></td>
                    <td><%#Eval("Area")%>-<%#Eval("State")%></td>
                    <td><%#Eval("AttrName")%></td>
                    <td><%#Eval("Retriecal")%></td>
                    <td><%#Eval("Tops")%></td>
                    <td>
                        <a href="Update.aspx?id=<%#Eval("Id")%>" target="_blank" class="btn btn-primary">编辑</a>
                    </td>
                  
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                   <td><%#Eval("Id")%></td>
                    <td><%#Eval("MarkUrl")%></td>
                    <td><%#Eval("MarkName")%></td>
                    <td><%#Eval("Area")%>-<%#Eval("State")%></td>
                    <td><%#Eval("AttrName")%></td>
                    <td><%#Eval("Retriecal")%></td>
                    <td><%#Eval("Tops")%></td>
                    <td>
                         <a href="Update.aspx?id=<%#Eval("Id")%> " target="_blank"  class="btn btn-primary">编辑</a>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>
        </table>
       <%-- 当前页：<asp:Label ID="num" runat="server"></asp:Label>
            <br />
            <%--<asp:Button ID="BtnUp" runat="server" onclick="BtnUp_Click" Text="上一页" />
            <asp:Button ID="BtnDown" runat="server" onclick="BtnDown_Click" Text="下一页" />--%>
            </div>
</body>
</html>
