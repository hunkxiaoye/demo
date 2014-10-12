<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="demos.Update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #beizhu
        {
            height: 95px;
            width: 388px;
            margin-left: 64px;
        }
        #jianjie
        {
            width: 374px;
            height: 101px;
            margin-right: 0px;
            margin-top: 6px;
        }
    </style>
</head>
<body>
    <form  runat="server">
    <div>
        <span>选择区域</span>
        <select id="area" name="area">

            <% ShowArea(); %>
        </select>
        <span>选择产地</span>
        <select id="state" name="state">
            <% ShowState();%>
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
        商品标题<input type="text" id="title" name="title" />
        <br/>
        <p>商品简介&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;备注</p>
        <textarea id="description"name="description"></textarea><textarea id="comment" name="comment"></textarea>
        <p>&nbsp;</p>
        &nbsp;<br/>
        <asp:Button ID="Button1" runat="server" Text="创建" OnClick="Unnamed1_Click" />
    </div>
    </form>
</body>
</html>
