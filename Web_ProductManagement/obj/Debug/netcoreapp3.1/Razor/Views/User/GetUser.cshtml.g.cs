#pragma checksum "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c7482b842fcf5b6c6e71078493ee5f5f45a3c7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_GetUser), @"mvc.1.0.view", @"/Views/User/GetUser.cshtml")]
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
#line 1 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\_ViewImports.cshtml"
using MVC_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\_ViewImports.cshtml"
using MVC_UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c7482b842fcf5b6c6e71078493ee5f5f45a3c7e", @"/Views/User/GetUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50cfe5b2535a5ae55c5a8ee0de5bb4c7bef7f708", @"/Views/_ViewImports.cshtml")]
    public class Views_User_GetUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Web_UserManagement.Models.UserDetails>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
  
    ViewData["Title"] = "GetUser";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetUser</h1>\r\n\r\n<div>\r\n    <h4>UserDetails</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n");
            WriteLiteral("        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayNameFor(model => model.UserPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayFor(model => model.UserPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayNameFor(model => model.EmailAddr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayFor(model => model.EmailAddr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n");
            WriteLiteral("        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 68 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayNameFor(model => model.UserAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 71 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
       Write(Html.DisplayFor(model => model.UserAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 76 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
Write(Html.ActionLink("Edit Profile", "EditUser", new { id = TempData["id"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 77 "F:\Cloned Folder\UI Cloned\ProductManagement\Web_ProductManagement\Views\User\GetUser.cshtml"
Write(Html.ActionLink("Back to List", "GetProducts", "Product", new { id = TempData["id"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web_UserManagement.Models.UserDetails> Html { get; private set; }
    }
}
#pragma warning restore 1591
