<%@ Page Title="" Language="VB" MasterPageFile="Terrains.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: ##TITLE##</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/##TYPE##.png" alt="##TITLE##" class="contentimage" />
	<div class="contentleft">
		##YIELDS##
		##MOVES##
		##COMBAT##
		##FEATURES##
		##RESOURCES##
	</div>
	<div class="contentright">
		<div class="title">##TITLE##</div>
		##HELP##
		##DESC##
	</div>
</asp:Content>

