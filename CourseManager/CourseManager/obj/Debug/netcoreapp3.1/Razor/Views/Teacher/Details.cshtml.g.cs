#pragma checksum "C:\Users\BDeyo\Desktop\classwork-deyo-brendan\CourseManager\CourseManager\Views\Teacher\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "342732e1b3f28e2867b7b81a30ccb343d334935b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Details), @"mvc.1.0.view", @"/Views/Teacher/Details.cshtml")]
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
#line 1 "C:\Users\BDeyo\Desktop\classwork-deyo-brendan\CourseManager\CourseManager\Views\_ViewImports.cshtml"
using CourseManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BDeyo\Desktop\classwork-deyo-brendan\CourseManager\CourseManager\Views\_ViewImports.cshtml"
using CourseManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"342732e1b3f28e2867b7b81a30ccb343d334935b", @"/Views/Teacher/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86a0572f074d3b8a640e694913b8cb8b34518460", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Teacher>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 5 "C:\Users\BDeyo\Desktop\classwork-deyo-brendan\CourseManager\CourseManager\Views\Teacher\Details.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<br />\r\n<hr />\r\n");
#nullable restore
#line 8 "C:\Users\BDeyo\Desktop\classwork-deyo-brendan\CourseManager\CourseManager\Views\Teacher\Details.cshtml"
 foreach (var c in Model.Courses)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>");
#nullable restore
#line 10 "C:\Users\BDeyo\Desktop\classwork-deyo-brendan\CourseManager\CourseManager\Views\Teacher\Details.cshtml"
   Write(c.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <br />\r\n");
#nullable restore
#line 12 "C:\Users\BDeyo\Desktop\classwork-deyo-brendan\CourseManager\CourseManager\Views\Teacher\Details.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Teacher> Html { get; private set; }
    }
}
#pragma warning restore 1591
