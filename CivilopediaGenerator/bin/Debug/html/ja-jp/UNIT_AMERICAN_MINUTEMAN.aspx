<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: ミニットマン</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_AMERICAN_MINUTEMAN.png" alt="ミニットマン" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">150 <img src="/civilopedia/images/production.png" alt="production" /> / 300 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>戦闘のタイプ:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">火器ユニット</div></div></div></div></div></div></div></div>
		<h2>戦闘力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">24 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		
		
		<h2>移動力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>文明:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CIVILIZATION_AMERICA.aspx" onmouseover="return tooltip('アメリカ文明');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/CIVILIZATION_AMERICA.png" /></a></div></div></div></div></div></div></div></div>
		<h2>能力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_IGNORE_TERRAIN_COST.aspx" onmouseover="return tooltip('地形による消費ポイントを無視');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_DRILL_1.aspx" onmouseover="return tooltip('訓練 I');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_19.png" /></a><a href="PROMOTION_GOLDEN_AGE_POINTS.aspx" onmouseover="return tooltip('勝利がもたらす黄金時代');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_EXP_2.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_GUNPOWDER.aspx" onmouseover="return tooltip('火薬');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_GUNPOWDER.png" /></a></div></div></div></div></div></div></div></div>
		<h2>陳腐化するテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_RIFLING.aspx" onmouseover="return tooltip('ライフリング');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_RIFLING.png" /></a></div></div></div></div></div></div></div></div>
		<h2>上位ユニット：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_RIFLEMAN.aspx" onmouseover="return tooltip('ライフル兵');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_RIFLEMAN.png" /></a></div></div></div></div></div></div></div></div>
		<h2>同種ユニット:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_MUSKETMAN.aspx" onmouseover="return tooltip('マスケット兵');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_MUSKETMAN.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">ミニットマン</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">初期の火薬ユニットの1つ。建設できるのはアメリカ人のみで、他の文明のマスケット兵に相当する。このユニットは通行困難なタイルでも平地と同じように移動することができ、険しい地形での戦闘ではボーナスが与えられる。敵を倒すと<img src="/civilopedia/images/golden_age.png" alt="golden age" />黄金時代の開始に必要なポイントが得られる。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">ミニットマンはアメリカ固有のユニットで、他の文明のマスケット兵に相当する。通行困難なタイルでも開けたタイルと同じように移動することができ（1タイルにつき1mpを消費）、険しい地形での戦闘ではボーナスが与えられる。敵を倒すと<img src="/civilopedia/images/golden_age.png" alt="golden age" />黄金時代を開始するために必要なポイントが得られる。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">アメリカ革命戦争中に起用されたアメリカのミニットマンとは、植民地側の民兵組織に属する鋭兵のことを指す。彼らは「即時対応」な軍隊で、敵の攻撃に素早く反応できるよう訓練を受けており、通常の軍隊(ミニットマン以外の民兵も同様)が戦いに備える時間を稼ぐための部隊である。実はミニットマンはアメリカ革命以前から存在する。マサチューセッツ湾植民地には、古くは1645年に民兵の中でミニットマンに任命された兵士たちがいた。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

