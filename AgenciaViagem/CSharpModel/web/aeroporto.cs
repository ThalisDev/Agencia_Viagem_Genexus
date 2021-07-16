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
   public class aeroporto : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A8paisID = (int)(NumberUtil.Val( GetPar( "paisID"), "."));
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A8paisID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A8paisID = (int)(NumberUtil.Val( GetPar( "paisID"), "."));
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            A13paisCidadeID = (int)(NumberUtil.Val( GetPar( "paisCidadeID"), "."));
            AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A8paisID, A13paisCidadeID) ;
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
               AV7AeroportoId = (int)(NumberUtil.Val( GetPar( "AeroportoId"), "."));
               AssignAttri("", false, "AV7AeroportoId", StringUtil.LTrimStr( (decimal)(AV7AeroportoId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vAEROPORTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AeroportoId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "aeroporto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAeroportoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aeroporto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aeroporto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_AeroportoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AeroportoId = aP1_AeroportoId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "aeroporto", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_aeroporto.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_aeroporto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAeroportoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAeroportoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAeroportoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17AeroportoId), 6, 0, ",", "")), ((edtAeroportoId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A17AeroportoId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A17AeroportoId), "ZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAeroportoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAeroportoId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAeroportoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAeroportoNome_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAeroportoNome_Internalname, A18AeroportoNome, StringUtil.RTrim( context.localUtil.Format( A18AeroportoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAeroportoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAeroportoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtpaisID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtpaisID_Internalname, "pais ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtpaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8paisID), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A8paisID), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtpaisID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtpaisID_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_aeroporto.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_8_Internalname, sImgUrl, imgprompt_8_Link, "", "", context.GetTheme( ), imgprompt_8_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_aeroporto.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisnome_Internalname, A9Paisnome, StringUtil.RTrim( context.localUtil.Format( A9Paisnome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisnome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisnome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtpaisCidadeID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtpaisCidadeID_Internalname, "pais Cidade ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtpaisCidadeID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13paisCidadeID), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A13paisCidadeID), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtpaisCidadeID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtpaisCidadeID_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_aeroporto.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_13_Internalname, sImgUrl, imgprompt_13_Link, "", "", context.GetTheme( ), imgprompt_13_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtpaisCidadeNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtpaisCidadeNome_Internalname, "pais Cidade Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtpaisCidadeNome_Internalname, A14paisCidadeNome, StringUtil.RTrim( context.localUtil.Format( A14paisCidadeNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtpaisCidadeNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtpaisCidadeNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_aeroporto.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_aeroporto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z17AeroportoId = (int)(context.localUtil.CToN( cgiGet( "Z17AeroportoId"), ",", "."));
               Z18AeroportoNome = cgiGet( "Z18AeroportoNome");
               Z8paisID = (int)(context.localUtil.CToN( cgiGet( "Z8paisID"), ",", "."));
               Z13paisCidadeID = (int)(context.localUtil.CToN( cgiGet( "Z13paisCidadeID"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N8paisID = (int)(context.localUtil.CToN( cgiGet( "N8paisID"), ",", "."));
               N13paisCidadeID = (int)(context.localUtil.CToN( cgiGet( "N13paisCidadeID"), ",", "."));
               AV7AeroportoId = (int)(context.localUtil.CToN( cgiGet( "vAEROPORTOID"), ",", "."));
               AV11Insert_paisID = (int)(context.localUtil.CToN( cgiGet( "vINSERT_PAISID"), ",", "."));
               AV12Insert_paisCidadeID = (int)(context.localUtil.CToN( cgiGet( "vINSERT_PAISCIDADEID"), ",", "."));
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A17AeroportoId = (int)(context.localUtil.CToN( cgiGet( edtAeroportoId_Internalname), ",", "."));
               AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
               A18AeroportoNome = cgiGet( edtAeroportoNome_Internalname);
               AssignAttri("", false, "A18AeroportoNome", A18AeroportoNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtpaisID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtpaisID_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtpaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8paisID = 0;
                  AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
               }
               else
               {
                  A8paisID = (int)(context.localUtil.CToN( cgiGet( edtpaisID_Internalname), ",", "."));
                  AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
               }
               A9Paisnome = cgiGet( edtPaisnome_Internalname);
               AssignAttri("", false, "A9Paisnome", A9Paisnome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtpaisCidadeID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtpaisCidadeID_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISCIDADEID");
                  AnyError = 1;
                  GX_FocusControl = edtpaisCidadeID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A13paisCidadeID = 0;
                  AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
               }
               else
               {
                  A13paisCidadeID = (int)(context.localUtil.CToN( cgiGet( edtpaisCidadeID_Internalname), ",", "."));
                  AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
               }
               A14paisCidadeNome = cgiGet( edtpaisCidadeNome_Internalname);
               AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"aeroporto");
               A17AeroportoId = (int)(context.localUtil.CToN( cgiGet( edtAeroportoId_Internalname), ",", "."));
               AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
               forbiddenHiddens.Add("AeroportoId", context.localUtil.Format( (decimal)(A17AeroportoId), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A17AeroportoId != Z17AeroportoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("aeroporto:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A17AeroportoId = (int)(NumberUtil.Val( GetPar( "AeroportoId"), "."));
                  AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
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
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode6;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "AEROPORTOID");
                        AnyError = 1;
                        GX_FocusControl = edtAeroportoId_Internalname;
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
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll056( ) ;
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
            DisableAttributes056( ) ;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls056( ) ;
            }
            else
            {
               CheckExtendedTable056( ) ;
               CloseExtendedTableCursors056( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "AgenciaViagem");
         AV11Insert_paisID = 0;
         AssignAttri("", false, "AV11Insert_paisID", StringUtil.LTrimStr( (decimal)(AV11Insert_paisID), 6, 0));
         AV12Insert_paisCidadeID = 0;
         AssignAttri("", false, "AV12Insert_paisCidadeID", StringUtil.LTrimStr( (decimal)(AV12Insert_paisCidadeID), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "paisID") == 0 )
               {
                  AV11Insert_paisID = (int)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_paisID", StringUtil.LTrimStr( (decimal)(AV11Insert_paisID), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "paisCidadeID") == 0 )
               {
                  AV12Insert_paisCidadeID = (int)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_paisCidadeID", StringUtil.LTrimStr( (decimal)(AV12Insert_paisCidadeID), 6, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
      }

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwaeroporto.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM056( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z18AeroportoNome = T00053_A18AeroportoNome[0];
               Z8paisID = T00053_A8paisID[0];
               Z13paisCidadeID = T00053_A13paisCidadeID[0];
            }
            else
            {
               Z18AeroportoNome = A18AeroportoNome;
               Z8paisID = A8paisID;
               Z13paisCidadeID = A13paisCidadeID;
            }
         }
         if ( GX_JID == -11 )
         {
            Z17AeroportoId = A17AeroportoId;
            Z18AeroportoNome = A18AeroportoNome;
            Z8paisID = A8paisID;
            Z13paisCidadeID = A13paisCidadeID;
            Z9Paisnome = A9Paisnome;
            Z14paisCidadeNome = A14paisCidadeNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAeroportoId_Enabled = 0;
         AssignProp("", false, edtAeroportoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAeroportoId_Enabled), 5, 0), true);
         imgprompt_8_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_13_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0051.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"PAISCIDADEID"+"'), id:'"+"PAISCIDADEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtAeroportoId_Enabled = 0;
         AssignProp("", false, edtAeroportoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAeroportoId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AeroportoId) )
         {
            A17AeroportoId = AV7AeroportoId;
            AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_paisID) )
         {
            edtpaisID_Enabled = 0;
            AssignProp("", false, edtpaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisID_Enabled), 5, 0), true);
         }
         else
         {
            edtpaisID_Enabled = 1;
            AssignProp("", false, edtpaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_paisCidadeID) )
         {
            edtpaisCidadeID_Enabled = 0;
            AssignProp("", false, edtpaisCidadeID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeID_Enabled), 5, 0), true);
         }
         else
         {
            edtpaisCidadeID_Enabled = 1;
            AssignProp("", false, edtpaisCidadeID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_paisCidadeID) )
         {
            A13paisCidadeID = AV12Insert_paisCidadeID;
            AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_paisID) )
         {
            A8paisID = AV11Insert_paisID;
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV14Pgmname = "aeroporto";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {A8paisID});
            A9Paisnome = T00054_A9Paisnome[0];
            AssignAttri("", false, "A9Paisnome", A9Paisnome);
            pr_default.close(2);
            /* Using cursor T00055 */
            pr_default.execute(3, new Object[] {A8paisID, A13paisCidadeID});
            A14paisCidadeNome = T00055_A14paisCidadeNome[0];
            AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
            pr_default.close(3);
         }
      }

      protected void Load056( )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A17AeroportoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound6 = 1;
            A18AeroportoNome = T00056_A18AeroportoNome[0];
            AssignAttri("", false, "A18AeroportoNome", A18AeroportoNome);
            A9Paisnome = T00056_A9Paisnome[0];
            AssignAttri("", false, "A9Paisnome", A9Paisnome);
            A14paisCidadeNome = T00056_A14paisCidadeNome[0];
            AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
            A8paisID = T00056_A8paisID[0];
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            A13paisCidadeID = T00056_A13paisCidadeID[0];
            AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
            ZM056( -11) ;
         }
         pr_default.close(4);
         OnLoadActions056( ) ;
      }

      protected void OnLoadActions056( )
      {
         AV14Pgmname = "aeroporto";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable056( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "aeroporto";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A8paisID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtpaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9Paisnome = T00054_A9Paisnome[0];
         AssignAttri("", false, "A9Paisnome", A9Paisnome);
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A8paisID, A13paisCidadeID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cidade'.", "ForeignKeyNotFound", 1, "PAISCIDADEID");
            AnyError = 1;
            GX_FocusControl = edtpaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A14paisCidadeNome = T00055_A14paisCidadeNome[0];
         AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors056( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A8paisID )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A8paisID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtpaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A9Paisnome = T00057_A9Paisnome[0];
         AssignAttri("", false, "A9Paisnome", A9Paisnome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A9Paisnome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_13( int A8paisID ,
                                int A13paisCidadeID )
      {
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A8paisID, A13paisCidadeID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cidade'.", "ForeignKeyNotFound", 1, "PAISCIDADEID");
            AnyError = 1;
            GX_FocusControl = edtpaisID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A14paisCidadeNome = T00058_A14paisCidadeNome[0];
         AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A14paisCidadeNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey056( )
      {
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A17AeroportoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A17AeroportoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM056( 11) ;
            RcdFound6 = 1;
            A17AeroportoId = T00053_A17AeroportoId[0];
            AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
            A18AeroportoNome = T00053_A18AeroportoNome[0];
            AssignAttri("", false, "A18AeroportoNome", A18AeroportoNome);
            A8paisID = T00053_A8paisID[0];
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            A13paisCidadeID = T00053_A13paisCidadeID[0];
            AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
            Z17AeroportoId = A17AeroportoId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load056( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey056( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey056( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey056( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {A17AeroportoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000510_A17AeroportoId[0] < A17AeroportoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000510_A17AeroportoId[0] > A17AeroportoId ) ) )
            {
               A17AeroportoId = T000510_A17AeroportoId[0];
               AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {A17AeroportoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000511_A17AeroportoId[0] > A17AeroportoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000511_A17AeroportoId[0] < A17AeroportoId ) ) )
            {
               A17AeroportoId = T000511_A17AeroportoId[0];
               AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey056( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAeroportoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert056( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A17AeroportoId != Z17AeroportoId )
               {
                  A17AeroportoId = Z17AeroportoId;
                  AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AEROPORTOID");
                  AnyError = 1;
                  GX_FocusControl = edtAeroportoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAeroportoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update056( ) ;
                  GX_FocusControl = edtAeroportoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A17AeroportoId != Z17AeroportoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAeroportoNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert056( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AEROPORTOID");
                     AnyError = 1;
                     GX_FocusControl = edtAeroportoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAeroportoNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert056( ) ;
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
         if ( A17AeroportoId != Z17AeroportoId )
         {
            A17AeroportoId = Z17AeroportoId;
            AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AEROPORTOID");
            AnyError = 1;
            GX_FocusControl = edtAeroportoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAeroportoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency056( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A17AeroportoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"aeroporto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z18AeroportoNome, T00052_A18AeroportoNome[0]) != 0 ) || ( Z8paisID != T00052_A8paisID[0] ) || ( Z13paisCidadeID != T00052_A13paisCidadeID[0] ) )
            {
               if ( StringUtil.StrCmp(Z18AeroportoNome, T00052_A18AeroportoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("aeroporto:[seudo value changed for attri]"+"AeroportoNome");
                  GXUtil.WriteLogRaw("Old: ",Z18AeroportoNome);
                  GXUtil.WriteLogRaw("Current: ",T00052_A18AeroportoNome[0]);
               }
               if ( Z8paisID != T00052_A8paisID[0] )
               {
                  GXUtil.WriteLog("aeroporto:[seudo value changed for attri]"+"paisID");
                  GXUtil.WriteLogRaw("Old: ",Z8paisID);
                  GXUtil.WriteLogRaw("Current: ",T00052_A8paisID[0]);
               }
               if ( Z13paisCidadeID != T00052_A13paisCidadeID[0] )
               {
                  GXUtil.WriteLog("aeroporto:[seudo value changed for attri]"+"paisCidadeID");
                  GXUtil.WriteLogRaw("Old: ",Z13paisCidadeID);
                  GXUtil.WriteLogRaw("Current: ",T00052_A13paisCidadeID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"aeroporto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM056( 0) ;
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000512 */
                     pr_default.execute(10, new Object[] {A18AeroportoNome, A8paisID, A13paisCidadeID});
                     A17AeroportoId = T000512_A17AeroportoId[0];
                     AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("aeroporto");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
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
               Load056( ) ;
            }
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void Update056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000513 */
                     pr_default.execute(11, new Object[] {A18AeroportoNome, A8paisID, A13paisCidadeID, A17AeroportoId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("aeroporto");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"aeroporto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate056( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void DeferredUpdate056( )
      {
      }

      protected void delete( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls056( ) ;
            AfterConfirm056( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete056( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000514 */
                  pr_default.execute(12, new Object[] {A17AeroportoId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("aeroporto");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel056( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls056( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "aeroporto";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000515 */
            pr_default.execute(13, new Object[] {A8paisID});
            A9Paisnome = T000515_A9Paisnome[0];
            AssignAttri("", false, "A9Paisnome", A9Paisnome);
            pr_default.close(13);
            /* Using cursor T000516 */
            pr_default.execute(14, new Object[] {A8paisID, A13paisCidadeID});
            A14paisCidadeNome = T000516_A14paisCidadeNome[0];
            AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000517 */
            pr_default.execute(15, new Object[] {A17AeroportoId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Voo"+" ("+"Voo Chegada"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000518 */
            pr_default.execute(16, new Object[] {A17AeroportoId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Voo"+" ("+"Voo Embarque"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel056( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete056( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("aeroporto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("aeroporto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart056( )
      {
         /* Scan By routine */
         /* Using cursor T000519 */
         pr_default.execute(17);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound6 = 1;
            A17AeroportoId = T000519_A17AeroportoId[0];
            AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext056( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound6 = 1;
            A17AeroportoId = T000519_A17AeroportoId[0];
            AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
         }
      }

      protected void ScanEnd056( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm056( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert056( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate056( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete056( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete056( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate056( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes056( )
      {
         edtAeroportoId_Enabled = 0;
         AssignProp("", false, edtAeroportoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAeroportoId_Enabled), 5, 0), true);
         edtAeroportoNome_Enabled = 0;
         AssignProp("", false, edtAeroportoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAeroportoNome_Enabled), 5, 0), true);
         edtpaisID_Enabled = 0;
         AssignProp("", false, edtpaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisID_Enabled), 5, 0), true);
         edtPaisnome_Enabled = 0;
         AssignProp("", false, edtPaisnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisnome_Enabled), 5, 0), true);
         edtpaisCidadeID_Enabled = 0;
         AssignProp("", false, edtpaisCidadeID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeID_Enabled), 5, 0), true);
         edtpaisCidadeNome_Enabled = 0;
         AssignProp("", false, edtpaisCidadeNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes056( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
      {
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
         context.AddJavascriptSource("gxcfg.js", "?20217152238297", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("aeroporto.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AeroportoId,6,0))}, new string[] {"Gx_mode","AeroportoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"aeroporto");
         forbiddenHiddens.Add("AeroportoId", context.localUtil.Format( (decimal)(A17AeroportoId), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("aeroporto:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z17AeroportoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17AeroportoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z18AeroportoNome", Z18AeroportoNome);
         GxWebStd.gx_hidden_field( context, "Z8paisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8paisID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z13paisCidadeID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13paisCidadeID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N8paisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8paisID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N13paisCidadeID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13paisCidadeID), 6, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vAEROPORTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AeroportoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAEROPORTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AeroportoId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_paisID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISCIDADEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_paisCidadeID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
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
         return formatLink("aeroporto.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AeroportoId,6,0))}, new string[] {"Gx_mode","AeroportoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "aeroporto" ;
      }

      public override string GetPgmdesc( )
      {
         return "aeroporto" ;
      }

      protected void InitializeNonKey056( )
      {
         A8paisID = 0;
         AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
         A13paisCidadeID = 0;
         AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
         A18AeroportoNome = "";
         AssignAttri("", false, "A18AeroportoNome", A18AeroportoNome);
         A9Paisnome = "";
         AssignAttri("", false, "A9Paisnome", A9Paisnome);
         A14paisCidadeNome = "";
         AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
         Z18AeroportoNome = "";
         Z8paisID = 0;
         Z13paisCidadeID = 0;
      }

      protected void InitAll056( )
      {
         A17AeroportoId = 0;
         AssignAttri("", false, "A17AeroportoId", StringUtil.LTrimStr( (decimal)(A17AeroportoId), 6, 0));
         InitializeNonKey056( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021715223831", true, true);
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
         context.AddJavascriptSource("aeroporto.js", "?2021715223831", false, true);
         /* End function include_jscripts */
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
         edtAeroportoId_Internalname = "AEROPORTOID";
         edtAeroportoNome_Internalname = "AEROPORTONOME";
         edtpaisID_Internalname = "PAISID";
         edtPaisnome_Internalname = "PAISNOME";
         edtpaisCidadeID_Internalname = "PAISCIDADEID";
         edtpaisCidadeNome_Internalname = "PAISCIDADENOME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_8_Internalname = "PROMPT_8";
         imgprompt_13_Internalname = "PROMPT_13";
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
         Form.Caption = "aeroporto";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtpaisCidadeNome_Jsonclick = "";
         edtpaisCidadeNome_Enabled = 0;
         imgprompt_13_Visible = 1;
         imgprompt_13_Link = "";
         edtpaisCidadeID_Jsonclick = "";
         edtpaisCidadeID_Enabled = 1;
         edtPaisnome_Jsonclick = "";
         edtPaisnome_Enabled = 0;
         imgprompt_8_Visible = 1;
         imgprompt_8_Link = "";
         edtpaisID_Jsonclick = "";
         edtpaisID_Enabled = 1;
         edtAeroportoNome_Jsonclick = "";
         edtAeroportoNome_Enabled = 1;
         edtAeroportoId_Jsonclick = "";
         edtAeroportoId_Enabled = 0;
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

      public void Valid_Paisid( )
      {
         /* Using cursor T000515 */
         pr_default.execute(13, new Object[] {A8paisID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtpaisID_Internalname;
         }
         A9Paisnome = T000515_A9Paisnome[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A9Paisnome", A9Paisnome);
      }

      public void Valid_Paiscidadeid( )
      {
         /* Using cursor T000516 */
         pr_default.execute(14, new Object[] {A8paisID, A13paisCidadeID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Cidade'.", "ForeignKeyNotFound", 1, "PAISCIDADEID");
            AnyError = 1;
            GX_FocusControl = edtpaisID_Internalname;
         }
         A14paisCidadeNome = T000516_A14paisCidadeNome[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7AeroportoId',fld:'vAEROPORTOID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7AeroportoId',fld:'vAEROPORTOID',pic:'ZZZZZ9',hsh:true},{av:'A17AeroportoId',fld:'AEROPORTOID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12052',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_AEROPORTOID","{handler:'Valid_Aeroportoid',iparms:[]");
         setEventMetadata("VALID_AEROPORTOID",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[{av:'A8paisID',fld:'PAISID',pic:'ZZZZZ9'},{av:'A9Paisnome',fld:'PAISNOME',pic:''}]");
         setEventMetadata("VALID_PAISID",",oparms:[{av:'A9Paisnome',fld:'PAISNOME',pic:''}]}");
         setEventMetadata("VALID_PAISCIDADEID","{handler:'Valid_Paiscidadeid',iparms:[{av:'A8paisID',fld:'PAISID',pic:'ZZZZZ9'},{av:'A13paisCidadeID',fld:'PAISCIDADEID',pic:'ZZZZZ9'},{av:'A14paisCidadeNome',fld:'PAISCIDADENOME',pic:''}]");
         setEventMetadata("VALID_PAISCIDADEID",",oparms:[{av:'A14paisCidadeNome',fld:'PAISCIDADENOME',pic:''}]}");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z18AeroportoNome = "";
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
         A18AeroportoNome = "";
         sImgUrl = "";
         A9Paisnome = "";
         A14paisCidadeNome = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z9Paisnome = "";
         Z14paisCidadeNome = "";
         T00054_A9Paisnome = new string[] {""} ;
         T00055_A14paisCidadeNome = new string[] {""} ;
         T00056_A17AeroportoId = new int[1] ;
         T00056_A18AeroportoNome = new string[] {""} ;
         T00056_A9Paisnome = new string[] {""} ;
         T00056_A14paisCidadeNome = new string[] {""} ;
         T00056_A8paisID = new int[1] ;
         T00056_A13paisCidadeID = new int[1] ;
         T00057_A9Paisnome = new string[] {""} ;
         T00058_A14paisCidadeNome = new string[] {""} ;
         T00059_A17AeroportoId = new int[1] ;
         T00053_A17AeroportoId = new int[1] ;
         T00053_A18AeroportoNome = new string[] {""} ;
         T00053_A8paisID = new int[1] ;
         T00053_A13paisCidadeID = new int[1] ;
         T000510_A17AeroportoId = new int[1] ;
         T000511_A17AeroportoId = new int[1] ;
         T00052_A17AeroportoId = new int[1] ;
         T00052_A18AeroportoNome = new string[] {""} ;
         T00052_A8paisID = new int[1] ;
         T00052_A13paisCidadeID = new int[1] ;
         T000512_A17AeroportoId = new int[1] ;
         T000515_A9Paisnome = new string[] {""} ;
         T000516_A14paisCidadeNome = new string[] {""} ;
         T000517_A19VooId = new int[1] ;
         T000518_A19VooId = new int[1] ;
         T000519_A17AeroportoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aeroporto__default(),
            new Object[][] {
                new Object[] {
               T00052_A17AeroportoId, T00052_A18AeroportoNome, T00052_A8paisID, T00052_A13paisCidadeID
               }
               , new Object[] {
               T00053_A17AeroportoId, T00053_A18AeroportoNome, T00053_A8paisID, T00053_A13paisCidadeID
               }
               , new Object[] {
               T00054_A9Paisnome
               }
               , new Object[] {
               T00055_A14paisCidadeNome
               }
               , new Object[] {
               T00056_A17AeroportoId, T00056_A18AeroportoNome, T00056_A9Paisnome, T00056_A14paisCidadeNome, T00056_A8paisID, T00056_A13paisCidadeID
               }
               , new Object[] {
               T00057_A9Paisnome
               }
               , new Object[] {
               T00058_A14paisCidadeNome
               }
               , new Object[] {
               T00059_A17AeroportoId
               }
               , new Object[] {
               T000510_A17AeroportoId
               }
               , new Object[] {
               T000511_A17AeroportoId
               }
               , new Object[] {
               T000512_A17AeroportoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000515_A9Paisnome
               }
               , new Object[] {
               T000516_A14paisCidadeNome
               }
               , new Object[] {
               T000517_A19VooId
               }
               , new Object[] {
               T000518_A19VooId
               }
               , new Object[] {
               T000519_A17AeroportoId
               }
            }
         );
         AV14Pgmname = "aeroporto";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound6 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_6 ;
      private short gxajaxcallmode ;
      private int wcpOAV7AeroportoId ;
      private int Z17AeroportoId ;
      private int Z8paisID ;
      private int Z13paisCidadeID ;
      private int N8paisID ;
      private int N13paisCidadeID ;
      private int A8paisID ;
      private int A13paisCidadeID ;
      private int AV7AeroportoId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A17AeroportoId ;
      private int edtAeroportoId_Enabled ;
      private int edtAeroportoNome_Enabled ;
      private int edtpaisID_Enabled ;
      private int imgprompt_8_Visible ;
      private int edtPaisnome_Enabled ;
      private int edtpaisCidadeID_Enabled ;
      private int imgprompt_13_Visible ;
      private int edtpaisCidadeNome_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_paisID ;
      private int AV12Insert_paisCidadeID ;
      private int AV15GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAeroportoNome_Internalname ;
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
      private string edtAeroportoId_Internalname ;
      private string edtAeroportoId_Jsonclick ;
      private string edtAeroportoNome_Jsonclick ;
      private string edtpaisID_Internalname ;
      private string edtpaisID_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_8_Internalname ;
      private string imgprompt_8_Link ;
      private string edtPaisnome_Internalname ;
      private string edtPaisnome_Jsonclick ;
      private string edtpaisCidadeID_Internalname ;
      private string edtpaisCidadeID_Jsonclick ;
      private string imgprompt_13_Internalname ;
      private string imgprompt_13_Link ;
      private string edtpaisCidadeNome_Internalname ;
      private string edtpaisCidadeNome_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode6 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string Z18AeroportoNome ;
      private string A18AeroportoNome ;
      private string A9Paisnome ;
      private string A14paisCidadeNome ;
      private string Z9Paisnome ;
      private string Z14paisCidadeNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00054_A9Paisnome ;
      private string[] T00055_A14paisCidadeNome ;
      private int[] T00056_A17AeroportoId ;
      private string[] T00056_A18AeroportoNome ;
      private string[] T00056_A9Paisnome ;
      private string[] T00056_A14paisCidadeNome ;
      private int[] T00056_A8paisID ;
      private int[] T00056_A13paisCidadeID ;
      private string[] T00057_A9Paisnome ;
      private string[] T00058_A14paisCidadeNome ;
      private int[] T00059_A17AeroportoId ;
      private int[] T00053_A17AeroportoId ;
      private string[] T00053_A18AeroportoNome ;
      private int[] T00053_A8paisID ;
      private int[] T00053_A13paisCidadeID ;
      private int[] T000510_A17AeroportoId ;
      private int[] T000511_A17AeroportoId ;
      private int[] T00052_A17AeroportoId ;
      private string[] T00052_A18AeroportoNome ;
      private int[] T00052_A8paisID ;
      private int[] T00052_A13paisCidadeID ;
      private int[] T000512_A17AeroportoId ;
      private string[] T000515_A9Paisnome ;
      private string[] T000516_A14paisCidadeNome ;
      private int[] T000517_A19VooId ;
      private int[] T000518_A19VooId ;
      private int[] T000519_A17AeroportoId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class aeroporto__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0) ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0)
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0) ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@AeroportoNome",GXType.NVarChar,40,0) ,
          new ParDef("@paisID",GXType.Int32,6,0) ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0)
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@AeroportoNome",GXType.NVarChar,40,0) ,
          new ParDef("@paisID",GXType.Int32,6,0) ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0) ,
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT000517;
          prmT000517 = new Object[] {
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT000518;
          prmT000518 = new Object[] {
          new ParDef("@AeroportoId",GXType.Int32,6,0)
          };
          Object[] prmT000519;
          prmT000519 = new Object[] {
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0)
          };
          Object[] prmT000516;
          prmT000516 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0) ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [AeroportoId], [AeroportoNome], [paisID], [paisCidadeID] FROM [aeroporto] WITH (UPDLOCK) WHERE [AeroportoId] = @AeroportoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [AeroportoId], [AeroportoNome], [paisID], [paisCidadeID] FROM [aeroporto] WHERE [AeroportoId] = @AeroportoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [Paisnome] FROM [pais] WHERE [paisID] = @paisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [paisCidadeNome] FROM [paisCidade] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT TM1.[AeroportoId], TM1.[AeroportoNome], T2.[Paisnome], T3.[paisCidadeNome], TM1.[paisID], TM1.[paisCidadeID] FROM (([aeroporto] TM1 INNER JOIN [pais] T2 ON T2.[paisID] = TM1.[paisID]) INNER JOIN [paisCidade] T3 ON T3.[paisID] = TM1.[paisID] AND T3.[paisCidadeID] = TM1.[paisCidadeID]) WHERE TM1.[AeroportoId] = @AeroportoId ORDER BY TM1.[AeroportoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [Paisnome] FROM [pais] WHERE [paisID] = @paisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT [paisCidadeNome] FROM [paisCidade] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00059", "SELECT [AeroportoId] FROM [aeroporto] WHERE [AeroportoId] = @AeroportoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000510", "SELECT TOP 1 [AeroportoId] FROM [aeroporto] WHERE ( [AeroportoId] > @AeroportoId) ORDER BY [AeroportoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000511", "SELECT TOP 1 [AeroportoId] FROM [aeroporto] WHERE ( [AeroportoId] < @AeroportoId) ORDER BY [AeroportoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000512", "INSERT INTO [aeroporto]([AeroportoNome], [paisID], [paisCidadeID]) VALUES(@AeroportoNome, @paisID, @paisCidadeID); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000512)
             ,new CursorDef("T000513", "UPDATE [aeroporto] SET [AeroportoNome]=@AeroportoNome, [paisID]=@paisID, [paisCidadeID]=@paisCidadeID  WHERE [AeroportoId] = @AeroportoId", GxErrorMask.GX_NOMASK,prmT000513)
             ,new CursorDef("T000514", "DELETE FROM [aeroporto]  WHERE [AeroportoId] = @AeroportoId", GxErrorMask.GX_NOMASK,prmT000514)
             ,new CursorDef("T000515", "SELECT [Paisnome] FROM [pais] WHERE [paisID] = @paisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000516", "SELECT [paisCidadeNome] FROM [paisCidade] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000517", "SELECT TOP 1 [VooId] FROM [Voo] WHERE [VooChegadaAeroportoID] = @AeroportoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000518", "SELECT TOP 1 [VooId] FROM [Voo] WHERE [VooEmbarqueAeroportoID] = @AeroportoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000518,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000519", "SELECT [AeroportoId] FROM [aeroporto] ORDER BY [AeroportoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
