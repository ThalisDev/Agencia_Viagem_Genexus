gx.evt.autoSkip=!1;gx.define("aeroporto",!1,function(){this.ServerClass="aeroporto";this.PackageName="GeneXus.Programs";this.ServerFullClass="aeroporto.aspx";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV7AeroportoId=gx.fn.getIntegerValue("vAEROPORTOID",".");this.AV11Insert_paisID=gx.fn.getIntegerValue("vINSERT_PAISID",".");this.AV12Insert_paisCidadeID=gx.fn.getIntegerValue("vINSERT_PAISCIDADEID",".");this.AV14Pgmname=gx.fn.getControlValue("vPGMNAME");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Aeroportoid=function(){return this.validCliEvt("Valid_Aeroportoid",0,function(){try{var n=gx.util.balloon.getNew("AEROPORTOID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Paisid=function(){return this.validSrvEvt("Valid_Paisid",0).then(function(n){return n}.closure(this))};this.Valid_Paiscidadeid=function(){return this.validSrvEvt("Valid_Paiscidadeid",0).then(function(n){return n}.closure(this))};this.e12052_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e13056_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e14056_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70];this.GXLastCtrlId=70;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TITLECONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLE",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"FORMCONTAINER",grid:0};n[16]={id:16,fld:"",grid:0};n[17]={id:17,fld:"TOOLBARCELL",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"BTN_FIRST",grid:0,evt:"e15056_client",std:"FIRST"};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"BTN_PREVIOUS",grid:0,evt:"e16056_client",std:"PREVIOUS"};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"BTN_NEXT",grid:0,evt:"e17056_client",std:"NEXT"};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTN_LAST",grid:0,evt:"e18056_client",std:"LAST"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTN_SELECT",grid:0,evt:"e19056_client",std:"SELECT"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Aeroportoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AEROPORTOID",gxz:"Z17AeroportoId",gxold:"O17AeroportoId",gxvar:"A17AeroportoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A17AeroportoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z17AeroportoId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("AEROPORTOID",gx.O.A17AeroportoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A17AeroportoId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("AEROPORTOID",".")},nac:gx.falseFn};this.declareDomainHdlr(34,function(){});n[35]={id:35,fld:"",grid:0};n[36]={id:36,fld:"",grid:0};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AEROPORTONOME",gxz:"Z18AeroportoNome",gxold:"O18AeroportoNome",gxvar:"A18AeroportoNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A18AeroportoNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z18AeroportoNome=n)},v2c:function(){gx.fn.setControlValue("AEROPORTONOME",gx.O.A18AeroportoNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A18AeroportoNome=this.val())},val:function(){return gx.fn.getControlValue("AEROPORTONOME")},nac:gx.falseFn};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[44]={id:44,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Paisid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISID",gxz:"Z8paisID",gxold:"O8paisID",gxvar:"A8paisID",ucs:[],op:[49],ip:[49,44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A8paisID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z8paisID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PAISID",gx.O.A8paisID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A8paisID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PAISID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV11Insert_paisID)}};this.declareDomainHdlr(44,function(){});n[45]={id:45,fld:"",grid:0};n[46]={id:46,fld:"",grid:0};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISNOME",gxz:"Z9Paisnome",gxold:"O9Paisnome",gxvar:"A9Paisnome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A9Paisnome=n)},v2z:function(n){n!==undefined&&(gx.O.Z9Paisnome=n)},v2c:function(){gx.fn.setControlValue("PAISNOME",gx.O.A9Paisnome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A9Paisnome=this.val())},val:function(){return gx.fn.getControlValue("PAISNOME")},nac:gx.falseFn};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"",grid:0};n[53]={id:53,fld:"",grid:0};n[54]={id:54,lvl:0,type:"int",len:6,dec:0,sign:!1,pic:"ZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Valid_Paiscidadeid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISCIDADEID",gxz:"Z13paisCidadeID",gxold:"O13paisCidadeID",gxvar:"A13paisCidadeID",ucs:[],op:[59],ip:[59,54,44],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A13paisCidadeID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z13paisCidadeID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PAISCIDADEID",gx.O.A13paisCidadeID,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A13paisCidadeID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PAISCIDADEID",".")},nac:function(){return gx.text.compare(this.Gx_mode,"INS")==0&&!(0==this.AV12Insert_paisCidadeID)}};this.declareDomainHdlr(54,function(){});n[55]={id:55,fld:"",grid:0};n[56]={id:56,fld:"",grid:0};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISCIDADENOME",gxz:"Z14paisCidadeNome",gxold:"O14paisCidadeNome",gxvar:"A14paisCidadeNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A14paisCidadeNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z14paisCidadeNome=n)},v2c:function(){gx.fn.setControlValue("PAISCIDADENOME",gx.O.A14paisCidadeNome,0)},c2v:function(){this.val()!==undefined&&(gx.O.A14paisCidadeNome=this.val())},val:function(){return gx.fn.getControlValue("PAISCIDADENOME")},nac:gx.falseFn};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"BTN_ENTER",grid:0,evt:"e13056_client",std:"ENTER"};n[65]={id:65,fld:"",grid:0};n[66]={id:66,fld:"BTN_CANCEL",grid:0,evt:"e14056_client"};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"BTN_DELETE",grid:0,evt:"e20056_client",std:"DELETE"};n[69]={id:69,fld:"PROMPT_8",grid:6};n[70]={id:70,fld:"PROMPT_13",grid:6};this.A17AeroportoId=0;this.Z17AeroportoId=0;this.O17AeroportoId=0;this.A18AeroportoNome="";this.Z18AeroportoNome="";this.O18AeroportoNome="";this.A8paisID=0;this.Z8paisID=0;this.O8paisID=0;this.A9Paisnome="";this.Z9Paisnome="";this.O9Paisnome="";this.A13paisCidadeID=0;this.Z13paisCidadeID=0;this.O13paisCidadeID=0;this.A14paisCidadeNome="";this.Z14paisCidadeNome="";this.O14paisCidadeNome="";this.AV14Pgmname="";this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV11Insert_paisID=0;this.AV12Insert_paisCidadeID=0;this.AV15GXV1=0;this.AV13TrnContextAtt={AttributeName:"",AttributeValue:""};this.AV7AeroportoId=0;this.AV10WebSession={};this.A17AeroportoId=0;this.A8paisID=0;this.A13paisCidadeID=0;this.A18AeroportoNome="";this.A9Paisnome="";this.A14paisCidadeNome="";this.Gx_mode="";this.Events={e12052_client:["AFTER TRN",!0],e13056_client:["ENTER",!0],e14056_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV7AeroportoId",fld:"vAEROPORTOID",pic:"ZZZZZ9",hsh:!0}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV7AeroportoId",fld:"vAEROPORTOID",pic:"ZZZZZ9",hsh:!0},{av:"A17AeroportoId",fld:"AEROPORTOID",pic:"ZZZZZ9"}],[]];this.EvtParms.START=[[{av:"AV14Pgmname",fld:"vPGMNAME",pic:""},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0}],[{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0},{av:"AV11Insert_paisID",fld:"vINSERT_PAISID",pic:"ZZZZZ9"},{av:"AV12Insert_paisCidadeID",fld:"vINSERT_PAISCIDADEID",pic:"ZZZZZ9"},{av:"AV15GXV1",fld:"vGXV1",pic:"99999999"},{av:"AV13TrnContextAtt",fld:"vTRNCONTEXTATT",pic:""}]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0},{av:"AV9TrnContext",fld:"vTRNCONTEXT",pic:"",hsh:!0}],[]];this.EvtParms.VALID_AEROPORTOID=[[],[]];this.EvtParms.VALID_PAISID=[[{av:"A8paisID",fld:"PAISID",pic:"ZZZZZ9"},{av:"A9Paisnome",fld:"PAISNOME",pic:""}],[{av:"A9Paisnome",fld:"PAISNOME",pic:""}]];this.EvtParms.VALID_PAISCIDADEID=[[{av:"A8paisID",fld:"PAISID",pic:"ZZZZZ9"},{av:"A13paisCidadeID",fld:"PAISCIDADEID",pic:"ZZZZZ9"},{av:"A14paisCidadeNome",fld:"PAISCIDADENOME",pic:""}],[{av:"A14paisCidadeNome",fld:"PAISCIDADENOME",pic:""}]];this.setPrompt("PROMPT_8",[44]);this.setPrompt("PROMPT_13",[54]);this.EnterCtrl=["BTN_ENTER"];this.setVCMap("AV7AeroportoId","vAEROPORTOID",0,"int",6,0);this.setVCMap("AV11Insert_paisID","vINSERT_PAISID",0,"int",6,0);this.setVCMap("AV12Insert_paisCidadeID","vINSERT_PAISCIDADEID",0,"int",6,0);this.setVCMap("AV14Pgmname","vPGMNAME",0,"char",129,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"TransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.aeroporto)})