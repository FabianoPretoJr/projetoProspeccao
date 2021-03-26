#pragma checksum "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fecad7a2a3b4e57e7c19974c3313bcfb02992ca0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ClientesControleRisco), @"mvc.1.0.view", @"/Views/Home/ClientesControleRisco.cshtml")]
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
#line 1 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\_ViewImports.cshtml"
using MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\_ViewImports.cshtml"
using MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fecad7a2a3b4e57e7c19974c3313bcfb02992ca0", @"/Views/Home/ClientesControleRisco.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d7a8f56340c239c091cff637a00cc2fdf252300", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ClientesControleRisco : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BLL.DTO.Cliente.ClienteListagemDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
  
    Layout = "_LayoutAdmin";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
  
    ViewData["Title"] = "Clientes controle de risco";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Clientes controle de risco</h2>
<hr />

<script>
    $(document).ready(function () {
        $('#clientes').DataTable({
            //""info"" : false,
            ""language"": {
                ""lengthMenu"": ""Mostrando _MENU_ registros por página"",
                ""zeroRecords"": ""Desculpe, nada encontrado"",
                ""info"": ""Mostrando página _PAGE_ de _PAGES_"",
                ""infoEmpty"": ""Nenhum registro disponível"",
                ""search"": ""Buscar:"",
                ""paginate"": {
                    ""first"": ""Primeiro"",
                    ""last"": ""Último"",
                    ""next"": ""próximo"",
                    ""previous"": ""Anterior""
                }
            }
        });
    });
</script>

<table id=""clientes"" class=""table table-striped table-bordered"">
    <thead>
        <tr>
            <th>Nome</th>
            <th>CPF</th>
            <th>RG</th>
            <th>Data Nascimento</th>
            <th>E-mail</th>
            <th>Ações</th>
        <");
            WriteLiteral("/tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 45 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
         foreach (var cliente in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 48 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
               Write(cliente.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 49 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
               Write(cliente.CPF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 50 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
               Write(cliente.RG);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 51 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
               Write(cliente.DataNascimento.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 52 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
               Write(cliente.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 54 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
                     switch (cliente.IdStatus)
                    {
                        case 4:

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 1669, "\"", 1710, 2);
            WriteAttributeValue("", 1676, "/Clientes/AprovarFluxo/", 1676, 23, true);
#nullable restore
#line 57 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
WriteAttributeValue("", 1699, cliente.Id, 1699, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Aprovar</a>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1779, "\"", 1826, 2);
            WriteAttributeValue("", 1786, "/Clientes/CorrecaoDeCadastro/", 1786, 29, true);
#nullable restore
#line 58 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
WriteAttributeValue("", 1815, cliente.Id, 1815, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">Correção</a>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1896, "\"", 1938, 2);
            WriteAttributeValue("", 1903, "/Clientes/ReprovarFluxo/", 1903, 24, true);
#nullable restore
#line 59 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
WriteAttributeValue("", 1927, cliente.Id, 1927, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Reprovar</a>\r\n");
#nullable restore
#line 60 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
                            break;
                        default:
                            break;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 66 "C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\projetoProspeccao\Application\ProjetoProspeccao\MVC\Views\Home\ClientesControleRisco.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BLL.DTO.Cliente.ClienteListagemDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591