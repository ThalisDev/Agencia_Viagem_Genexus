using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pais : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpais_cidade") == 0 )
         {
            nRC_GXsfl_53 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."));
            nGXsfl_53_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."));
            sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
            A16PaisCidadeLastid = (int)(NumberUtil.Val( GetPar( "PaisCidadeLastid"), "."));
            Gx_BScreen = (short)(NumberUtil.Val( GetPar( "Gx_BScreen"), "."));
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridpais_cidade_newrow( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7paisID = (int)(NumberUtil.Val( GetPar( "paisID"), "."));
               AssignAttri("", false, "AV7paisID", StringUtil.LTrimStr( (decimal)(AV7paisID), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7paisID), "ZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_4-151606", 0) ;
            }
            Form.Meta.addItem("description", "pais", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaisnome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public pais( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pais( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_paisID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7paisID = aP1_paisID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "pais", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtpaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtpaisID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtpaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8paisID), 6, 0, ",", "")), ((edtpaisID_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A8paisID), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A8paisID), "ZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtpaisID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtpaisID_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisnome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisnome_Internalname, "Paisnome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisnome_Internalname, A9Paisnome, StringUtil.RTrim( context.localUtil.Format( A9Paisnome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisnome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisnome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisCidadeLastid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisCidadeLastid_Internalname, "Cidade Lastid", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisCidadeLastid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16PaisCidadeLastid), 6, 0, ",", "")), ((edtPaisCidadeLastid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A16PaisCidadeLastid), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A16PaisCidadeLastid), "ZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisCidadeLastid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisCidadeLastid_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divCidadetable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlecidade_Internalname, "Cidade", "", "", lblTitlecidade_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridpais_cidade( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_pais.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridpais_cidade( )
      {
         /*  Grid Control  */
         Gridpais_cidadeContainer.AddObjectProperty("GridName", "Gridpais_cidade");
         Gridpais_cidadeContainer.AddObjectProperty("Header", subGridpais_cidade_Header);
         Gridpais_cidadeContainer.AddObjectProperty("Class", "Grid");
         Gridpais_cidadeContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridpais_cidadeContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridpais_cidadeContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_cidade_Backcolorstyle), 1, 0, ".", "")));
         Gridpais_cidadeContainer.AddObjectProperty("CmpContext", "");
         Gridpais_cidadeContainer.AddObjectProperty("InMasterPage", "false");
         Gridpais_cidadeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpais_cidadeColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13paisCidadeID), 6, 0, ".", "")));
         Gridpais_cidadeColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtpaisCidadeID_Enabled), 5, 0, ".", "")));
         Gridpais_cidadeContainer.AddColumnProperties(Gridpais_cidadeColumn);
         Gridpais_cidadeColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpais_cidadeColumn.AddObjectProperty("Value", A14paisCidadeNome);
         Gridpais_cidadeColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtpaisCidadeNome_Enabled), 5, 0, ".", "")));
         Gridpais_cidadeContainer.AddColumnProperties(Gridpais_cidadeColumn);
         Gridpais_cidadeContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_cidade_Selectedindex), 4, 0, ".", "")));
         Gridpais_cidadeContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_cidade_Allowselection), 1, 0, ".", "")));
         Gridpais_cidadeContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_cidade_Selectioncolor), 9, 0, ".", "")));
         Gridpais_cidadeContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_cidade_Allowhovering), 1, 0, ".", "")));
         Gridpais_cidadeContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_cidade_Hoveringcolor), 9, 0, ".", "")));
         Gridpais_cidadeContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_cidade_Allowcollapsing), 1, 0, ".", "")));
         Gridpais_cidadeContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpais_cidade_Collapsed), 1, 0, ".", "")));
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount5 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_5 = 1;
               ScanStart035( ) ;
               while ( RcdFound5 != 0 )
               {
                  init_level_properties5( ) ;
                  getByPrimaryKey035( ) ;
                  AddRow035( ) ;
                  ScanNext035( ) ;
               }
               ScanEnd035( ) ;
               nBlankRcdCount5 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B16PaisCidadeLastid = A16PaisCidadeLastid;
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
            standaloneNotModal035( ) ;
            standaloneModal035( ) ;
            sMode5 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow035( ) ;
               edtpaisCidadeID_Enabled = (int)(context.localUtil.CToN( cgiGet( "PAISCIDADEID_"+sGXsfl_53_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtpaisCidadeID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtpaisCidadeNome_Enabled = (int)(context.localUtil.CToN( cgiGet( "PAISCIDADENOME_"+sGXsfl_53_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtpaisCidadeNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeNome_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               if ( ( nRcdExists_5 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal035( ) ;
               }
               SendRow035( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A16PaisCidadeLastid = B16PaisCidadeLastid;
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount5 = 5;
            nRcdExists_5 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart035( ) ;
               while ( RcdFound5 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_535( ) ;
                  init_level_properties5( ) ;
                  standaloneNotModal035( ) ;
                  getByPrimaryKey035( ) ;
                  standaloneModal035( ) ;
                  AddRow035( ) ;
                  ScanNext035( ) ;
               }
               ScanEnd035( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode5 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
            SubsflControlProps_535( ) ;
            InitAll035( ) ;
            init_level_properties5( ) ;
            B16PaisCidadeLastid = A16PaisCidadeLastid;
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
            nRcdExists_5 = 0;
            nIsMod_5 = 0;
            nRcdDeleted_5 = 0;
            nBlankRcdCount5 = (short)(nBlankRcdUsr5+nBlankRcdCount5);
            fRowAdded = 0;
            while ( nBlankRcdCount5 > 0 )
            {
               standaloneNotModal035( ) ;
               standaloneModal035( ) ;
               AddRow035( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtpaisCidadeID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount5 = (short)(nBlankRcdCount5-1);
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A16PaisCidadeLastid = B16PaisCidadeLastid;
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridpais_cidadeContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpais_cidade", Gridpais_cidadeContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpais_cidadeContainerData", Gridpais_cidadeContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpais_cidadeContainerData"+"V", Gridpais_cidadeContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridpais_cidadeContainerData"+"V"+"\" value='"+Gridpais_cidadeContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z8paisID = (int)(context.localUtil.CToN( cgiGet( "Z8paisID"), ",", "."));
               Z9Paisnome = cgiGet( "Z9Paisnome");
               Z16PaisCidadeLastid = (int)(context.localUtil.CToN( cgiGet( "Z16PaisCidadeLastid"), ",", "."));
               O16PaisCidadeLastid = (int)(context.localUtil.CToN( cgiGet( "O16PaisCidadeLastid"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_53 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ",", "."));
               AV7paisID = (int)(context.localUtil.CToN( cgiGet( "vPAISID"), ",", "."));
               AV12Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."));
               /* Read variables values. */
               A8paisID = (int)(context.localUtil.CToN( cgiGet( edtpaisID_Internalname), ",", "."));
               n8paisID = false;
               AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
               A9Paisnome = cgiGet( edtPaisnome_Internalname);
               AssignAttri("", false, "A9Paisnome", A9Paisnome);
               A16PaisCidadeLastid = (int)(context.localUtil.CToN( cgiGet( edtPaisCidadeLastid_Internalname), ",", "."));
               AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"pais");
               A8paisID = (int)(context.localUtil.CToN( cgiGet( edtpaisID_Internalname), ",", "."));
               n8paisID = false;
               AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
               forbiddenHiddens.Add("paisID", context.localUtil.Format( (decimal)(A8paisID), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A8paisID != Z8paisID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("pais:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A8paisID = (int)(NumberUtil.Val( GetPar( "paisID"), "."));
                  n8paisID = false;
                  AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PAISID");
                        AnyError = 1;
                        GX_FocusControl = edtpaisID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes033( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode3 = Gx_mode;
            CONFIRM_035( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode3;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_035( )
      {
         s16PaisCidadeLastid = O16PaisCidadeLastid;
         AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow035( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               GetKey035( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  if ( RcdFound5 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate035( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable035( ) ;
                        CloseExtendedTableCursors035( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O16PaisCidadeLastid = A16PaisCidadeLastid;
                        AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "PAISCIDADEID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtpaisCidadeID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( nRcdDeleted_5 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey035( ) ;
                        Load035( ) ;
                        BeforeValidate035( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls035( ) ;
                           O16PaisCidadeLastid = A16PaisCidadeLastid;
                           AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate035( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable035( ) ;
                              CloseExtendedTableCursors035( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O16PaisCidadeLastid = A16PaisCidadeLastid;
                              AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "PAISCIDADEID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtpaisCidadeID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtpaisCidadeID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13paisCidadeID), 6, 0, ",", ""))) ;
            ChangePostValue( edtpaisCidadeNome_Internalname, A14paisCidadeNome) ;
            ChangePostValue( "ZT_"+"Z13paisCidadeID_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13paisCidadeID), 6, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z14paisCidadeNome_"+sGXsfl_53_idx, Z14paisCidadeNome) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ",", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "PAISCIDADEID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtpaisCidadeID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAISCIDADENOME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtpaisCidadeNome_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O16PaisCidadeLastid = s16PaisCidadeLastid;
         AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV12Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "AgenciaViagem");
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpais.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z9Paisnome = T00035_A9Paisnome[0];
               Z16PaisCidadeLastid = T00035_A16PaisCidadeLastid[0];
            }
            else
            {
               Z9Paisnome = A9Paisnome;
               Z16PaisCidadeLastid = A16PaisCidadeLastid;
            }
         }
         if ( GX_JID == -7 )
         {
            Z8paisID = A8paisID;
            Z9Paisnome = A9Paisnome;
            Z16PaisCidadeLastid = A16PaisCidadeLastid;
         }
      }

      protected void standaloneNotModal( )
      {
         edtpaisID_Enabled = 0;
         AssignProp("", false, edtpaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisID_Enabled), 5, 0), true);
         edtPaisCidadeLastid_Enabled = 0;
         AssignProp("", false, edtPaisCidadeLastid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCidadeLastid_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtpaisID_Enabled = 0;
         AssignProp("", false, edtpaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisID_Enabled), 5, 0), true);
         edtPaisCidadeLastid_Enabled = 0;
         AssignProp("", false, edtPaisCidadeLastid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCidadeLastid_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7paisID) )
         {
            A8paisID = AV7paisID;
            n8paisID = false;
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load033( )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {n8paisID, A8paisID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
            A9Paisnome = T00036_A9Paisnome[0];
            AssignAttri("", false, "A9Paisnome", A9Paisnome);
            A16PaisCidadeLastid = T00036_A16PaisCidadeLastid[0];
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
            ZM033( -7) ;
         }
         pr_default.close(4);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV12Pgmname = "pais";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV12Pgmname = "pais";
         AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {n8paisID, A8paisID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {n8paisID, A8paisID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM033( 7) ;
            RcdFound3 = 1;
            A8paisID = T00035_A8paisID[0];
            n8paisID = T00035_n8paisID[0];
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            A9Paisnome = T00035_A9Paisnome[0];
            AssignAttri("", false, "A9Paisnome", A9Paisnome);
            A16PaisCidadeLastid = T00035_A16PaisCidadeLastid[0];
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
            O16PaisCidadeLastid = A16PaisCidadeLastid;
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
            Z8paisID = A8paisID;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {n8paisID, A8paisID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00038_A8paisID[0] < A8paisID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00038_A8paisID[0] > A8paisID ) ) )
            {
               A8paisID = T00038_A8paisID[0];
               n8paisID = T00038_n8paisID[0];
               AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {n8paisID, A8paisID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00039_A8paisID[0] > A8paisID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00039_A8paisID[0] < A8paisID ) ) )
            {
               A8paisID = T00039_A8paisID[0];
               n8paisID = T00039_n8paisID[0];
               AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A16PaisCidadeLastid = O16PaisCidadeLastid;
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
            GX_FocusControl = edtPaisnome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A8paisID != Z8paisID )
               {
                  A8paisID = Z8paisID;
                  n8paisID = false;
                  AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtpaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A16PaisCidadeLastid = O16PaisCidadeLastid;
                  AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaisnome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A16PaisCidadeLastid = O16PaisCidadeLastid;
                  AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
                  Update033( ) ;
                  GX_FocusControl = edtPaisnome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A8paisID != Z8paisID )
               {
                  /* Insert record */
                  A16PaisCidadeLastid = O16PaisCidadeLastid;
                  AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
                  GX_FocusControl = edtPaisnome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAISID");
                     AnyError = 1;
                     GX_FocusControl = edtpaisID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A16PaisCidadeLastid = O16PaisCidadeLastid;
                     AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
                     GX_FocusControl = edtPaisnome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A8paisID != Z8paisID )
         {
            A8paisID = Z8paisID;
            n8paisID = false;
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtpaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A16PaisCidadeLastid = O16PaisCidadeLastid;
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaisnome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {n8paisID, A8paisID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"pais"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z9Paisnome, T00034_A9Paisnome[0]) != 0 ) || ( Z16PaisCidadeLastid != T00034_A16PaisCidadeLastid[0] ) )
            {
               if ( StringUtil.StrCmp(Z9Paisnome, T00034_A9Paisnome[0]) != 0 )
               {
                  GXUtil.WriteLog("pais:[seudo value changed for attri]"+"Paisnome");
                  GXUtil.WriteLogRaw("Old: ",Z9Paisnome);
                  GXUtil.WriteLogRaw("Current: ",T00034_A9Paisnome[0]);
               }
               if ( Z16PaisCidadeLastid != T00034_A16PaisCidadeLastid[0] )
               {
                  GXUtil.WriteLog("pais:[seudo value changed for attri]"+"PaisCidadeLastid");
                  GXUtil.WriteLogRaw("Old: ",Z16PaisCidadeLastid);
                  GXUtil.WriteLogRaw("Current: ",T00034_A16PaisCidadeLastid[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"pais"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A9Paisnome, A16PaisCidadeLastid});
                     A8paisID = T000310_A8paisID[0];
                     n8paisID = T000310_n8paisID[0];
                     AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("pais");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption030( ) ;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A9Paisnome, A16PaisCidadeLastid, n8paisID, A8paisID});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("pais");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"pais"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel033( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  A16PaisCidadeLastid = O16PaisCidadeLastid;
                  AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
                  ScanStart035( ) ;
                  while ( RcdFound5 != 0 )
                  {
                     getByPrimaryKey035( ) ;
                     Delete035( ) ;
                     ScanNext035( ) ;
                     O16PaisCidadeLastid = A16PaisCidadeLastid;
                     AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
                  }
                  ScanEnd035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000312 */
                     pr_default.execute(10, new Object[] {n8paisID, A8paisID});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("pais");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV12Pgmname = "pais";
            AssignAttri("", false, "AV12Pgmname", AV12Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000313 */
            pr_default.execute(11, new Object[] {n8paisID, A8paisID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"atracao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel035( )
      {
         s16PaisCidadeLastid = O16PaisCidadeLastid;
         AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow035( ) ;
            if ( ( nRcdExists_5 != 0 ) || ( nIsMod_5 != 0 ) )
            {
               standaloneNotModal035( ) ;
               GetKey035( ) ;
               if ( ( nRcdExists_5 == 0 ) && ( nRcdDeleted_5 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert035( ) ;
               }
               else
               {
                  if ( RcdFound5 != 0 )
                  {
                     if ( ( nRcdDeleted_5 != 0 ) && ( nRcdExists_5 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete035( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_5 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update035( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_5 == 0 )
                     {
                        GXCCtl = "PAISCIDADEID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtpaisCidadeID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O16PaisCidadeLastid = A16PaisCidadeLastid;
               AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
            }
            ChangePostValue( edtpaisCidadeID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13paisCidadeID), 6, 0, ",", ""))) ;
            ChangePostValue( edtpaisCidadeNome_Internalname, A14paisCidadeNome) ;
            ChangePostValue( "ZT_"+"Z13paisCidadeID_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13paisCidadeID), 6, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z14paisCidadeNome_"+sGXsfl_53_idx, Z14paisCidadeNome) ;
            ChangePostValue( "nRcdDeleted_5_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_5_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_5_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ",", ""))) ;
            if ( nIsMod_5 != 0 )
            {
               ChangePostValue( "PAISCIDADEID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtpaisCidadeID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAISCIDADENOME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtpaisCidadeNome_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll035( ) ;
         if ( AnyError != 0 )
         {
            O16PaisCidadeLastid = s16PaisCidadeLastid;
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         }
         nRcdExists_5 = 0;
         nIsMod_5 = 0;
         nRcdDeleted_5 = 0;
      }

      protected void ProcessLevel033( )
      {
         /* Save parent mode. */
         sMode3 = Gx_mode;
         ProcessNestedLevel035( ) ;
         if ( AnyError != 0 )
         {
            O16PaisCidadeLastid = s16PaisCidadeLastid;
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000314 */
         pr_default.execute(12, new Object[] {A16PaisCidadeLastid, n8paisID, A8paisID});
         pr_default.close(12);
         dsDefault.SmartCacheProvider.SetUpdated("pais");
      }

      protected void EndLevel033( )
      {
         pr_default.close(2);
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("pais",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.RollbackDataStores("pais",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000315 */
         pr_default.execute(13);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A8paisID = T000315_A8paisID[0];
            n8paisID = T000315_n8paisID[0];
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound3 = 1;
            A8paisID = T000315_A8paisID[0];
            n8paisID = T000315_n8paisID[0];
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtpaisID_Enabled = 0;
         AssignProp("", false, edtpaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisID_Enabled), 5, 0), true);
         edtPaisnome_Enabled = 0;
         AssignProp("", false, edtPaisnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisnome_Enabled), 5, 0), true);
         edtPaisCidadeLastid_Enabled = 0;
         AssignProp("", false, edtPaisCidadeLastid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCidadeLastid_Enabled), 5, 0), true);
      }

      protected void ZM035( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z14paisCidadeNome = T00033_A14paisCidadeNome[0];
            }
            else
            {
               Z14paisCidadeNome = A14paisCidadeNome;
            }
         }
         if ( GX_JID == -8 )
         {
            Z8paisID = A8paisID;
            Z13paisCidadeID = A13paisCidadeID;
            Z14paisCidadeNome = A14paisCidadeNome;
         }
      }

      protected void standaloneNotModal035( )
      {
         edtPaisCidadeLastid_Enabled = 0;
         AssignProp("", false, edtPaisCidadeLastid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCidadeLastid_Enabled), 5, 0), true);
         edtPaisCidadeLastid_Enabled = 0;
         AssignProp("", false, edtPaisCidadeLastid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisCidadeLastid_Enabled), 5, 0), true);
      }

      protected void standaloneModal035( )
      {
         if ( IsIns( )  )
         {
            A16PaisCidadeLastid = (int)(O16PaisCidadeLastid+1);
            AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A13paisCidadeID = A16PaisCidadeLastid;
            n13paisCidadeID = false;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtpaisCidadeID_Enabled = 0;
            AssignProp("", false, edtpaisCidadeID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtpaisCidadeID_Enabled = 1;
            AssignProp("", false, edtpaisCidadeID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
      }

      protected void Load035( )
      {
         /* Using cursor T000316 */
         pr_default.execute(14, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound5 = 1;
            A14paisCidadeNome = T000316_A14paisCidadeNome[0];
            ZM035( -8) ;
         }
         pr_default.close(14);
         OnLoadActions035( ) ;
      }

      protected void OnLoadActions035( )
      {
      }

      protected void CheckExtendedTable035( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal035( ) ;
      }

      protected void CloseExtendedTableCursors035( )
      {
      }

      protected void enableDisable035( )
      {
      }

      protected void GetKey035( )
      {
         /* Using cursor T000317 */
         pr_default.execute(15, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey035( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM035( 8) ;
            RcdFound5 = 1;
            InitializeNonKey035( ) ;
            A13paisCidadeID = T00033_A13paisCidadeID[0];
            n13paisCidadeID = T00033_n13paisCidadeID[0];
            A14paisCidadeNome = T00033_A14paisCidadeNome[0];
            Z8paisID = A8paisID;
            Z13paisCidadeID = A13paisCidadeID;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load035( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey035( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal035( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes035( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency035( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"paisCidade"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z14paisCidadeNome, T00032_A14paisCidadeNome[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z14paisCidadeNome, T00032_A14paisCidadeNome[0]) != 0 )
               {
                  GXUtil.WriteLog("pais:[seudo value changed for attri]"+"paisCidadeNome");
                  GXUtil.WriteLogRaw("Old: ",Z14paisCidadeNome);
                  GXUtil.WriteLogRaw("Current: ",T00032_A14paisCidadeNome[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"paisCidade"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM035( 0) ;
            CheckOptimisticConcurrency035( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm035( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert035( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000318 */
                     pr_default.execute(16, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID, A14paisCidadeNome});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("paisCidade");
                     if ( (pr_default.getStatus(16) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load035( ) ;
            }
            EndLevel035( ) ;
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void Update035( )
      {
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable035( ) ;
         }
         if ( ( nIsMod_5 != 0 ) || ( nIsDirty_5 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency035( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm035( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate035( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000319 */
                        pr_default.execute(17, new Object[] {A14paisCidadeNome, n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
                        pr_default.close(17);
                        dsDefault.SmartCacheProvider.SetUpdated("paisCidade");
                        if ( (pr_default.getStatus(17) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"paisCidade"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate035( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey035( ) ;
                           }
                        }
                        else
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                           AnyError = 1;
                        }
                     }
                  }
               }
               EndLevel035( ) ;
            }
         }
         CloseExtendedTableCursors035( ) ;
      }

      protected void DeferredUpdate035( )
      {
      }

      protected void Delete035( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate035( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency035( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls035( ) ;
            AfterConfirm035( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete035( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000320 */
                  pr_default.execute(18, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("paisCidade");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel035( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls035( )
      {
         standaloneModal035( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000321 */
            pr_default.execute(19, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"aeroporto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000322 */
            pr_default.execute(20, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"atracao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel035( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart035( )
      {
         /* Scan By routine */
         /* Using cursor T000323 */
         pr_default.execute(21, new Object[] {n8paisID, A8paisID});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound5 = 1;
            A13paisCidadeID = T000323_A13paisCidadeID[0];
            n13paisCidadeID = T000323_n13paisCidadeID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext035( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound5 = 1;
            A13paisCidadeID = T000323_A13paisCidadeID[0];
            n13paisCidadeID = T000323_n13paisCidadeID[0];
         }
      }

      protected void ScanEnd035( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm035( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert035( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate035( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete035( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete035( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate035( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes035( )
      {
         edtpaisCidadeID_Enabled = 0;
         AssignProp("", false, edtpaisCidadeID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtpaisCidadeNome_Enabled = 0;
         AssignProp("", false, edtpaisCidadeNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeNome_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes035( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void SubsflControlProps_535( )
      {
         edtpaisCidadeID_Internalname = "PAISCIDADEID_"+sGXsfl_53_idx;
         edtpaisCidadeNome_Internalname = "PAISCIDADENOME_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_535( )
      {
         edtpaisCidadeID_Internalname = "PAISCIDADEID_"+sGXsfl_53_fel_idx;
         edtpaisCidadeNome_Internalname = "PAISCIDADENOME_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow035( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_535( ) ;
         SendRow035( ) ;
      }

      protected void SendRow035( )
      {
         Gridpais_cidadeRow = GXWebRow.GetNew(context);
         if ( subGridpais_cidade_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpais_cidade_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpais_cidade_Class, "") != 0 )
            {
               subGridpais_cidade_Linesclass = subGridpais_cidade_Class+"Odd";
            }
         }
         else if ( subGridpais_cidade_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpais_cidade_Backstyle = 0;
            subGridpais_cidade_Backcolor = subGridpais_cidade_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpais_cidade_Class, "") != 0 )
            {
               subGridpais_cidade_Linesclass = subGridpais_cidade_Class+"Uniform";
            }
         }
         else if ( subGridpais_cidade_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpais_cidade_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpais_cidade_Class, "") != 0 )
            {
               subGridpais_cidade_Linesclass = subGridpais_cidade_Class+"Odd";
            }
            subGridpais_cidade_Backcolor = (int)(0x0);
         }
         else if ( subGridpais_cidade_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpais_cidade_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridpais_cidade_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpais_cidade_Class, "") != 0 )
               {
                  subGridpais_cidade_Linesclass = subGridpais_cidade_Class+"Even";
               }
            }
            else
            {
               subGridpais_cidade_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpais_cidade_Class, "") != 0 )
               {
                  subGridpais_cidade_Linesclass = subGridpais_cidade_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridpais_cidadeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtpaisCidadeID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13paisCidadeID), 6, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13paisCidadeID), "ZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtpaisCidadeID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtpaisCidadeID_Enabled,(short)1,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_5_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridpais_cidadeRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtpaisCidadeNome_Internalname,(string)A14paisCidadeNome,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtpaisCidadeNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtpaisCidadeNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridpais_cidadeRow);
         send_integrity_lvl_hashes035( ) ;
         GXCCtl = "Z13paisCidadeID_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13paisCidadeID), 6, 0, ",", "")));
         GXCCtl = "Z14paisCidadeNome_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z14paisCidadeNome);
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_5), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_5_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_5), 4, 0, ",", "")));
         GXCCtl = "nIsMod_5_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_5), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_53_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPAISID_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7paisID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PAISCIDADEID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtpaisCidadeID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAISCIDADENOME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtpaisCidadeNome_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridpais_cidadeContainer.AddRow(Gridpais_cidadeRow);
      }

      protected void ReadRow035( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_535( ) ;
         edtpaisCidadeID_Enabled = (int)(context.localUtil.CToN( cgiGet( "PAISCIDADEID_"+sGXsfl_53_idx+"Enabled"), ",", "."));
         edtpaisCidadeNome_Enabled = (int)(context.localUtil.CToN( cgiGet( "PAISCIDADENOME_"+sGXsfl_53_idx+"Enabled"), ",", "."));
         if ( ( ( context.localUtil.CToN( cgiGet( edtpaisCidadeID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtpaisCidadeID_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PAISCIDADEID_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtpaisCidadeID_Internalname;
            wbErr = true;
            A13paisCidadeID = 0;
            n13paisCidadeID = false;
         }
         else
         {
            A13paisCidadeID = (int)(context.localUtil.CToN( cgiGet( edtpaisCidadeID_Internalname), ",", "."));
            n13paisCidadeID = false;
         }
         A14paisCidadeNome = cgiGet( edtpaisCidadeNome_Internalname);
         GXCCtl = "Z13paisCidadeID_" + sGXsfl_53_idx;
         Z13paisCidadeID = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z14paisCidadeNome_" + sGXsfl_53_idx;
         Z14paisCidadeNome = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_5_" + sGXsfl_53_idx;
         nRcdDeleted_5 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_5_" + sGXsfl_53_idx;
         nRcdExists_5 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_5_" + sGXsfl_53_idx;
         nIsMod_5 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtpaisCidadeID_Enabled = edtpaisCidadeID_Enabled;
      }

      protected void ConfirmValues030( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_535( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_535( ) ;
            ChangePostValue( "Z13paisCidadeID_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z13paisCidadeID_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z13paisCidadeID_"+sGXsfl_53_idx) ;
            ChangePostValue( "Z14paisCidadeNome_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z14paisCidadeNome_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z14paisCidadeNome_"+sGXsfl_53_idx) ;
         }
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 348140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202171522281828", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("pais.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7paisID,6,0))}, new string[] {"Gx_mode","paisID"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"pais");
         forbiddenHiddens.Add("paisID", context.localUtil.Format( (decimal)(A8paisID), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("pais:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z8paisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8paisID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z9Paisnome", Z9Paisnome);
         GxWebStd.gx_hidden_field( context, "Z16PaisCidadeLastid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16PaisCidadeLastid), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O16PaisCidadeLastid", StringUtil.LTrim( StringUtil.NToC( (decimal)(O16PaisCidadeLastid), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7paisID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAISID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7paisID), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV12Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("pais.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7paisID,6,0))}, new string[] {"Gx_mode","paisID"})  ;
      }

      public override string GetPgmname( )
      {
         return "pais" ;
      }

      public override string GetPgmdesc( )
      {
         return "pais" ;
      }

      protected void InitializeNonKey033( )
      {
         A9Paisnome = "";
         AssignAttri("", false, "A9Paisnome", A9Paisnome);
         A16PaisCidadeLastid = 0;
         AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         O16PaisCidadeLastid = A16PaisCidadeLastid;
         AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
         Z9Paisnome = "";
         Z16PaisCidadeLastid = 0;
      }

      protected void InitAll033( )
      {
         A8paisID = 0;
         n8paisID = false;
         AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey035( )
      {
         A14paisCidadeNome = "";
         Z14paisCidadeNome = "";
      }

      protected void InitAll035( )
      {
         A13paisCidadeID = 0;
         n13paisCidadeID = false;
         InitializeNonKey035( ) ;
      }

      protected void StandaloneModalInsert035( )
      {
         A16PaisCidadeLastid = i16PaisCidadeLastid;
         AssignAttri("", false, "A16PaisCidadeLastid", StringUtil.LTrimStr( (decimal)(A16PaisCidadeLastid), 6, 0));
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202171522281833", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("pais.js", "?202171522281833", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties5( )
      {
         edtpaisCidadeID_Enabled = defedtpaisCidadeID_Enabled;
         AssignProp("", false, edtpaisCidadeID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeID_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtpaisID_Internalname = "PAISID";
         edtPaisnome_Internalname = "PAISNOME";
         edtPaisCidadeLastid_Internalname = "PAISCIDADELASTID";
         lblTitlecidade_Internalname = "TITLECIDADE";
         edtpaisCidadeID_Internalname = "PAISCIDADEID";
         edtpaisCidadeNome_Internalname = "PAISCIDADENOME";
         divCidadetable_Internalname = "CIDADETABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridpais_cidade_Internalname = "GRIDPAIS_CIDADE";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "pais";
         edtpaisCidadeNome_Jsonclick = "";
         edtpaisCidadeID_Jsonclick = "";
         subGridpais_cidade_Class = "Grid";
         subGridpais_cidade_Backcolorstyle = 0;
         subGridpais_cidade_Allowcollapsing = 0;
         subGridpais_cidade_Allowselection = 0;
         edtpaisCidadeNome_Enabled = 1;
         edtpaisCidadeID_Enabled = 1;
         subGridpais_cidade_Header = "";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPaisCidadeLastid_Jsonclick = "";
         edtPaisCidadeLastid_Enabled = 0;
         edtPaisnome_Jsonclick = "";
         edtPaisnome_Enabled = 1;
         edtpaisID_Jsonclick = "";
         edtpaisID_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridpais_cidade_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_535( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal035( ) ;
            standaloneModal035( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow035( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_535( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpais_cidadeContainer)) ;
         /* End function gxnrGridpais_cidade_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7paisID',fld:'vPAISID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7paisID',fld:'vPAISID',pic:'ZZZZZ9',hsh:true},{av:'A8paisID',fld:'PAISID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12032',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
         setEventMetadata("VALID_PAISCIDADELASTID","{handler:'Valid_Paiscidadelastid',iparms:[]");
         setEventMetadata("VALID_PAISCIDADELASTID",",oparms:[]}");
         setEventMetadata("VALID_PAISCIDADEID","{handler:'Valid_Paiscidadeid',iparms:[]");
         setEventMetadata("VALID_PAISCIDADEID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Paiscidadenome',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(3);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z9Paisnome = "";
         Z14paisCidadeNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A9Paisnome = "";
         lblTitlecidade_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridpais_cidadeContainer = new GXWebGrid( context);
         Gridpais_cidadeColumn = new GXWebColumn();
         A14paisCidadeNome = "";
         sMode5 = "";
         sStyleString = "";
         AV12Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00036_A8paisID = new int[1] ;
         T00036_n8paisID = new bool[] {false} ;
         T00036_A9Paisnome = new string[] {""} ;
         T00036_A16PaisCidadeLastid = new int[1] ;
         T00037_A8paisID = new int[1] ;
         T00037_n8paisID = new bool[] {false} ;
         T00035_A8paisID = new int[1] ;
         T00035_n8paisID = new bool[] {false} ;
         T00035_A9Paisnome = new string[] {""} ;
         T00035_A16PaisCidadeLastid = new int[1] ;
         T00038_A8paisID = new int[1] ;
         T00038_n8paisID = new bool[] {false} ;
         T00039_A8paisID = new int[1] ;
         T00039_n8paisID = new bool[] {false} ;
         T00034_A8paisID = new int[1] ;
         T00034_n8paisID = new bool[] {false} ;
         T00034_A9Paisnome = new string[] {""} ;
         T00034_A16PaisCidadeLastid = new int[1] ;
         T000310_A8paisID = new int[1] ;
         T000310_n8paisID = new bool[] {false} ;
         T000313_A7atracaoID = new int[1] ;
         T000315_A8paisID = new int[1] ;
         T000315_n8paisID = new bool[] {false} ;
         T000316_A8paisID = new int[1] ;
         T000316_n8paisID = new bool[] {false} ;
         T000316_A13paisCidadeID = new int[1] ;
         T000316_n13paisCidadeID = new bool[] {false} ;
         T000316_A14paisCidadeNome = new string[] {""} ;
         T000317_A8paisID = new int[1] ;
         T000317_n8paisID = new bool[] {false} ;
         T000317_A13paisCidadeID = new int[1] ;
         T000317_n13paisCidadeID = new bool[] {false} ;
         T00033_A8paisID = new int[1] ;
         T00033_n8paisID = new bool[] {false} ;
         T00033_A13paisCidadeID = new int[1] ;
         T00033_n13paisCidadeID = new bool[] {false} ;
         T00033_A14paisCidadeNome = new string[] {""} ;
         T00032_A8paisID = new int[1] ;
         T00032_n8paisID = new bool[] {false} ;
         T00032_A13paisCidadeID = new int[1] ;
         T00032_n13paisCidadeID = new bool[] {false} ;
         T00032_A14paisCidadeNome = new string[] {""} ;
         T000321_A17AeroportoId = new int[1] ;
         T000322_A7atracaoID = new int[1] ;
         T000323_A8paisID = new int[1] ;
         T000323_n8paisID = new bool[] {false} ;
         T000323_A13paisCidadeID = new int[1] ;
         T000323_n13paisCidadeID = new bool[] {false} ;
         Gridpais_cidadeRow = new GXWebRow();
         subGridpais_cidade_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pais__default(),
            new Object[][] {
                new Object[] {
               T00032_A8paisID, T00032_A13paisCidadeID, T00032_A14paisCidadeNome
               }
               , new Object[] {
               T00033_A8paisID, T00033_A13paisCidadeID, T00033_A14paisCidadeNome
               }
               , new Object[] {
               T00034_A8paisID, T00034_A9Paisnome, T00034_A16PaisCidadeLastid
               }
               , new Object[] {
               T00035_A8paisID, T00035_A9Paisnome, T00035_A16PaisCidadeLastid
               }
               , new Object[] {
               T00036_A8paisID, T00036_A9Paisnome, T00036_A16PaisCidadeLastid
               }
               , new Object[] {
               T00037_A8paisID
               }
               , new Object[] {
               T00038_A8paisID
               }
               , new Object[] {
               T00039_A8paisID
               }
               , new Object[] {
               T000310_A8paisID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000313_A7atracaoID
               }
               , new Object[] {
               }
               , new Object[] {
               T000315_A8paisID
               }
               , new Object[] {
               T000316_A8paisID, T000316_A13paisCidadeID, T000316_A14paisCidadeNome
               }
               , new Object[] {
               T000317_A8paisID, T000317_A13paisCidadeID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000321_A17AeroportoId
               }
               , new Object[] {
               T000322_A7atracaoID
               }
               , new Object[] {
               T000323_A8paisID, T000323_A13paisCidadeID
               }
            }
         );
         AV12Pgmname = "pais";
      }

      private short nRcdDeleted_5 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short GxWebError ;
      private short Gx_BScreen ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridpais_cidade_Backcolorstyle ;
      private short subGridpais_cidade_Allowselection ;
      private short subGridpais_cidade_Allowhovering ;
      private short subGridpais_cidade_Allowcollapsing ;
      private short subGridpais_cidade_Collapsed ;
      private short nBlankRcdCount5 ;
      private short RcdFound5 ;
      private short nBlankRcdUsr5 ;
      private short RcdFound3 ;
      private short GX_JID ;
      private short nIsDirty_3 ;
      private short nIsDirty_5 ;
      private short subGridpais_cidade_Backstyle ;
      private short gxajaxcallmode ;
      private int wcpOAV7paisID ;
      private int Z8paisID ;
      private int Z16PaisCidadeLastid ;
      private int O16PaisCidadeLastid ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int Z13paisCidadeID ;
      private int A16PaisCidadeLastid ;
      private int AV7paisID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A8paisID ;
      private int edtpaisID_Enabled ;
      private int edtPaisnome_Enabled ;
      private int edtPaisCidadeLastid_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int A13paisCidadeID ;
      private int edtpaisCidadeID_Enabled ;
      private int edtpaisCidadeNome_Enabled ;
      private int subGridpais_cidade_Selectedindex ;
      private int subGridpais_cidade_Selectioncolor ;
      private int subGridpais_cidade_Hoveringcolor ;
      private int B16PaisCidadeLastid ;
      private int fRowAdded ;
      private int s16PaisCidadeLastid ;
      private int subGridpais_cidade_Backcolor ;
      private int subGridpais_cidade_Allbackcolor ;
      private int defedtpaisCidadeID_Enabled ;
      private int i16PaisCidadeLastid ;
      private int idxLst ;
      private long GRIDPAIS_CIDADE_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_53_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPaisnome_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtpaisID_Internalname ;
      private string edtpaisID_Jsonclick ;
      private string edtPaisnome_Jsonclick ;
      private string edtPaisCidadeLastid_Internalname ;
      private string edtPaisCidadeLastid_Jsonclick ;
      private string divCidadetable_Internalname ;
      private string lblTitlecidade_Internalname ;
      private string lblTitlecidade_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridpais_cidade_Header ;
      private string sMode5 ;
      private string edtpaisCidadeID_Internalname ;
      private string edtpaisCidadeNome_Internalname ;
      private string sStyleString ;
      private string AV12Pgmname ;
      private string hsh ;
      private string sMode3 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridpais_cidade_Class ;
      private string subGridpais_cidade_Linesclass ;
      private string ROClassString ;
      private string edtpaisCidadeID_Jsonclick ;
      private string edtpaisCidadeNome_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridpais_cidade_Internalname ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private bool n8paisID ;
      private bool returnInSub ;
      private bool n13paisCidadeID ;
      private string Z9Paisnome ;
      private string Z14paisCidadeNome ;
      private string A9Paisnome ;
      private string A14paisCidadeNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridpais_cidadeContainer ;
      private GXWebRow Gridpais_cidadeRow ;
      private GXWebColumn Gridpais_cidadeColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00036_A8paisID ;
      private bool[] T00036_n8paisID ;
      private string[] T00036_A9Paisnome ;
      private int[] T00036_A16PaisCidadeLastid ;
      private int[] T00037_A8paisID ;
      private bool[] T00037_n8paisID ;
      private int[] T00035_A8paisID ;
      private bool[] T00035_n8paisID ;
      private string[] T00035_A9Paisnome ;
      private int[] T00035_A16PaisCidadeLastid ;
      private int[] T00038_A8paisID ;
      private bool[] T00038_n8paisID ;
      private int[] T00039_A8paisID ;
      private bool[] T00039_n8paisID ;
      private int[] T00034_A8paisID ;
      private bool[] T00034_n8paisID ;
      private string[] T00034_A9Paisnome ;
      private int[] T00034_A16PaisCidadeLastid ;
      private int[] T000310_A8paisID ;
      private bool[] T000310_n8paisID ;
      private int[] T000313_A7atracaoID ;
      private int[] T000315_A8paisID ;
      private bool[] T000315_n8paisID ;
      private int[] T000316_A8paisID ;
      private bool[] T000316_n8paisID ;
      private int[] T000316_A13paisCidadeID ;
      private bool[] T000316_n13paisCidadeID ;
      private string[] T000316_A14paisCidadeNome ;
      private int[] T000317_A8paisID ;
      private bool[] T000317_n8paisID ;
      private int[] T000317_A13paisCidadeID ;
      private bool[] T000317_n13paisCidadeID ;
      private int[] T00033_A8paisID ;
      private bool[] T00033_n8paisID ;
      private int[] T00033_A13paisCidadeID ;
      private bool[] T00033_n13paisCidadeID ;
      private string[] T00033_A14paisCidadeNome ;
      private int[] T00032_A8paisID ;
      private bool[] T00032_n8paisID ;
      private int[] T00032_A13paisCidadeID ;
      private bool[] T00032_n13paisCidadeID ;
      private string[] T00032_A14paisCidadeNome ;
      private int[] T000321_A17AeroportoId ;
      private int[] T000322_A7atracaoID ;
      private int[] T000323_A8paisID ;
      private bool[] T000323_n8paisID ;
      private int[] T000323_A13paisCidadeID ;
      private bool[] T000323_n13paisCidadeID ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
   }

   public class pais__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@Paisnome",GXType.NVarChar,40,0) ,
          new ParDef("@PaisCidadeLastid",GXType.Int32,6,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@Paisnome",GXType.NVarChar,40,0) ,
          new ParDef("@PaisCidadeLastid",GXType.Int32,6,0) ,
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          new ParDef("@PaisCidadeLastid",GXType.Int32,6,0) ,
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000317;
          prmT000317 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000318;
          prmT000318 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeNome",GXType.NVarChar,40,0)
          };
          Object[] prmT000319;
          prmT000319 = new Object[] {
          new ParDef("@paisCidadeNome",GXType.NVarChar,40,0) ,
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000320;
          prmT000320 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000321;
          prmT000321 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000322;
          prmT000322 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000323;
          prmT000323 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [paisID], [paisCidadeID], [paisCidadeNome] FROM [paisCidade] WITH (UPDLOCK) WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [paisID], [paisCidadeID], [paisCidadeNome] FROM [paisCidade] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [paisID], [Paisnome], [PaisCidadeLastid] FROM [pais] WITH (UPDLOCK) WHERE [paisID] = @paisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT [paisID], [Paisnome], [PaisCidadeLastid] FROM [pais] WHERE [paisID] = @paisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT TM1.[paisID], TM1.[Paisnome], TM1.[PaisCidadeLastid] FROM [pais] TM1 WHERE TM1.[paisID] = @paisID ORDER BY TM1.[paisID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00037", "SELECT [paisID] FROM [pais] WHERE [paisID] = @paisID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT TOP 1 [paisID] FROM [pais] WHERE ( [paisID] > @paisID) ORDER BY [paisID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00039", "SELECT TOP 1 [paisID] FROM [pais] WHERE ( [paisID] < @paisID) ORDER BY [paisID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000310", "INSERT INTO [pais]([Paisnome], [PaisCidadeLastid]) VALUES(@Paisnome, @PaisCidadeLastid); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000310)
             ,new CursorDef("T000311", "UPDATE [pais] SET [Paisnome]=@Paisnome, [PaisCidadeLastid]=@PaisCidadeLastid  WHERE [paisID] = @paisID", GxErrorMask.GX_NOMASK,prmT000311)
             ,new CursorDef("T000312", "DELETE FROM [pais]  WHERE [paisID] = @paisID", GxErrorMask.GX_NOMASK,prmT000312)
             ,new CursorDef("T000313", "SELECT TOP 1 [atracaoID] FROM [atracao] WHERE [paisID] = @paisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000314", "UPDATE [pais] SET [PaisCidadeLastid]=@PaisCidadeLastid  WHERE [paisID] = @paisID", GxErrorMask.GX_NOMASK,prmT000314)
             ,new CursorDef("T000315", "SELECT [paisID] FROM [pais] ORDER BY [paisID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000316", "SELECT [paisID], [paisCidadeID], [paisCidadeNome] FROM [paisCidade] WHERE [paisID] = @paisID and [paisCidadeID] = @paisCidadeID ORDER BY [paisID], [paisCidadeID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000317", "SELECT [paisID], [paisCidadeID] FROM [paisCidade] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000318", "INSERT INTO [paisCidade]([paisID], [paisCidadeID], [paisCidadeNome]) VALUES(@paisID, @paisCidadeID, @paisCidadeNome)", GxErrorMask.GX_NOMASK,prmT000318)
             ,new CursorDef("T000319", "UPDATE [paisCidade] SET [paisCidadeNome]=@paisCidadeNome  WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID", GxErrorMask.GX_NOMASK,prmT000319)
             ,new CursorDef("T000320", "DELETE FROM [paisCidade]  WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID", GxErrorMask.GX_NOMASK,prmT000320)
             ,new CursorDef("T000321", "SELECT TOP 1 [AeroportoId] FROM [aeroporto] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000321,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000322", "SELECT TOP 1 [atracaoID] FROM [atracao] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000322,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000323", "SELECT [paisID], [paisCidadeID] FROM [paisCidade] WHERE [paisID] = @paisID ORDER BY [paisID], [paisCidadeID] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000323,11, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
