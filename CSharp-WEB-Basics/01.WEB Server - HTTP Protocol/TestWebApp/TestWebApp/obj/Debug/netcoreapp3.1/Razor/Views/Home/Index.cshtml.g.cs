#pragma checksum "/Users/ivaylotonkovski/Documents/GitHub/CSharp-Web-Mai2021/CSharp-WEB-Basics/01.WEB Server - HTTP Protocol/TestWebApp/TestWebApp/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3da44b99534b945edc1ea00012e36a238753782c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "/Users/ivaylotonkovski/Documents/GitHub/CSharp-Web-Mai2021/CSharp-WEB-Basics/01.WEB Server - HTTP Protocol/TestWebApp/TestWebApp/Views/_ViewImports.cshtml"
using TestWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ivaylotonkovski/Documents/GitHub/CSharp-Web-Mai2021/CSharp-WEB-Basics/01.WEB Server - HTTP Protocol/TestWebApp/TestWebApp/Views/_ViewImports.cshtml"
using TestWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3da44b99534b945edc1ea00012e36a238753782c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28c7b43283102eee2c6cca4a5baa815ab66ce1e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>\n    <a href=\"/Home/English\">English</a>\n    <a href=\"/Home/Bulgarian\">Bulgarian</a>\n</h1>\n\n");
#nullable restore
#line 6 "/Users/ivaylotonkovski/Documents/GitHub/CSharp-Web-Mai2021/CSharp-WEB-Basics/01.WEB Server - HTTP Protocol/TestWebApp/TestWebApp/Views/Home/Index.cshtml"
 if (this.Context.Request.Cookies.ContainsKey("Language")
  && this.Context.Request.Cookies["Language"] == "bg")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>Страница на български</h2>\n");
#nullable restore
#line 10 "/Users/ivaylotonkovski/Documents/GitHub/CSharp-Web-Mai2021/CSharp-WEB-Basics/01.WEB Server - HTTP Protocol/TestWebApp/TestWebApp/Views/Home/Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>The web page is in English</h2>\n");
#nullable restore
#line 14 "/Users/ivaylotonkovski/Documents/GitHub/CSharp-Web-Mai2021/CSharp-WEB-Basics/01.WEB Server - HTTP Protocol/TestWebApp/TestWebApp/Views/Home/Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591