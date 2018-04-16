<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 戦車弓兵</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_CHARIOT_ARCHER.png" alt="戦車弓兵" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">56 <img src="/civilopedia/images/production.png" alt="production" /> / 112 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>戦闘のタイプ:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">弓術ユニット</div></div></div></div></div></div></div></div>
		<h2>戦闘力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">6 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">10 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃範囲:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2</div></div></div></div></div></div></div></div>
		<h2>移動力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">4 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>能力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_ROUGH_TERRAIN_ENDS_TURN.aspx" onmouseover="return tooltip('起伏に富んだ地形でのペナルティ');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('地形による防御ボーナスなし');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('白兵攻撃不可');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		<h2>必要な資源:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="RESOURCE_HORSE.aspx" onmouseover="return tooltip('馬');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_HORSE.png" /></a></div></div></div></div></div></div></div></div>
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_THE_WHEEL.aspx" onmouseover="return tooltip('車輪');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_THE_WHEEL.png" /></a></div></div></div></div></div></div></div></div>
		<h2>陳腐化するテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_CHIVALRY.aspx" onmouseover="return tooltip('騎士道');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_CHIVALRY.png" /></a></div></div></div></div></div></div></div></div>
		<h2>上位ユニット：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_KNIGHT.aspx" onmouseover="return tooltip('騎士');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_KNIGHT.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">戦車弓兵</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">機動力のある遠隔攻撃ユニットであり、平地で特に高い能力を発揮する。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">戦車弓兵は移動速度の速い遠隔攻撃ユニットで、平坦な地形でその実力を発揮する。攻撃力は弓兵よりもやや強力で、移動速度は2倍となっている。ただしこのユニットは、森林やジャングル、そして丘陵で移動ペナルティーを受ける(道が敷かれている場合を除く)。騎乗ユニットなので槍兵が弱点となる。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">あぶみの発明以前は、馬上で戦うことは実質不可能であった。体を固定する方法などなく、わずかな動きでも落馬し悲惨な結果になりかねなかったのである。当初、戦場にはチャリオットを引いた馬が登場した。1台のチャリオットは通常1頭から2頭の馬と運転士、それに弓兵で構成されていた。チャリオットはその機動力からとりわけ歩兵にとって危険な存在となった。素早く射程内に入って一斉に矢を放ち、足を取られた兵士たちが近づいてくる前に逃げ出すことができるからである。戦車弓兵の最大の弱点は、峻嶮な地形に対応できないことであった。広い平地では古代戦場の王であった戦車弓兵も、丘陵地帯や森林での戦いには非常に不利であった。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

