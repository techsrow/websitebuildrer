#pragma checksum "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5588f94b8805946e91b5f27201e382a71997ddff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customization_Index), @"mvc.1.0.view", @"/Views/Customization/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5588f94b8805946e91b5f27201e382a71997ddff", @"/Views/Customization/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Customization_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebsiteBuilder.Models.Customization>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 5 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml"
  
    ViewData["Title"] = "Index";

    Layout = "~/Views/Shared/_AdminLayout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Seo  for the Website</h2>




<table>
    <thead>
        <tr>
            <td>Theme Color</td>
            <td>Heading Color</td>
            <td>Sub heading Color</td>
            <td>Text Color</td>
            <td>Primary BgColor</td>
            <td>Secondry BgColor</td>
            <td></td>
            
            
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 33 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml"
         foreach (var theme in Model)
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 37 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml"
               Write(theme.ThemeColor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml"
               Write(theme.headingColor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 39 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml"
               Write(theme.SubheadingColor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml"
               Write(theme.TextColor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 41 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml"
               Write(theme.PrimaryBgColor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 42 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml"
               Write(theme.SecondryBgColor);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                \r\n            </tr>\r\n");
#nullable restore
#line 45 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Customization\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebsiteBuilder.Models.Customization>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
