#pragma checksum "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4e724d7f5dcc374dbf897e6af672771c1d55ca5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_GetProductById), @"mvc.1.0.view", @"/Views/Product/GetProductById.cshtml")]
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
#line 1 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\_ViewImports.cshtml"
using MVC_UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\_ViewImports.cshtml"
using MVC_UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4e724d7f5dcc374dbf897e6af672771c1d55ca5", @"/Views/Product/GetProductById.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50cfe5b2535a5ae55c5a8ee0de5bb4c7bef7f708", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_GetProductById : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Web_UserManagement.Models.Products>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
  
    ViewData["Title"] = "GetProductById";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetProductById</h1>\r\n\r\n<div>\r\n    <h4>Products</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n");
            WriteLiteral("        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayFor(model => model.ProductDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayFor(model => model.ProductPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayNameFor(model => model.ProducedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayFor(model => model.ProducedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayNameFor(model => model.ProductExpireDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayFor(model => model.ProductExpireDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n");
            WriteLiteral("        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
       Write(Html.DisplayFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 70 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
Write(Html.ActionLink("Edit", "UpdateProduct", new { id = Model.UserId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 71 "F:\Clone-9th\ProductManagement\Web_ProductManagement\Views\Product\GetProductById.cshtml"
Write(Html.ActionLink("Back to List", "GetProducts", new { id = Model.UserId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web_UserManagement.Models.Products> Html { get; private set; }
    }
}
#pragma warning restore 1591
