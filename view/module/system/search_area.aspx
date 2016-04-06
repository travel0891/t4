<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search_area.aspx.cs" Inherits="view.module.system.search_area" %>

<!doctype html>
<html>
<head>
    <title>temp</title>
    <link href="../../lib/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../static/css/extend.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .btn-<%=Request.QueryString["charId"]%> ,.btn-<%=Request.QueryString["charId"]%>:hover{
          background-color:#f0ad4e;
          color:#fff;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
        <nav class="navbar navbar-default">
        </nav>
        <div class="row">
            <div role="group" class="btn-group-vertical col-md-2">
                <%=districtList%>
            </div>
            <div class="col-md-10">
                <ol class="breadcrumb">当前：
                    <li><a href="#">系统管理</a></li>
                    <li><a href="#">商圈配置</a></li>
                    <li><a href="#">上海市</a></li>
                    <li class="active"><%=Request.QueryString["district"]%></li>
                </ol>
            </div>
        </div>
    </div>
</body>
</html>
<script src="/<%=staticUrl%>/require/2.1.11/require.js" data-main="/static/main"
    type="text/javascript"></script>
