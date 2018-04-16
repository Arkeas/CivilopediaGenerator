<%@ Page Title="" Language="VB" MasterPageFile="Terrains.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 바다</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/TERRAIN_OCEAN.png" alt="바다" class="contentimage" />
	<div class="contentleft">
		<h2>생산:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">1 <img src="/civilopedia/images/food.png" alt="food" /> </div></div></div></div></div></div></div></div>
		<h2>이동 비용:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">1 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>보정치:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">0%</div></div></div></div></div></div></div></div>
		
<h2>특성:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="FEATURE_ICE.aspx" onmouseover="return tooltip('빙하');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/FEATURE_ICE.png" /></a><a href="FEATURE_ATOLL.aspx" onmouseover="return tooltip('산호섬');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/FEATURE_ATOLL.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">바다</div>
		
		<h2>역사적 정보:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">바다 타일은 심해 타일이다. 도시에서 필요한 기술을 연구하면 식량과 금을 제공한다.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

