<%--
//================================================================================
//  FileName: Index.aspx
//  Desc:
//
//  Called by
//
//  Auth:杨勇（jeason1914@gmail.com）
//  Date: 2014-1-25
//================================================================================
//  Change History
//================================================================================
//  Date  Author  Description
//  ----    ------  -----------------
//
//================================================================================
//  Copyright (C) 2004-2009 Jeason Young Corporation
//================================================================================
--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Yaesoft.DSI.Web.Index" %>
<%@ Register assembly="iPower.Web" namespace="iPower.Web.UI" tagprefix="JWC" %>
<!DOCTYPE html>
<html lang="zh-cn">
    <head runat="server">
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
        <title><%=this.CurrentSystemName %></title>
        <link rel="stylesheet" href="~/bootstrap/css/bootstrap.min.css" type="text/css"/>
        <link rel="stylesheet" href="~/bootstrap/css/carousel.css" type="text/css"/>
	    <!--[if lt IE 9]>
		    <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/bootstrap/js/ie8-responsive-file-warning.js"></script>
		    <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/bootstrap/js/html5shiv.js"></script>
		    <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/bootstrap/js/respond.min.js"></script>
	    <![endif]-->
	    <style type="text/css">
	    .navbar-right{ margin-right:10px;}
	    </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="navbar-wrapper">
              <div class="container">

                <div class="navbar navbar-inverse navbar-static-top" role="navigation">
                  <div class="container">
                    <div class="navbar-header">
                      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                      </button>
                      <a class="navbar-brand" href="#"><%=this.CurrentSystemName %></a>
                    </div>
                    <div class="navbar-collapse collapse">
                      <div class="navbar-form navbar-right" role="form">
                        <div class="form-group">
                          <input type="text" id="txtLoginAccount" runat="server" title="请输入城域网账号" placeholder="请输入城域网账号" class="form-control">
                        </div>
                        <div class="form-group">
                          <input type="password" id="txtLoginPassword" runat="server" title="请输入城域网密码" placeholder="请输入城域网密码" class="form-control">
                        </div>
                        <button type="submit" id="btnLogin" runat="server" onserverclick="btnLogin_OnClick" class="btn btn-success"> 登 录</button>
                        <JWC:ServerAlert ID="errMessage" runat="server" />
                      </div>
                    </div>
                  </div>
                </div>

              </div>
            </div>
         
            <!-- Main component for a primary marketing message or call to action -->
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
              <!-- Indicators -->
              <ol class="carousel-indicators">
                <asp:Literal ID="liIndicators" runat="server">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                </asp:Literal>
              </ol>
              <div class="carousel-inner">
                <asp:Literal ID="liItems" runat="server">
                    <div class="item active">
                      <div class="container">
                       <div class="carousel-caption">
                          <h1>Example headline.</h1>
                          <p>Note: If you're viewing this page via a <code>file://</code> URL, the "next" and "previous" Glyphicon buttons on the left and right might not load/display properly due to web browser security rules.</p>
                          <p><a class="btn btn-lg btn-primary" href="#" role="button">Sign up today</a></p>
                         </div>
                       </div>
                    </div>
                    <div class="item">
                      <div class="container">
                         <div class="carousel-caption">
                          <h1>Another example headline.</h1>
                          <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                          <p><a class="btn btn-lg btn-primary" href="#" role="button">Learn more</a></p>
                         </div>
                      </div>
                    </div>
                    <div class="item">
                      <div class="container">
                         <div class="carousel-caption">
                          <h1>One more for good measure.</h1>
                          <p>Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.</p>
                          <p><a class="btn btn-lg btn-primary" href="#" role="button">Browse gallery</a></p>
                         </div>
                      </div>
                    </div>
                </asp:Literal>
              </div>
              <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a>
              <a class="right carousel-control" href="#myCarousel" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
            </div><!-- /.carousel -->
            
            
            <!-- Marketing messaging and featurettes -->
            <!-- Wrap the rest of the page in another container to center all the content. -->

            <div class="container marketing">

              <%--<!-- Three columns of text below the carousel -->
              <div class="row">
                <div class="col-lg-4">
                  <img class="img-circle" data-src="holder.js/140x140" alt="Generic placeholder image">
                  <h2>Heading</h2>
                  <p>Donec sed odio dui. Etiam porta sem malesuada magna mollis euismod. Nullam id dolor id nibh ultricies vehicula ut id elit. Morbi leo risus, porta ac consectetur ac, vestibulum at eros. Praesent commodo cursus magna.</p>
                  <p><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
                </div><!-- /.col-lg-4 -->
                <div class="col-lg-4">
                  <img class="img-circle" data-src="holder.js/140x140" alt="Generic placeholder image">
                  <h2>Heading</h2>
                  <p>Duis mollis, est non commodo luctus, nisi erat porttitor ligula, eget lacinia odio sem nec elit. Cras mattis consectetur purus sit amet fermentum. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh.</p>
                  <p><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
                </div><!-- /.col-lg-4 -->
                <div class="col-lg-4">
                  <img class="img-circle" data-src="holder.js/140x140" alt="Generic placeholder image">
                  <h2>Heading</h2>
                  <p>Donec sed odio dui. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Vestibulum id ligula porta felis euismod semper. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus.</p>
                  <p><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>
                </div><!-- /.col-lg-4 -->
              </div><!-- /.row -->--%>

              <!-- FOOTER -->
              <footer>
                <%--<p class="pull-right"><a href="#">Back to top</a></p>--%>
                <p>&middot;<%=this.CopyRight %>&middot;</p>
              </footer>

            </div><!-- /.container -->
        </form>
        <!-- Bootstrap core JavaScript-->
        <!-- Placed at the end of the document so the pages load faster -->
        <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/bootstrap/js/jquery-1.11.0.min.js"></script>
        <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/bootstrap/js/bootstrap.min.js"></script>
        <script type="text/javascript" charset="utf-8" src="<%#Request.ApplicationPath %>/bootstrap/js/holder.js"></script>
        <script type="text/javascript">
        </script>
    </body>
</html>