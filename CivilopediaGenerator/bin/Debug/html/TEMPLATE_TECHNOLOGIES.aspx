<%@ Page Title="" Language="VB" MasterPageFile="Technologies.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: ##TITLE##</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/##TYPE##.png" alt="##TITLE##" class="contentimage" />
	<div class="contentleft">
		##COST##
		##PREREQ##
		##LEADS##
		##UNITS##
		##BUILDINGS##
        ##PROJECTS##
		##RESOURCES##
		##ACTIONS##
	</div>
	<div class="contentright">
		<div class="title">##TITLE##</div>
		##HELP##
		##SPECIAL##
		##QUOTE##
		##DESC##
	</div>
</asp:Content>

