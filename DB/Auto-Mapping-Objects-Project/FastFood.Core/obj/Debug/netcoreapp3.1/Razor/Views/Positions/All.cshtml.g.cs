#pragma checksum "D:\Softuni\DB\Auto-Mapping-Objects-Project\FastFood.Core\Views\Positions\All.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "818a125a65ba0b0539c2562d2f719dfc45cb1b3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Positions_All), @"mvc.1.0.view", @"/Views/Positions/All.cshtml")]
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
#line 1 "D:\Softuni\DB\Auto-Mapping-Objects-Project\FastFood.Core\Views\_ViewImports.cshtml"
using FastFood.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"818a125a65ba0b0539c2562d2f719dfc45cb1b3f", @"/Views/Positions/All.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ed879bff0478396c899ea94a6589fe8b9c42e19", @"/Views/_ViewImports.cshtml")]
    public class Views_Positions_All : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<FastFood.Core.ViewModels.Positions.PositionsAllViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Softuni\DB\Auto-Mapping-Objects-Project\FastFood.Core\Views\Positions\All.cshtml"
  
    ViewData["Title"] = "All Positions";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 class=\"text-center\">");
#nullable restore
#line 6 "D:\Softuni\DB\Auto-Mapping-Objects-Project\FastFood.Core\Views\Positions\All.cshtml"
                   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<hr class=\"hr-2\" />\r\n<table class=\"table mx-auto\">\r\n    <thead>\r\n        <tr class=\"row\">\r\n            <th class=\"col-md-1\">#</th>\r\n            <th class=\"col-md-2\">Position</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 16 "D:\Softuni\DB\Auto-Mapping-Objects-Project\FastFood.Core\Views\Positions\All.cshtml"
         for (var i = 0; i < Model.Count(); i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr class=\"row\">\r\n                <th class=\"col-md-1\">");
#nullable restore
#line 19 "D:\Softuni\DB\Auto-Mapping-Objects-Project\FastFood.Core\Views\Positions\All.cshtml"
                                 Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td class=\"col-md-2\">");
#nullable restore
#line 20 "D:\Softuni\DB\Auto-Mapping-Objects-Project\FastFood.Core\Views\Positions\All.cshtml"
                                Write(Model[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 22 "D:\Softuni\DB\Auto-Mapping-Objects-Project\FastFood.Core\Views\Positions\All.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<FastFood.Core.ViewModels.Positions.PositionsAllViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
