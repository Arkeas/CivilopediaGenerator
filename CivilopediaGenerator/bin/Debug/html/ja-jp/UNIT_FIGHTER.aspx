<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 戦闘機</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_FIGHTER.png" alt="戦闘機" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">375 <img src="/civilopedia/images/production.png" alt="production" /></div></div></div></div></div></div></div></div>
		<h2>戦闘のタイプ:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">戦闘機ユニット</div></div></div></div></div></div></div></div>
		
		<h2>遠隔攻撃力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">45 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>遠隔攻撃範囲:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">8</div></div></div></div></div></div></div></div>
		<h2>移動力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>能力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_INTERCEPTION_IV.aspx" onmouseover="return tooltip('迎撃(100)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_58.png" /></a><a href="PROMOTION_AIR_SWEEP.aspx" onmouseover="return tooltip('掃射');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_58.png" /></a><a href="PROMOTION_AIR_RECON.aspx" onmouseover="return tooltip('空中偵察');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_58.png" /></a><a href="PROMOTION_ANTI_AIR_II.aspx" onmouseover="return tooltip('対爆撃機・ヘリコプターボーナス(150)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a></div></div></div></div></div></div></div></div>
		<h2>必要な資源:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="RESOURCE_OIL.aspx" onmouseover="return tooltip('石油');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_OIL.png" /></a></div></div></div></div></div></div></div></div>
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_RADAR.aspx" onmouseover="return tooltip('レーダー');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_RADAR.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>上位ユニット：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_JET_FIGHTER.aspx" onmouseover="return tooltip('ジェット戦闘機');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_JET_FIGHTER.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">戦闘機</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">制空権を支配し、敵機を迎撃する能力を有する航空ユニット。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">戦闘機はそこそこ強力な航空ユニットである。所有している都市であればどこでも基地にすることができ、航空母艦への搭載も可能となっている。8タイル以内であれば、基地から基地(または母艦)へと移動する事ができ、「ミッション」を遂行することもできる。戦闘機は、敵の航空ユニットや地上ユニットへの攻撃、敵の位置を把握するための偵察、敵の爆撃に対する迎撃などに使用すると良い。またこのユニットは、対ヘリコプター戦を非常に得意としている。詳細については航空ユニットのルールを参照のこと。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">戦闘機は第一次世界大戦中に発達した航空機である。初期の「戦闘機」は機関銃が搭載された、自力推進の凧とあまり変わらなかった。第二次世界大戦までに技術と原理が大きく向上し、命を脅かすプラットフォームとして一枚翼で装甲した航空機を作り上げた。戦闘機の主な役割は、戦場上空の制空権を獲得し、敵の航空機を墜落させるか追い払い、仲間の爆撃機が邪魔されることなく、空から敵の領土や海軍に攻撃を行えるようにすることであった。戦闘機の中には陸上部隊に対して使用するための爆弾を積載しているものもあるが、爆弾がなくても陸上や海上の敵軍に対して非常に効果が高い、機銃掃射を行うことができる。<br /><br />現代のジェット戦闘機は、第二次世界大戦の頃のものより、さらに速く、より強力な兵器と装甲を装備している。しかし、空中戦での原則は当時と変わらず、制空権を握った者が敵を大きくリードできる。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

