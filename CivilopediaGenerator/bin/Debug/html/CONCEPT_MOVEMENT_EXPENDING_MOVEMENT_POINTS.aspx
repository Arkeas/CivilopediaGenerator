<%@ Page Title="" Language="VB" MasterPageFile="Concepts.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: Expending Movement Points</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="contentleft">
		&nbsp;
	</div>
	<div class="contentright">
		<div class="title">Expending Movement Points</div>
		<h2>Summary:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">
        Units expend MPs to enter tiles. The terrain of the tile a unit is entering determines the MP cost of the move. It doesn't cost anything to leave your current tile; the MP cost is determined by the tile you're entering.<br /><br />See the terrain rules for details on MP costs, but generally, open terrain like Grassland and Plains costs 1 MP to enter, while Forest and Jungle costs 2. It also expends all of a unit's MPs to cross a river (unless a road is there).<br /><br />A unit can always move one tile if it has any MPs left. It doesn't matter how expensive the tile is; as long as the unit has something left, it can enter. Once the unit has expended all of its MPs, it must stop moving.
      </div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

