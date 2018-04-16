<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 戦列艦</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_ENGLISH_SHIPOFTHELINE.png" alt="戦列艦" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">170 <img src="/civilopedia/images/production.png" alt="production" /></div></div></div></div></div></div></div></div>
		<h2>戦闘のタイプ:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">海軍遠隔攻撃ユニット</div></div></div></div></div></div></div></div>
		<h2>戦闘力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">30 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">35 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃範囲:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2</div></div></div></div></div></div></div></div>
		<h2>移動力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">5 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>文明:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CIVILIZATION_ENGLAND.aspx" onmouseover="return tooltip('イギリス文明');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/CIVILIZATION_ENGLAND.png" /></a></div></div></div></div></div></div></div></div>
		<h2>能力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('白兵攻撃不可');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_EXTRA_SIGHT_I.aspx" onmouseover="return tooltip('追加視界(1)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a></div></div></div></div></div></div></div></div>
		<h2>必要な資源:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="RESOURCE_IRON.aspx" onmouseover="return tooltip('鉄');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_IRON.png" /></a></div></div></div></div></div></div></div></div>
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_NAVIGATION.aspx" onmouseover="return tooltip('航海術');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_NAVIGATION.png" /></a></div></div></div></div></div></div></div></div>
		<h2>陳腐化するテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_ELECTRONICS.aspx" onmouseover="return tooltip('電子工学');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_ELECTRONICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>上位ユニット：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_BATTLESHIP.aspx" onmouseover="return tooltip('戦艦');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_BATTLESHIP.png" /></a></div></div></div></div></div></div></div></div>
		<h2>同種ユニット:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_FRIGATE.aspx" onmouseover="return tooltip('フリゲート艦');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_FRIGATE.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">戦列艦</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">海洋の支配権を掌握するルネサンス時代の強力な海軍ユニット。イギリスのみ生産可能。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">戦列艦はイギリスの固有ユニットで、他の文明ではフリゲート艦に当たる。遠隔戦闘力はフリゲートよりも若干高く、生産コストはフリゲートよりも若干少なくて済む。フリゲートよりも1タイル広い視界を持っているため、非常に広大な海の上でも敵を見つけやすくなっている。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">戦列艦は、これまで造られた帆船の中で最大かつ最強の戦艦で、17世紀から19世紀半ばまでのヨーロッパ海軍の中心を成した。戦列艦というのは、これらの船が戦う時の伝統的な編成から名づけられた。それは両軍の船が敵に向かって一列に近づき、敵の船が通過する際に舷側の大砲を爆音とともに発射し、敵の船と乗員に甚大なダメージを与えるというものであった。より多くの大砲と、熟練の海兵を持つ船が勝利を手にすることが多かった。イギリスはこの形式の戦いを極め、イギリス軍の戦列艦が1世紀以上にもわたり世界の海を支配していたのである。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

