<%@ Page Title="" Language="VB" MasterPageFile="Buildings.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: ##TITLE##</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/##TYPE##.png" alt="##TITLE##" class="contentimage" />
	<div class="contentleft">
		##COST##
		##MAINTENANCE##
		##HAPPINESS##
		##FOOD##
		##GOLD##
		##PRODUCTION##
		##CULTURE##
        ##FAITH##
        ##DEFENSE##
		##SCIENCE##
		##CIVILIZATION##
		##RESOURCES##
        ##LOCALRESOURCES##
		##GREATPEOPLE##
		##PREREQ##
		##REQUIRED##
		##SPECIALISTS##
		##GREATWORKS##
		##REPLACES##
	</div>
	<div class="contentright">
		<div class="title">##TITLE##</div>
		##HELP##
		##STRATEGY##
		##DESC##
	</div>
</asp:Content>

