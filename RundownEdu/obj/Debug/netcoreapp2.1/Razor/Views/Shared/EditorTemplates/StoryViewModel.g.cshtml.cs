#pragma checksum "E:\Development\VisualStudio\Projects\RundownEdu\RundownEdu\Views\Shared\EditorTemplates\StoryViewModel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b2a8c85fb74b747fedc24db1dda23118f9f0601"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_StoryViewModel), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/StoryViewModel.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/EditorTemplates/StoryViewModel.cshtml", typeof(AspNetCore.Views_Shared_EditorTemplates_StoryViewModel))]
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
#line 1 "E:\Development\VisualStudio\Projects\RundownEdu\RundownEdu\Views\_ViewImports.cshtml"
using RundownEdu;

#line default
#line hidden
#line 2 "E:\Development\VisualStudio\Projects\RundownEdu\RundownEdu\Views\_ViewImports.cshtml"
using RundownEdu.Models;

#line default
#line hidden
#line 3 "E:\Development\VisualStudio\Projects\RundownEdu\RundownEdu\Views\_ViewImports.cshtml"
using RundownEdu.ViewModels;

#line default
#line hidden
#line 4 "E:\Development\VisualStudio\Projects\RundownEdu\RundownEdu\Views\_ViewImports.cshtml"
using RundownEdu.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b2a8c85fb74b747fedc24db1dda23118f9f0601", @"/Views/Shared/EditorTemplates/StoryViewModel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3071b459bb4873cfeeeec75c57b446f2ae2f828", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_StoryViewModel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RundownEdu.ViewModels.StoryViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "E:\Development\VisualStudio\Projects\RundownEdu\RundownEdu\Views\Shared\EditorTemplates\StoryViewModel.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(72, 16, true);
            WriteLiteral("\r\n<tr>\r\n    <td>");
            EndContext();
            BeginContext(89, 36, false);
#line 7 "E:\Development\VisualStudio\Projects\RundownEdu\RundownEdu\Views\Shared\EditorTemplates\StoryViewModel.cshtml"
   Write(Html.EditorFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(125, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(141, 45, false);
#line 8 "E:\Development\VisualStudio\Projects\RundownEdu\RundownEdu\Views\Shared\EditorTemplates\StoryViewModel.cshtml"
   Write(Html.DisplayFor(model => model.Rundown.Title));

#line default
#line hidden
            EndContext();
            BeginContext(186, 14, true);
            WriteLiteral("</td>\r\n</tr>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RundownEdu.ViewModels.StoryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
