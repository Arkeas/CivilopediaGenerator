<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: Rycerzy</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_KNIGHT.png" alt="Rycerzy" class="contentimage" />
	<div class="contentleft">
		<h2>Koszt:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">120 <img src="/civilopedia/images/production.png" alt="production" /> / 240 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>Typ jednostki:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Konna</div></div></div></div></div></div></div></div>
		<h2>Si&#322;a:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">20 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		
		
		<h2>Ruch:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">4 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>Umiej&#281;tno&#347;ci:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('Bez terenowej premii do obrony');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CAN_MOVE_AFTER_ATTACKING.aspx" onmouseover="return tooltip('Mo&#380;e wykona&#263; ruch po ataku');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_CITY_PENALTY.aspx" onmouseover="return tooltip('Kara przy atakowaniu miasta (33)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Wymagane surowce:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="RESOURCE_HORSE.aspx" onmouseover="return tooltip('Koni');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_HORSE.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Wymaga technologii:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_CHIVALRY.aspx" onmouseover="return tooltip('Rycerstwo');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_CHIVALRY.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Wypierana przez:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_MILITARY_SCIENCE.aspx" onmouseover="return tooltip('Nauk militarnych');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_MILITARY_SCIENCE.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Ulepsz jednostk&#281;</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_CAVALRY.aspx" onmouseover="return tooltip('Kawaleria');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_CAVALRY.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">Rycerzy</div>
		<h2>Informacje o grze:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Pot&#281;&#380;na, &#347;redniowieczna jednostka kawaleryjska, s&#322;aba w walce z pikinierami.</div></div></div></div></div></div></div></div>
		<h2>Strategia:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Rycerze to szybka i silna jednostka, niekwestionowani kr&oacute;lowie &#347;redniowiecznego pola bitwy. Jako jednostka kawaleryjska s&#261; podatni na ataki pikinier&oacute;w, ale z &#322;atwo&#347;ci&#261; mog&#261; zmia&#380;d&#380;y&#263; pozosta&#322;ych przeciwnik&oacute;w. Rycerze mog&#261; si&#281; ruszy&#263; po ataku, dzi&#281;ki czemu mog&#261; tworzy&#263; wy&#322;omy w liniach wroga, a nast&#281;pnie w nie wje&#380;d&#380;a&#263;.</div></div></div></div></div></div></div></div>
		<h2>Informacje historyczne:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Rycerze niemal zawsze wywodzili si&#281; ze szlachty, tylko t&#281; cz&#281;&#347;&#263; spo&#322;ecze&#324;stwa sta&#263; by&#322;o na zakup sprz&#281;tu, utrzymanie konia oraz op&#322;acenie rozbudowanego szkolenia. Byli ci&#281;&#380;k&#261; kawaleri&#261; &#347;redniowiecznej armii. Ze wzgl&#281;du na swoje wyszkolenie i opancerzenie, dominowali na &oacute;wczesnych placach boju. Mimo solidnego opancerzenia byli bardzo mobilni, co pozwala&#322;o im wykorzystywa&#263; ka&#380;d&#261; luk&#281; w liniach wrogach. Jedynym sposobem na szar&#380;uj&#261;cych rycerzy by&#322;a &#347;ciana pikinier&oacute;w. Spos&oacute;b ten dzia&#322;a&#322; jednak tylko wtedy, gdy pikinierzy byli na tyle zdyscyplinowani, by wytrwa&#263; na posterunku, maj&#261;c przed sob&#261; dziesi&#261;tki szar&#380;uj&#261;cych koni. Je&#347;li cho&#263;by zadr&#380;eli, gin&#281;li.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

