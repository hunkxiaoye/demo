<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="demos.Update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Content/DLL/bootstrap/css/bootstrap-responsive.css" rel="stylesheet"
        type="text/css" />
    <link href="Content/DLL/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Content/jquery-1.8.3.min.js"></script>
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
    <form runat="server">
    <div class="row">
        <div class="span4">
            <span>选择区域</span>
            <select id="area" name="area" onchange="format(this)">
                <% ShowArea(); %>
            </select>
        </div>
        <div class="span4">
            <span>选择产地</span>
            <select id="state" name="state">
            </select>
        </div>
        <div class="span4">
            <span>所属类别</span>
            <select id="retriecal" name="retriecal">
                <% ShowRetriecal(); %>
            </select>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="span4">
            品牌名称
            <select id="mark" name="mark">
                <% ShowMark();%>
            </select>
        </div>
        <div class="span4">
            <span>显示位置</span>
            <select id="top" name="top">
                <% ShowTops();%>
            </select>
        </div>
    </div>
    <div class="row">
        <div class="span6">
            <span>产品属性</span>
            <select id="attr" name="attr">
                <% ShowAttr();%>
            </select>
        </div>
        <div class="span6">
            <span>商品标题</span>
            <asp:TextBox runat="server" ID="Title" name="Title"></asp:TextBox>
        </div>
         </div>
         <div class="row">
            <div class="span6">
                <span>商品简介</span>
            </div>
            <div class="span6">
                <span>备注</span>
            </div>
         </div>
         <div class="=row">
           <div class="span6">
                       <asp:TextBox ID="des" name="des" runat="server" Height="169px" TextMode="MultiLine"
            Width="454px"></asp:TextBox>
           </div> 

            <div class="span6">
                <asp:TextBox ID="comment" name="comment" runat="server" Height="172px" TextMode="MultiLine"
            Width="507px"></asp:TextBox>
            </div> 
         </div>
         <div class="row">
             <div class="span12">
             <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="创建" OnClick="Unnamed1_Click" />
             </div>
              
         </div>
                
       
    </form>
</body>
</html>
