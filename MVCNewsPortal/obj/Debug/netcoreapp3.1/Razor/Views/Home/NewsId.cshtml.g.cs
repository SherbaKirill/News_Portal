#pragma checksum "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\Home\NewsId.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6083acbd36b74987191f5ff2f0a44fef4f670b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_NewsId), @"mvc.1.0.view", @"/Views/Home/NewsId.cshtml")]
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
#line 1 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\_ViewImports.cshtml"
using MVCNewsPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\_ViewImports.cshtml"
using MVCNewsPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6083acbd36b74987191f5ff2f0a44fef4f670b5", @"/Views/Home/NewsId.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e9197435e358a3a77fb533027db923590e27b82", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_NewsId : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"text-center\">\r\n    <h1>");
#nullable restore
#line 2 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\Home\NewsId.cshtml"
   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <img class=\"img-thumbnail\"");
            BeginWriteAttribute("src", " src=\"", 83, "\"", 99, 1);
#nullable restore
#line 3 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\Home\NewsId.cshtml"
WriteAttributeValue("", 89, Model.Img, 89, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 100, "\"", 117, 1);
#nullable restore
#line 3 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\Home\NewsId.cshtml"
WriteAttributeValue("", 106, Model.Name, 106, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    < <p>");
#nullable restore
#line 4 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\Home\NewsId.cshtml"
    Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591