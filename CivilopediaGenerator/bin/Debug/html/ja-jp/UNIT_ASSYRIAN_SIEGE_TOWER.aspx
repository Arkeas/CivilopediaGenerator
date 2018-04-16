<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 攻城塔</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_ASSYRIAN_SIEGE_TOWER.png" alt="攻城塔" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">75 <img src="/civilopedia/images/production.png" alt="production" /> / 150 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>戦闘のタイプ:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">白兵ユニット</div></div></div></div></div></div></div></div>
		<h2>戦闘力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">12 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		
		
		<h2>移動力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>文明:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CIVILIZATION_ASSYRIA.aspx" onmouseover="return tooltip('アッシリア帝国');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/CIVILIZATION_ASSYRIA.png" /></a></div></div></div></div></div></div></div></div>
		<h2>能力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_SAPPER.aspx" onmouseover="return tooltip('工兵');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_EXP_6.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('対都市ボーナス(200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_COVER_1.aspx" onmouseover="return tooltip('援護 I');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_14.png" /></a><a href="PROMOTION_ONLY_ATTACKS_CITIES.aspx" onmouseover="return tooltip('都市攻撃限定');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_EXTRA_SIGHT_I.aspx" onmouseover="return tooltip('追加視界(1)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('地形による防御ボーナスなし');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_MATHEMATICS.aspx" onmouseover="return tooltip('数学');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_MATHEMATICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>陳腐化するテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_PHYSICS.aspx" onmouseover="return tooltip('物理学');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_PHYSICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>上位ユニット：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_TREBUCHET.aspx" onmouseover="return tooltip('トレビュシェット');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_TREBUCHET.png" /></a></div></div></div></div></div></div></div></div>
		<h2>同種ユニット:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_CATAPULT.aspx" onmouseover="return tooltip('カタパルト');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_CATAPULT.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">攻城塔</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">強力な白兵戦系攻城ユニット。敵の都市に隣接している場合、近くのユニットに都市攻撃ボーナスをもたらす。アッシリアにしか生産できない。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">白兵戦系攻城ユニット。力を発揮するには敵の都市に隣接しなくてはならないが、ひとたび隣接すれば圧倒的な強さを誇る。みずから都市に強烈な攻撃を浴びせるだけでなく、近くで都市を攻撃中の味方ユニットにボーナスを与えることもできる。白兵ユニットや遠隔攻撃ユニットに攻城塔を援護させ、目的地まで確実にたどり着かせれば、都市の陥落はぐっと早まるだろう。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">攻城塔は現在知られているかぎり、紀元前9世紀頃に新アッシリア帝国が用いたのが最初とされる。アッシュールナツィルパル2世治下に製作された浅浮彫りには、攻城塔で敵都市の城壁を攻める様子が描かれている。当時のメソポタミアでは、軍隊の攻撃を防ぐには泥煉瓦の城壁さえあれば概ね事足りていた。しかし、攻城塔を導入したアッシリアは迅速かつ効率的に敵都市を攻略できるようになり、それが、以後3世紀にわたるほぼ無制限の成長を可能にしたのである。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

