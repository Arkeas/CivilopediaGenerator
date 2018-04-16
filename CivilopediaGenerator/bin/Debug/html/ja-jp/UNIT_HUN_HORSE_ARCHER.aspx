<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 弓騎兵</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_HUN_HORSE_ARCHER.png" alt="弓騎兵" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">56 <img src="/civilopedia/images/production.png" alt="production" /> / 112 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>戦闘のタイプ:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">弓術ユニット</div></div></div></div></div></div></div></div>
		<h2>戦闘力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">7 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">10 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃範囲:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2</div></div></div></div></div></div></div></div>
		<h2>移動力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">4 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>文明:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CIVILIZATION_HUNS.aspx" onmouseover="return tooltip('フン帝国');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/CIVILIZATION_HUNS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>能力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('地形による防御ボーナスなし');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('白兵攻撃不可');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_ACCURACY_1.aspx" onmouseover="return tooltip('命中率 I');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_0.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_THE_WHEEL.aspx" onmouseover="return tooltip('車輪');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_THE_WHEEL.png" /></a></div></div></div></div></div></div></div></div>
		<h2>陳腐化するテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_CHIVALRY.aspx" onmouseover="return tooltip('騎士道');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_CHIVALRY.png" /></a></div></div></div></div></div></div></div></div>
		<h2>上位ユニット：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_KNIGHT.aspx" onmouseover="return tooltip('騎士');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_KNIGHT.png" /></a></div></div></div></div></div></div></div></div>
		<h2>同種ユニット:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_CHARIOT_ARCHER.aspx" onmouseover="return tooltip('戦車弓兵');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_CHARIOT_ARCHER.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">弓騎兵</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">一撃離脱による攻撃に使用できる、機動力のある遠隔攻撃ユニット。フン族だけが作成できる。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">弓騎兵は機動力のある遠隔攻撃ユニットであり、平坦な大地で強力な力を発揮する。戦車弓兵よりも若干防御力が高く、起伏に富んだ地形でも戦車弓兵の移動ペナルティを受けることなく移動することができる。また、最初から「命中率 I」のレベルアップを保有している。騎乗ユニットであるため、槍兵を弱点としている。また、戦車弓兵と違って馬を必要としない。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">恐るべきフン族の騎兵は弓術と馬術に優れることで知られ、4世紀から5世紀にかけてヨーロッパを席巻し、大きな災禍をもたらした。フン族の弓騎兵は強力な複合弓を使い、中央アジアの草原地帯で狩りをしながら腕を磨いた。彼らにとって、人間相手の戦いに狩猟技術を転用することは造作なかったに違いない。フン族の襲来以降、騎兵が格段に重視されるようになった。フン族による弓騎兵の活用は、ヨーロッパとアジアの諸王国における後世の軍事研究に多大な影響を及ぼしたと言われている。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

