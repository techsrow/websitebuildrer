#pragma checksum "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Testimonial\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d595e5d37ff12c61aa2238d78e9b2d19f66d9bff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Testimonial_Index), @"mvc.1.0.view", @"/Views/Testimonial/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d595e5d37ff12c61aa2238d78e9b2d19f66d9bff", @"/Views/Testimonial/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Testimonial_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<WebsiteBuilder.Models.Testimonial>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 5 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Testimonial\Index.cshtml"
  
    ViewData["Title"] = "Index";

    Layout = "~/Views/Shared/_AdminLayout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Testimonial for the Website</h2>\r\n\r\n\r\n\r\n\r\n<table>\r\n   <thead>\r\n       <tr>\r\n           <td>Name</td>\r\n           <td>Photo</td>\r\n           <td></td>\r\n       </tr>\r\n   </thead>\r\n\r\n   <tbody>\r\n");
#nullable restore
#line 27 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Testimonial\Index.cshtml"
        foreach (var testimonial in Model)
       {


#line default
#line hidden
#nullable disable
            WriteLiteral("           <tr>\r\n               <td>");
#nullable restore
#line 31 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Testimonial\Index.cshtml"
              Write(testimonial.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n               <td><img");
            BeginWriteAttribute("src", " src=\"", 492, "\"", 516, 1);
#nullable restore
#line 32 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Testimonial\Index.cshtml"
WriteAttributeValue("", 498, testimonial.Photo, 498, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"60\" width=\"60\" style=\"border-radius:100%\" /></td>\r\n           </tr>\r\n");
#nullable restore
#line 34 "D:\Techsrow\WebsiteMaker\WebsiteBuilder\Views\Testimonial\Index.cshtml"
          
       }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n   </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<WebsiteBuilder.Models.Testimonial>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591