#pragma checksum "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4a518ce1f9aef1b03e4ea28fefd8d64956582a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProductDetail_Index), @"mvc.1.0.view", @"/Views/ProductDetail/Index.cshtml")]
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
#line 1 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\_ViewImports.cshtml"
using Razzi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\_ViewImports.cshtml"
using Razzi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\_ViewImports.cshtml"
using Razzi.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4a518ce1f9aef1b03e4ea28fefd8d64956582a3", @"/Views/ProductDetail/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e9de5c2c34d2187cca6361f6d4fc36932f51cbb", @"/Views/_ViewImports.cshtml")]
    public class Views_ProductDetail_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main style=""padding-top: 50px;"">
    <section id=""product-detail"">
        <div class=""container"">
            <div class=""content"">
                <div class=""row"">
                    <div class=""col-xxl-5 col-12"">
                        <div class=""img"">
                            <div id=""carouselExampleIndicators"" class=""carousel slide"" data-bs-ride=""carousel"">
                                <div class=""carousel-indicators"">
                                    <button type=""button"" data-bs-target=""#carouselExampleIndicators""
                                            data-bs-slide-to=""0"" class=""active"" aria-current=""true""
                                            aria-label=""Slide 1""></button>
                                    <button type=""button"" data-bs-target=""#carouselExampleIndicators""
                                            data-bs-slide-to=""1"" aria-label=""Slide 2""></button>
                                    <button type=""button"" data-bs-target=""#carouselExampleIndi");
            WriteLiteral(@"cators""
                                            data-bs-slide-to=""2"" aria-label=""Slide 3""></button>
                                </div>
                                <div class=""carousel-inner"">
                                    <div class=""carousel-item active"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f4a518ce1f9aef1b03e4ea28fefd8d64956582a35768", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1411, "~/assets/img/product/", 1411, 21, true);
#nullable restore
#line 25 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
AddHtmlAttributeValue("", 1432, Model.Image, 1432, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </div>
                                </div>
                                <button class=""carousel-control-prev"" type=""button""
                                        data-bs-target=""#carouselExampleIndicators"" data-bs-slide=""prev"">
                                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                                    <span class=""visually-hidden"">Previous</span>
                                </button>
                                <button class=""carousel-control-next"" type=""button""
                                        data-bs-target=""#carouselExampleIndicators"" data-bs-slide=""next"">
                                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                                    <span class=""visually-hidden"">Next</span>
                                </button>
                            </div>
                        </div>
                    </div>
");
            WriteLiteral("                    <div class=\"col-xxl-7 col-12 mt-4\">\r\n                        <div class=\"category\">\r\n                            <p>");
#nullable restore
#line 44 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                          Write(Model.Gender.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"name\">\r\n                            <h1>");
#nullable restore
#line 47 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                        </div>\r\n                        <div class=\"price-wrapper\">\r\n                            <span class=\"price\">$");
#nullable restore
#line 50 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                                            Write(Model.RealPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 51 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                             if (Model.StockStatus == true)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"stock-status\">(In Stock)</span>\r\n");
#nullable restore
#line 54 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"stock-status\">(Out of order)</span>\r\n");
#nullable restore
#line 58 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <div class=\"description\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 62 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                           Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n                        <div class=\"categories\">\r\n                            <span><b>Categorie:</b> ");
#nullable restore
#line 66 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                                               Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 66 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                                                                     Write(Model.Gender.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n");
#nullable restore
#line 68 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                         if (Model.StockStatus == true)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"sizes\" id=\"product-size\">\r\n                                <p>Size</p>\r\n                                <div class=\"row\">\r\n");
#nullable restore
#line 73 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                                     foreach (var item in Model.ProductSizes)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"col-1\">\r\n                                            <div class=\"size\">");
#nullable restore
#line 76 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                                                         Write(item.Size.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                        </div>\r\n");
#nullable restore
#line 78 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>
                            <div class=""product-buttons"">
                                <div class=""row"">
                                    <div class=""col-3"">
                                        <div class=""count d-flex justify-content-around"">
                                            <button id=""down-count""><i class=""fas fa-minus""></i></button>
                                            <input id=""count"" type=""number""");
            BeginWriteAttribute("name", " name=\"", 4896, "\"", 4903, 0);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 4904, "\"", 4909, 0);
            EndWriteAttribute();
            WriteLiteral(@" min=""1"" value=""1"">
                                            <button id=""up-count""><i class=""fas fa-plus""></i></button>
                                        </div>
                                    </div>
                                    <div class=""col-5 d-flex justify-content-center"">
                                        <div class=""add-to-cart"">
                                            <button id=""add-to-cart-btn"" type=""submit"" disabled>
                                                Add To Cart <i class=""fas fa-shopping-bag""></i>
                                            </button>
                                        </div>
                                    </div>
                                    <div class=""col-3"">
                                        <div class=""wishlist"">
                                            <button type=""submit"">Wishlist <i class=""fas fa-heart""></i></button>
                                        </div>
                            ");
            WriteLiteral("        </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 104 "C:\Users\mikay\OneDrive\Рабочий стол\P126\Final Project\RazziBackend\Razzi\Razzi\Views\ProductDetail\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591