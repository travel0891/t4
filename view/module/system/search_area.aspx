<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search_area.aspx.cs" Inherits="view.module.system.search_area" %>

<!doctype html>
<html>
<head>
    <title>temp</title>
    <link href="/lib/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/lib/modalty/1.0.0/css/modalty.css" rel="stylesheet" type="text/css" />
    <link href="/static/css/extend.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .btn-hover , .btn-hover:focus{
          background-color:#f0ad4e;
          color:#fff;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
        <div id="navbarListId" class="navbar navbar-default">
        </div>
        <div class="row">
            <div id="districtListId" class="btn-group-vertical col-md-2" runat="server">
            </div>
            <div class="col-md-10">
                <div id="breadListId">
                    <ol class="breadcrumb">
                        <li><a href="javascript:;">系统管理</a></li>
                        <li><a href="javascript:;">商圈配置</a></li>
                        <li><a href="javascript:;">上海市</a></li>
                        <li class="active"></li>
                    </ol>
                </div>
                <div id="areaListId">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            商圈信息 <span style="float: right"><a class="btn btn-success btn-inline">新增商圈</a></span>
                        </div>
                        <div class="panel-body">
                           <span>请选择一个区域</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/lib/jquery/2.2.3/jquery.min.js" type="text/javascript"></script>
    <script src="/lib/jquery-ui/1.11.4/jquery-ui.min.js" type="text/javascript"></script>
    <script src="/lib/modalty/1.0.0/js/modalty.js" type="text/javascript"></script>
    <script type="text/javascript">

        $("#districtListId").on("click", ".district", function () {
            $("#districtListId .district").removeClass("btn-hover");
            $(this).addClass("btn-hover");

            $("#breadListId .breadcrumb .active").html($(this).data("name"));

            $.get("/action/system/search_area.ashx"
            , { action: "searchAreaByDistrictCharId", districtCharId: $(this).data("charid") }
            , function (data) {
                $("#areaListId .panel .panel-body").html(data);
            });
        });

        $("#districtSettings").on("click", function () {
            modalty.modal("400", "常用区域设置", true, "searchAreaByDistrictCharId", "system/search_area");
        });

    </script>
</body>
</html>