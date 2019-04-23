<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connections.aspx.cs" Inherits="DashBox.Connections" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
  <!-- Meta, title, CSS, favicons, etc. -->
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">

  <title>Bienvenue sur Dashbox !</title>

 <!-- Bootstrap core CSS -->

  <link href="css/bootstrap.min.css" rel="stylesheet">

  <link href="fonts/css/font-awesome.min.css" rel="stylesheet">
  <link href="css/animate.min.css" rel="stylesheet">

  <!-- Custom styling plus plugins -->
  <link href="css/custom.css" rel="stylesheet">
  <link href="css/icheck/flat/green.css" rel="stylesheet">
  <!-- editor -->
  <link href="http://netdna.bootstrapcdn.com/font-awesome/3.0.2/css/font-awesome.css" rel="stylesheet">
  <link href="css/editor/external/google-code-prettify/prettify.css" rel="stylesheet">
  <link href="css/editor/index.css" rel="stylesheet">
  <!-- select2 -->
  <link href="css/select/select2.min.css" rel="stylesheet">
  <!-- switchery -->
  <link rel="stylesheet" href="css/switchery/switchery.min.css" />

  <script src="js/jquery.min.js"></script>

  <!--[if lt IE 9]>
        <script src="../assets/js/ie8-responsive-file-warning.js"></script>
        <![endif]-->

  <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
  <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
          <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
        <![endif]-->

</head>


<body class="nav-md">

  <div class="container body">


    <div class="main_container">

      <div class="col-md-3 left_col">
        <div class="left_col scroll-view">

          <div class="navbar nav_title" style="border: 0;">
            <a href="index.html" class="site_title"><span>Dashbox</span></a>
          </div>
          <div class="clearfix"></div>


          <!-- menu prile quick info -->

          <!-- /menu prile quick info -->

          <br />
            <br />

          <!-- sidebar menu -->
                   <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">

            <div class="menu_section">
              <h3>General</h3>
              <ul class="nav side-menu">
                <li><a><i class="fa fa-home"></i> Accueil <span class="fa fa-chevron-down"></span></a>
                  <ul class="nav child_menu" style="display: none">
                    <li><a href="Dashboard.aspx">Visualisation</a>
                    </li>
                  </ul>
                </li>
                <li><a><i class="fa fa-edit"></i> Admin <span class="fa fa-chevron-down"></span></a>
                  <ul class="nav child_menu" style="display: none">
                    <li><a href="Connections.aspx">Connections</a>
                    </li>
                      <li><a href="Charts.aspx">Graphiques</a>
                    </li>
                       <li><a href="DashboardEditor.aspx">Tableaux de bord</a>
                    </li>
                  </ul>
                </li>
                
              </ul>
            </div>

          </div>
          <!-- /sidebar menu -->

          <!-- /menu footer buttons -->
          <div class="sidebar-footer hidden-small">
            <a data-toggle="tooltip" data-placement="top" title="Settings">
              <span class="glyphicon glyphicon-cog" aria-hidden="true"></span>
            </a>
            <a data-toggle="tooltip" data-placement="top" title="FullScreen">
              <span class="glyphicon glyphicon-fullscreen" aria-hidden="true"></span>
            </a>
            <a data-toggle="tooltip" data-placement="top" title="Lock">
              <span class="glyphicon glyphicon-eye-close" aria-hidden="true"></span>
            </a>
            <a data-toggle="tooltip" data-placement="top" title="Logout">
              <span class="glyphicon glyphicon-off" aria-hidden="true"></span>
            </a>
          </div>
          <!-- /menu footer buttons -->
        </div>
      </div>

      <!-- top navigation -->
      <div class="top_nav">

        <div class="nav_menu">
          <nav class="" role="navigation">
            <div class="nav toggle">
              <a id="menu_toggle"><i class="fa fa-bars"></i></a>
            </div>

            <ul class="nav navbar-nav navbar-right">
              <li class="">
                <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                  <img src="images/img.jpg" alt=""><span id="usernamespan" runat="server" ></span>
                  <span class=" fa fa-angle-down"></span>
                </a>
                <ul class="dropdown-menu dropdown-usermenu animated fadeInDown pull-right">
                  <li><a href="javascript:;">  Profile</a>
                  </li>
                  <li>
                    <a href="javascript:;">
                      <span class="badge bg-red pull-right">50%</span>
                      <span>Settings</span>
                    </a>
                  </li>
                  <li>
                    <a href="javascript:;">Help</a>
                  </li>
                  <li><a href="login.aspx"><i class="fa fa-sign-out pull-right"></i> Log Out</a>
                  </li>
                </ul>
              </li>

              <li role="presentation" class="dropdown">
                <a href="javascript:;" class="dropdown-toggle info-number" data-toggle="dropdown" aria-expanded="false">
                  <i class="fa fa-envelope-o"></i>
                  <span class="badge bg-green">6</span>
                </a>
                <ul id="menu1" class="dropdown-menu list-unstyled msg_list animated fadeInDown" role="menu">
                  <li>
                    <a>
                      <span class="image">
                                        <img src="images/img.jpg" alt="Profile Image" />
                                    </span>
                      <span>
                                        <span>John Smith</span>
                      <span class="time">3 mins ago</span>
                      </span>
                      <span class="message">
                                        Film festivals used to be do-or-die moments for movie makers. They were where...
                                    </span>
                    </a>
                  </li>
                  <li>
                    <a>
                      <span class="image">
                                        <img src="images/img.jpg" alt="Profile Image" />
                                    </span>
                      <span>
                                        <span>John Smith</span>
                      <span class="time">3 mins ago</span>
                      </span>
                      <span class="message">
                                        Film festivals used to be do-or-die moments for movie makers. They were where...
                                    </span>
                    </a>
                  </li>
                  <li>
                    <a>
                      <span class="image">
                                        <img src="images/img.jpg" alt="Profile Image" />
                                    </span>
                      <span>
                                        <span>John Smith</span>
                      <span class="time">3 mins ago</span>
                      </span>
                      <span class="message">
                                        Film festivals used to be do-or-die moments for movie makers. They were where...
                                    </span>
                    </a>
                  </li>
                  <li>
                    <a>
                      <span class="image">
                                        <img src="images/img.jpg" alt="Profile Image" />
                                    </span>
                      <span>
                                        <span>John Smith</span>
                      <span class="time">3 mins ago</span>
                      </span>
                      <span class="message">
                                        Film festivals used to be do-or-die moments for movie makers. They were where...
                                    </span>
                    </a>
                  </li>
                  <li>
                    <div class="text-center">
                      <a>
                        <strong>See All Alerts</strong>
                        <i class="fa fa-angle-right"></i>
                      </a>
                    </div>
                  </li>
                </ul>
              </li>

            </ul>
          </nav>
        </div>

      </div>
      <!-- /top navigation -->


      <!-- page content -->
      <div class="right_col" role="main">
        <div class="">

          <div class="page-title">
            <div class="title_left">
              <h3>Connections</h3>
            </div>
            <div class="title_right">
              <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                <div class="input-group">
                  <input type="text" class="form-control" placeholder="Search for...">
                  <span class="input-group-btn">
                            <button class="btn btn-default" type="button">Go!</button>
                        </span>
                </div>
              </div>
            </div>
          </div>
          <div class="clearfix"></div>



          <div class="row">

               <div id="ErrorNotif" style="display:none" class="alert alert-danger">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <span class="glyphicon glyphicon-exclamation-sign"></span> &nbsp;<span id="ErrorNotifMessage">This alert box could indicate a dangerous or potentially negative action.</span>
              </div>

             <div id="SuccesNotif" style="display:none" class="alert alert-success">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span> &nbsp;<span id="SuccesNotifMessage">This alert box could indicate a successful or positive action.</span>
              </div>

            <div class="col-md-6 col-xs-12">
              <div class="x_panel">
                <div class="x_title">
                  <h2>Création connexion</h2>
                  <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                      <ul class="dropdown-menu" role="menu">
                        <li><a href="#">Settings 1</a>
                        </li>
                        <li><a href="#">Settings 2</a>
                        </li>
                      </ul>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                  </ul>
                  <div class="clearfix"></div>
                </div>
                <div class="x_content">
                  <br />
                  <form class="form-horizontal form-label-left">
                      <div class="form-group">
                      <label class="control-label col-md-3 col-sm-3 col-xs-12">Nom <span class="required">*</span></label>
                      <div class="col-md-9 col-sm-9 col-xs-12">
                        <input id="Nom" type="text" class="form-control" placeholder="Nom">
                      </div>
                    </div>
                      <div class="form-group">
                      <label class="control-label col-md-3 col-sm-3 col-xs-12">Source <span class="required">*</span></label>
                      <div class="col-md-9 col-sm-9 col-xs-12">
                        <select id="Source" class="form-control">
                          <option value="Dynamics CRM">Dynamics CRM</option>
                          <option value="SAGE 100">SAGE 100</option>
                          <option value="SAGE 1000">SAGE 1000</option>
                          <option value="SAP Business One">SAP Business One</option>
                        </select>
                      </div>
                    </div>
                      <div class="form-group">
                      <label class="control-label col-md-3 col-sm-3 col-xs-12">URL <span class="required">*</span></label>
                      <div class="col-md-9 col-sm-9 col-xs-12">
                        <input id="URL" type="text" required="required"  class="form-control" placeholder="https://crm.domaine.com">
                      </div>
                    </div>
                       <div class="form-group">
                      <label class="control-label col-md-3 col-sm-3 col-xs-12">Nom d'utilisateur <span class="required">*</span></label>
                      <div class="col-md-9 col-sm-9 col-xs-12">
                        <input id="Username" type="text" required="required"  class="form-control" placeholder="Nom d'utilisateur">
                      </div>
                    </div>
                     <div class="form-group">
                      <label class="control-label col-md-3 col-sm-3 col-xs-12">Mot de passe <span class="required">*</span></label>
                      <div class="col-md-9 col-sm-9 col-xs-12">
                        <input id="Password" type="password" required="required"  class="form-control" >
                      </div>
                    </div>
                    


                    <div class="ln_solid"></div>
                    <div class="form-group">
                      <div class="col-md-9 col-sm-9 col-xs-12 col-md-offset-3">
                        <button type="button" onclick="return TestConnection()" class="btn btn-info">Tester</button>
                        <button type="button" onclick="return submitForm()" class="btn btn-success">Enregistrer</button>
                      </div>
                    </div>

                  </form>
                </div>
              </div>
            </div>


            <div class="col-md-6 col-sm-12 col-xs-12">
              <div class="x_panel">
                <div class="x_title">
                  <h2>Graphiques</h2>
                  <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li class="dropdown">
                      <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                      <ul class="dropdown-menu" role="menu">
                        <li><a href="#">Settings 1</a>
                        </li>
                        <li><a href="#">Settings 2</a>
                        </li>
                      </ul>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                  </ul>
                  <div class="clearfix"></div>
                </div>
                <div class="x_content">

                    <table id="ConnectionsTable" class="table table-striped">
                    <thead>
                      <tr>
                        <th>Id</th>
                        <th>Nom</th>
                        <th>Source</th>
                        <th>Compte</th>
                      </tr>
                    </thead>
                  </table>

                </div>
              </div>
            </div>
          </div>




        </div>
        <!-- /page content -->

        <!-- footer content -->
        <footer>
          <div class="copyright-info">
            <p class="pull-right">Gentelella - Bootstrap Admin Template by <a href="https://colorlib.com">Colorlib</a>
            </p>
          </div>
          <div class="clearfix"></div>
        </footer>
        <!-- /footer content -->

      </div>
      <!-- /page content -->
    </div>


  </div>


  <div id="custom_notifications" class="custom-notifications dsp_none">
    <ul class="list-unstyled notifications clearfix" data-tabbed_notifications="notif-group">
    </ul>
    <div class="clearfix"></div>
    <div id="notif-group" class="tabbed_notifications"></div>
  </div>

  <script src="js/bootstrap.min.js"></script>

  <!-- bootstrap progress js -->
  <script src="js/progressbar/bootstrap-progressbar.min.js"></script>
  <script src="js/nicescroll/jquery.nicescroll.min.js"></script>
  <!-- icheck -->
  <script src="js/icheck/icheck.min.js"></script>
  <!-- tags -->
  <script src="js/tags/jquery.tagsinput.min.js"></script>
  <!-- switchery -->
  <script src="js/switchery/switchery.min.js"></script>
  <!-- daterangepicker -->
  <script type="text/javascript" src="js/moment/moment.min.js"></script>
  <script type="text/javascript" src="js/datepicker/daterangepicker.js"></script>
  <!-- richtext editor -->
  <script src="js/editor/bootstrap-wysiwyg.js"></script>
  <script src="js/editor/external/jquery.hotkeys.js"></script>
  <script src="js/editor/external/google-code-prettify/prettify.js"></script>
  <!-- select2 -->
  <script src="js/select/select2.full.js"></script>
  <!-- form validation -->
  <script type="text/javascript" src="js/parsley/parsley.min.js"></script>
  <!-- textarea resize -->
  <script src="js/textarea/autosize.min.js"></script>
  <script>
      autosize($('.resizable_textarea'));
  </script>
  <!-- Autocomplete -->
  <script type="text/javascript" src="js/autocomplete/countries.js"></script>
  <script src="js/autocomplete/jquery.autocomplete.js"></script>

 <!-- Datatables -->
    <script type="text/javascript"  src="js/datatables/js/jquery.dataTables.min.js"></script>
    <!--<script type="text/javascript" language="javascript" src="https://cdn.datatables.net/1.10.11/js/jquery.dataTables.min.js"> </script>-->
  <script src="js/datatables/tools/js/dataTables.tableTools.js"></script>

      <!-- PNotify -->
  <script type="text/javascript" src="js/notify/pnotify.core.js"></script>
  <script type="text/javascript" src="js/notify/pnotify.buttons.js"></script>
  <script type="text/javascript" src="js/notify/pnotify.nonblock.js"></script>

  <!-- pace -->
  <script src="js/pace/pace.min.js"></script>
  <script type="text/javascript">
      $(function () {
          'use strict';
          var countriesArray = $.map(countries, function (value, key) {
              return {
                  value: value,
                  data: key
              };
          });
          // Initialize autocomplete with custom appendTo:
          $('#autocomplete-custom-append').autocomplete({
              lookup: countriesArray,
              appendTo: '#autocomplete-container'
          });
      });
  </script>
  <script src="js/custom.js"></script>


  <!-- select2 -->
  <script>
      $(document).ready(function () {
          $(".select2_single").select2({
              placeholder: "Select a state",
              allowClear: true
          });
          $(".select2_group").select2({});
          $(".select2_multiple").select2({
              maximumSelectionLength: 4,
              placeholder: "With Max Selection limit 4",
              allowClear: true
          });
      });
  </script>
  <!-- /select2 -->
  <!-- input tags -->
  <script>
      function onAddTag(tag) {
          alert("Added a tag: " + tag);
      }

      function onRemoveTag(tag) {
          alert("Removed a tag: " + tag);
      }

      function onChangeTag(input, tag) {
          alert("Changed a tag: " + tag);
      }

      $(function () {
          $('#tags_1').tagsInput({
              width: 'auto'
          });
      });
  </script>
  <!-- /input tags -->
  <!-- form validation -->
  <script type="text/javascript">
      $(document).ready(function () {
          $.listen('parsley:field:validate', function () {
              validateFront();
          });
          $('#demo-form .btn').on('click', function () {
              $('#demo-form').parsley().validate();
              validateFront();
          });
          var validateFront = function () {
              if (true === $('#demo-form').parsley().isValid()) {
                  $('.bs-callout-info').removeClass('hidden');
                  $('.bs-callout-warning').addClass('hidden');
              } else {
                  $('.bs-callout-info').addClass('hidden');
                  $('.bs-callout-warning').removeClass('hidden');
              }
          };
      });

      $(document).ready(function () {
          $.listen('parsley:field:validate', function () {
              validateFront();
          });
          $('#demo-form2 .btn').on('click', function () {
              $('#demo-form2').parsley().validate();
              validateFront();
          });
          var validateFront = function () {
              if (true === $('#demo-form2').parsley().isValid()) {
                  $('.bs-callout-info').removeClass('hidden');
                  $('.bs-callout-warning').addClass('hidden');
              } else {
                  $('.bs-callout-info').addClass('hidden');
                  $('.bs-callout-warning').removeClass('hidden');
              }
          };
      });
      try {
          hljs.initHighlightingOnLoad();
      } catch (err) { }
  </script>
  <!-- /form validation -->
  <!-- editor -->
  <script>

      var tableconn;

      $(document).ready(function () {
          $('.xcxc').click(function () {
              $('#descr').val($('#editor').html());
          });


          tableconn = $('#ConnectionsTable').DataTable({
              "processing": true,
              "serverSide": true,
              "searching": false,
              "ordering": false,
              "searching": false,
              "ajax": "api/connections/grid",
              "columns": [
                  { "data": "Id" },
                  { "data": "Nom" },
                  { "data": "Source" },
                  { "data": "Compte" }
              ]
          });


      });

      $(function () {
          function initToolbarBootstrapBindings() {
              var fonts = ['Serif', 'Sans', 'Arial', 'Arial Black', 'Courier',
                  'Courier New', 'Comic Sans MS', 'Helvetica', 'Impact', 'Lucida Grande', 'Lucida Sans', 'Tahoma', 'Times',
                  'Times New Roman', 'Verdana'
              ],
                fontTarget = $('[title=Font]').siblings('.dropdown-menu');
              $.each(fonts, function (idx, fontName) {
                  fontTarget.append($('<li><a data-edit="fontName ' + fontName + '" style="font-family:\'' + fontName + '\'">' + fontName + '</a></li>'));
              });
              $('a[title]').tooltip({
                  container: 'body'
              });
              $('.dropdown-menu input').click(function () {
                  return false;
              })
                .change(function () {
                    $(this).parent('.dropdown-menu').siblings('.dropdown-toggle').dropdown('toggle');
                })
                .keydown('esc', function () {
                    this.value = '';
                    $(this).change();
                });

              $('[data-role=magic-overlay]').each(function () {
                  var overlay = $(this),
                    target = $(overlay.data('target'));
                  overlay.css('opacity', 0).css('position', 'absolute').offset(target.offset()).width(target.outerWidth()).height(target.outerHeight());
              });
              if ("onwebkitspeechchange" in document.createElement("input")) {
                  var editorOffset = $('#editor').offset();
                  $('#voiceBtn').css('position', 'absolute').offset({
                      top: editorOffset.top,
                      left: editorOffset.left + $('#editor').innerWidth() - 35
                  });
              } else {
                  $('#voiceBtn').hide();
              }
          };

          function showErrorAlert(reason, detail) {
              var msg = '';
              if (reason === 'unsupported-file-type') {
                  msg = "Unsupported format " + detail;
              } else {
                  console.log("error uploading file", reason, detail);
              }
              $('<div class="alert"> <button type="button" class="close" data-dismiss="alert">&times;</button>' +
                '<strong>File upload error</strong> ' + msg + ' </div>').prependTo('#alerts');
          };
          initToolbarBootstrapBindings();
          $('#editor').wysiwyg({
              fileUploadError: showErrorAlert
          });
          window.prettyPrint && prettyPrint();
      });


      function TestConnection() {

          var connection = {
              Source: $('#Source').val(),
              Url: $('#URL').val(),
              Username: $('#Username').val(),
              Password: $('#Password').val()
          }

    


          $.ajax({
              type: "POST",
              url: "api/connections/testconnection",
              dataType: 'json',
              contentType: "application/json",
              data: JSON.stringify(connection),
              success: function () {

                  new PNotify({
                      title: 'Succès',
                      text: "Test de connexion réussi",
                      type: 'success'
                  });


              
              },
              error: function (request, status, error) {

              

                  new PNotify({
                      title: 'Erreur',
                      text: "Erreur lors du test de connexion " + $('#Nom').val() + " : " + request.responseText,
                      type: 'error',
                      hide: false
                  });

              }
          });
          return false;
      }

      function submitForm() {

          var connection = {
              Nom: $('#Nom').val(),
              Source: $('#Source').val(),
              Url: $('#URL').val(),
              Username: $('#Username').val(),
              Password: $('#Password').val()
          }


          $.ajax({
              type: "POST",
              url: "api/connections/createconnection",
              dataType: 'json',
              contentType: "application/json",
              data: JSON.stringify(connection),
              success: function () {

                  new PNotify({
                      title: 'Succès',
                      text: "Connexion : '" + $('#Nom').val() + "' créée avec succès",
                      type: 'success'
                  });

               

                  setTimeout(function () {
               
                      $('#ConnectionsTable').DataTable().destroy();

                      $('#ConnectionsTable').DataTable({
                          "processing": true,
                          "serverSide": true,
                          "searching": false,
                          "ordering": false,
                          "searching": false,
                          "ajax": "api/connections/grid",
                          "columns": [
                              { "data": "Id" },
                              { "data": "Nom" },
                              { "data": "Source" },
                              { "data": "Compte" }
                          ]
                      });

                  
                  }, 1000);


              },
              error: function (request, status, error) {


                  new PNotify({
                      title: 'Erreur',
                      text: "Erreur lors de céation de la connexion '" + $('#Nom').val() + "' : " + request.responseText,
                      type: 'error'
                  });
              }
          });

          return false;
      }
  </script>
</body>

</html>
