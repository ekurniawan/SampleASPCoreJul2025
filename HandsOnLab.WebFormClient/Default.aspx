<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="HandsOnLab.WebFormClient._Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">List Of Cars</h1>
        </section>

        <div class="row">
          <asp:DataGrid ID="gvCars" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
              <Columns>
                  <asp:BoundColumn DataField="CarId" HeaderText="Car ID" />
                  <asp:BoundColumn DataField="Model" HeaderText="Model" />
                  <asp:BoundColumn DataField="Type" HeaderText="Type" />
                  <asp:BoundColumn DataField="BasePrice" HeaderText="Base Price" DataFormatString="Rp.{0:N0}" />
                  <asp:BoundColumn DataField="Color" HeaderText="Color"  />
                  <asp:BoundColumn DataField="Stock" HeaderText="Stock" DataFormatString="{0:N0}" />
              </Columns>
              <PagerStyle CssClass="pagination justify-content-center" />
          </asp:DataGrid>
        </div>
    </main>

</asp:Content>
