<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 大砲</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_ARTILLERY.png" alt="大砲" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">250 <img src="/civilopedia/images/production.png" alt="production" /> / 500 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>戦闘のタイプ:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">攻城兵器</div></div></div></div></div></div></div></div>
		<h2>戦闘力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">21 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">28 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃範囲:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">3</div></div></div></div></div></div></div></div>
		<h2>移動力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>能力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_INDIRECT_FIRE.aspx" onmouseover="return tooltip('間接射撃');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_35.png" /></a><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('白兵攻撃不可');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('対都市ボーナス(200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('地形による防御ボーナスなし');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('遠隔攻撃を行うには準備が必要');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('視界制限');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_DYNAMITE.aspx" onmouseover="return tooltip('ダイナマイト');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_DYNAMITE.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>上位ユニット：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_ROCKET_ARTILLERY.aspx" onmouseover="return tooltip('ロケット砲');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_ROCKET_ARTILLERY.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">大砲</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">本ゲームで最初に登場する3タイル先まで攻撃が可能な攻城ユニット。攻撃の前に準備が必要。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">大砲は強力な攻城兵器で、カノンより火力が高く射程も長くなっている。カノンと同じように視界は狭く、攻撃の前に準備(1移動ポイントを消費)が必要となるが、遠隔戦闘力は非常に高い。大砲には「間接射撃」の能力が備わっているため、目視できない敵に対しても、障害物を越えて砲撃を加えることができる(他の味方ユニットがその敵を見ることができる場合に限る)。他の攻城兵器と同様に、白兵ユニットを苦手としている。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">テクノロジーが進化するにつれ、大砲はますます重要な兵器になると考えられていた。ナポレオン戦争やアメリカ南北戦争で見られた19世紀の機関砲はなくなり、時とともにより大きく、より正確でかつ致命的な兵器へと取って代わっていった。ドイツ軍の88ミリ砲は、第二次世界大戦で使われた大砲の中で、最も万能で優れた兵器の1つである。元々は対航空機砲として開発された88ミリ砲は、他の兵器が1つの目的のためだけに生産されている中で、対戦車兵器としても優秀であることが証明されたのである。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

