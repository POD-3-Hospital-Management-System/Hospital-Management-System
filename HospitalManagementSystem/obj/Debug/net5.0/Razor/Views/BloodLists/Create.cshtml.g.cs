#pragma checksum "C:\Users\2101601\source\repos\HospitalManagementSystem\HospitalManagementSystem\Views\BloodLists\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0e868acb0c750387a4a9b8be60fa6cb18163b6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BloodLists_Create), @"mvc.1.0.view", @"/Views/BloodLists/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0e868acb0c750387a4a9b8be60fa6cb18163b6d", @"/Views/BloodLists/Create.cshtml")]
    public class Views_BloodLists_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HospitalManagementSystem.Models.BloodList>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\2101601\source\repos\HospitalManagementSystem\HospitalManagementSystem\Views\BloodLists\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>BloodList</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""BloodGroup"" class=""control-label""></label>
                <input asp-for=""BloodGroup"" class=""form-control"" />
                <span asp-validation-for=""BloodGroup"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""BloodAvilability"" class=""control-label""></label>
                <input asp-for=""BloodAvilability"" class=""form-control"" />
                <span asp-validation-for=""BloodAvilability"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List");
            WriteLiteral("</a>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\2101601\source\repos\HospitalManagementSystem\HospitalManagementSystem\Views\BloodLists\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HospitalManagementSystem.Models.BloodList> Html { get; private set; }
    }
}
#pragma warning restore 1591