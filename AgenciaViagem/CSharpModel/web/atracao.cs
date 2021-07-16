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
   public class atracao : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A8paisID = (int)(NumberUtil.Val( GetPar( "paisID"), "."));
            n8paisID = false;
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A8paisID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A8paisID = (int)(NumberUtil.Val( GetPar( "paisID"), "."));
            n8paisID = false;
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            A13paisCidadeID = (int)(NumberUtil.Val( GetPar( "paisCidadeID"), "."));
            n13paisCidadeID = false;
            AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A8paisID, A13paisCidadeID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A10CategoriaID = (int)(NumberUtil.Val( GetPar( "CategoriaID"), "."));
            AssignAttri("", false, "A10CategoriaID", StringUtil.LTrimStr( (decimal)(A10CategoriaID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A10CategoriaID) ;
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
               AV7atracaoID = (int)(NumberUtil.Val( GetPar( "atracaoID"), "."));
               AssignAttri("", false, "AV7atracaoID", StringUtil.LTrimStr( (decimal)(AV7atracaoID), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vATRACAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7atracaoID), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "atracao", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public atracao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public atracao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_atracaoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7atracaoID = aP1_atracaoID;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "atracao", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_atracao.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_atracao.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtatracaoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtatracaoID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtatracaoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7atracaoID), 6, 0, ",", "")), ((edtatracaoID_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A7atracaoID), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A7atracaoID), "ZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtatracaoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtatracaoID_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNome_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNome_Internalname, A2Nome, StringUtil.RTrim( context.localUtil.Format( A2Nome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNome_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_atracao.htm");
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
         GxWebStd.gx_single_line_edit( context, edtpaisID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8paisID), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A8paisID), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtpaisID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtpaisID_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_atracao.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_8_Internalname, sImgUrl, imgprompt_8_Link, "", "", context.GetTheme( ), imgprompt_8_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_atracao.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisnome_Internalname, A9Paisnome, StringUtil.RTrim( context.localUtil.Format( A9Paisnome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisnome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisnome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoriaID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaID_Internalname, "Categoria ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoriaID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10CategoriaID), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A10CategoriaID), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoriaID_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_atracao.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_10_Internalname, sImgUrl, imgprompt_10_Link, "", "", context.GetTheme( ), imgprompt_10_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoriaNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaNome_Internalname, "Categoria Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCategoriaNome_Internalname, A11CategoriaNome, StringUtil.RTrim( context.localUtil.Format( A11CategoriaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoriaNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgImagem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagem", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A12Imagem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000Imagem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem)) ? A40000Imagem_GXI : context.PathToRelativeUrl( A12Imagem));
         GxWebStd.gx_bitmap( context, imgImagem_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgImagem_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "", "", "", 0, A12Imagem_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_atracao.htm");
         AssignProp("", false, imgImagem_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem)) ? A40000Imagem_GXI : context.PathToRelativeUrl( A12Imagem)), true);
         AssignProp("", false, imgImagem_Internalname, "IsBlob", StringUtil.BoolToStr( A12Imagem_IsBlob), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtpaisCidadeID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13paisCidadeID), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A13paisCidadeID), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtpaisCidadeID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtpaisCidadeID_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_atracao.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_13_Internalname, sImgUrl, imgprompt_13_Link, "", "", context.GetTheme( ), imgprompt_13_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_atracao.htm");
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
         GxWebStd.gx_single_line_edit( context, edtpaisCidadeNome_Internalname, A14paisCidadeNome, StringUtil.RTrim( context.localUtil.Format( A14paisCidadeNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtpaisCidadeNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtpaisCidadeNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_atracao.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_atracao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_atracao.htm");
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z7atracaoID = (int)(context.localUtil.CToN( cgiGet( "Z7atracaoID"), ",", "."));
               Z2Nome = cgiGet( "Z2Nome");
               Z8paisID = (int)(context.localUtil.CToN( cgiGet( "Z8paisID"), ",", "."));
               n8paisID = ((0==A8paisID) ? true : false);
               Z13paisCidadeID = (int)(context.localUtil.CToN( cgiGet( "Z13paisCidadeID"), ",", "."));
               n13paisCidadeID = ((0==A13paisCidadeID) ? true : false);
               Z10CategoriaID = (int)(context.localUtil.CToN( cgiGet( "Z10CategoriaID"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N8paisID = (int)(context.localUtil.CToN( cgiGet( "N8paisID"), ",", "."));
               n8paisID = ((0==A8paisID) ? true : false);
               N10CategoriaID = (int)(context.localUtil.CToN( cgiGet( "N10CategoriaID"), ",", "."));
               N13paisCidadeID = (int)(context.localUtil.CToN( cgiGet( "N13paisCidadeID"), ",", "."));
               n13paisCidadeID = ((0==A13paisCidadeID) ? true : false);
               AV7atracaoID = (int)(context.localUtil.CToN( cgiGet( "vATRACAOID"), ",", "."));
               AV11Insert_paisID = (int)(context.localUtil.CToN( cgiGet( "vINSERT_PAISID"), ",", "."));
               AV12Insert_CategoriaID = (int)(context.localUtil.CToN( cgiGet( "vINSERT_CATEGORIAID"), ",", "."));
               AV13Insert_paisCidadeID = (int)(context.localUtil.CToN( cgiGet( "vINSERT_PAISCIDADEID"), ",", "."));
               A40000Imagem_GXI = cgiGet( "IMAGEM_GXI");
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A7atracaoID = (int)(context.localUtil.CToN( cgiGet( edtatracaoID_Internalname), ",", "."));
               AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
               A2Nome = cgiGet( edtNome_Internalname);
               AssignAttri("", false, "A2Nome", A2Nome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtpaisID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtpaisID_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtpaisID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8paisID = 0;
                  n8paisID = false;
                  AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
               }
               else
               {
                  A8paisID = (int)(context.localUtil.CToN( cgiGet( edtpaisID_Internalname), ",", "."));
                  n8paisID = false;
                  AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
               }
               n8paisID = ((0==A8paisID) ? true : false);
               A9Paisnome = cgiGet( edtPaisnome_Internalname);
               AssignAttri("", false, "A9Paisnome", A9Paisnome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCategoriaID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoriaID_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORIAID");
                  AnyError = 1;
                  GX_FocusControl = edtCategoriaID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A10CategoriaID = 0;
                  AssignAttri("", false, "A10CategoriaID", StringUtil.LTrimStr( (decimal)(A10CategoriaID), 6, 0));
               }
               else
               {
                  A10CategoriaID = (int)(context.localUtil.CToN( cgiGet( edtCategoriaID_Internalname), ",", "."));
                  AssignAttri("", false, "A10CategoriaID", StringUtil.LTrimStr( (decimal)(A10CategoriaID), 6, 0));
               }
               A11CategoriaNome = cgiGet( edtCategoriaNome_Internalname);
               AssignAttri("", false, "A11CategoriaNome", A11CategoriaNome);
               A12Imagem = cgiGet( imgImagem_Internalname);
               AssignAttri("", false, "A12Imagem", A12Imagem);
               if ( ( ( context.localUtil.CToN( cgiGet( edtpaisCidadeID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtpaisCidadeID_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISCIDADEID");
                  AnyError = 1;
                  GX_FocusControl = edtpaisCidadeID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A13paisCidadeID = 0;
                  n13paisCidadeID = false;
                  AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
               }
               else
               {
                  A13paisCidadeID = (int)(context.localUtil.CToN( cgiGet( edtpaisCidadeID_Internalname), ",", "."));
                  n13paisCidadeID = false;
                  AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
               }
               n13paisCidadeID = ((0==A13paisCidadeID) ? true : false);
               A14paisCidadeNome = cgiGet( edtpaisCidadeNome_Internalname);
               AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgImagem_Internalname, ref  A12Imagem, ref  A40000Imagem_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"atracao");
               A7atracaoID = (int)(context.localUtil.CToN( cgiGet( edtatracaoID_Internalname), ",", "."));
               AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
               forbiddenHiddens.Add("atracaoID", context.localUtil.Format( (decimal)(A7atracaoID), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A7atracaoID != Z7atracaoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("atracao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A7atracaoID = (int)(NumberUtil.Val( GetPar( "atracaoID"), "."));
                  AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ATRACAOID");
                        AnyError = 1;
                        GX_FocusControl = edtatracaoID_Internalname;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "AgenciaViagem");
         AV11Insert_paisID = 0;
         AssignAttri("", false, "AV11Insert_paisID", StringUtil.LTrimStr( (decimal)(AV11Insert_paisID), 6, 0));
         AV12Insert_CategoriaID = 0;
         AssignAttri("", false, "AV12Insert_CategoriaID", StringUtil.LTrimStr( (decimal)(AV12Insert_CategoriaID), 6, 0));
         AV13Insert_paisCidadeID = 0;
         AssignAttri("", false, "AV13Insert_paisCidadeID", StringUtil.LTrimStr( (decimal)(AV13Insert_paisCidadeID), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "paisID") == 0 )
               {
                  AV11Insert_paisID = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_paisID", StringUtil.LTrimStr( (decimal)(AV11Insert_paisID), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "CategoriaID") == 0 )
               {
                  AV12Insert_CategoriaID = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_CategoriaID", StringUtil.LTrimStr( (decimal)(AV12Insert_CategoriaID), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "paisCidadeID") == 0 )
               {
                  AV13Insert_paisCidadeID = (int)(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_paisCidadeID", StringUtil.LTrimStr( (decimal)(AV13Insert_paisCidadeID), 6, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            }
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwatracao.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2Nome = T00023_A2Nome[0];
               Z8paisID = T00023_A8paisID[0];
               Z13paisCidadeID = T00023_A13paisCidadeID[0];
               Z10CategoriaID = T00023_A10CategoriaID[0];
            }
            else
            {
               Z2Nome = A2Nome;
               Z8paisID = A8paisID;
               Z13paisCidadeID = A13paisCidadeID;
               Z10CategoriaID = A10CategoriaID;
            }
         }
         if ( GX_JID == -14 )
         {
            Z7atracaoID = A7atracaoID;
            Z2Nome = A2Nome;
            Z12Imagem = A12Imagem;
            Z40000Imagem_GXI = A40000Imagem_GXI;
            Z8paisID = A8paisID;
            Z13paisCidadeID = A13paisCidadeID;
            Z10CategoriaID = A10CategoriaID;
            Z9Paisnome = A9Paisnome;
            Z11CategoriaNome = A11CategoriaNome;
            Z14paisCidadeNome = A14paisCidadeNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtatracaoID_Enabled = 0;
         AssignProp("", false, edtatracaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtatracaoID_Enabled), 5, 0), true);
         imgprompt_8_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_10_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORIAID"+"'), id:'"+"CATEGORIAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_13_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0051.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"PAISCIDADEID"+"'), id:'"+"PAISCIDADEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtatracaoID_Enabled = 0;
         AssignProp("", false, edtatracaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtatracaoID_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7atracaoID) )
         {
            A7atracaoID = AV7atracaoID;
            AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CategoriaID) )
         {
            edtCategoriaID_Enabled = 0;
            AssignProp("", false, edtCategoriaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaID_Enabled), 5, 0), true);
         }
         else
         {
            edtCategoriaID_Enabled = 1;
            AssignProp("", false, edtCategoriaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_paisCidadeID) )
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_paisCidadeID) )
         {
            A13paisCidadeID = AV13Insert_paisCidadeID;
            n13paisCidadeID = false;
            AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CategoriaID) )
         {
            A10CategoriaID = AV12Insert_CategoriaID;
            AssignAttri("", false, "A10CategoriaID", StringUtil.LTrimStr( (decimal)(A10CategoriaID), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_paisID) )
         {
            A8paisID = AV11Insert_paisID;
            n8paisID = false;
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
            AV15Pgmname = "atracao";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00026 */
            pr_default.execute(4, new Object[] {A10CategoriaID});
            A11CategoriaNome = T00026_A11CategoriaNome[0];
            AssignAttri("", false, "A11CategoriaNome", A11CategoriaNome);
            pr_default.close(4);
            /* Using cursor T00024 */
            pr_default.execute(2, new Object[] {n8paisID, A8paisID});
            A9Paisnome = T00024_A9Paisnome[0];
            AssignAttri("", false, "A9Paisnome", A9Paisnome);
            pr_default.close(2);
            /* Using cursor T00025 */
            pr_default.execute(3, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
            A14paisCidadeNome = T00025_A14paisCidadeNome[0];
            AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
            pr_default.close(3);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A7atracaoID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
            A2Nome = T00027_A2Nome[0];
            AssignAttri("", false, "A2Nome", A2Nome);
            A9Paisnome = T00027_A9Paisnome[0];
            AssignAttri("", false, "A9Paisnome", A9Paisnome);
            A11CategoriaNome = T00027_A11CategoriaNome[0];
            AssignAttri("", false, "A11CategoriaNome", A11CategoriaNome);
            A40000Imagem_GXI = T00027_A40000Imagem_GXI[0];
            AssignProp("", false, imgImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem)) ? A40000Imagem_GXI : context.convertURL( context.PathToRelativeUrl( A12Imagem))), true);
            AssignProp("", false, imgImagem_Internalname, "SrcSet", context.GetImageSrcSet( A12Imagem), true);
            A14paisCidadeNome = T00027_A14paisCidadeNome[0];
            AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
            A8paisID = T00027_A8paisID[0];
            n8paisID = T00027_n8paisID[0];
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            A13paisCidadeID = T00027_A13paisCidadeID[0];
            n13paisCidadeID = T00027_n13paisCidadeID[0];
            AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
            A10CategoriaID = T00027_A10CategoriaID[0];
            AssignAttri("", false, "A10CategoriaID", StringUtil.LTrimStr( (decimal)(A10CategoriaID), 6, 0));
            A12Imagem = T00027_A12Imagem[0];
            AssignAttri("", false, "A12Imagem", A12Imagem);
            AssignProp("", false, imgImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem)) ? A40000Imagem_GXI : context.convertURL( context.PathToRelativeUrl( A12Imagem))), true);
            AssignProp("", false, imgImagem_Internalname, "SrcSet", context.GetImageSrcSet( A12Imagem), true);
            ZM022( -14) ;
         }
         pr_default.close(5);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV15Pgmname = "atracao";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV15Pgmname = "atracao";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {n8paisID, A8paisID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A8paisID) ) )
            {
               GX_msglist.addItem("Não existe 'pais'.", "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
               GX_FocusControl = edtpaisID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A9Paisnome = T00024_A9Paisnome[0];
         AssignAttri("", false, "A9Paisnome", A9Paisnome);
         pr_default.close(2);
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A8paisID) || (0==A13paisCidadeID) ) )
            {
               GX_msglist.addItem("Não existe 'Cidade'.", "ForeignKeyNotFound", 1, "PAISCIDADEID");
               AnyError = 1;
               GX_FocusControl = edtpaisID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A14paisCidadeNome = T00025_A14paisCidadeNome[0];
         AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
         pr_default.close(3);
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A10CategoriaID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11CategoriaNome = T00026_A11CategoriaNome[0];
         AssignAttri("", false, "A11CategoriaNome", A11CategoriaNome);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( int A8paisID )
      {
         /* Using cursor T00028 */
         pr_default.execute(6, new Object[] {n8paisID, A8paisID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A8paisID) ) )
            {
               GX_msglist.addItem("Não existe 'pais'.", "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
               GX_FocusControl = edtpaisID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A9Paisnome = T00028_A9Paisnome[0];
         AssignAttri("", false, "A9Paisnome", A9Paisnome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A9Paisnome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_16( int A8paisID ,
                                int A13paisCidadeID )
      {
         /* Using cursor T00029 */
         pr_default.execute(7, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A8paisID) || (0==A13paisCidadeID) ) )
            {
               GX_msglist.addItem("Não existe 'Cidade'.", "ForeignKeyNotFound", 1, "PAISCIDADEID");
               AnyError = 1;
               GX_FocusControl = edtpaisID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A14paisCidadeNome = T00029_A14paisCidadeNome[0];
         AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A14paisCidadeNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_17( int A10CategoriaID )
      {
         /* Using cursor T000210 */
         pr_default.execute(8, new Object[] {A10CategoriaID});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A11CategoriaNome = T000210_A11CategoriaNome[0];
         AssignAttri("", false, "A11CategoriaNome", A11CategoriaNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A11CategoriaNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000211 */
         pr_default.execute(9, new Object[] {A7atracaoID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A7atracaoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 14) ;
            RcdFound2 = 1;
            A7atracaoID = T00023_A7atracaoID[0];
            AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
            A2Nome = T00023_A2Nome[0];
            AssignAttri("", false, "A2Nome", A2Nome);
            A40000Imagem_GXI = T00023_A40000Imagem_GXI[0];
            AssignProp("", false, imgImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem)) ? A40000Imagem_GXI : context.convertURL( context.PathToRelativeUrl( A12Imagem))), true);
            AssignProp("", false, imgImagem_Internalname, "SrcSet", context.GetImageSrcSet( A12Imagem), true);
            A8paisID = T00023_A8paisID[0];
            n8paisID = T00023_n8paisID[0];
            AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
            A13paisCidadeID = T00023_A13paisCidadeID[0];
            n13paisCidadeID = T00023_n13paisCidadeID[0];
            AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
            A10CategoriaID = T00023_A10CategoriaID[0];
            AssignAttri("", false, "A10CategoriaID", StringUtil.LTrimStr( (decimal)(A10CategoriaID), 6, 0));
            A12Imagem = T00023_A12Imagem[0];
            AssignAttri("", false, "A12Imagem", A12Imagem);
            AssignProp("", false, imgImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem)) ? A40000Imagem_GXI : context.convertURL( context.PathToRelativeUrl( A12Imagem))), true);
            AssignProp("", false, imgImagem_Internalname, "SrcSet", context.GetImageSrcSet( A12Imagem), true);
            Z7atracaoID = A7atracaoID;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000212 */
         pr_default.execute(10, new Object[] {A7atracaoID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000212_A7atracaoID[0] < A7atracaoID ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000212_A7atracaoID[0] > A7atracaoID ) ) )
            {
               A7atracaoID = T000212_A7atracaoID[0];
               AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000213 */
         pr_default.execute(11, new Object[] {A7atracaoID});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000213_A7atracaoID[0] > A7atracaoID ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000213_A7atracaoID[0] < A7atracaoID ) ) )
            {
               A7atracaoID = T000213_A7atracaoID[0];
               AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A7atracaoID != Z7atracaoID )
               {
                  A7atracaoID = Z7atracaoID;
                  AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ATRACAOID");
                  AnyError = 1;
                  GX_FocusControl = edtatracaoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A7atracaoID != Z7atracaoID )
               {
                  /* Insert record */
                  GX_FocusControl = edtNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ATRACAOID");
                     AnyError = 1;
                     GX_FocusControl = edtatracaoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A7atracaoID != Z7atracaoID )
         {
            A7atracaoID = Z7atracaoID;
            AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ATRACAOID");
            AnyError = 1;
            GX_FocusControl = edtatracaoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A7atracaoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"atracao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2Nome, T00022_A2Nome[0]) != 0 ) || ( Z8paisID != T00022_A8paisID[0] ) || ( Z13paisCidadeID != T00022_A13paisCidadeID[0] ) || ( Z10CategoriaID != T00022_A10CategoriaID[0] ) )
            {
               if ( StringUtil.StrCmp(Z2Nome, T00022_A2Nome[0]) != 0 )
               {
                  GXUtil.WriteLog("atracao:[seudo value changed for attri]"+"Nome");
                  GXUtil.WriteLogRaw("Old: ",Z2Nome);
                  GXUtil.WriteLogRaw("Current: ",T00022_A2Nome[0]);
               }
               if ( Z8paisID != T00022_A8paisID[0] )
               {
                  GXUtil.WriteLog("atracao:[seudo value changed for attri]"+"paisID");
                  GXUtil.WriteLogRaw("Old: ",Z8paisID);
                  GXUtil.WriteLogRaw("Current: ",T00022_A8paisID[0]);
               }
               if ( Z13paisCidadeID != T00022_A13paisCidadeID[0] )
               {
                  GXUtil.WriteLog("atracao:[seudo value changed for attri]"+"paisCidadeID");
                  GXUtil.WriteLogRaw("Old: ",Z13paisCidadeID);
                  GXUtil.WriteLogRaw("Current: ",T00022_A13paisCidadeID[0]);
               }
               if ( Z10CategoriaID != T00022_A10CategoriaID[0] )
               {
                  GXUtil.WriteLog("atracao:[seudo value changed for attri]"+"CategoriaID");
                  GXUtil.WriteLogRaw("Old: ",Z10CategoriaID);
                  GXUtil.WriteLogRaw("Current: ",T00022_A10CategoriaID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"atracao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000214 */
                     pr_default.execute(12, new Object[] {A2Nome, A12Imagem, A40000Imagem_GXI, n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID, A10CategoriaID});
                     A7atracaoID = T000214_A7atracaoID[0];
                     AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("atracao");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000215 */
                     pr_default.execute(13, new Object[] {A2Nome, n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID, A10CategoriaID, A7atracaoID});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("atracao");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"atracao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000216 */
            pr_default.execute(14, new Object[] {A12Imagem, A40000Imagem_GXI, A7atracaoID});
            pr_default.close(14);
            dsDefault.SmartCacheProvider.SetUpdated("atracao");
         }
      }

      protected void delete( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000217 */
                  pr_default.execute(15, new Object[] {A7atracaoID});
                  pr_default.close(15);
                  dsDefault.SmartCacheProvider.SetUpdated("atracao");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "atracao";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000218 */
            pr_default.execute(16, new Object[] {n8paisID, A8paisID});
            A9Paisnome = T000218_A9Paisnome[0];
            AssignAttri("", false, "A9Paisnome", A9Paisnome);
            pr_default.close(16);
            /* Using cursor T000219 */
            pr_default.execute(17, new Object[] {A10CategoriaID});
            A11CategoriaNome = T000219_A11CategoriaNome[0];
            AssignAttri("", false, "A11CategoriaNome", A11CategoriaNome);
            pr_default.close(17);
            /* Using cursor T000220 */
            pr_default.execute(18, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
            A14paisCidadeNome = T000220_A14paisCidadeNome[0];
            AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
            pr_default.close(18);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(16);
            pr_default.close(18);
            pr_default.close(17);
            context.CommitDataStores("atracao",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(16);
            pr_default.close(18);
            pr_default.close(17);
            context.RollbackDataStores("atracao",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000221 */
         pr_default.execute(19);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound2 = 1;
            A7atracaoID = T000221_A7atracaoID[0];
            AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound2 = 1;
            A7atracaoID = T000221_A7atracaoID[0];
            AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtatracaoID_Enabled = 0;
         AssignProp("", false, edtatracaoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtatracaoID_Enabled), 5, 0), true);
         edtNome_Enabled = 0;
         AssignProp("", false, edtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNome_Enabled), 5, 0), true);
         edtpaisID_Enabled = 0;
         AssignProp("", false, edtpaisID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisID_Enabled), 5, 0), true);
         edtPaisnome_Enabled = 0;
         AssignProp("", false, edtPaisnome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisnome_Enabled), 5, 0), true);
         edtCategoriaID_Enabled = 0;
         AssignProp("", false, edtCategoriaID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaID_Enabled), 5, 0), true);
         edtCategoriaNome_Enabled = 0;
         AssignProp("", false, edtCategoriaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaNome_Enabled), 5, 0), true);
         imgImagem_Enabled = 0;
         AssignProp("", false, imgImagem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgImagem_Enabled), 5, 0), true);
         edtpaisCidadeID_Enabled = 0;
         AssignProp("", false, edtpaisCidadeID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeID_Enabled), 5, 0), true);
         edtpaisCidadeNome_Enabled = 0;
         AssignProp("", false, edtpaisCidadeNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtpaisCidadeNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.AddJavascriptSource("gxcfg.js", "?2021715223881", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("atracao.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7atracaoID,6,0))}, new string[] {"Gx_mode","atracaoID"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"atracao");
         forbiddenHiddens.Add("atracaoID", context.localUtil.Format( (decimal)(A7atracaoID), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("atracao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z7atracaoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7atracaoID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z2Nome", Z2Nome);
         GxWebStd.gx_hidden_field( context, "Z8paisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8paisID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z13paisCidadeID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13paisCidadeID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z10CategoriaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10CategoriaID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N8paisID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8paisID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N10CategoriaID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10CategoriaID), 6, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vATRACAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7atracaoID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vATRACAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7atracaoID), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_paisID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_CategoriaID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISCIDADEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_paisCidadeID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IMAGEM_GXI", A40000Imagem_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
         GXCCtlgxBlob = "IMAGEM" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A12Imagem);
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
         return formatLink("atracao.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7atracaoID,6,0))}, new string[] {"Gx_mode","atracaoID"})  ;
      }

      public override string GetPgmname( )
      {
         return "atracao" ;
      }

      public override string GetPgmdesc( )
      {
         return "atracao" ;
      }

      protected void InitializeNonKey022( )
      {
         A8paisID = 0;
         n8paisID = false;
         AssignAttri("", false, "A8paisID", StringUtil.LTrimStr( (decimal)(A8paisID), 6, 0));
         n8paisID = ((0==A8paisID) ? true : false);
         A10CategoriaID = 0;
         AssignAttri("", false, "A10CategoriaID", StringUtil.LTrimStr( (decimal)(A10CategoriaID), 6, 0));
         A13paisCidadeID = 0;
         n13paisCidadeID = false;
         AssignAttri("", false, "A13paisCidadeID", StringUtil.LTrimStr( (decimal)(A13paisCidadeID), 6, 0));
         n13paisCidadeID = ((0==A13paisCidadeID) ? true : false);
         A2Nome = "";
         AssignAttri("", false, "A2Nome", A2Nome);
         A9Paisnome = "";
         AssignAttri("", false, "A9Paisnome", A9Paisnome);
         A11CategoriaNome = "";
         AssignAttri("", false, "A11CategoriaNome", A11CategoriaNome);
         A12Imagem = "";
         AssignAttri("", false, "A12Imagem", A12Imagem);
         AssignProp("", false, imgImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem)) ? A40000Imagem_GXI : context.convertURL( context.PathToRelativeUrl( A12Imagem))), true);
         AssignProp("", false, imgImagem_Internalname, "SrcSet", context.GetImageSrcSet( A12Imagem), true);
         A40000Imagem_GXI = "";
         AssignProp("", false, imgImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A12Imagem)) ? A40000Imagem_GXI : context.convertURL( context.PathToRelativeUrl( A12Imagem))), true);
         AssignProp("", false, imgImagem_Internalname, "SrcSet", context.GetImageSrcSet( A12Imagem), true);
         A14paisCidadeNome = "";
         AssignAttri("", false, "A14paisCidadeNome", A14paisCidadeNome);
         Z2Nome = "";
         Z8paisID = 0;
         Z13paisCidadeID = 0;
         Z10CategoriaID = 0;
      }

      protected void InitAll022( )
      {
         A7atracaoID = 0;
         AssignAttri("", false, "A7atracaoID", StringUtil.LTrimStr( (decimal)(A7atracaoID), 6, 0));
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021715223887", true, true);
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
         context.AddJavascriptSource("atracao.js", "?2021715223887", false, true);
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
         edtatracaoID_Internalname = "ATRACAOID";
         edtNome_Internalname = "NOME";
         edtpaisID_Internalname = "PAISID";
         edtPaisnome_Internalname = "PAISNOME";
         edtCategoriaID_Internalname = "CATEGORIAID";
         edtCategoriaNome_Internalname = "CATEGORIANOME";
         imgImagem_Internalname = "IMAGEM";
         edtpaisCidadeID_Internalname = "PAISCIDADEID";
         edtpaisCidadeNome_Internalname = "PAISCIDADENOME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_8_Internalname = "PROMPT_8";
         imgprompt_10_Internalname = "PROMPT_10";
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
         Form.Caption = "atracao";
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
         imgImagem_Enabled = 1;
         edtCategoriaNome_Jsonclick = "";
         edtCategoriaNome_Enabled = 0;
         imgprompt_10_Visible = 1;
         imgprompt_10_Link = "";
         edtCategoriaID_Jsonclick = "";
         edtCategoriaID_Enabled = 1;
         edtPaisnome_Jsonclick = "";
         edtPaisnome_Enabled = 0;
         imgprompt_8_Visible = 1;
         imgprompt_8_Link = "";
         edtpaisID_Jsonclick = "";
         edtpaisID_Enabled = 1;
         edtNome_Jsonclick = "";
         edtNome_Enabled = 1;
         edtatracaoID_Jsonclick = "";
         edtatracaoID_Enabled = 0;
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
         n8paisID = false;
         /* Using cursor T000218 */
         pr_default.execute(16, new Object[] {n8paisID, A8paisID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A8paisID) ) )
            {
               GX_msglist.addItem("Não existe 'pais'.", "ForeignKeyNotFound", 1, "PAISID");
               AnyError = 1;
               GX_FocusControl = edtpaisID_Internalname;
            }
         }
         A9Paisnome = T000218_A9Paisnome[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A9Paisnome", A9Paisnome);
      }

      public void Valid_Categoriaid( )
      {
         /* Using cursor T000219 */
         pr_default.execute(17, new Object[] {A10CategoriaID});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("Não existe 'Categoria'.", "ForeignKeyNotFound", 1, "CATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaID_Internalname;
         }
         A11CategoriaNome = T000219_A11CategoriaNome[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A11CategoriaNome", A11CategoriaNome);
      }

      public void Valid_Paiscidadeid( )
      {
         n8paisID = false;
         n13paisCidadeID = false;
         /* Using cursor T000220 */
         pr_default.execute(18, new Object[] {n8paisID, A8paisID, n13paisCidadeID, A13paisCidadeID});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( (0==A8paisID) || (0==A13paisCidadeID) ) )
            {
               GX_msglist.addItem("Não existe 'Cidade'.", "ForeignKeyNotFound", 1, "PAISCIDADEID");
               AnyError = 1;
               GX_FocusControl = edtpaisID_Internalname;
            }
         }
         A14paisCidadeNome = T000220_A14paisCidadeNome[0];
         pr_default.close(18);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7atracaoID',fld:'vATRACAOID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7atracaoID',fld:'vATRACAOID',pic:'ZZZZZ9',hsh:true},{av:'A7atracaoID',fld:'ATRACAOID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ATRACAOID","{handler:'Valid_Atracaoid',iparms:[]");
         setEventMetadata("VALID_ATRACAOID",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[{av:'A8paisID',fld:'PAISID',pic:'ZZZZZ9'},{av:'A9Paisnome',fld:'PAISNOME',pic:''}]");
         setEventMetadata("VALID_PAISID",",oparms:[{av:'A9Paisnome',fld:'PAISNOME',pic:''}]}");
         setEventMetadata("VALID_CATEGORIAID","{handler:'Valid_Categoriaid',iparms:[{av:'A10CategoriaID',fld:'CATEGORIAID',pic:'ZZZZZ9'},{av:'A11CategoriaNome',fld:'CATEGORIANOME',pic:''}]");
         setEventMetadata("VALID_CATEGORIAID",",oparms:[{av:'A11CategoriaNome',fld:'CATEGORIANOME',pic:''}]}");
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
         pr_default.close(16);
         pr_default.close(18);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z2Nome = "";
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
         A2Nome = "";
         sImgUrl = "";
         A9Paisnome = "";
         A11CategoriaNome = "";
         A12Imagem = "";
         A40000Imagem_GXI = "";
         A14paisCidadeNome = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z12Imagem = "";
         Z40000Imagem_GXI = "";
         Z9Paisnome = "";
         Z11CategoriaNome = "";
         Z14paisCidadeNome = "";
         T00026_A11CategoriaNome = new string[] {""} ;
         T00024_A9Paisnome = new string[] {""} ;
         T00025_A14paisCidadeNome = new string[] {""} ;
         T00027_A7atracaoID = new int[1] ;
         T00027_A2Nome = new string[] {""} ;
         T00027_A9Paisnome = new string[] {""} ;
         T00027_A11CategoriaNome = new string[] {""} ;
         T00027_A40000Imagem_GXI = new string[] {""} ;
         T00027_A14paisCidadeNome = new string[] {""} ;
         T00027_A8paisID = new int[1] ;
         T00027_n8paisID = new bool[] {false} ;
         T00027_A13paisCidadeID = new int[1] ;
         T00027_n13paisCidadeID = new bool[] {false} ;
         T00027_A10CategoriaID = new int[1] ;
         T00027_A12Imagem = new string[] {""} ;
         T00028_A9Paisnome = new string[] {""} ;
         T00029_A14paisCidadeNome = new string[] {""} ;
         T000210_A11CategoriaNome = new string[] {""} ;
         T000211_A7atracaoID = new int[1] ;
         T00023_A7atracaoID = new int[1] ;
         T00023_A2Nome = new string[] {""} ;
         T00023_A40000Imagem_GXI = new string[] {""} ;
         T00023_A8paisID = new int[1] ;
         T00023_n8paisID = new bool[] {false} ;
         T00023_A13paisCidadeID = new int[1] ;
         T00023_n13paisCidadeID = new bool[] {false} ;
         T00023_A10CategoriaID = new int[1] ;
         T00023_A12Imagem = new string[] {""} ;
         T000212_A7atracaoID = new int[1] ;
         T000213_A7atracaoID = new int[1] ;
         T00022_A7atracaoID = new int[1] ;
         T00022_A2Nome = new string[] {""} ;
         T00022_A40000Imagem_GXI = new string[] {""} ;
         T00022_A8paisID = new int[1] ;
         T00022_n8paisID = new bool[] {false} ;
         T00022_A13paisCidadeID = new int[1] ;
         T00022_n13paisCidadeID = new bool[] {false} ;
         T00022_A10CategoriaID = new int[1] ;
         T00022_A12Imagem = new string[] {""} ;
         T000214_A7atracaoID = new int[1] ;
         T000218_A9Paisnome = new string[] {""} ;
         T000219_A11CategoriaNome = new string[] {""} ;
         T000220_A14paisCidadeNome = new string[] {""} ;
         T000221_A7atracaoID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.atracao__default(),
            new Object[][] {
                new Object[] {
               T00022_A7atracaoID, T00022_A2Nome, T00022_A40000Imagem_GXI, T00022_A8paisID, T00022_n8paisID, T00022_A13paisCidadeID, T00022_n13paisCidadeID, T00022_A10CategoriaID, T00022_A12Imagem
               }
               , new Object[] {
               T00023_A7atracaoID, T00023_A2Nome, T00023_A40000Imagem_GXI, T00023_A8paisID, T00023_n8paisID, T00023_A13paisCidadeID, T00023_n13paisCidadeID, T00023_A10CategoriaID, T00023_A12Imagem
               }
               , new Object[] {
               T00024_A9Paisnome
               }
               , new Object[] {
               T00025_A14paisCidadeNome
               }
               , new Object[] {
               T00026_A11CategoriaNome
               }
               , new Object[] {
               T00027_A7atracaoID, T00027_A2Nome, T00027_A9Paisnome, T00027_A11CategoriaNome, T00027_A40000Imagem_GXI, T00027_A14paisCidadeNome, T00027_A8paisID, T00027_n8paisID, T00027_A13paisCidadeID, T00027_n13paisCidadeID,
               T00027_A10CategoriaID, T00027_A12Imagem
               }
               , new Object[] {
               T00028_A9Paisnome
               }
               , new Object[] {
               T00029_A14paisCidadeNome
               }
               , new Object[] {
               T000210_A11CategoriaNome
               }
               , new Object[] {
               T000211_A7atracaoID
               }
               , new Object[] {
               T000212_A7atracaoID
               }
               , new Object[] {
               T000213_A7atracaoID
               }
               , new Object[] {
               T000214_A7atracaoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000218_A9Paisnome
               }
               , new Object[] {
               T000219_A11CategoriaNome
               }
               , new Object[] {
               T000220_A14paisCidadeNome
               }
               , new Object[] {
               T000221_A7atracaoID
               }
            }
         );
         AV15Pgmname = "atracao";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound2 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_2 ;
      private short gxajaxcallmode ;
      private int wcpOAV7atracaoID ;
      private int Z7atracaoID ;
      private int Z8paisID ;
      private int Z13paisCidadeID ;
      private int Z10CategoriaID ;
      private int N8paisID ;
      private int N10CategoriaID ;
      private int N13paisCidadeID ;
      private int A8paisID ;
      private int A13paisCidadeID ;
      private int A10CategoriaID ;
      private int AV7atracaoID ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A7atracaoID ;
      private int edtatracaoID_Enabled ;
      private int edtNome_Enabled ;
      private int edtpaisID_Enabled ;
      private int imgprompt_8_Visible ;
      private int edtPaisnome_Enabled ;
      private int edtCategoriaID_Enabled ;
      private int imgprompt_10_Visible ;
      private int edtCategoriaNome_Enabled ;
      private int imgImagem_Enabled ;
      private int edtpaisCidadeID_Enabled ;
      private int imgprompt_13_Visible ;
      private int edtpaisCidadeNome_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_paisID ;
      private int AV12Insert_CategoriaID ;
      private int AV13Insert_paisCidadeID ;
      private int AV16GXV1 ;
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
      private string edtNome_Internalname ;
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
      private string edtatracaoID_Internalname ;
      private string edtatracaoID_Jsonclick ;
      private string edtNome_Jsonclick ;
      private string edtpaisID_Internalname ;
      private string edtpaisID_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_8_Internalname ;
      private string imgprompt_8_Link ;
      private string edtPaisnome_Internalname ;
      private string edtPaisnome_Jsonclick ;
      private string edtCategoriaID_Internalname ;
      private string edtCategoriaID_Jsonclick ;
      private string imgprompt_10_Internalname ;
      private string imgprompt_10_Link ;
      private string edtCategoriaNome_Internalname ;
      private string edtCategoriaNome_Jsonclick ;
      private string imgImagem_Internalname ;
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
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n8paisID ;
      private bool n13paisCidadeID ;
      private bool wbErr ;
      private bool A12Imagem_IsBlob ;
      private bool returnInSub ;
      private string Z2Nome ;
      private string A2Nome ;
      private string A9Paisnome ;
      private string A11CategoriaNome ;
      private string A40000Imagem_GXI ;
      private string A14paisCidadeNome ;
      private string Z40000Imagem_GXI ;
      private string Z9Paisnome ;
      private string Z11CategoriaNome ;
      private string Z14paisCidadeNome ;
      private string A12Imagem ;
      private string Z12Imagem ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00026_A11CategoriaNome ;
      private string[] T00024_A9Paisnome ;
      private string[] T00025_A14paisCidadeNome ;
      private int[] T00027_A7atracaoID ;
      private string[] T00027_A2Nome ;
      private string[] T00027_A9Paisnome ;
      private string[] T00027_A11CategoriaNome ;
      private string[] T00027_A40000Imagem_GXI ;
      private string[] T00027_A14paisCidadeNome ;
      private int[] T00027_A8paisID ;
      private bool[] T00027_n8paisID ;
      private int[] T00027_A13paisCidadeID ;
      private bool[] T00027_n13paisCidadeID ;
      private int[] T00027_A10CategoriaID ;
      private string[] T00027_A12Imagem ;
      private string[] T00028_A9Paisnome ;
      private string[] T00029_A14paisCidadeNome ;
      private string[] T000210_A11CategoriaNome ;
      private int[] T000211_A7atracaoID ;
      private int[] T00023_A7atracaoID ;
      private string[] T00023_A2Nome ;
      private string[] T00023_A40000Imagem_GXI ;
      private int[] T00023_A8paisID ;
      private bool[] T00023_n8paisID ;
      private int[] T00023_A13paisCidadeID ;
      private bool[] T00023_n13paisCidadeID ;
      private int[] T00023_A10CategoriaID ;
      private string[] T00023_A12Imagem ;
      private int[] T000212_A7atracaoID ;
      private int[] T000213_A7atracaoID ;
      private int[] T00022_A7atracaoID ;
      private string[] T00022_A2Nome ;
      private string[] T00022_A40000Imagem_GXI ;
      private int[] T00022_A8paisID ;
      private bool[] T00022_n8paisID ;
      private int[] T00022_A13paisCidadeID ;
      private bool[] T00022_n13paisCidadeID ;
      private int[] T00022_A10CategoriaID ;
      private string[] T00022_A12Imagem ;
      private int[] T000214_A7atracaoID ;
      private string[] T000218_A9Paisnome ;
      private string[] T000219_A11CategoriaNome ;
      private string[] T000220_A14paisCidadeNome ;
      private int[] T000221_A7atracaoID ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class atracao__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@atracaoID",GXType.Int32,6,0)
          };
          Object[] prmT00024;
          prmT00024 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@atracaoID",GXType.Int32,6,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@atracaoID",GXType.Int32,6,0)
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@atracaoID",GXType.Int32,6,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@atracaoID",GXType.Int32,6,0)
          };
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@atracaoID",GXType.Int32,6,0)
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@Nome",GXType.NVarChar,50,0) ,
          new ParDef("@Imagem",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@Imagem_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="atracao", Fld="Imagem"} ,
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@Nome",GXType.NVarChar,50,0) ,
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@CategoriaID",GXType.Int32,6,0) ,
          new ParDef("@atracaoID",GXType.Int32,6,0)
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@Imagem",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@Imagem_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="atracao", Fld="Imagem"} ,
          new ParDef("@atracaoID",GXType.Int32,6,0)
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@atracaoID",GXType.Int32,6,0)
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@CategoriaID",GXType.Int32,6,0)
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          new ParDef("@paisID",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@paisCidadeID",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [atracaoID], [Nome], [Imagem_GXI], [paisID], [paisCidadeID], [CategoriaID], [Imagem] FROM [atracao] WITH (UPDLOCK) WHERE [atracaoID] = @atracaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [atracaoID], [Nome], [Imagem_GXI], [paisID], [paisCidadeID], [CategoriaID], [Imagem] FROM [atracao] WHERE [atracaoID] = @atracaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00024", "SELECT [Paisnome] FROM [pais] WHERE [paisID] = @paisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT [paisCidadeNome] FROM [paisCidade] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT [CategoriaNome] FROM [Categoria] WHERE [CategoriaID] = @CategoriaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT TM1.[atracaoID], TM1.[Nome], T2.[Paisnome], T3.[CategoriaNome], TM1.[Imagem_GXI], T4.[paisCidadeNome], TM1.[paisID], TM1.[paisCidadeID], TM1.[CategoriaID], TM1.[Imagem] FROM ((([atracao] TM1 LEFT JOIN [pais] T2 ON T2.[paisID] = TM1.[paisID]) INNER JOIN [Categoria] T3 ON T3.[CategoriaID] = TM1.[CategoriaID]) LEFT JOIN [paisCidade] T4 ON T4.[paisID] = TM1.[paisID] AND T4.[paisCidadeID] = TM1.[paisCidadeID]) WHERE TM1.[atracaoID] = @atracaoID ORDER BY TM1.[atracaoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT [Paisnome] FROM [pais] WHERE [paisID] = @paisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT [paisCidadeNome] FROM [paisCidade] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT [CategoriaNome] FROM [Categoria] WHERE [CategoriaID] = @CategoriaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000211", "SELECT [atracaoID] FROM [atracao] WHERE [atracaoID] = @atracaoID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000212", "SELECT TOP 1 [atracaoID] FROM [atracao] WHERE ( [atracaoID] > @atracaoID) ORDER BY [atracaoID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000213", "SELECT TOP 1 [atracaoID] FROM [atracao] WHERE ( [atracaoID] < @atracaoID) ORDER BY [atracaoID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000214", "INSERT INTO [atracao]([Nome], [Imagem], [Imagem_GXI], [paisID], [paisCidadeID], [CategoriaID]) VALUES(@Nome, @Imagem, @Imagem_GXI, @paisID, @paisCidadeID, @CategoriaID); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000214)
             ,new CursorDef("T000215", "UPDATE [atracao] SET [Nome]=@Nome, [paisID]=@paisID, [paisCidadeID]=@paisCidadeID, [CategoriaID]=@CategoriaID  WHERE [atracaoID] = @atracaoID", GxErrorMask.GX_NOMASK,prmT000215)
             ,new CursorDef("T000216", "UPDATE [atracao] SET [Imagem]=@Imagem, [Imagem_GXI]=@Imagem_GXI  WHERE [atracaoID] = @atracaoID", GxErrorMask.GX_NOMASK,prmT000216)
             ,new CursorDef("T000217", "DELETE FROM [atracao]  WHERE [atracaoID] = @atracaoID", GxErrorMask.GX_NOMASK,prmT000217)
             ,new CursorDef("T000218", "SELECT [Paisnome] FROM [pais] WHERE [paisID] = @paisID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000219", "SELECT [CategoriaNome] FROM [Categoria] WHERE [CategoriaID] = @CategoriaID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000220", "SELECT [paisCidadeNome] FROM [paisCidade] WHERE [paisID] = @paisID AND [paisCidadeID] = @paisCidadeID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000221", "SELECT [atracaoID] FROM [atracao] ORDER BY [atracaoID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
