#pragma checksum "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b70253cfdf34c8deb57d439e101f028bae951645e72022fe8c5c100faee14a16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Exam_Start), @"mvc.1.0.view", @"/Views/Exam/Start.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\_ViewImports.cshtml"
using ExamManagementApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\_ViewImports.cshtml"
using ExamManagementApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"b70253cfdf34c8deb57d439e101f028bae951645e72022fe8c5c100faee14a16", @"/Views/Exam/Start.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6addb6a6e00591d67b9ca3b72bce9b24f5b09a17ecff02d4ab0310146e81914e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Exam_Start : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ExamManagementApp.Models.Question>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/MyJs/script.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b70253cfdf34c8deb57d439e101f028bae951645e72022fe8c5c100faee14a164354", async() => {
                WriteLiteral("\r\n    <title></title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b70253cfdf34c8deb57d439e101f028bae951645e72022fe8c5c100faee14a165367", async() => {
                WriteLiteral(@"
    <nav class=""container-fluid d-flex flex-md-row flex-column justify-content-md-between pt-2"">
        <div class=""row col-md-8"">
            <p class=""fw-bold fs-4"" id=""question-text""></p>
            <div class=""d-none"" id=""contain-answer"">
                <input type=""radio"" name=""answer"" value=""A"" id=""A"" /><p id=""question-choiceA"" class=""fs-6""></p>
                <input type=""radio"" name=""answer"" value=""B"" id=""B"" /><p id=""question-choiceB"" class=""fs-6""></p>
                <input type=""radio"" name=""answer"" value=""C"" id=""C"" /><p id=""question-choiceC"" class=""fs-6""></p>
            </div>
            <div class=""pb-2"">
                <button class=""btn btn-success"" onclick=""CheckUserCheckedAnswer()"">حفظ وانتقال للسؤال التالي</button>
            </div>
        </div>
        <div class=""bg-secondary container-fluid col-md-4"">
            <div class=""d-flex justify-content-between pt-2 container"">
                <div id=""timer"" class=""fs-3""> 10:00</div>
                <button class=""btn");
                WriteLiteral(@" btn-danger border-0 rounded-0"" onclick=""LogOut()"">إنهاء الامتحان</button>
            </div>
            <ul class=""pagination d-flex justify-content-around pt-2"">
                <li class=""page-item""><a class=""page-link text-center border-0 rounded-0"" id=""Countanswer"">تمت الإجابة</a></li>
                <li class=""page-item""><a class=""page-link text-center border-0 rounded-0"" id=""CountnotAnswer"">لم يتم الإجابة</a></li>
            </ul>
            <div class=""d-flex justify-content-around"">
                <p>تمت الإجابة</p>
                <p>لم يتم الإجابة</p>
            </div>
            <ul class=""pagination gy-2 row row-cols-5"">
");
#nullable restore
#line 38 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
                 foreach (var item in Model.Select((value, i) => new { i, value }))
                {
                    if (item.i == 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"page-item qNum active\"");
                BeginWriteAttribute("id", " id=\"", 2064, "\"", 2083, 1);
#nullable restore
#line 42 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
WriteAttributeValue("", 2069, item.value.Id, 2069, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("onclick", " onclick=\"", 2084, "\"", 2117, 3);
                WriteAttributeValue("", 2094, "AddACtiveClass(", 2094, 15, true);
#nullable restore
#line 42 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
WriteAttributeValue("", 2109, item.i, 2109, 7, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2116, ")", 2116, 1, true);
                EndWriteAttribute();
                WriteLiteral("><a class=\"page-link text-black border-0 rounded-0 text-center Question\" href=\"javascript:;\" data-id=\"");
#nullable restore
#line 42 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
                                                                                                                                                                                                                Write(item.value.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">");
#nullable restore
#line 42 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
                                                                                                                                                                                                                                 Write((int)item.i + 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\r\n");
#nullable restore
#line 43 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"

                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"page-item qNum\"");
                BeginWriteAttribute("id", " id=\"", 2389, "\"", 2408, 1);
#nullable restore
#line 47 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
WriteAttributeValue("", 2394, item.value.Id, 2394, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("onclick", " onclick=\"", 2409, "\"", 2442, 3);
                WriteAttributeValue("", 2419, "AddACtiveClass(", 2419, 15, true);
#nullable restore
#line 47 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
WriteAttributeValue("", 2434, item.i, 2434, 7, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2441, ")", 2441, 1, true);
                EndWriteAttribute();
                WriteLiteral("><a class=\"page-link Question text-black border-0 rounded-0 text-center\" href=\"javascript:;\" data-id=\"");
#nullable restore
#line 47 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
                                                                                                                                                                                                         Write(item.value.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">");
#nullable restore
#line 47 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
                                                                                                                                                                                                                          Write((int)item.i + 1);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\r\n");
#nullable restore
#line 48 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </ul>\r\n        </div>\r\n    </nav>\r\n");
                DefineSection("Scripts", async() => {
                    WriteLiteral("\r\n        <script>\r\n            function getEmployeeId() {\r\n                return ");
#nullable restore
#line 56 "D:\New folder\ExamManagementSystem\ExamManagementSystem\ExamManagementApp\ExamManagementApp\Views\Exam\Start.cshtml"
                  Write(TempData["EmpId"]);

#line default
#line hidden
#nullable disable
                    WriteLiteral(";\r\n            }\r\n        </script>\r\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b70253cfdf34c8deb57d439e101f028bae951645e72022fe8c5c100faee14a1613104", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n    ");
                }
                );
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ExamManagementApp.Models.Question>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
