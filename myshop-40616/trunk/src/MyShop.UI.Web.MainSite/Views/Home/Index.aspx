<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Project Description</h2>
<p>This is a sample application to proof the concept of DDDD, better known as CQS &amp; event storage an extension to DDD. 
This concept was first mentioned by Gregory Young and since then it created a huge buzz in the community.</p><p>Let's feed the buzz and proof that it works!</p>
<h2>Status</h2>
<p>At the moment to project is still in exploratory development stage. Although <b>all technical implementations, as Event Based Storage and Command and Query separation, are implemented</b>,
 the domain modeling part isn't complete and MyShop is far from ready to deploy. Yet, a stable and final product isn't the goal of this project; the goal is to give an example of 
 Domain Driven Design, Event Based Storage, Command &amp; Query separation, Behavior Driven Design and other principles.</p><p>You can always download the latest 
 <a href="http://myshop.codeplex.com/SourceControl/ListDownloadableCommits.aspx">source code</a>.</p>

<h2>Getting started</h2>
<p>Please see the <a href="http://myshop.codeplex.com/documentation?referringTitle=Home">documentation</a> for a getting started guide.</p><p>For more info about the principles 
behind MyShop, listen to the <a href="http://devnology.nl/en/podcast/10-content/80-devnology-podcast-002-greg-young-over-domain-driven-design">Devnology podcast
 with Greg Young</a>.</p>
<h2>Contact</h2>
<p>If you want extra information, have ideas, comments, other thoughts or the source code doesn't compile or run, feel free to contact me via <a href="http://twitter.com/pjvds">twitter</a> or <a href="mailto:pj@born2code.net">e-mail</a>.</p>
</asp:Content>
