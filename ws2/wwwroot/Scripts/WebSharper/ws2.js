(function()
{
 "use strict";
 var Global,ws2,Clarity,ClarityButtonType,ClaritySelectVar,ClarityInputVar,ClarityCheckboxItem,ClarityCheckboxVar,ClarityButtonSpec,ButtonSize,ClarityDatePickerVar,DatePickerType,DatePickerViewManager,SC$1,Client,SC$2,ws2_Templates,console,WebSharper,UI,Var$1,Doc,List,AttrProxy,AttrModule,MatchFailureException,Utils,Seq,Strings,View,IntelliFactory,Runtime,Submitter,Remoting,AjaxRemotingProvider,Concurrency,Templating,Runtime$1,Server,ProviderBuilder,Handler,TemplateInstance,Enumerator,ListModel,Client$1,Templates,DomUtility;
 Global=self;
 ws2=Global.ws2=Global.ws2||{};
 Clarity=ws2.Clarity=ws2.Clarity||{};
 ClarityButtonType=Clarity.ClarityButtonType=Clarity.ClarityButtonType||{};
 ClaritySelectVar=Clarity.ClaritySelectVar=Clarity.ClaritySelectVar||{};
 ClarityInputVar=Clarity.ClarityInputVar=Clarity.ClarityInputVar||{};
 ClarityCheckboxItem=Clarity.ClarityCheckboxItem=Clarity.ClarityCheckboxItem||{};
 ClarityCheckboxVar=Clarity.ClarityCheckboxVar=Clarity.ClarityCheckboxVar||{};
 ClarityButtonSpec=Clarity.ClarityButtonSpec=Clarity.ClarityButtonSpec||{};
 ButtonSize=Clarity.ButtonSize=Clarity.ButtonSize||{};
 ClarityDatePickerVar=Clarity.ClarityDatePickerVar=Clarity.ClarityDatePickerVar||{};
 DatePickerType=Clarity.DatePickerType=Clarity.DatePickerType||{};
 DatePickerViewManager=Clarity.DatePickerViewManager=Clarity.DatePickerViewManager||{};
 SC$1=Global.StartupCode$ws2$Clarity=Global.StartupCode$ws2$Clarity||{};
 Client=ws2.Client=ws2.Client||{};
 SC$2=Global.StartupCode$ws2$Client=Global.StartupCode$ws2$Client||{};
 ws2_Templates=Global.ws2_Templates=Global.ws2_Templates||{};
 console=Global.console;
 WebSharper=Global.WebSharper;
 UI=WebSharper&&WebSharper.UI;
 Var$1=UI&&UI.Var$1;
 Doc=UI&&UI.Doc;
 List=WebSharper&&WebSharper.List;
 AttrProxy=UI&&UI.AttrProxy;
 AttrModule=UI&&UI.AttrModule;
 MatchFailureException=WebSharper&&WebSharper.MatchFailureException;
 Utils=WebSharper&&WebSharper.Utils;
 Seq=WebSharper&&WebSharper.Seq;
 Strings=WebSharper&&WebSharper.Strings;
 View=UI&&UI.View;
 IntelliFactory=Global.IntelliFactory;
 Runtime=IntelliFactory&&IntelliFactory.Runtime;
 Submitter=UI&&UI.Submitter;
 Remoting=WebSharper&&WebSharper.Remoting;
 AjaxRemotingProvider=Remoting&&Remoting.AjaxRemotingProvider;
 Concurrency=WebSharper&&WebSharper.Concurrency;
 Templating=UI&&UI.Templating;
 Runtime$1=Templating&&Templating.Runtime;
 Server=Runtime$1&&Runtime$1.Server;
 ProviderBuilder=Server&&Server.ProviderBuilder;
 Handler=Server&&Server.Handler;
 TemplateInstance=Server&&Server.TemplateInstance;
 Enumerator=WebSharper&&WebSharper.Enumerator;
 ListModel=UI&&UI.ListModel;
 Client$1=UI&&UI.Client;
 Templates=Client$1&&Client$1.Templates;
 DomUtility=UI&&UI.DomUtility;
 ClarityButtonType.Tertiary={
  $:11
 };
 ClarityButtonType.Secondary={
  $:10
 };
 ClarityButtonType.Flat={
  $:9
 };
 ClarityButtonType.DangerOutline={
  $:8
 };
 ClarityButtonType.WarningOutline={
  $:7
 };
 ClarityButtonType.Info={
  $:6
 };
 ClarityButtonType.SuccessOutline={
  $:5
 };
 ClarityButtonType.Regular={
  $:4
 };
 ClarityButtonType.Danger={
  $:3
 };
 ClarityButtonType.Warning={
  $:2
 };
 ClarityButtonType.Success={
  $:1
 };
 ClarityButtonType.Primary={
  $:0
 };
 ClaritySelectVar.New=function(Selection,ErrorState,Values,SubText,Id,Label)
 {
  return{
   Selection:Selection,
   ErrorState:ErrorState,
   Values:Values,
   SubText:SubText,
   Id:Id,
   Label:Label
  };
 };
 ClarityInputVar.New=function(Value,Label,ErrorState,SubText,Placeholder,Id)
 {
  return{
   Value:Value,
   Label:Label,
   ErrorState:ErrorState,
   SubText:SubText,
   Placeholder:Placeholder,
   Id:Id
  };
 };
 ClarityCheckboxItem.New=function(Option,Checked)
 {
  return{
   Option:Option,
   Checked:Checked
  };
 };
 ClarityCheckboxVar.New=function(Id,ErrorState,SubText,Options,Label)
 {
  return{
   Id:Id,
   ErrorState:ErrorState,
   SubText:SubText,
   Options:Options,
   Label:Label
  };
 };
 ClarityButtonSpec.New=function(Type,Disabled,Size,Text)
 {
  return{
   Type:Type,
   Disabled:Disabled,
   Size:Size,
   Text:Text
  };
 };
 ButtonSize.Normal={
  $:1
 };
 ButtonSize.Small={
  $:0
 };
 ClarityDatePickerVar.New=function(TheDate)
 {
  return{
   TheDate:TheDate
  };
 };
 DatePickerType.YearPicker={
  $:3
 };
 DatePickerType.MonthPicker={
  $:2
 };
 DatePickerType.DayPicker={
  $:1
 };
 DatePickerType.Invisible={
  $:0
 };
 DatePickerViewManager.New=function(CurrentView)
 {
  return{
   CurrentView:CurrentView
  };
 };
 Clarity.ClarityDatePicker=function(cdp)
 {
  var cal,ciw;
  function clickHandler(a,b)
  {
   console.log("clicked");
   Var$1.Lens(cal,function($1)
   {
    return $1.CurrentView;
   },function($1,$2)
   {
    return(function()
    {
     return DatePickerViewManager.New;
    }($1))($2);
   }).Set(DatePickerType.DayPicker);
   return null;
  }
  function blurHandler(a,b)
  {
   console.log("clicked");
   Var$1.Lens(cal,function($1)
   {
    return $1.CurrentView;
   },function($1,$2)
   {
    return(function()
    {
     return DatePickerViewManager.New;
    }($1))($2);
   }).Set(DatePickerType.Invisible);
   return null;
  }
  function dayPicker()
  {
   var dayPickerDiv;
   dayPickerDiv=Doc.Element("clr-daypicker",List.ofArray([AttrProxy.Create("class","daypicker")]),List.ofArray([Doc.Element("div",[AttrProxy.Create("class","calendar-header")],[Doc.Element("div",[AttrProxy.Create("class","calendar-pickers")],[Doc.Element("button",[AttrProxy.Create("class","calendar-btn monthpicker-trigger"),AttrProxy.Create("type","button")],[Doc.TextNode("Mar")]),Doc.Element("button",[AttrProxy.Create("class","calendar-btn yearpicker-trigger"),AttrProxy.Create("type","button")],[Doc.TextNode("2019")])]),Doc.Element("div",[AttrProxy.Create("class","calendar-switchers")],[Doc.Element("button",[AttrProxy.Create("class","calendar-btn switcher"),AttrProxy.Create("type","button")],[Doc.Element("clr-icon",List.ofArray([AttrProxy.Create("dir","left"),AttrProxy.Create("shape","angle")]),List.T.Empty)]),Doc.Element("button",[AttrProxy.Create("class","calendar-btn switcher"),AttrProxy.Create("type","button")],[Doc.Element("clr-icon",List.ofArray([AttrProxy.Create("shape","event")]),List.T.Empty)]),Doc.Element("button",[AttrProxy.Create("class","calendar-btn switcher"),AttrProxy.Create("type","button")],[Doc.Element("clr-icon",List.ofArray([AttrProxy.Create("dir","right"),AttrProxy.Create("shape","angle")]),List.T.Empty)])])]),Doc.Element("clr-calendar",List.T.Empty,List.ofArray([Doc.Element("table",[AttrProxy.Create("class","calendar-table weekdays")],[Doc.Element("tbody",[],[Doc.Element("tr",[AttrProxy.Create("class","calendar-row")],[Doc.Element("td",[AttrProxy.Create("class","calendar-cell")],[Doc.TextNode("S")]),Doc.Element("td",[AttrProxy.Create("class","calendar-cell")],[Doc.TextNode("M")]),Doc.Element("td",[AttrProxy.Create("class","calendar-cell")],[Doc.TextNode("T")]),Doc.Element("td",[AttrProxy.Create("class","calendar-cell")],[Doc.TextNode("W")]),Doc.Element("td",[AttrProxy.Create("class","calendar-cell")],[Doc.TextNode("T")]),Doc.Element("td",[AttrProxy.Create("class","calendar-cell")],[Doc.TextNode("F")]),Doc.Element("td",[AttrProxy.Create("class","calendar-cell")],[Doc.TextNode("S")])])])])]))]));
   return List.ofArray([Doc.Element("clr-datepicker-view-manager",List.ofArray([AttrProxy.Create("class","datepicker"),AttrProxy.Create("tabindex","0")]),List.ofArray([dayPickerDiv]))]);
  }
  AttrModule.DynamicPred("clrDate",Var$1.Create$1(true).get_View(),Var$1.Create$1("").get_View());
  cal=Var$1.Create$1(DatePickerViewManager.New(DatePickerType.Invisible));
  ciw=Clarity.ClarityInputWrapper([Clarity.ClarityInputGroup([Doc.Element("input",[AttrProxy.Create("type","text")],[]),Doc.Element("button",[AttrProxy.Create("type","button"),AttrProxy.Create("class","clr-input-group-icon-action"),AttrModule.Handler("click",function($1)
  {
   return function($2)
   {
    return clickHandler($1,$2);
   };
  }),AttrModule.Handler("blur",function($1)
  {
   return function($2)
   {
    return blurHandler($1,$2);
   };
  })],[Doc.Element("clr-icon",List.ofArray([AttrProxy.Create("shape","calendar")]),List.T.Empty)]),Doc.BindView(function(v)
  {
   var $1,m;
   m=v.CurrentView;
   if(m.$==0)
    $1=List.ofArray([Doc.Verbatim("<!---->")]);
   else
    if(m.$==1)
     $1=dayPicker();
    else
     throw new MatchFailureException.New("Clarity.fs",273,18);
   return Doc.Concat($1);
  },cal.get_View())])]);
  return Clarity.ClarityControlContainer(Var$1.Create$1(false).get_View(),[ciw]);
 };
 Clarity.ClarityDateContainer=function(children)
 {
  return Doc.Element("clr-date-container",List.ofArray([AttrProxy.Create("class","clr-form-control")]),children);
 };
 Clarity.ClarityInputGroup=function(children)
 {
  return Doc.Element("div",[AttrProxy.Create("class","clr-input-group")],children);
 };
 Clarity.ClaritySelect=function(attrs,csv)
 {
  var Id,wdoc,d2;
  Id=csv.Get().Id;
  wdoc=Clarity.ClaritySelectWrapper([Doc.Select(new List.T({
   $:1,
   $0:AttrProxy.Create("id",Id),
   $1:new List.T({
    $:1,
    $0:AttrProxy.Create("class","clr-select"),
    $1:attrs
   })
  }),function(value)
  {
   return typeof value=="string"?value:(function($1)
   {
    return function($2)
    {
     return $1(Utils.prettyPrint($2));
    };
   }(Global.id))(value);
  },csv.Get().Values,Var$1.Lens(csv,function($1)
  {
   return $1.Selection;
  },function($1,$2)
  {
   return ClaritySelectVar.New($2,$1.ErrorState,$1.Values,$1.SubText,$1.Id,$1.Label);
  })),Doc.Element("clr-icon",List.ofArray([AttrProxy.Create("class","clr-validate-icon"),AttrProxy.Create("shape","exclamation-circle")]),List.T.Empty)]);
  d2=Clarity.ClarityControlContainer(Var$1.Lens(csv,function($1)
  {
   return $1.ErrorState;
  },function($1,$2)
  {
   return ClaritySelectVar.New($1.Selection,$2,$1.Values,$1.SubText,$1.Id,$1.Label);
  }).get_View(),[wdoc,Doc.Element("span",[AttrProxy.Create("class","clr-subtext")],[Doc.TextView(Var$1.Lens(csv,function($1)
  {
   return $1.SubText;
  },function($1,$2)
  {
   return ClaritySelectVar.New($1.Selection,$1.ErrorState,$1.Values,$2,$1.Id,$1.Label);
  }).get_View())])]);
  return Clarity.ClarityFormControl([Clarity.ClarityControlLabel([AttrProxy.Create("for",Id)],csv.Get().Label),d2]);
 };
 Clarity.ClarityPassword=function(attrs,civ)
 {
  var Id,wdoc,d2;
  Id=civ.Get().Id;
  wdoc=Clarity.ClarityInputWrapper([Doc.PasswordBox(new List.T({
   $:1,
   $0:AttrProxy.Create("placeholder",civ.Get().Placeholder),
   $1:new List.T({
    $:1,
    $0:AttrProxy.Create("id",Id),
    $1:new List.T({
     $:1,
     $0:AttrProxy.Create("type","text"),
     $1:new List.T({
      $:1,
      $0:AttrProxy.Create("class","clr-input"),
      $1:attrs
     })
    })
   })
  }),Var$1.Lens(civ,function($1)
  {
   return $1.Value;
  },function($1,$2)
  {
   return ClarityInputVar.New($2,$1.Label,$1.ErrorState,$1.SubText,$1.Placeholder,$1.Id);
  })),Doc.Element("clr-icon",List.ofArray([AttrProxy.Create("class","clr-validate-icon"),AttrProxy.Create("shape","exclamation-circle")]),List.T.Empty)]);
  d2=Clarity.ClarityControlContainer(Var$1.Lens(civ,function($1)
  {
   return $1.ErrorState;
  },function($1,$2)
  {
   return ClarityInputVar.New($1.Value,$1.Label,$2,$1.SubText,$1.Placeholder,$1.Id);
  }).get_View(),[wdoc,Doc.Element("span",[AttrProxy.Create("class","clr-subtext")],[Doc.TextView(Var$1.Lens(civ,function($1)
  {
   return $1.SubText;
  },function($1,$2)
  {
   return ClarityInputVar.New($1.Value,$1.Label,$1.ErrorState,$2,$1.Placeholder,$1.Id);
  }).get_View())])]);
  return Clarity.ClarityFormControl([Clarity.ClarityControlLabel([AttrProxy.Create("for",Id)],civ.Get().Label),d2]);
 };
 Clarity.ClarityInput=function(attrs,civ)
 {
  var Id,wdoc,d2;
  Id=civ.Get().Id;
  wdoc=Clarity.ClarityInputWrapper([Doc.Input(new List.T({
   $:1,
   $0:AttrProxy.Create("placeholder",civ.Get().Placeholder),
   $1:new List.T({
    $:1,
    $0:AttrProxy.Create("id",Id),
    $1:new List.T({
     $:1,
     $0:AttrProxy.Create("type","text"),
     $1:new List.T({
      $:1,
      $0:AttrProxy.Create("class","clr-input"),
      $1:attrs
     })
    })
   })
  }),Var$1.Lens(civ,function($1)
  {
   return $1.Value;
  },function($1,$2)
  {
   return ClarityInputVar.New($2,$1.Label,$1.ErrorState,$1.SubText,$1.Placeholder,$1.Id);
  })),Doc.Element("clr-icon",List.ofArray([AttrProxy.Create("class","clr-validate-icon"),AttrProxy.Create("shape","exclamation-circle")]),List.T.Empty)]);
  d2=Clarity.ClarityControlContainer(Var$1.Lens(civ,function($1)
  {
   return $1.ErrorState;
  },function($1,$2)
  {
   return ClarityInputVar.New($1.Value,$1.Label,$2,$1.SubText,$1.Placeholder,$1.Id);
  }).get_View(),[wdoc,Doc.Element("span",[AttrProxy.Create("class","clr-subtext")],[Doc.TextView(Var$1.Lens(civ,function($1)
  {
   return $1.SubText;
  },function($1,$2)
  {
   return ClarityInputVar.New($1.Value,$1.Label,$1.ErrorState,$2,$1.Placeholder,$1.Id);
  }).get_View())])]);
  return Clarity.ClarityFormControl([Clarity.ClarityControlLabel([AttrProxy.Create("for",Id)],civ.Get().Label),d2]);
 };
 Clarity.ClarityCheckbox=function(attrs,ccv)
 {
  var res,stw,d2;
  ccv.Get();
  res=Doc.BindView(Doc.Concat,ccv.Get().Options.MapLens(function(k,vp)
  {
   return Clarity.ClarityCheckboxWrapper([Doc.CheckBox([AttrProxy.Create("id",vp.Get().Option)],Var$1.Lens(vp,function($1)
   {
    return $1.Checked;
   },function($1,$2)
   {
    return ClarityCheckboxItem.New($1.Option,$2);
   })),Clarity.ClarityControlLabel([AttrProxy.Create("for",vp.Get().Option)],vp.Get().Option)]);
  }));
  stw=Clarity.ClaritySelectWrapper([Doc.Element("clr-icon",List.ofArray([AttrProxy.Create("class","clr-validate-icon"),AttrProxy.Create("shape","exclamation-circle")]),List.T.Empty),Doc.Element("span",[AttrProxy.Create("class","clr-subtext")],[Doc.TextView(Var$1.Lens(ccv,function($1)
  {
   return $1.SubText;
  },function($1,$2)
  {
   return ClarityCheckboxVar.New($1.Id,$1.ErrorState,$2,$1.Options,$1.Label);
  }).get_View())])]);
  d2=List.ofArray([Clarity.ClarityControlContainer(Var$1.Lens(ccv,function($1)
  {
   return $1.ErrorState;
  },function($1,$2)
  {
   return ClarityCheckboxVar.New($1.Id,$2,$1.SubText,$1.Options,$1.Label);
  }).get_View(),[res]),stw]);
  return Clarity.ClarityFormControl(new List.T({
   $:1,
   $0:Clarity.ClarityControlLabel([],ccv.Get().Label),
   $1:d2
  }));
 };
 Clarity.ClaritySubtextWrapper=function(children)
 {
  return Doc.Element("div",[AttrProxy.Create("class","clr-subtext-wrapper")],children);
 };
 Clarity.ClarityControlLabel=function(attrs,labelText)
 {
  return Doc.Element("label",Seq.append(attrs,[AttrProxy.Create("class","clr-control-label")]),[Doc.TextNode(labelText)]);
 };
 Clarity.ClarityControlContainer=function(showError,children)
 {
  return Doc.Element("div",[AttrProxy.Create("class","clr-control-container"),AttrModule.DynamicClassPred("clr-error",showError)],children);
 };
 Clarity.ClarityCheckboxWrapper=function(children)
 {
  return Doc.Element("div",[AttrProxy.Create("class","clr-checkbox-wrapper")],children);
 };
 Clarity.ClarityFormControl=function(children)
 {
  return Doc.Element("div",[AttrProxy.Create("class","clr-form-control")],children);
 };
 Clarity.ClaritySelectWrapper=function(children)
 {
  return Doc.Element("div",[AttrProxy.Create("class","clr-select-wrapper")],children);
 };
 Clarity.ClarityInputWrapper=function(children)
 {
  return Doc.Element("div",[AttrProxy.Create("class","clr-input-wrapper")],children);
 };
 Clarity.ClarityButton=function(spec,callback)
 {
  var classes,t,vpred,vstr,vsize;
  classes=Strings.concat(" ",["btn",(t=spec.Get().Type,t.$==1?"btn-success":t.$==3?"btn-danger":t.$==2?"btn-warning":t.$==4?"btn-outline":t.$==5?"btn-success-outline":t.$==6?"btn-info-outline":t.$==7?"btn-warning-outline":t.$==8?"btn-danger-outline":t.$==9?"btn-link":t.$==10?"":t.$==11?"btn-link":"btn-primary")]);
  vpred=View.Map(function($1)
  {
   return $1.Disabled;
  },spec.get_View());
  vstr=Var$1.Create$1("").get_View();
  vsize=View.Map(function(p)
  {
   return p.$!=1;
  },View.Map(function($1)
  {
   return $1.Size;
  },spec.get_View()));
  return Doc.Button(spec.Get().Text,[AttrProxy.Create("class",classes),((Clarity.AttrDisabledDyn())(vpred))(vstr),(Clarity.ButtonSizePred())(vsize)],callback);
 };
 Clarity.ButtonSizePred=function()
 {
  SC$1.$cctor();
  return SC$1.ButtonSizePred;
 };
 Clarity.AttrDisabledDyn=function()
 {
  SC$1.$cctor();
  return SC$1.AttrDisabledDyn;
 };
 SC$1.$cctor=function()
 {
  SC$1.$cctor=Global.ignore;
  SC$1.AttrDisabledDyn=(Runtime.Curried3(AttrModule.DynamicPred))("disabled");
  SC$1.ButtonSizePred=function(i)
  {
   return AttrModule.DynamicClassPred("btn-sm",i);
  };
 };
 Client.Main=function()
 {
  var varText,d,rvInput,submit,vReversed,b,_this,p,i;
  varText=Var$1.Create$1("initial value");
  d=Doc.BindView(Doc.Concat,View.MapSeqCached(function(i$1)
  {
   return Doc.Element("li",[],[Doc.TextNode(Global.String(i$1))]);
  },Client.its().get_View()));
  rvInput=Var$1.Create$1("");
  submit=Submitter.CreateOption(rvInput.get_View());
  vReversed=View.MapAsync(function(a)
  {
   var b$1;
   return a!=null&&a.$==1?(new AjaxRemotingProvider.New()).Async("ws2:ws2.Server.DoSomething:-1840423385",[a.$0]):(b$1=null,Concurrency.Delay(function()
   {
    return Concurrency.Return("");
   }));
  },submit.view);
  return Doc.Element("div",[],[Doc.Element("div",[AttrProxy.Create("class","login-wrapper")],[Doc.Element("form",[AttrProxy.Create("class","login")],[Doc.Element("section",[AttrProxy.Create("class","title")],[Doc.Element("h3",[AttrProxy.Create("class","welcome")],[Doc.TextNode("Welcome to")]),Doc.TextNode("Company Product Name"),Doc.Element("h5",[AttrProxy.Create("class","hint")],[Doc.TextNode("Use your Company ID to sign in or create one now")])]),Doc.Element("div",[AttrProxy.Create("class","login-group")],[Doc.Element("div",[AttrProxy.Create("class","clr-control-container clr-form-control")],[Doc.Element("div",[AttrProxy.Create("class","clr-select-wrapper")],[Doc.Element("select",[],[Doc.Element("option",[AttrProxy.Create("value","local")],[Doc.TextNode("Local Users")]),Doc.Element("option",[AttrProxy.Create("value","admin")],[Doc.TextNode("Administrator")])])])]),Clarity.ClarityInput(List.T.Empty,Client.username()),Clarity.ClarityPassword(List.T.Empty,Client.password()),Doc.Element("div",[],[Doc.TextView(Client.sel().get_View()),Doc.TextView(Var$1.Lens(Client.username(),function($1)
  {
   return $1.Value;
  },function($1,$2)
  {
   return ClarityInputVar.New($2,$1.Label,$1.ErrorState,$1.SubText,$1.Placeholder,$1.Id);
  }).get_View()),Doc.TextView(varText.get_View())]),Clarity.ClaritySelect(List.T.Empty,Client.csvV()),Clarity.ClarityInput(List.T.Empty,Client.civV()),Clarity.ClarityCheckbox(List.T.Empty,Client.checks()),Doc.Element("div",[],[Doc.TextView(Client.csvSel())]),Clarity.ClarityButton(Client.but1(),function()
  {
   Var$1.Lens(Client.but1(),function($1)
   {
    return $1.Disabled;
   },function($1,$2)
   {
    return ClarityButtonSpec.New($1.Type,$2,$1.Size,$1.Text);
   }).Set(true);
  }),Clarity.ClarityDatePicker(Client.cdp())])])]),Doc.Input([],rvInput),Doc.Button("Send",[],function()
  {
   submit.Trigger();
  }),Doc.Button("Get",[],function()
  {
   Client.GetN();
  }),Doc.Element("hr",[],[]),Doc.Element("h4",[AttrProxy.Create("class","text-muted")],[Doc.TextNode("The server responded:")]),Doc.Element("div",[AttrProxy.Create("class","jumbotron")],[Doc.Element("h1",[],[Doc.TextView(vReversed)])]),Doc.Element("ul",[],[d]),(b=(_this=new ProviderBuilder.New$1(),(_this.h.push({
   $:0,
   $0:"content",
   $1:d
  }),_this)),(p=Handler.CompleteHoles(b.k,b.h,[]),(i=new TemplateInstance.New(p[1],ws2_Templates.t(p[0])),b.i=i,i))).get_Doc()]);
 };
 Client.GetN=function()
 {
  Client.GetNames(null,function(l)
  {
   Client.f(l);
  });
 };
 Client.f2=function(n)
 {
  Client.its().Set(List.ofArray([n]));
 };
 Client.f=function(l)
 {
  var a;
  a=List.ofSeq(l);
  Client.its().Set(a);
 };
 Client.it=function(mytext)
 {
  return Doc.Element("li",[],[Doc.TextNode(mytext)]);
 };
 Client.GetNames=function(u,callback)
 {
  var b;
  Concurrency.Start((b=null,Concurrency.Delay(function()
  {
   return Concurrency.Bind((new AjaxRemotingProvider.New()).Async("ws2:ws2.Server.GetNames:-1913616411",[]),function(a)
   {
    callback(a);
    return Concurrency.Return(null);
   });
  })),null);
 };
 Client.v2=function()
 {
  SC$2.$cctor();
  return SC$2.v2;
 };
 Client.loginType=function()
 {
  SC$2.$cctor();
  return SC$2.loginType;
 };
 Client.sel2=function()
 {
  SC$2.$cctor();
  return SC$2.sel2;
 };
 Client.sel=function()
 {
  SC$2.$cctor();
  return SC$2.sel;
 };
 Client.its=function()
 {
  SC$2.$cctor();
  return SC$2.its;
 };
 Client.pv=function()
 {
  SC$2.$cctor();
  return SC$2.pv;
 };
 Client.cdp=function()
 {
  SC$2.$cctor();
  return SC$2.cdp;
 };
 Client.but1=function()
 {
  SC$2.$cctor();
  return SC$2.but1;
 };
 Client.observe2=function(v)
 {
  console.log(v);
 };
 Client.nnn=function()
 {
  SC$2.$cctor();
  return SC$2.nnn;
 };
 Client.item=function()
 {
  SC$2.$cctor();
  return SC$2.item;
 };
 Client.mmm=function()
 {
  SC$2.$cctor();
  return SC$2.mmm;
 };
 Client.checks=function()
 {
  SC$2.$cctor();
  return SC$2.checks;
 };
 Client.password=function()
 {
  SC$2.$cctor();
  return SC$2.password;
 };
 Client.username=function()
 {
  SC$2.$cctor();
  return SC$2.username;
 };
 Client.civV=function()
 {
  SC$2.$cctor();
  return SC$2.civV;
 };
 Client.civ=function()
 {
  SC$2.$cctor();
  return SC$2.civ;
 };
 Client.observe=function(v)
 {
  console.log(v);
  v==="6"?(Client.stv().Set("some new helper"),Client.selV().Set("4"),Client.showError().Set(true)):void 0;
 };
 Client.csvSel=function()
 {
  SC$2.$cctor();
  return SC$2.csvSel;
 };
 Client.showError=function()
 {
  SC$2.$cctor();
  return SC$2.showError;
 };
 Client.selV=function()
 {
  SC$2.$cctor();
  return SC$2.selV;
 };
 Client.stv=function()
 {
  SC$2.$cctor();
  return SC$2.stv;
 };
 Client.csvV=function()
 {
  SC$2.$cctor();
  return SC$2.csvV;
 };
 Client.csv=function()
 {
  SC$2.$cctor();
  return SC$2.csv;
 };
 Client.factory=function()
 {
  SC$2.$cctor();
  return SC$2.factory;
 };
 SC$2.$cctor=function()
 {
  var en;
  SC$2.$cctor=Global.ignore;
  SC$2.factory=(en=Enumerator.Get(Seq.initInfinite(Global.id)),function()
  {
   en.MoveNext();
   return en.Current();
  });
  SC$2.csv=ClaritySelectVar.New("4",false,List.ofArray(["4","5","6"]),"Helper Text","MySelect","This is my label");
  SC$2.csvV=Var$1.Create$1(Client.csv());
  SC$2.stv=Var$1.Lens(Client.csvV(),function(p)
  {
   return p.SubText;
  },function($1,$2)
  {
   return ClaritySelectVar.New($1.Selection,$1.ErrorState,$1.Values,$2,$1.Id,$1.Label);
  });
  SC$2.selV=Var$1.Lens(Client.csvV(),function(p)
  {
   return p.Selection;
  },function($1,$2)
  {
   return ClaritySelectVar.New($2,$1.ErrorState,$1.Values,$1.SubText,$1.Id,$1.Label);
  });
  SC$2.showError=Var$1.Lens(Client.csvV(),function(p)
  {
   return p.ErrorState;
  },function($1,$2)
  {
   return ClaritySelectVar.New($1.Selection,$2,$1.Values,$1.SubText,$1.Id,$1.Label);
  });
  SC$2.csvSel=View.Map(function(i)
  {
   return i.Selection;
  },Client.csvV().get_View());
  View.Sink(function(v)
  {
   Client.observe(v);
  },Client.csvSel());
  SC$2.civ=ClarityInputVar.New("","Some label",false,"Helper text","placeholder text","MyInput");
  SC$2.civV=Var$1.Create$1(Client.civ());
  SC$2.username=Var$1.Create$1(ClarityInputVar.New("","Username",false,"Please enter your username","username","IdUsername"));
  SC$2.password=Var$1.Create$1(ClarityInputVar.New("","Password",false,"Please enter your pasword","password","IdPassword"));
  SC$2.checks=Var$1.Create$1(ClarityCheckboxVar.New("IdCheck",false,"Choose some options",ListModel.FromSeq([ClarityCheckboxItem.New("Option 1",false),ClarityCheckboxItem.New("Option 2",false)]),"Checkboxes"));
  SC$2.mmm=Client.checks().Get().Options;
  SC$2.item=ClarityCheckboxItem.New("Option 1",false);
  SC$2.nnn=Client.mmm().Lens(Client.item());
  View.Sink(function(v)
  {
   Client.observe2(v);
  },Client.mmm().v);
  SC$2.but1=Var$1.Create$1(ClarityButtonSpec.New(ClarityButtonType.Danger,false,ButtonSize.Small,"Press Me!"));
  SC$2.cdp=Var$1.Create$1(ClarityDatePickerVar.New(""));
  SC$2.pv=View.Map(function($1)
  {
   return $1.Label;
  },Client.civV().get_View());
  SC$2.its=Var$1.Create$1(List.T.Empty);
  SC$2.sel=Var$1.Create$1("1");
  SC$2.sel2=Var$1.Create$1(1);
  SC$2.loginType=Var$1.Create$1("local");
  SC$2.v2=View.Map(function(i)
  {
   return(function($1)
   {
    return function($2)
    {
     return $1(Utils.prettyPrint($2));
    };
   }(Global.id))(i);
  },Client.sel2().get_View());
 };
 ws2_Templates.t=function(h)
 {
  return h?Templates.GetOrLoadTemplate("my-template",null,function()
  {
   return DomUtility.ParseHTMLIntoFakeRoot("<div>\r\n    <ul>\r\n        <li ws-replace=\"Content\"></li>\r\n    </ul>\r\n</div>");
  },h):Templates.PrepareTemplate("my-template",null,function()
  {
   return DomUtility.ParseHTMLIntoFakeRoot("<div>\r\n    <ul>\r\n        <li ws-replace=\"Content\"></li>\r\n    </ul>\r\n</div>");
  });
 };
}());

//# sourceMappingURL=ws2.map