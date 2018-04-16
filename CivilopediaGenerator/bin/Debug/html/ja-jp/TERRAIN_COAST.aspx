<%@ Page Title="" Language="VB" MasterPageFile="Terrains.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 近海</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/TERRAIN_COAST.png" alt="近海" class="contentimage" />
	<div class="contentleft">
		<h2>生産:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">1 <img src="/civilopedia/images/food.png" alt="food" /> </div></div></div></div></div></div></div></div>
		<h2>移動コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">1 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>戦闘力補正:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">0%</div></div></div></div></div></div></div></div>
		
<h2>発見可能な地物:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="FEATURE_ICE.aspx" onmouseover="return tooltip('氷河');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/FEATURE_ICE.png" /></a><a href="FEATURE_ATOLL.aspx" onmouseover="return tooltip('環礁');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/FEATURE_ATOLL.png" /></a></div></div></div></div></div></div></div></div>
		
<h2>発見可能な資源:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="RESOURCE_OIL.aspx" onmouseover="return tooltip('石油');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_OIL.png" /></a><a href="RESOURCE_FISH.aspx" onmouseover="return tooltip('魚');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_FISH.png" /></a><a href="RESOURCE_WHALE.aspx" onmouseover="return tooltip('鯨');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_WHALE.png" /></a><a href="RESOURCE_PEARLS.aspx" onmouseover="return tooltip('真珠');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_PEARLS.png" /></a><a href="RESOURCE_CRAB.aspx" onmouseover="return tooltip('');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_CRAB.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">近海</div>
		
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">近海タイルは海岸に沿って隣接する外洋タイルである。周辺の都市は近海から食料やゴールドを得ることができるが、これは文明が帆走テクノロジーを所有する場合に限る。海軍ユニットと「出航した」陸上ユニットのみが近海タイルに入ることができる。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

