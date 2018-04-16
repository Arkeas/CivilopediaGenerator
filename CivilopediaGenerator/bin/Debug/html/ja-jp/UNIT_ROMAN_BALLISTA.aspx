<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 投石機</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_ROMAN_BALLISTA.png" alt="投石機" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">75 <img src="/civilopedia/images/production.png" alt="production" /> / 150 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>戦闘のタイプ:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">攻城兵器</div></div></div></div></div></div></div></div>
		<h2>戦闘力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">8 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">10 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃範囲:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2</div></div></div></div></div></div></div></div>
		<h2>移動力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>文明:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CIVILIZATION_ROME.aspx" onmouseover="return tooltip('ローマ文明');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/CIVILIZATION_ROME.png" /></a></div></div></div></div></div></div></div></div>
		<h2>能力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('白兵攻撃不可');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('対都市ボーナス(200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('地形による防御ボーナスなし');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('遠隔攻撃を行うには準備が必要');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('視界制限');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_MATHEMATICS.aspx" onmouseover="return tooltip('数学');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_MATHEMATICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>陳腐化するテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_PHYSICS.aspx" onmouseover="return tooltip('物理学');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_PHYSICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>上位ユニット：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_TREBUCHET.aspx" onmouseover="return tooltip('トレビュシェット');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_TREBUCHET.png" /></a></div></div></div></div></div></div></div></div>
		<h2>同種ユニット:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_CATAPULT.aspx" onmouseover="return tooltip('カタパルト');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_CATAPULT.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">投石機</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">遠距離から大きなダメージを与えるが、攻撃の前に準備が必要。ローマのみ生産可能。このユニットは他文明の同等ユニットであるカタパルトよりも高い<img src="/civilopedia/images/range_strength.png" alt="range strength" />遠隔戦闘力を備えている。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">ローマの固有ユニットで、カタパルトよりも強力になっている。この投石機は優れた攻城兵器である。都市攻撃で大活躍するユニットだが、他ユニットからの攻撃には非常に弱い。投石機は常に他ユニットに守らせておくよう心がけておきたい。投石機は攻撃を行う前に「準備」(1移動ポイント消費)をする必要がある。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">ローマの投石機は、敵に石や木を撃ち込む高度なカタパルトであった。厚い鉄板で補強された木材でできており、熟練した操作で驚異的な命中率を誇った。最大飛距離は約450メートルだが、実際はそれよりも大幅に短く、特に要塞化した地点に対しては飛距離が伸びない。ユリウス・カエサルはドイツおよびイギリス遠征の際に、この投石機をいとも効果的に使用した。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

