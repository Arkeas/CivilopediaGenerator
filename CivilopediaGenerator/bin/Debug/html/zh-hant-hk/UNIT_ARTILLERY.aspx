<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 火砲</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_ARTILLERY.png" alt="火砲" class="contentimage" />
	<div class="contentleft">
		<h2>消耗：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">250 <img src="/civilopedia/images/production.png" alt="production" /> / 500 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>戰鬥類型：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">攻城武器</div></div></div></div></div></div></div></div>
		<h2>戰鬥力：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">21 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>遠程攻擊力：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">28 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>射程：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">3</div></div></div></div></div></div></div></div>
		<h2>移動力：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>能力：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_INDIRECT_FIRE.aspx" onmouseover="return tooltip('間接攻擊');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_35.png" /></a><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('無法近戰');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('對城市加成（200）');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('無防禦地形加成');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('需架設後才可遠程攻擊');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('視野受限');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>所需科技：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_DYNAMITE.aspx" onmouseover="return tooltip('炸藥');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_DYNAMITE.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>晉升單位</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_ROCKET_ARTILLERY.aspx" onmouseover="return tooltip('多管火箭');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_ROCKET_ARTILLERY.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">火砲</div>
		<h2>遊戲資訊：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">遊戲中第一種射程達3格的攻城單位。開火前需要進行設置準備。</div></div></div></div></div></div></div></div>
		<h2>戰略資訊：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">火炮是一種致命的攻城武器，比加農炮更強大且射程更長。跟加農炮一樣，它有視野的限制且必須進行設置準備後（消耗1點MP）才能攻擊，但其遠程攻擊力相當驚人。火炮也有“間接攻擊”的強化能力，它可以射穿障礙物命中看不到的目標（只要其他友軍能看到他們）。跟其他攻城單位一樣，火炮難以防禦近戰攻擊。</div></div></div></div></div></div></div></div>
		<h2>歷史資訊：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">科技進步之際，戰場上，火炮愈形重要。十九世紀期間的騎馬砍殺或美國內戰用的槍砲早已退場。多年之後，更大型、精準度更高、殺傷力更強的武器取而代之。二戰期間，德國的88毫米口徑的火炮便是最佳的全方位炮兵武器之一。它原本是設計為防空武器，因為用來做反戰車也確實非常有效，因此衍生新的用途。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

