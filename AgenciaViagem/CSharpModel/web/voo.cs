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
   public class voo : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A20VooEmbarqueAeroportoID = (int)(NumberUtil.Val( GetPar( "VooEmbarqueAeroportoID"), "."));
            AssignAttri("", false, "A20VooEmbarqueAeroportoID", StringUtil.LTrimStr( (decimal)(A20VooEmbarqueAeroportoID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A20VooEmbarqueAeroportoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A22VooChegadaAeroportoID = (int)(NumberUtil.Val( GetPar( "VooChegadaAeroportoID"), "."));
            AssignAttri("", false, "A22VooChegadaAeroportoID", StringUtil.LTrimStr( (decimal)(A22VooChegadaAeroportoID), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A22VooChegadaAeroportoID) ;
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
               AV7VooId = (int)(NumberUtil.Val( GetPar( "VooId"), "."));
               AssignAttri("", false, "AV7VooId", StringUtil.LTrimStr( (decimal)(AV7VooId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vVOOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VooId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Voo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public voo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public voo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_VooId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7VooId = aP1_VooId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Voo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Voo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Voo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVooId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVooId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVooId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19VooId), 6, 0, ",", "")), ((edtVooId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A19VooId), "ZZZZZ9")) : context.localUtil.Format( (decimal)(A19VooId), "ZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVooId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVooId_Enabled, 0, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVooEmbarqueAeroportoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVooEmbarqueAeroportoID_Internalname, "Embarque_ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVooEmbarqueAeroportoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20VooEmbarqueAeroportoID), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A20VooEmbarqueAeroportoID), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVooEmbarqueAeroportoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVooEmbarqueAeroportoID_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Voo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_20_Internalname, sImgUrl, imgprompt_20_Link, "", "", context.GetTheme( ), imgprompt_20_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVooEmbarqueAeroportoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVooEmbarqueAeroportoNome_Internalname, "Aeroporto Embarque", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVooEmbarqueAeroportoNome_Internalname, A21VooEmbarqueAeroportoNome, StringUtil.RTrim( context.localUtil.Format( A21VooEmbarqueAeroportoNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVooEmbarqueAeroportoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVooEmbarqueAeroportoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVooChegadaAeroportoID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVooChegadaAeroportoID_Internalname, "Chegada_Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVooChegadaAeroportoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22VooChegadaAeroportoID), 6, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A22VooChegadaAeroportoID), "ZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVooChegadaAeroportoID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVooChegadaAeroportoID_Enabled, 1, "number", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Voo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_22_Internalname, sImgUrl, imgprompt_22_Link, "", "", context.GetTheme( ), imgprompt_22_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVooChegadaAeroportoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVooChegadaAeroportoNome_Internalname, "Aeroporto Chegada", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVooChegadaAeroportoNome_Internalname, A23VooChegadaAeroportoNome, StringUtil.RTrim( context.localUtil.Format( A23VooChegadaAeroportoNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVooChegadaAeroportoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVooChegadaAeroportoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Voo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Voo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Voo.htm");
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z19VooId = (int)(context.localUtil.CToN( cgiGet( "Z19VooId"), ",", "."));
               Z20VooEmbarqueAeroportoID = (int)(context.localUtil.CToN( cgiGet( "Z20VooEmbarqueAeroportoID"), ",", "."));
               Z22VooChegadaAeroportoID = (int)(context.localUtil.CToN( cgiGet( "Z22VooChegadaAeroportoID"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N20VooEmbarqueAeroportoID = (int)(context.localUtil.CToN( cgiGet( "N20VooEmbarqueAeroportoID"), ",", "."));
               N22VooChegadaAeroportoID = (int)(context.localUtil.CToN( cgiGet( "N22VooChegadaAeroportoID"), ",", "."));
               AV7VooId = (int)(context.localUtil.CToN( cgiGet( "vVOOID"), ",", "."));
               AV11Insert_VooEmbarqueAeroportoID = (int)(context.localUtil.CToN( cgiGet( "vINSERT_VOOEMBARQUEAEROPORTOID"), ",", "."));
               AV12Insert_VooChegadaAeroportoID = (int)(context.localUtil.CToN( cgiGet( "vINSERT_VOOCHEGADAAEROPORTOID"), ",", "."));
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A19VooId = (int)(context.localUtil.CToN( cgiGet( edtVooId_Internalname), ",", "."));
               AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtVooEmbarqueAeroportoID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVooEmbarqueAeroportoID_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOOEMBARQUEAEROPORTOID");
                  AnyError = 1;
                  GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A20VooEmbarqueAeroportoID = 0;
                  AssignAttri("", false, "A20VooEmbarqueAeroportoID", StringUtil.LTrimStr( (decimal)(A20VooEmbarqueAeroportoID), 6, 0));
               }
               else
               {
                  A20VooEmbarqueAeroportoID = (int)(context.localUtil.CToN( cgiGet( edtVooEmbarqueAeroportoID_Internalname), ",", "."));
                  AssignAttri("", false, "A20VooEmbarqueAeroportoID", StringUtil.LTrimStr( (decimal)(A20VooEmbarqueAeroportoID), 6, 0));
               }
               A21VooEmbarqueAeroportoNome = cgiGet( edtVooEmbarqueAeroportoNome_Internalname);
               AssignAttri("", false, "A21VooEmbarqueAeroportoNome", A21VooEmbarqueAeroportoNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtVooChegadaAeroportoID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVooChegadaAeroportoID_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VOOCHEGADAAEROPORTOID");
                  AnyError = 1;
                  GX_FocusControl = edtVooChegadaAeroportoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A22VooChegadaAeroportoID = 0;
                  AssignAttri("", false, "A22VooChegadaAeroportoID", StringUtil.LTrimStr( (decimal)(A22VooChegadaAeroportoID), 6, 0));
               }
               else
               {
                  A22VooChegadaAeroportoID = (int)(context.localUtil.CToN( cgiGet( edtVooChegadaAeroportoID_Internalname), ",", "."));
                  AssignAttri("", false, "A22VooChegadaAeroportoID", StringUtil.LTrimStr( (decimal)(A22VooChegadaAeroportoID), 6, 0));
               }
               A23VooChegadaAeroportoNome = cgiGet( edtVooChegadaAeroportoNome_Internalname);
               AssignAttri("", false, "A23VooChegadaAeroportoNome", A23VooChegadaAeroportoNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Voo");
               A19VooId = (int)(context.localUtil.CToN( cgiGet( edtVooId_Internalname), ",", "."));
               AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
               forbiddenHiddens.Add("VooId", context.localUtil.Format( (decimal)(A19VooId), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A19VooId != Z19VooId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("voo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A19VooId = (int)(NumberUtil.Val( GetPar( "VooId"), "."));
                  AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
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
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "VOOID");
                        AnyError = 1;
                        GX_FocusControl = edtVooId_Internalname;
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
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12062 ();
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
            E12062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll067( ) ;
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
            DisableAttributes067( ) ;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls067( ) ;
            }
            else
            {
               CheckExtendedTable067( ) ;
               CloseExtendedTableCursors067( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "TransactionContext", "AgenciaViagem");
         AV11Insert_VooEmbarqueAeroportoID = 0;
         AssignAttri("", false, "AV11Insert_VooEmbarqueAeroportoID", StringUtil.LTrimStr( (decimal)(AV11Insert_VooEmbarqueAeroportoID), 6, 0));
         AV12Insert_VooChegadaAeroportoID = 0;
         AssignAttri("", false, "AV12Insert_VooChegadaAeroportoID", StringUtil.LTrimStr( (decimal)(AV12Insert_VooChegadaAeroportoID), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "VooEmbarqueAeroportoID") == 0 )
               {
                  AV11Insert_VooEmbarqueAeroportoID = (int)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_VooEmbarqueAeroportoID", StringUtil.LTrimStr( (decimal)(AV11Insert_VooEmbarqueAeroportoID), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "VooChegadaAeroportoID") == 0 )
               {
                  AV12Insert_VooChegadaAeroportoID = (int)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_VooChegadaAeroportoID", StringUtil.LTrimStr( (decimal)(AV12Insert_VooChegadaAeroportoID), 6, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            }
         }
      }

      protected void E12062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwvoo.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM067( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z20VooEmbarqueAeroportoID = T00063_A20VooEmbarqueAeroportoID[0];
               Z22VooChegadaAeroportoID = T00063_A22VooChegadaAeroportoID[0];
            }
            else
            {
               Z20VooEmbarqueAeroportoID = A20VooEmbarqueAeroportoID;
               Z22VooChegadaAeroportoID = A22VooChegadaAeroportoID;
            }
         }
         if ( GX_JID == -11 )
         {
            Z19VooId = A19VooId;
            Z20VooEmbarqueAeroportoID = A20VooEmbarqueAeroportoID;
            Z22VooChegadaAeroportoID = A22VooChegadaAeroportoID;
            Z21VooEmbarqueAeroportoNome = A21VooEmbarqueAeroportoNome;
            Z23VooChegadaAeroportoNome = A23VooChegadaAeroportoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtVooId_Enabled = 0;
         AssignProp("", false, edtVooId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooId_Enabled), 5, 0), true);
         imgprompt_20_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"VOOEMBARQUEAEROPORTOID"+"'), id:'"+"VOOEMBARQUEAEROPORTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_22_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"VOOCHEGADAAEROPORTOID"+"'), id:'"+"VOOCHEGADAAEROPORTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtVooId_Enabled = 0;
         AssignProp("", false, edtVooId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7VooId) )
         {
            A19VooId = AV7VooId;
            AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_VooEmbarqueAeroportoID) )
         {
            edtVooEmbarqueAeroportoID_Enabled = 0;
            AssignProp("", false, edtVooEmbarqueAeroportoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooEmbarqueAeroportoID_Enabled), 5, 0), true);
         }
         else
         {
            edtVooEmbarqueAeroportoID_Enabled = 1;
            AssignProp("", false, edtVooEmbarqueAeroportoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooEmbarqueAeroportoID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_VooChegadaAeroportoID) )
         {
            edtVooChegadaAeroportoID_Enabled = 0;
            AssignProp("", false, edtVooChegadaAeroportoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooChegadaAeroportoID_Enabled), 5, 0), true);
         }
         else
         {
            edtVooChegadaAeroportoID_Enabled = 1;
            AssignProp("", false, edtVooChegadaAeroportoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooChegadaAeroportoID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_VooChegadaAeroportoID) )
         {
            A22VooChegadaAeroportoID = AV12Insert_VooChegadaAeroportoID;
            AssignAttri("", false, "A22VooChegadaAeroportoID", StringUtil.LTrimStr( (decimal)(A22VooChegadaAeroportoID), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_VooEmbarqueAeroportoID) )
         {
            A20VooEmbarqueAeroportoID = AV11Insert_VooEmbarqueAeroportoID;
            AssignAttri("", false, "A20VooEmbarqueAeroportoID", StringUtil.LTrimStr( (decimal)(A20VooEmbarqueAeroportoID), 6, 0));
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
            AV14Pgmname = "Voo";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T00065 */
            pr_default.execute(3, new Object[] {A22VooChegadaAeroportoID});
            A23VooChegadaAeroportoNome = T00065_A23VooChegadaAeroportoNome[0];
            AssignAttri("", false, "A23VooChegadaAeroportoNome", A23VooChegadaAeroportoNome);
            pr_default.close(3);
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {A20VooEmbarqueAeroportoID});
            A21VooEmbarqueAeroportoNome = T00064_A21VooEmbarqueAeroportoNome[0];
            AssignAttri("", false, "A21VooEmbarqueAeroportoNome", A21VooEmbarqueAeroportoNome);
            pr_default.close(2);
         }
      }

      protected void Load067( )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A19VooId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound7 = 1;
            A21VooEmbarqueAeroportoNome = T00066_A21VooEmbarqueAeroportoNome[0];
            AssignAttri("", false, "A21VooEmbarqueAeroportoNome", A21VooEmbarqueAeroportoNome);
            A23VooChegadaAeroportoNome = T00066_A23VooChegadaAeroportoNome[0];
            AssignAttri("", false, "A23VooChegadaAeroportoNome", A23VooChegadaAeroportoNome);
            A20VooEmbarqueAeroportoID = T00066_A20VooEmbarqueAeroportoID[0];
            AssignAttri("", false, "A20VooEmbarqueAeroportoID", StringUtil.LTrimStr( (decimal)(A20VooEmbarqueAeroportoID), 6, 0));
            A22VooChegadaAeroportoID = T00066_A22VooChegadaAeroportoID[0];
            AssignAttri("", false, "A22VooChegadaAeroportoID", StringUtil.LTrimStr( (decimal)(A22VooChegadaAeroportoID), 6, 0));
            ZM067( -11) ;
         }
         pr_default.close(4);
         OnLoadActions067( ) ;
      }

      protected void OnLoadActions067( )
      {
         AV14Pgmname = "Voo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable067( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Voo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A20VooEmbarqueAeroportoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Voo Embarque'.", "ForeignKeyNotFound", 1, "VOOEMBARQUEAEROPORTOID");
            AnyError = 1;
            GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21VooEmbarqueAeroportoNome = T00064_A21VooEmbarqueAeroportoNome[0];
         AssignAttri("", false, "A21VooEmbarqueAeroportoNome", A21VooEmbarqueAeroportoNome);
         pr_default.close(2);
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A22VooChegadaAeroportoID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Voo Chegada'.", "ForeignKeyNotFound", 1, "VOOCHEGADAAEROPORTOID");
            AnyError = 1;
            GX_FocusControl = edtVooChegadaAeroportoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23VooChegadaAeroportoNome = T00065_A23VooChegadaAeroportoNome[0];
         AssignAttri("", false, "A23VooChegadaAeroportoNome", A23VooChegadaAeroportoNome);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors067( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A20VooEmbarqueAeroportoID )
      {
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A20VooEmbarqueAeroportoID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Voo Embarque'.", "ForeignKeyNotFound", 1, "VOOEMBARQUEAEROPORTOID");
            AnyError = 1;
            GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A21VooEmbarqueAeroportoNome = T00067_A21VooEmbarqueAeroportoNome[0];
         AssignAttri("", false, "A21VooEmbarqueAeroportoNome", A21VooEmbarqueAeroportoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A21VooEmbarqueAeroportoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_13( int A22VooChegadaAeroportoID )
      {
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A22VooChegadaAeroportoID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Voo Chegada'.", "ForeignKeyNotFound", 1, "VOOCHEGADAAEROPORTOID");
            AnyError = 1;
            GX_FocusControl = edtVooChegadaAeroportoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23VooChegadaAeroportoNome = T00068_A23VooChegadaAeroportoNome[0];
         AssignAttri("", false, "A23VooChegadaAeroportoNome", A23VooChegadaAeroportoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A23VooChegadaAeroportoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey067( )
      {
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A19VooId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A19VooId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM067( 11) ;
            RcdFound7 = 1;
            A19VooId = T00063_A19VooId[0];
            AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
            A20VooEmbarqueAeroportoID = T00063_A20VooEmbarqueAeroportoID[0];
            AssignAttri("", false, "A20VooEmbarqueAeroportoID", StringUtil.LTrimStr( (decimal)(A20VooEmbarqueAeroportoID), 6, 0));
            A22VooChegadaAeroportoID = T00063_A22VooChegadaAeroportoID[0];
            AssignAttri("", false, "A22VooChegadaAeroportoID", StringUtil.LTrimStr( (decimal)(A22VooChegadaAeroportoID), 6, 0));
            Z19VooId = A19VooId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load067( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey067( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey067( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey067( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T000610 */
         pr_default.execute(8, new Object[] {A19VooId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000610_A19VooId[0] < A19VooId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000610_A19VooId[0] > A19VooId ) ) )
            {
               A19VooId = T000610_A19VooId[0];
               AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T000611 */
         pr_default.execute(9, new Object[] {A19VooId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000611_A19VooId[0] > A19VooId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000611_A19VooId[0] < A19VooId ) ) )
            {
               A19VooId = T000611_A19VooId[0];
               AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey067( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert067( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A19VooId != Z19VooId )
               {
                  A19VooId = Z19VooId;
                  AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VOOID");
                  AnyError = 1;
                  GX_FocusControl = edtVooId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update067( ) ;
                  GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A19VooId != Z19VooId )
               {
                  /* Insert record */
                  GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert067( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VOOID");
                     AnyError = 1;
                     GX_FocusControl = edtVooId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert067( ) ;
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
         if ( A19VooId != Z19VooId )
         {
            A19VooId = Z19VooId;
            AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VOOID");
            AnyError = 1;
            GX_FocusControl = edtVooId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency067( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A19VooId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Voo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z20VooEmbarqueAeroportoID != T00062_A20VooEmbarqueAeroportoID[0] ) || ( Z22VooChegadaAeroportoID != T00062_A22VooChegadaAeroportoID[0] ) )
            {
               if ( Z20VooEmbarqueAeroportoID != T00062_A20VooEmbarqueAeroportoID[0] )
               {
                  GXUtil.WriteLog("voo:[seudo value changed for attri]"+"VooEmbarqueAeroportoID");
                  GXUtil.WriteLogRaw("Old: ",Z20VooEmbarqueAeroportoID);
                  GXUtil.WriteLogRaw("Current: ",T00062_A20VooEmbarqueAeroportoID[0]);
               }
               if ( Z22VooChegadaAeroportoID != T00062_A22VooChegadaAeroportoID[0] )
               {
                  GXUtil.WriteLog("voo:[seudo value changed for attri]"+"VooChegadaAeroportoID");
                  GXUtil.WriteLogRaw("Old: ",Z22VooChegadaAeroportoID);
                  GXUtil.WriteLogRaw("Current: ",T00062_A22VooChegadaAeroportoID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Voo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM067( 0) ;
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000612 */
                     pr_default.execute(10, new Object[] {A20VooEmbarqueAeroportoID, A22VooChegadaAeroportoID});
                     A19VooId = T000612_A19VooId[0];
                     AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Voo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption060( ) ;
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
               Load067( ) ;
            }
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void Update067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000613 */
                     pr_default.execute(11, new Object[] {A20VooEmbarqueAeroportoID, A22VooChegadaAeroportoID, A19VooId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Voo");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Voo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate067( ) ;
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
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void DeferredUpdate067( )
      {
      }

      protected void delete( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls067( ) ;
            AfterConfirm067( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete067( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000614 */
                  pr_default.execute(12, new Object[] {A19VooId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("Voo");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel067( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls067( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Voo";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000615 */
            pr_default.execute(13, new Object[] {A20VooEmbarqueAeroportoID});
            A21VooEmbarqueAeroportoNome = T000615_A21VooEmbarqueAeroportoNome[0];
            AssignAttri("", false, "A21VooEmbarqueAeroportoNome", A21VooEmbarqueAeroportoNome);
            pr_default.close(13);
            /* Using cursor T000616 */
            pr_default.execute(14, new Object[] {A22VooChegadaAeroportoID});
            A23VooChegadaAeroportoNome = T000616_A23VooChegadaAeroportoNome[0];
            AssignAttri("", false, "A23VooChegadaAeroportoNome", A23VooChegadaAeroportoNome);
            pr_default.close(14);
         }
      }

      protected void EndLevel067( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete067( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("voo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
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
            context.RollbackDataStores("voo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart067( )
      {
         /* Scan By routine */
         /* Using cursor T000617 */
         pr_default.execute(15);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound7 = 1;
            A19VooId = T000617_A19VooId[0];
            AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext067( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound7 = 1;
            A19VooId = T000617_A19VooId[0];
            AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
         }
      }

      protected void ScanEnd067( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm067( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert067( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate067( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete067( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete067( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate067( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes067( )
      {
         edtVooId_Enabled = 0;
         AssignProp("", false, edtVooId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooId_Enabled), 5, 0), true);
         edtVooEmbarqueAeroportoID_Enabled = 0;
         AssignProp("", false, edtVooEmbarqueAeroportoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooEmbarqueAeroportoID_Enabled), 5, 0), true);
         edtVooEmbarqueAeroportoNome_Enabled = 0;
         AssignProp("", false, edtVooEmbarqueAeroportoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooEmbarqueAeroportoNome_Enabled), 5, 0), true);
         edtVooChegadaAeroportoID_Enabled = 0;
         AssignProp("", false, edtVooChegadaAeroportoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooChegadaAeroportoID_Enabled), 5, 0), true);
         edtVooChegadaAeroportoNome_Enabled = 0;
         AssignProp("", false, edtVooChegadaAeroportoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVooChegadaAeroportoNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes067( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.AddJavascriptSource("gxcfg.js", "?20217152238410", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("voo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VooId,6,0))}, new string[] {"Gx_mode","VooId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Voo");
         forbiddenHiddens.Add("VooId", context.localUtil.Format( (decimal)(A19VooId), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("voo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z19VooId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19VooId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z20VooEmbarqueAeroportoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20VooEmbarqueAeroportoID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z22VooChegadaAeroportoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22VooChegadaAeroportoID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N20VooEmbarqueAeroportoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20VooEmbarqueAeroportoID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N22VooChegadaAeroportoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22VooChegadaAeroportoID), 6, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vVOOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7VooId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVOOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VooId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_VOOEMBARQUEAEROPORTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_VooEmbarqueAeroportoID), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_VOOCHEGADAAEROPORTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_VooChegadaAeroportoID), 6, 0, ",", "")));
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
         return formatLink("voo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VooId,6,0))}, new string[] {"Gx_mode","VooId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Voo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Voo" ;
      }

      protected void InitializeNonKey067( )
      {
         A20VooEmbarqueAeroportoID = 0;
         AssignAttri("", false, "A20VooEmbarqueAeroportoID", StringUtil.LTrimStr( (decimal)(A20VooEmbarqueAeroportoID), 6, 0));
         A22VooChegadaAeroportoID = 0;
         AssignAttri("", false, "A22VooChegadaAeroportoID", StringUtil.LTrimStr( (decimal)(A22VooChegadaAeroportoID), 6, 0));
         A21VooEmbarqueAeroportoNome = "";
         AssignAttri("", false, "A21VooEmbarqueAeroportoNome", A21VooEmbarqueAeroportoNome);
         A23VooChegadaAeroportoNome = "";
         AssignAttri("", false, "A23VooChegadaAeroportoNome", A23VooChegadaAeroportoNome);
         Z20VooEmbarqueAeroportoID = 0;
         Z22VooChegadaAeroportoID = 0;
      }

      protected void InitAll067( )
      {
         A19VooId = 0;
         AssignAttri("", false, "A19VooId", StringUtil.LTrimStr( (decimal)(A19VooId), 6, 0));
         InitializeNonKey067( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20217152238414", true, true);
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
         context.AddJavascriptSource("voo.js", "?20217152238414", false, true);
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
         edtVooId_Internalname = "VOOID";
         edtVooEmbarqueAeroportoID_Internalname = "VOOEMBARQUEAEROPORTOID";
         edtVooEmbarqueAeroportoNome_Internalname = "VOOEMBARQUEAEROPORTONOME";
         edtVooChegadaAeroportoID_Internalname = "VOOCHEGADAAEROPORTOID";
         edtVooChegadaAeroportoNome_Internalname = "VOOCHEGADAAEROPORTONOME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_20_Internalname = "PROMPT_20";
         imgprompt_22_Internalname = "PROMPT_22";
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
         Form.Caption = "Voo";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtVooChegadaAeroportoNome_Jsonclick = "";
         edtVooChegadaAeroportoNome_Enabled = 0;
         imgprompt_22_Visible = 1;
         imgprompt_22_Link = "";
         edtVooChegadaAeroportoID_Jsonclick = "";
         edtVooChegadaAeroportoID_Enabled = 1;
         edtVooEmbarqueAeroportoNome_Jsonclick = "";
         edtVooEmbarqueAeroportoNome_Enabled = 0;
         imgprompt_20_Visible = 1;
         imgprompt_20_Link = "";
         edtVooEmbarqueAeroportoID_Jsonclick = "";
         edtVooEmbarqueAeroportoID_Enabled = 1;
         edtVooId_Jsonclick = "";
         edtVooId_Enabled = 0;
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

      public void Valid_Vooembarqueaeroportoid( )
      {
         /* Using cursor T000615 */
         pr_default.execute(13, new Object[] {A20VooEmbarqueAeroportoID});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Voo Embarque'.", "ForeignKeyNotFound", 1, "VOOEMBARQUEAEROPORTOID");
            AnyError = 1;
            GX_FocusControl = edtVooEmbarqueAeroportoID_Internalname;
         }
         A21VooEmbarqueAeroportoNome = T000615_A21VooEmbarqueAeroportoNome[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A21VooEmbarqueAeroportoNome", A21VooEmbarqueAeroportoNome);
      }

      public void Valid_Voochegadaaeroportoid( )
      {
         /* Using cursor T000616 */
         pr_default.execute(14, new Object[] {A22VooChegadaAeroportoID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Voo Chegada'.", "ForeignKeyNotFound", 1, "VOOCHEGADAAEROPORTOID");
            AnyError = 1;
            GX_FocusControl = edtVooChegadaAeroportoID_Internalname;
         }
         A23VooChegadaAeroportoNome = T000616_A23VooChegadaAeroportoNome[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A23VooChegadaAeroportoNome", A23VooChegadaAeroportoNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7VooId',fld:'vVOOID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7VooId',fld:'vVOOID',pic:'ZZZZZ9',hsh:true},{av:'A19VooId',fld:'VOOID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12062',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_VOOID","{handler:'Valid_Vooid',iparms:[]");
         setEventMetadata("VALID_VOOID",",oparms:[]}");
         setEventMetadata("VALID_VOOEMBARQUEAEROPORTOID","{handler:'Valid_Vooembarqueaeroportoid',iparms:[{av:'A20VooEmbarqueAeroportoID',fld:'VOOEMBARQUEAEROPORTOID',pic:'ZZZZZ9'},{av:'A21VooEmbarqueAeroportoNome',fld:'VOOEMBARQUEAEROPORTONOME',pic:''}]");
         setEventMetadata("VALID_VOOEMBARQUEAEROPORTOID",",oparms:[{av:'A21VooEmbarqueAeroportoNome',fld:'VOOEMBARQUEAEROPORTONOME',pic:''}]}");
         setEventMetadata("VALID_VOOCHEGADAAEROPORTOID","{handler:'Valid_Voochegadaaeroportoid',iparms:[{av:'A22VooChegadaAeroportoID',fld:'VOOCHEGADAAEROPORTOID',pic:'ZZZZZ9'},{av:'A23VooChegadaAeroportoNome',fld:'VOOCHEGADAAEROPORTONOME',pic:''}]");
         setEventMetadata("VALID_VOOCHEGADAAEROPORTOID",",oparms:[{av:'A23VooChegadaAeroportoNome',fld:'VOOCHEGADAAEROPORTONOME',pic:''}]}");
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
         sImgUrl = "";
         A21VooEmbarqueAeroportoNome = "";
         A23VooChegadaAeroportoNome = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z21VooEmbarqueAeroportoNome = "";
         Z23VooChegadaAeroportoNome = "";
         T00065_A23VooChegadaAeroportoNome = new string[] {""} ;
         T00064_A21VooEmbarqueAeroportoNome = new string[] {""} ;
         T00066_A19VooId = new int[1] ;
         T00066_A21VooEmbarqueAeroportoNome = new string[] {""} ;
         T00066_A23VooChegadaAeroportoNome = new string[] {""} ;
         T00066_A20VooEmbarqueAeroportoID = new int[1] ;
         T00066_A22VooChegadaAeroportoID = new int[1] ;
         T00067_A21VooEmbarqueAeroportoNome = new string[] {""} ;
         T00068_A23VooChegadaAeroportoNome = new string[] {""} ;
         T00069_A19VooId = new int[1] ;
         T00063_A19VooId = new int[1] ;
         T00063_A20VooEmbarqueAeroportoID = new int[1] ;
         T00063_A22VooChegadaAeroportoID = new int[1] ;
         T000610_A19VooId = new int[1] ;
         T000611_A19VooId = new int[1] ;
         T00062_A19VooId = new int[1] ;
         T00062_A20VooEmbarqueAeroportoID = new int[1] ;
         T00062_A22VooChegadaAeroportoID = new int[1] ;
         T000612_A19VooId = new int[1] ;
         T000615_A21VooEmbarqueAeroportoNome = new string[] {""} ;
         T000616_A23VooChegadaAeroportoNome = new string[] {""} ;
         T000617_A19VooId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.voo__default(),
            new Object[][] {
                new Object[] {
               T00062_A19VooId, T00062_A20VooEmbarqueAeroportoID, T00062_A22VooChegadaAeroportoID
               }
               , new Object[] {
               T00063_A19VooId, T00063_A20VooEmbarqueAeroportoID, T00063_A22VooChegadaAeroportoID
               }
               , new Object[] {
               T00064_A21VooEmbarqueAeroportoNome
               }
               , new Object[] {
               T00065_A23VooChegadaAeroportoNome
               }
               , new Object[] {
               T00066_A19VooId, T00066_A21VooEmbarqueAeroportoNome, T00066_A23VooChegadaAeroportoNome, T00066_A20VooEmbarqueAeroportoID, T00066_A22VooChegadaAeroportoID
               }
               , new Object[] {
               T00067_A21VooEmbarqueAeroportoNome
               }
               , new Object[] {
               T00068_A23VooChegadaAeroportoNome
               }
               , new Object[] {
               T00069_A19VooId
               }
               , new Object[] {
               T000610_A19VooId
               }
               , new Object[] {
               T000611_A19VooId
               }
               , new Object[] {
               T000612_A19VooId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000615_A21VooEmbarqueAeroportoNome
               }
               , new Object[] {
               T000616_A23VooChegadaAeroportoNome
               }
               , new Object[] {
               T000617_A19VooId
               }
            }
         );
         AV14Pgmname = "Voo";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound7 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_7 ;
      private short gxajaxcallmode ;
      private int wcpOAV7VooId ;
      private int Z19VooId ;
      private int Z20VooEmbarqueAeroportoID ;
      private int Z22VooChegadaAeroportoID ;
      private int N20VooEmbarqueAeroportoID ;
      private int N22VooChegadaAeroportoID ;
      private int A20VooEmbarqueAeroportoID ;
      private int A22VooChegadaAeroportoID ;
      private int AV7VooId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A19VooId ;
      private int edtVooId_Enabled ;
      private int edtVooEmbarqueAeroportoID_Enabled ;
      private int imgprompt_20_Visible ;
      private int edtVooEmbarqueAeroportoNome_Enabled ;
      private int edtVooChegadaAeroportoID_Enabled ;
      private int imgprompt_22_Visible ;
      private int edtVooChegadaAeroportoNome_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_VooEmbarqueAeroportoID ;
      private int AV12Insert_VooChegadaAeroportoID ;
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
      private string edtVooEmbarqueAeroportoID_Internalname ;
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
      private string edtVooId_Internalname ;
      private string edtVooId_Jsonclick ;
      private string edtVooEmbarqueAeroportoID_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_20_Internalname ;
      private string imgprompt_20_Link ;
      private string edtVooEmbarqueAeroportoNome_Internalname ;
      private string edtVooEmbarqueAeroportoNome_Jsonclick ;
      private string edtVooChegadaAeroportoID_Internalname ;
      private string edtVooChegadaAeroportoID_Jsonclick ;
      private string imgprompt_22_Internalname ;
      private string imgprompt_22_Link ;
      private string edtVooChegadaAeroportoNome_Internalname ;
      private string edtVooChegadaAeroportoNome_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode7 ;
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
      private string A21VooEmbarqueAeroportoNome ;
      private string A23VooChegadaAeroportoNome ;
      private string Z21VooEmbarqueAeroportoNome ;
      private string Z23VooChegadaAeroportoNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00065_A23VooChegadaAeroportoNome ;
      private string[] T00064_A21VooEmbarqueAeroportoNome ;
      private int[] T00066_A19VooId ;
      private string[] T00066_A21VooEmbarqueAeroportoNome ;
      private string[] T00066_A23VooChegadaAeroportoNome ;
      private int[] T00066_A20VooEmbarqueAeroportoID ;
      private int[] T00066_A22VooChegadaAeroportoID ;
      private string[] T00067_A21VooEmbarqueAeroportoNome ;
      private string[] T00068_A23VooChegadaAeroportoNome ;
      private int[] T00069_A19VooId ;
      private int[] T00063_A19VooId ;
      private int[] T00063_A20VooEmbarqueAeroportoID ;
      private int[] T00063_A22VooChegadaAeroportoID ;
      private int[] T000610_A19VooId ;
      private int[] T000611_A19VooId ;
      private int[] T00062_A19VooId ;
      private int[] T00062_A20VooEmbarqueAeroportoID ;
      private int[] T00062_A22VooChegadaAeroportoID ;
      private int[] T000612_A19VooId ;
      private string[] T000615_A21VooEmbarqueAeroportoNome ;
      private string[] T000616_A23VooChegadaAeroportoNome ;
      private int[] T000617_A19VooId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class voo__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@VooId",GXType.Int32,6,0)
          };
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@VooEmbarqueAeroportoID",GXType.Int32,6,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@VooChegadaAeroportoID",GXType.Int32,6,0)
          };
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@VooEmbarqueAeroportoID",GXType.Int32,6,0)
          };
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@VooChegadaAeroportoID",GXType.Int32,6,0)
          };
          Object[] prmT00069;
          prmT00069 = new Object[] {
          new ParDef("@VooId",GXType.Int32,6,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@VooId",GXType.Int32,6,0)
          };
          Object[] prmT000610;
          prmT000610 = new Object[] {
          new ParDef("@VooId",GXType.Int32,6,0)
          };
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@VooId",GXType.Int32,6,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@VooId",GXType.Int32,6,0)
          };
          Object[] prmT000612;
          prmT000612 = new Object[] {
          new ParDef("@VooEmbarqueAeroportoID",GXType.Int32,6,0) ,
          new ParDef("@VooChegadaAeroportoID",GXType.Int32,6,0)
          };
          Object[] prmT000613;
          prmT000613 = new Object[] {
          new ParDef("@VooEmbarqueAeroportoID",GXType.Int32,6,0) ,
          new ParDef("@VooChegadaAeroportoID",GXType.Int32,6,0) ,
          new ParDef("@VooId",GXType.Int32,6,0)
          };
          Object[] prmT000614;
          prmT000614 = new Object[] {
          new ParDef("@VooId",GXType.Int32,6,0)
          };
          Object[] prmT000617;
          prmT000617 = new Object[] {
          };
          Object[] prmT000615;
          prmT000615 = new Object[] {
          new ParDef("@VooEmbarqueAeroportoID",GXType.Int32,6,0)
          };
          Object[] prmT000616;
          prmT000616 = new Object[] {
          new ParDef("@VooChegadaAeroportoID",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [VooId], [VooEmbarqueAeroportoID] AS VooEmbarqueAeroportoID, [VooChegadaAeroportoID] AS VooChegadaAeroportoID FROM [Voo] WITH (UPDLOCK) WHERE [VooId] = @VooId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [VooId], [VooEmbarqueAeroportoID] AS VooEmbarqueAeroportoID, [VooChegadaAeroportoID] AS VooChegadaAeroportoID FROM [Voo] WHERE [VooId] = @VooId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [AeroportoNome] AS VooEmbarqueAeroportoNome FROM [aeroporto] WHERE [AeroportoId] = @VooEmbarqueAeroportoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [AeroportoNome] AS VooChegadaAeroportoNome FROM [aeroporto] WHERE [AeroportoId] = @VooChegadaAeroportoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT TM1.[VooId], T2.[AeroportoNome] AS VooEmbarqueAeroportoNome, T3.[AeroportoNome] AS VooChegadaAeroportoNome, TM1.[VooEmbarqueAeroportoID] AS VooEmbarqueAeroportoID, TM1.[VooChegadaAeroportoID] AS VooChegadaAeroportoID FROM (([Voo] TM1 INNER JOIN [aeroporto] T2 ON T2.[AeroportoId] = TM1.[VooEmbarqueAeroportoID]) INNER JOIN [aeroporto] T3 ON T3.[AeroportoId] = TM1.[VooChegadaAeroportoID]) WHERE TM1.[VooId] = @VooId ORDER BY TM1.[VooId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT [AeroportoNome] AS VooEmbarqueAeroportoNome FROM [aeroporto] WHERE [AeroportoId] = @VooEmbarqueAeroportoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT [AeroportoNome] AS VooChegadaAeroportoNome FROM [aeroporto] WHERE [AeroportoId] = @VooChegadaAeroportoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00069", "SELECT [VooId] FROM [Voo] WHERE [VooId] = @VooId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000610", "SELECT TOP 1 [VooId] FROM [Voo] WHERE ( [VooId] > @VooId) ORDER BY [VooId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000611", "SELECT TOP 1 [VooId] FROM [Voo] WHERE ( [VooId] < @VooId) ORDER BY [VooId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000612", "INSERT INTO [Voo]([VooEmbarqueAeroportoID], [VooChegadaAeroportoID]) VALUES(@VooEmbarqueAeroportoID, @VooChegadaAeroportoID); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000612)
             ,new CursorDef("T000613", "UPDATE [Voo] SET [VooEmbarqueAeroportoID]=@VooEmbarqueAeroportoID, [VooChegadaAeroportoID]=@VooChegadaAeroportoID  WHERE [VooId] = @VooId", GxErrorMask.GX_NOMASK,prmT000613)
             ,new CursorDef("T000614", "DELETE FROM [Voo]  WHERE [VooId] = @VooId", GxErrorMask.GX_NOMASK,prmT000614)
             ,new CursorDef("T000615", "SELECT [AeroportoNome] AS VooEmbarqueAeroportoNome FROM [aeroporto] WHERE [AeroportoId] = @VooEmbarqueAeroportoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000616", "SELECT [AeroportoNome] AS VooChegadaAeroportoNome FROM [aeroporto] WHERE [AeroportoId] = @VooChegadaAeroportoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000617", "SELECT [VooId] FROM [Voo] ORDER BY [VooId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
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
       }
    }

 }

}
