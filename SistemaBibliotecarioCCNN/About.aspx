<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SistemaBibliotecarioCCNN.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/><br/>
    
    <%--<h2><%: Title %>.</h2>--%>
    <div class="container-fluid" style="background:#F5F5F5;">
        <br/>
        <div class="row">
            <div class="col-md-12">
                <h3 style="font-weight:bold">Sistema Bibliotecario de Prestamo y Registro de Materiales SISBIPREM - Emily Dickinson CCNN</h3><br/>
                <p style="font-size:15px; text-align:justify">Esta aplicacion web permite realizar reservaciones de materiales como: Libros, Audiobooks, Peliculas, Revistar
                    disponibles en la Biblioteca Emily del Centro Cultura Nicaraguense Norteamaricano CCNN.
                </p>
            </div>
          <%--   <div class="col-md-1"></div>--%>
            <br/>
         
            <div class="col-md-12">
                   <br/>
                <div class="col-md-6">
                    <p style="text-align:justify;font-size:15px;">El Centro Cultural Nicaragüense Norteamericano (CCNN) fue fundado en 1942 para servir como puente inter-cultural entre 
                       el pueblo de Nicaragua y los Estados Unidos de América. El CCNN ha administrado una prestigiosa escuela desde hace 
                       treinta años y ha producido una generación de personas de habla inglesa, muchos de los cuales han pasado a ofrecer 
                       un liderazgo en los negocios y la comunidad. Años mas tarde, el Centro fue destruido por el terremoto que devastó 
                       Managua en 1972 y permaneció cerrado durante veinte años, hasta la compra de un edificio en la localidad de Nejapa
                      (Managua) financiado por el Gobierno de los EE.UU. en el año 1993. Durante los siguientes quince años, el CCNN 
                       creció para servir a los estudiantes en las comunidades de todo el país.

                    </p>

                </div>

                <div class="col-md-6">
                    <p style="text-align:justify; font-size:15px;">
                        En 2009 el CCNN inició un proceso de reorganización que comenzó con el traslado a una mejor ubicación en Los Robles,
                        y la revitalización de los programas y servicios. En 2011 la Junta Directiva y el Gobierno de los EE.UU.
                        se comprometieron con la construcción de un nuevo campus ubicado en una propiedad de dos hectáreas cerca de la Colonia
                        Militar Villa Tiscapa, en el centro de Managua. El CCNN inauguró su nueva instalación en enero del 2014.
                    </p>
                </div>

                <div class="col-md-12">
                     <asp:Image ID="LogoFooter" ImageUrl="~/Img/Logo-footer-ccnn-2019.png" CssClass="img-responsive" runat="server" />
                </div>

            </div>
        </div>
    </div>

    <div class="container-fluid" style="background:#F5F5F5;">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-5">
                    <div id="myCarousel" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                            <li data-target="#myCarousel" data-slide-to="1"></li>
                            <li data-target="#myCarousel" data-slide-to="2"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">
                            <div class="item active">
                                <img src="Img/Foto1CCNN.jpg" alt="Los Angeles">
                            </div>

                            <div class="item">
                                <img src="Img/Foto2CCNN.jpg" alt="Chicago">
                            </div>

                            <div class="item">
                                <img src="Img/Foto3CCNN.jpg" alt="New York">
                            </div>
                        </div>

                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#myCarousel" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                    <br/>
                    <p style="font-weight:bold;">Contactenos:</p>
                    <p>(505) 2278 1288 | Fax: (505) 2278 1244</p>
                    <p style="font-weight:bold;">Escribanos al correo:</p>
                    <p>soportetecnicobibliotecaccnn@gmail.com</p>
                    
                   

                </div>
                <div class="col-md-7">
                    <%--<div class="col-md-1"></div>--%>
                    <p style="text-align:justify; font-size:15px;">
                        En el año 2018 se realizó una remodelacion de la Biblioteca Emily Dickinson, donada por la embajada américa,
                        con el fin de motivar la lectura en los estudiantes y publico en general, poniendo a disposición nuevos materiales
                        en idioma inglés.
                    </p>

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
                                <img src="Img/IMG10.jpg" alt="Los Angeles">
                            </div>

                            <div class="item">
                                <img src="Img/IMG12.jpg" alt="Chicago">
                            </div>

                            <div class="item">
                                <img src="Img/IMG5.jpg" alt="New York">
                            </div>

                            <div class="item">
                                <img src="Img/IMG6.jpg" alt="New York">
                            </div>

                            <div class="item">
                                <img src="Img/IMG8.jpg" alt="New York">
                            </div>

                            <div class="item">
                                <img src="Img/IMG9.jpg" alt="New York">
                            </div>
                        </div>

                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#myCarousel" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>
                </div>



            </div>
        </div>
    </div>
</asp:Content>
