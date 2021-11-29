#pragma checksum "C:\container\EmployeeCoreApp\Views\Employee\Employees.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c88094373a2e45edb0b9557112d2e2303576828"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Employees), @"mvc.1.0.view", @"/Views/Employee/Employees.cshtml")]
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
#line 1 "C:\container\EmployeeCoreApp\Views\_ViewImports.cshtml"
using AspCoreApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\container\EmployeeCoreApp\Views\_ViewImports.cshtml"
using AspCoreApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c88094373a2e45edb0b9557112d2e2303576828", @"/Views/Employee/Employees.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64c61db8311b2b7ea1ea024e007218f564b3a9f5", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Employees : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\container\EmployeeCoreApp\Views\Employee\Employees.cshtml"
  
    ViewBag.Title = "All employees";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<p style=""margin-top:10px"">
    <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#addEditEmpModal"" onclick=""clearAddEmpModal();"">Add employee</button>
</p>

<h2>Employees</h2>

<table id=""tblEmployees"" class=""table"">
    <thead>
        <tr>
            <th align=""left"">FirstName</th>
            <th align=""left"">LastName</th>
            <th align=""left"">Experience</th>
            <th align=""left"">Salary</th>
            <th align=""left"">Team</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>

<div class=""modal fade"" id=""addEditEmpModal"" role=""dialog"" style=""width:1500px;height:1000px;"">
");
#nullable restore
#line 26 "C:\container\EmployeeCoreApp\Views\Employee\Employees.cshtml"
      
        Html.RenderPartial("_AddEditEmployee");
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(function () {

            LoadEmployees();
        });

        function LoadEmployees() {
            $(""#tblEmployees tbody tr"").remove();
            $.ajax({
                type: 'GET',
                url: '/Employee/GetEmployees',
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {

                    $.each(data, function (i, item) {
                        console.log(item);
                        var rows = ""<tr>""
                            + ""<td style='max-width: 400px'>"" + item.firstName + ""</td>""
                            + ""<td style='max-width: 200px'>"" + item.lastName + ""</td>""
                            + ""<td>"" + item.experience + ""</td>""
                            + ""<td>"" + item.salary + ""</td>""
                            + ""<td>"" + item.team + ""</td>""
                            + ""<td> <a href='#' onclick='return getByID("" + item.id + "")'>Edit</a> | <a href='");
                WriteLiteral(@"#' onclick='Delete("" + item.id + "")'> Delete </a></td>""
                            + ""</tr>"";
                        $('#tblEmployees tbody').append(rows);
                    });
                },
                error: function (ex) {
                    var r = jQuery.parseJSON(response.responseText);
                }
            });
            return false;
        }

        function Add() {
            //var res = validate();
            //if (res == false) {
            //    return false;
            //}

            var empObj = {
                FirstName: $('#FirstName').val(),
                LastName: $('#LastName').val(),
                Experience: $('#Experience').val(),
                Salary: $('#Salary').val(),
                Team: $('#Team').val()
            };

            $.ajax({
                url: ""/Employee/Create"",
                data: {emp:empObj},
                type: ""POST"",
                dataType: ""json"",
                success: function (result) {

                ");
                WriteLiteral(@"    $('#addEditEmpModal').modal('hide');

                    LoadEmployees();

                },
                error: function (errormessage) {

                }
            });
        }

        function Update() {
            //var res = validate();
            //if (res == false) {
            //    return false;
            //}

            var emp = {
                Id: $('#EmployeeId').val(),
                FirstName: $('#FirstName').val(),
                LastName: $('#LastName').val(),
                Experience: $('#Experience').val(),
                Salary: $('#Salary').val(),
                Team: $('#Team').val()
            };

            $.ajax({
                url: ""/Employee/Update/"",
                data: {emp:emp},
                type: ""POST"",
                dataType: ""json"",
                success: function (result) {

                    $('#addEditEmpModal').modal('hide');

                    LoadEmployees();

                },
                error: function (errormessage");
                WriteLiteral(@") {
                }
            });
        }

        function getByID(id) {

            $('#Note').css('border-color', 'lightgrey');
            $('#Tags').css('border-color', 'lightgrey');
            $('#Priority').css('border-color', 'lightgrey');
            $.ajax({
                url: ""/Employee/GetById/"" + id,
                type: ""GET"",
                contentType: ""application/json;charset=UTF-8"",
                dataType: ""json"",
                success: function (result) {

                    $('#EmployeeId').val(id);

                    $('#FirstName').val(result.firstName);
                    $('#LastName').val(result.lastName);
                    $('#Experience').val(result.experience);
                    $('#Salary').val(result.salary);
                    $('#Team').val(result.team);

                    $('#addEditEmpModal').modal('show');
                    $('#btnUpdate').show();
                    $('#btnAdd').hide();
                },
                error: function (errorm");
                WriteLiteral(@"essage) {
                }
            });
            return false;
        }

        function Delete(id) {

            $.ajax({
                url: ""/Employee/Delete/"" + id,
                type: ""GET"",
                contentType: ""application/json;charset=UTF-8"",
                dataType: ""json"",
                success: function (result) {
                    LoadEmployees();
                },
                error: function (errormessage) {
                }
            });
            return false;
        }

        function clearAddEmpModal() {

            $('#FirstName').val("""");
            $('#LastName').val("""");
            $('#Experience').val("""");
            $('#Salary').val("""");
            $('#Team').val("""");

            $('#btnUpdate').hide();
            $('#btnAdd').show();

            $('#FirstName').css('border-color', 'lightgrey');
            $('#LastName').css('border-color', 'lightgrey');
            $('#Experience').css('border-color', 'lightgrey');
            $('#Salary')");
                WriteLiteral(".css(\'border-color\', \'lightgrey\');\n            $(\'#Team\').css(\'border-color\', \'lightgrey\');\n        }\n    </script>\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
