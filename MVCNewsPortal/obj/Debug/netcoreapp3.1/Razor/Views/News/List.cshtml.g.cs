#pragma checksum "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\News\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "167e2f8881126fbbf0f821f87f54b2ccda54ab36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_List), @"mvc.1.0.view", @"/Views/News/List.cshtml")]
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
using MVCNewsPortal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"167e2f8881126fbbf0f821f87f54b2ccda54ab36", @"/Views/News/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17825fe4ad6da918757d5e6b034a650a67c82732", @"/Views/_ViewImports.cshtml")]
    public class Views_News_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MVCNewsPortal.Models.NewsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h2> ");
#nullable restore
#line 2 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\News\List.cshtml"
Write(Model.First().Category.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n<div class=\"row mt-4 mb-2\">\r\n");
#nullable restore
#line 4 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\News\List.cshtml"
      
        if (Model != null)
            foreach (var news in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-4\">\r\n                    <h2>");
#nullable restore
#line 9 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\News\List.cshtml"
                   Write(news.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                    <img class=\"img-thumbnail\"");
            BeginWriteAttribute("src", " src=\"", 352, "\"", 367, 1);
#nullable restore
#line 10 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\News\List.cshtml"
WriteAttributeValue("", 358, news.Img, 358, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 368, "\"", 384, 1);
#nullable restore
#line 10 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\News\List.cshtml"
WriteAttributeValue("", 374, news.Name, 374, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    <p>");
#nullable restore
#line 11 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\News\List.cshtml"
                  Write(news.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p><a class=\"btn-dark\"");
            BeginWriteAttribute("href", " href=\"", 478, "\"", 506, 2);
            WriteAttributeValue("", 485, "/News/NewsId/", 485, 13, true);
#nullable restore
#line 12 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\News\List.cshtml"
WriteAttributeValue("", 498, news.Id, 498, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Подробнее</a> </p>\r\n\r\n                </div>\r\n");
#nullable restore
#line 15 "C:\Users\sherb\Documents\GitHub\News_Portal\MVCNewsPortal\Views\News\List.cshtml"
            }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MVCNewsPortal.Models.NewsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591