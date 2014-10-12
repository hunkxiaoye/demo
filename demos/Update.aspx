<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="demos.Update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="Content/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="ld.aspx"></script>
    <script>
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
        $(function() {
            var aid = $("#area").find("option:selected").val();
            instate(aid);
        });
    </script>
</head>
<body>
    <form  runat="server">
    <div>
        <span>选择区域</span>
        <select id="area" name="area" onchange="format(this)">
            <% ShowArea(); %>
        </select>
        <span>选择产地</span>
        <select id="state" name="state">
            
        </select>
        <span>所属类别</span>
        <select id="retriecal" name="retriecal">
            <% ShowRetriecal(); %>
        </select><br />
        &nbsp;品牌名称
         <select id="mark" name="mark">
            <% ShowMark();%>
        </select>
        <span>显示位置</span>
        <select id="top" name="top">
            <% ShowTops();%>
        </select>
        <span>产品属性</span>
         <select id="attr" name="attr">
            <% ShowAttr();%>
        </select>
        <br />
        商品标题<asp:TextBox runat="server" ID="Title"  name="Title"></asp:TextBox>
        <br/>
        <p>商品简介&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 备注</p>
        <asp:TextBox  ID="des" name="des" runat="server" Height="169px" TextMode="MultiLine" Width="454px"></asp:TextBox>
        <asp:TextBox ID="comment" name="comment" runat="server" Height="172px" 
            TextMode="MultiLine" Width="507px"></asp:TextBox>
        <p>&nbsp;</p>
        &nbsp;<br/>
        <asp:Button ID="Button1" runat="server" Text="创建" OnClick="Unnamed1_Click" />
    </div>
    </form>
</body>
</html>
