<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: テルシオ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_SPANISH_TERCIO.png" alt="テルシオ" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">160 <img src="/civilopedia/images/production.png" alt="production" /> / 320 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>戦闘のタイプ:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">白兵ユニット</div></div></div></div></div></div></div></div>
		<h2>戦闘力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">26 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		
		
		<h2>移動力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>文明:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CIVILIZATION_SPAIN.aspx" onmouseover="return tooltip('スペイン帝国');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/CIVILIZATION_SPAIN.png" /></a></div></div></div></div></div></div></div></div>
		<h2>能力:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_ANTI_MOUNTED_I.aspx" onmouseover="return tooltip('対騎乗ボーナス(50)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_GUNPOWDER.aspx" onmouseover="return tooltip('火薬');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_GUNPOWDER.png" /></a></div></div></div></div></div></div></div></div>
		<h2>陳腐化するテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_RIFLING.aspx" onmouseover="return tooltip('ライフリング');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_RIFLING.png" /></a></div></div></div></div></div></div></div></div>
		<h2>上位ユニット：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_RIFLEMAN.aspx" onmouseover="return tooltip('ライフル兵');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_RIFLEMAN.png" /></a></div></div></div></div></div></div></div></div>
		<h2>同種ユニット:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_MUSKETMAN.aspx" onmouseover="return tooltip('マスケット兵');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_MUSKETMAN.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">テルシオ</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">ルネサンス時代の有力な軍事ユニット。スペインのみ生産可能。対騎乗ボーナスを所持しており、代替元であるマスケット銃兵より高い<img src="/civilopedia/images/strength.png" alt="strength" />戦闘力を誇る。ただし、生産コストはこちらの方が高い。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">テルシオは2つあるスペイン固有ユニットの1つであり、他文明ではマスケット銃兵に当たる。マスケット銃兵より戦闘力が高く、対騎乗ユニット戦でその能力を発揮する。ただし、生産コストはこちらの方が高い。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">優れた軍事発明であるテルシオは、長槍兵と火縄銃兵(原始的な火器で武装した兵)で構成される布陣で、16世紀初期にスペインの将軍ゴンサロ・フェルナンデス・デ・コルドバによって考案された。テルシオ(スペイン方陣とも呼ばれる)では、格子状に陣形を組み、お互いを守るように長槍兵と火縄銃兵を配置する。この方陣の有利な点は、遠距離では火縄銃兵が攻撃を行い、近距離では長槍兵が使用できることである。その後この布陣は、1世紀以上に渡り、ルネサンス期の戦争で無類の強さを誇るようになった。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

