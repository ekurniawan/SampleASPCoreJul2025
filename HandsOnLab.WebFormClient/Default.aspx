<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HandsOnLab.WebFormClient._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h3 id="aspnetTitle">List Of Cars</h3>
        </section>
        <br />
        <div class="row">
            <asp:Literal ID="ltMessage" runat="server" /><br />
            <asp:HiddenField ID="hfCarId" runat="server" />
            <div class="col-md-4">
                <div class="mb-3 mt-3">
                    <label for="Model" class="form-label">Model :</label>
                    <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="Type" class="form-label">Type :</label>
                    <asp:TextBox ID="txtType" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="BasePrice" class="form-label">Base Price :</label>
                    <asp:TextBox ID="txtBasePrice" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="Color" class="form-label">Color :</label>
                    <asp:TextBox ID="txtColor" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtStock" class="form-label">Stock :</label>
                    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" />
                </div>
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary btn-sm" OnClick="btnAdd_Click" />
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-warning btn-sm" OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" OnClick="btnDelete_Click" />
            </div>

            <div class="col-md-8">
                <asp:DataGrid ID="gvCars" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundColumn DataField="CarId" HeaderText="Car ID" />
                        <asp:BoundColumn DataField="Model" HeaderText="Model" />
                        <asp:BoundColumn DataField="Type" HeaderText="Type" />
                        <asp:BoundColumn DataField="BasePrice" HeaderText="Base Price" DataFormatString="Rp.{0:N0}" />
                        <asp:BoundColumn DataField="Color" HeaderText="Color" />
                        <asp:BoundColumn DataField="Stock" HeaderText="Stock" DataFormatString="{0:N0}" />
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <a class="btn btn-primary btn-sm" runat="server" href='<%# "Default.aspx?CarId=" + Eval("CarId") %>'>select</a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle CssClass="pagination justify-content-center" />
                </asp:DataGrid>
            </div>


        </div>
    </main>

</asp:Content>
