#pragma checksum "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2105b179f55029e55a6870d916635b21c45d36bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_Delete), @"mvc.1.0.view", @"/Views/Client/Delete.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\_ViewImports.cshtml"
using InvoiceMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\_ViewImports.cshtml"
using InvoiceMVC.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2105b179f55029e55a6870d916635b21c45d36bf", @"/Views/Client/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4ed3b1eac43975ed5a23a9a6c7971d113f97aaf", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InvoiceMVC.ViewModels.ClientVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ClockPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "GedeeldeViewsClient/_ClientFieldsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "GedeeldeViewsClient/_BackToClientIndexView.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_BackToMainMenuPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h3>Verwijder klant \"");
#nullable restore
#line 4 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
                Write(Model.ClientFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"</h3>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2105b179f55029e55a6870d916635b21c45d36bf4760", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 5 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.KlokVM);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("for", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
Write(Html.HiddenFor(c => c.Client.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <fieldset disabled>\r\n        <legend style=\"font-style: italic\">Details:</legend>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 17 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
       Write(Html.LabelFor(c => c.Client.ActionCode, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 18 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
       Write(Html.EditorFor(c => c.Client.ActionCode, new { htmlAttributes = new { @class = "editor-for-JP" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 22 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
       Write(Html.LabelFor(c => c.ClientFullName, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 23 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
       Write(Html.EditorFor(c => c.ClientFullName, new { htmlAttributes = new { @class = "editor-for-JP" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 27 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
       Write(Html.LabelFor(c => c.Client.ClientNumber, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 28 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
       Write(Html.EditorFor(c => c.Client.ClientNumber, new { htmlAttributes = new { @class = "editor-for-JP" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 32 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
       Write(Html.LabelFor(c => c.NumberOfInvoices, htmlAttributes: new { @class = "label-for-JP" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 33 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
       Write(Html.EditorFor(c => c.NumberOfInvoices, new { htmlAttributes = new { @class = "editor-for-JP" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>

        <!-- Als de shared view niet direct onder een standaard View folder staat -->
        <!-- Bijvoorbeeld ""Client"" ""Invoice"" of ""Shared"" -->
        <!-- Gebruik dan onderstaande syntax, met of zonder .cshtml extensie  -->
        <!-- Opmerking: vergeet de subfolder ""GedeeldeViewsClient"" niet -->
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2105b179f55029e55a6870d916635b21c45d36bf10535", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 40 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("for", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </fieldset>\r\n");
            WriteLiteral("    <div>\r\n        <input type=\"submit\" value=\"Verwijder\" class=\"redJP\" />\r\n    </div>\r\n");
            WriteLiteral("    <br />\r\n    <br />\r\n    <!-- Maak een back to clienten-lijst knop-->\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2105b179f55029e55a6870d916635b21c45d36bf12460", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral(@"    <!-- Maak een back to menu knop, kan met of zonder .cshtml extensie-->
    <!-- Onderstaande partial wordt automatisch gezocht in de standard view folders: -->
    <!-- ""Client"", ""Invoice"", etc, en ""Shared"", dus geen foldernaam nodig hieronder-->
    <br />
    <br />
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2105b179f55029e55a6870d916635b21c45d36bf13897", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 59 "C:\Users\janpi\source\repos\@Invoice App\InvoiceApplication Current\InvoiceMVC\Views\Client\Delete.cshtml"


}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InvoiceMVC.ViewModels.ClientVM> Html { get; private set; }
    }
}
#pragma warning restore 1591