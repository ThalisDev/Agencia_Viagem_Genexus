gx.evt.autoSkip=!1;gx.define("clientes",!1,function(){this.ServerClass="clientes";this.PackageName="GeneXus.Programs";this.ServerFullClass="clientes.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7ClienteID=gx.fn.getIntegerValue("vCLIENTEID",".");this.Gx_date=gx.fn.getDateValue("vTODAY");this.Gx_BScreen=gx.fn.getIntegerValue("vGXBSCREEN",".");this.AV13Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Clienteid=function(){return this.validCliEvt("Valid_Clienteid",0,function(){try{var n=gx.util.balloon.getNew("CLIENTEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Clientenome=function(){return this.validCliEvt("Valid_Clientenome",0,function(){try{var n=gx.util.balloon.getNew("CLIENTENOME");if(this.AnyError=0,gx.text.compare("",this.A3ClienteNome)==0)try{n.setError("por favor digite o nome do cliente");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Clientetelefone=function(){return this.validCliEvt("Valid_Clientetelefone",0,function(){try{var n=gx.util.balloon.getNew("CLIENTETELEFONE");if(this.AnyError=0,gx.text.compare("",this.A5ClienteTelefone)==0)try{n.setMessage("O telefone esta vazio")}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Clienteemail=function(){return this.validCliEvt("Valid_Clienteemail",0,function(){try{var n=gx.util.balloon.getNew("CLIENTEEMAIL");if(this.AnyError=0,!gx.util.regExp.isMatch(this.A6ClienteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$"))try{n.setError("O valor de Cliente Email não coincide com o padrão especificado");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Clientedataentrada=function(){return this.validCliEvt("Valid_Clientedataentrada",0,function(){try{var n=gx.util.balloon.getNew("CLIENTEDATAENTRADA");if(this.AnyError=0,new gx.date.gxdate(this.A15ClienteDataEntrada).compare(this.Gx_date)>0)try{n.setError("A data de cadastro não pode estar no futuro!");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e12012_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13011_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14011_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68];this.GXLastCtrlId=68;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15011_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16011_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17011_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18011_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19011_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Clienteid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEID",gxz:"Z1ClienteID",gxold:"O1ClienteID",gxvar:"A1ClienteID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1ClienteID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1ClienteID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CLIENTEID",gx.O.A1ClienteID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1ClienteID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CLIENTEID",".")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clientenome,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTENOME",gxz:"Z3ClienteNome",gxold:"O3ClienteNome",gxvar:"A3ClienteNome",ucs:[],op:[39],ip:[39],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A3ClienteNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z3ClienteNome=n)},v2c:function(){gx.fn.setControlValue("CLIENTENOME",gx.O.A3ClienteNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A3ClienteNome=this.val())},val:function(){return gx.fn.getControlValue("CLIENTENOME")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"svchar",len:1024,dec:0,sign:!1,ro:0,multiline:!0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEENDERECO",gxz:"Z4ClienteEndereco",gxold:"O4ClienteEndereco",gxvar:"A4ClienteEndereco",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A4ClienteEndereco=n)},v2z:function(n){n!==undefined&&(gx.O.Z4ClienteEndereco=n)},v2c:function(){gx.fn.setControlValue("CLIENTEENDERECO",gx.O.A4ClienteEndereco,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A4ClienteEndereco=this.val())},val:function(){return gx.fn.getControlValue("CLIENTEENDERECO")},nac:gx.falseFn};this.declareDomainHdlr(44,function(){gx.fn.setCtrlProperty("CLIENTEENDERECO","Link",gx.fn.getCtrlProperty("CLIENTEENDERECO","Enabled")?"":"http://maps.google.com/maps?q="+encodeURIComponent(this.A4ClienteEndereco))});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clientetelefone,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTETELEFONE",gxz:"Z5ClienteTelefone",gxold:"O5ClienteTelefone",gxvar:"A5ClienteTelefone",ucs:[],op:[],ip:[49],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5ClienteTelefone=n)},v2z:function(n){n!==undefined&&(gx.O.Z5ClienteTelefone=n)},v2c:function(){gx.fn.setControlValue("CLIENTETELEFONE",gx.O.A5ClienteTelefone,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A5ClienteTelefone=this.val())},val:function(){return gx.fn.getControlValue("CLIENTETELEFONE")},nac:gx.falseFn};this.declareDomainHdlr(49,function(){});n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Clienteemail,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEEMAIL",gxz:"Z6ClienteEmail",gxold:"O6ClienteEmail",gxvar:"A6ClienteEmail",ucs:[],op:[],ip:[54],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A6ClienteEmail=n)},v2z:function(n){n!==undefined&&(gx.O.Z6ClienteEmail=n)},v2c:function(){gx.fn.setControlValue("CLIENTEEMAIL",gx.O.A6ClienteEmail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A6ClienteEmail=this.val())},val:function(){return gx.fn.getControlValue("CLIENTEEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(54,function(){gx.fn.setCtrlProperty("CLIENTEEMAIL","Link",gx.fn.getCtrlProperty("CLIENTEEMAIL","Enabled")?"":"mailto:"+this.A6ClienteEmail)});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:this.Valid_Clientedataentrada,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEDATAENTRADA",gxz:"Z15ClienteDataEntrada",gxold:"O15ClienteDataEntrada",gxvar:"A15ClienteDataEntrada",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[59],ip:[59],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A15ClienteDataEntrada=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z15ClienteDataEntrada=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("CLIENTEDATAENTRADA",gx.O.A15ClienteDataEntrada,0)},c2v:function(){this.val()!==undefined&&(gx.O.A15ClienteDataEntrada=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("CLIENTEDATAENTRADA")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"BTN_ENTER",grid:0,evt:"e13011_client",std:"ENTER"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"BTN_CANCEL",grid:0,evt:"e14011_client"};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"BTN_DELETE",grid:0,evt:"e20011_client",std:"DELETE"};this.A1ClienteID=0;this.Z1ClienteID=0;this.O1ClienteID=0;this.A3ClienteNome="";this.Z3ClienteNome="";this.O3ClienteNome="";this.A4ClienteEndereco="";this.Z4ClienteEndereco="";this.O4ClienteEndereco="";this.A5ClienteTelefone="";this.Z5ClienteTelefone="";this.O5ClienteTelefone="";this.A6ClienteEmail="";this.Z6ClienteEmail="";this.O6ClienteEmail="";this.A15ClienteDataEntrada=gx.date.nullDate();this.Z15ClienteDataEntrada=gx.date.nullDate();this.O15ClienteDataEntrada=gx.date.nullDate();this.AV13Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7ClienteID=0;this.AV10WebSession={};this.A1ClienteID=0;this.Gx_BScreen=0;this.Gx_date=gx.date.nullDate();this.A3ClienteNome="";this.A4ClienteEndereco="";this.A5ClienteTelefone="";this.A6ClienteEmail="";this.A15ClienteDataEntrada=gx.date.nullDate();this.Gx_mode="";this.Events={e12012_client:["AFTER TRN",!0],e13011_client:["ENTER",!0],e14011_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7ClienteID",fld:"vCLIENTEID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7ClienteID",fld:"vCLIENTEID",pic:"ZZZZZ9",hsh:!0},{av:"A1ClienteID",fld:"CLIENTEID",pic:"ZZZZZ9"},{av:"A15ClienteDataEntrada",fld:"CLIENTEDATAENTRADA",pic:""}],[]];this.EvtParms.START=[[{av:"AV13Pgmname",fld:"vPGMNAME",pic:""}],[{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_CLIENTEID=[[],[]];this.EvtParms.VALID_CLIENTENOME=[[{av:"A3ClienteNome",fld:"CLIENTENOME",pic:""}],[{av:"A3ClienteNome",fld:"CLIENTENOME",pic:""}]];this.EvtParms.VALID_CLIENTETELEFONE=[[{av:"A5ClienteTelefone",fld:"CLIENTETELEFONE",pic:""}],[]];this.EvtParms.VALID_CLIENTEEMAIL=[[{av:"A6ClienteEmail",fld:"CLIENTEEMAIL",pic:""}],[]];this.EvtParms.VALID_CLIENTEDATAENTRADA=[[{av:"A15ClienteDataEntrada",fld:"CLIENTEDATAENTRADA",pic:""}],[{av:"A15ClienteDataEntrada",fld:"CLIENTEDATAENTRADA",pic:""}]];this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7ClienteID","vCLIENTEID",0,"int",6,0);this.setVCMap("Gx_date","vTODAY",0,"date",8,0);this.setVCMap("Gx_BScreen","vGXBSCREEN",0,"int",1,0);this.setVCMap("AV13Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.clientes)})