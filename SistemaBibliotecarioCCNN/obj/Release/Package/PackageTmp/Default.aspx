<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaBibliotecarioCCNN._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container-fluid">
            
             <div id="myCarousel2" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel2" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel2" data-slide-to="1"></li>
                            <li data-target="#myCarousel2" data-slide-to="2"></li>
                            <li data-target="#myCarousel2" data-slide-to="3"></li>
                            <li data-target="#myCarousel2" data-slide-to="4"></li>
                            <li data-target="#myCarousel2" data-slide-to="5"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">
                            <div class="item active">
                                <img src="Img/IMG10.jpg" style="width:100%; height:600px;" alt="Los Angeles">
                            </div>

                            <div class="item">
                                <img src="Img/IMG12.jpg" style="width:100%; height:600px;" alt="Chicago">
                            </div>

                            <div class="item">
                                <img src="Img/IMG5.jpg" style="width:100%; height:600px;" alt="New York">
                            </div>

                            <div class="item">
                                <img src="Img/IMG6.jpg" style="width:100%; height:600px;" alt="New York">
                            </div>

                            <div class="item">
                                <img src="Img/IMG8.jpg" style="width:100%; height:600px;" alt="New York">
                            </div>

                            <div class="item">
                                <img src="Img/IMG9.jpg" style="width:100%; height:600px;" alt="New York">
                            </div>
                        </div>

                        <!-- Left and right controls -->
                       <%-- <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#myCarousel" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                            <span class="sr-only">Next</span>
                        </a>--%>
                    </div>
      </div>

    <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4">
                <h5 style="font-style:italic">Copyright Developed by RARG - CCNN - Biblioteca Emily Dickinson</h5>
                
            </div>
        </div>

         <div class="row">
            <div class="col-md-5"></div>
            <div class="col-md-4">
                <h5 style="font-style:italic">Renán Alfredo Rosales - UNI</h5>
                
            </div>
        </div>
   
</asp:Content>
