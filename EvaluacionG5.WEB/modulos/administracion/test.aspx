﻿<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="EvaluacionG5.WEB.modulos.administracion.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <style type="text/css">
        /***********************************************/
        /***************** Accordion ********************/
        /***********************************************/
        @import url('https://fonts.googleapis.com/css?family=Tajawal');
        @import url('https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css');

        section {
            padding: 60px 0;
        }

        #accordion-style-1 h1,
        #accordion-style-1 a {
            color: #007b5e;
        }

        #accordion-style-1 .btn-link {
            font-weight: 400;
            color: #007b5e;
            background-color: transparent;
            text-decoration: none !important;
            font-size: 16px;
            font-weight: bold;
            padding-left: 25px;
        }

        #accordion-style-1 .card-body {
            border-top: 2px solid #007b5e;
        }

        #accordion-style-1 .card-header .btn.collapsed .fa.main {
            display: none;
        }

        #accordion-style-1 .card-header .btn .fa.main {
            background: #007b5e;
            padding: 13px 11px;
            color: #ffffff;
            width: 35px;
            height: 41px;
            position: absolute;
            left: -1px;
            top: 10px;
            border-top-right-radius: 7px;
            border-bottom-right-radius: 7px;
            display: block;
        }
    </style>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        window.alert = function () { };
        var defaultCSS = document.getElementById('bootstrap-css');
        function changeCSS(css) {
            if (css) $('head > link').filter(':first').replaceWith('<link rel="stylesheet" href="' + css + '" type="text/css" />');
            else $('head > link').filter(':first').replaceWith(defaultCSS);
        }
        $(document).ready(function () {
            var iframe_height = parseInt($('html').height());
            window.parent.postMessage(iframe_height, 'https://bootsnipp.com');
        });
    </script>

    <div id="accordion-style-1">
        <div class="container">

            <div class="accordion" id="accordionExample">
                <div class="card">
                    <div class="card-header" id="headingOne">
                        <h5 class="mb-0">
                            <button class="btn btn-link btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                <i class="fa fa-amazon main"></i><i class="fa fa-angle-double-right mr-3"></i>How to pay amazon.
                            </button>
                        </h5>
                    </div>

                    <div id="collapseOne" class="collapse show fade" aria-labelledby="headingOne" data-parent="#accordionExample">
                        <div class="card-body">
                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.<a href="https://www.fiverr.com/sunlimetech/fix-your-bootstrap-html-and-css3-issues" class="ml-3" target="_blank"><strong>View More designs <i class="fa fa-angle-double-right"></i></strong></a>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header" id="headingTwo">
                        <h5 class="mb-0">
                            <button class="btn btn-link collapsed btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                <i class="fa fa-plus main"></i><i class="fa fa-angle-double-right mr-3"></i>There are many more.
                            </button>
                        </h5>
                    </div>
                    <div id="collapseTwo" class="collapse fade" aria-labelledby="headingTwo" data-parent="#accordionExample">
                        <div class="card-body">
                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.<a href="https://www.fiverr.com/sunlimetech/design-and-fix-your-bootstrap-4-issues" class="ml-3" target="_blank"><strong>View More designs <i class="fa fa-angle-double-right"></i></strong></a>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header" id="headingThree">
                        <h5 class="mb-0">
                            <button class="btn btn-link collapsed btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                <i class="fa fa-expeditedssl main"></i><i class="fa fa-angle-double-right mr-3"></i>How to enable two factor authentication.
                            </button>
                        </h5>
                    </div>
                    <div id="collapseThree" class="collapse fade" aria-labelledby="headingThree" data-parent="#accordionExample">
                        <div class="card-body">
                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.<a href="https://www.fiverr.com/sunlimetech/convert-bootstrap-or-html-to-wordpress-for-global-devices" class="ml-3" target="_blank"><strong>View More designs <i class="fa fa-angle-double-right"></i></strong></a>
                        </div>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header" id="headingFour">
                        <h5 class="mb-0">
                            <button class="btn btn-link collapsed btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                                <i class="fa fa-envelope main"></i><i class="fa fa-angle-double-right mr-3"></i>How to contact us.
                            </button>
                        </h5>
                    </div>
                    <div id="collapseFour" class="collapse fade" aria-labelledby="headingFour" data-parent="#accordionExample">
                        <div class="card-body">
                            Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.<a href="https://www.fiverr.com/sunlimetech/do-web-development-in-pure-php-and-frameworks" class="ml-3" target="_blank"><strong>View More designs <i class="fa fa-angle-double-right"></i></strong></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
