<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="view.module.login" %>

<!doctype html>
<html lang="zh-CN">
<head>
    <meta charset="utf-8" />
    <title>login</title>
    <link href="../lib/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../static/css/login.css" rel="stylesheet" type="text/css" />
    <link href="../static/css/extend.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="login_wrap">
        <div class="header text-center">
            <p>LOGIN</p>
        </div>
        <div class="login_form">
            <form id="login_form">
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-home color999"></span>
                </span>
                <input type="text" name="company" id="companyInput" class="form-control" placeholder="公司编码"
                    maxlength="6" />
            </div>
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-user color999"></span>
                </span>
                <input type="text" name="account" id="accountInput" class="form-control" placeholder="登录账号"
                    maxlength="12" />
            </div>
            <div class="input-group form-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-lock color999"></span>
                </span>
                <input type="password" name="password" id="passwordInput" class="form-control" placeholder="登录密码"
                    maxlength="18" />
            </div>
            <div class="form-group">
                <div class="checkbox">
                    <label class="color999">
                        <input type="checkbox" name="keepLine" />记住账号密码</label>
                </div>
            </div>
            <div class="form-group">
                <button type="submit" class="btn btn-info btn-block">
                    登 录</button>
            </div>
            </form>
        </div>
        <div class="footer text-center color999">
            © 2016 website
        </div>
    </div>
</body>
</html>
<!--
<script src="../static/require.js" data-main="../static/main" type="text/javascript"></script>
-->