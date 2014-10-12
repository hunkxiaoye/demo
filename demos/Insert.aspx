<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="demos.Insert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Content/DLL/bootstrap/css/bootstrap-responsive.css" rel="stylesheet"
        type="text/css" />
    <link href="Content/DLL/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="Content/jquery-1.8.3.min.js" type="text/javascript"></script>   
</head>
<body>
    <form runat="server">
    <div class="row">
        <div class="span4">
            <span>选择区域</span>
            <select id="area" name="area">
                <option value="0">请选择</option>
                <% ShowArea(); %>
            </select>
        </div>
        <div class="span4">
            <span>选择产地</span>
            <select id="state" name="state">
                <option value="0">请选择</option>
                <% ShowState();%>
            </select>
        </div>
        <div class="span4">
            <span>所属类别</span>
            <select id="retriecal" name="retriecal">
                <option value="0">请选择</option>
                <% ShowRetriecal(); %>
            </select></div>
    </div>
    <br />
    &nbsp;
    <div class="row">
        <div class="span4">
            <span>品牌名称</span>
            <select id="mark" name="mark">
                <option value="0">请选择</option>
                <% ShowMark();%>
            </select>
        </div>
        <div class="span4">
            <span>显示位置</span>
            <select id="top" name="top">
                <option value="0">请选择</option>
                <% ShowTops();%>
            </select>
        </div>
        <div class="span4">
            <span>产品属性</span>
            <select id="attr" name="attr">
                <option value="0">请选择</option>
                <% ShowAttr();%>
            </select>
        </div>
    </div>
    <br />
    <span>商品标题</span><input type="text" id="title" name="title" />
    <br />
    <div class="row">
        <div class="span6">
            <span>商品简介</span></div>
        <div class="span6">
            <span>备注</span></div>
    </div>
    <div class="row">
        <div class="span6">
            <textarea id="description" name="description" rows="5"></textarea></div>
        <div class="span6">
            <textarea id="comment" name="comment" rows="5" ></textarea></div>
    </div>
    &nbsp; &nbsp;<br />
    <asp:Button ID="Button1"  class="btn btn-primary" runat="server" Text="创建" OnClick="Unnamed1_Click" />
    </form>
</body>
</html>
