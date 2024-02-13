<%@ Page Title="Search" Async="true" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="RecipeWEB.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img src="photos/icecream.jpg" class="cakephoto" />
    <div id="searchbar">
    <div id="searcher">
            <asp:TextBox id="search" runat="server" placeholder="What are you craving for ?"></asp:TextBox>
           &nbsp;<asp:ImageButton id="searchbtnn" runat="server" AlternateText="coverimg" ImageUrl="photos/magnifying-glass.png" OnClick="Searchbtn_Click"/>    
         </div>
        </div>

            <div class="box">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <table class="recipe">
                        <tr>
                            <td>
                                <asp:Image ID="Label2" runat="server" ImageUrl='<%#Eval("Img") %>' CssClass="photo"></asp:Image> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#Eval("Title") %>' NavigateUrl='<%#Eval("Url") %>'></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:Label ID="Label4" runat="server" Text='<%#"Servings: " + Eval("Serv") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:Label ID="Label5" runat="server" Text='<%#"Ready In Minutes: "+Eval("Minu") %>'></asp:Label>
                            </td>
                        </tr>
                     </table>
                </ItemTemplate>
            </asp:Repeater>
                </div>
</asp:Content>
