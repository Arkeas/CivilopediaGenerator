<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: Artiglieria</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_ARTILLERY.png" alt="Artiglieria" class="contentimage" />
	<div class="contentleft">
		<h2>Costo:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">250 <img src="/civilopedia/images/production.png" alt="production" /> / 500 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>Tipo di combattimento:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Armi d'assedio</div></div></div></div></div></div></div></div>
		<h2>Combattimento:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">21 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>Combattimento a distanza:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">28 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>Raggio d'azione:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">3</div></div></div></div></div></div></div></div>
		<h2>Movimento:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>Abilit&agrave;:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_INDIRECT_FIRE.aspx" onmouseover="return tooltip('Fuoco indiretto');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_35.png" /></a><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('Non può attaccare in mischia');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('Bonus contro le citt&agrave; (200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('Nessun bonus difensivo per terreno');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('Deve eseguire l\'allestimento per attaccare a distanza');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('Visibilit&agrave; limitata');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>Tecnologie propedeutiche:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_DYNAMITE.aspx" onmouseover="return tooltip('Dinamite');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_DYNAMITE.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>Aggiorna unit&agrave;</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_ROCKET_ARTILLERY.aspx" onmouseover="return tooltip('Artiglieria lanciarazzi');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_ROCKET_ARTILLERY.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">Artiglieria</div>
		<h2>Informazione sulla partita:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">La prima unit&agrave; d'assedio del gioco, può tirare a una distanza di 3 caselle. Deve eseguire l'allestimento prima di attaccare.</div></div></div></div></div></div></div></div>
		<h2>Strategia:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">L'Artiglieria &egrave; un'arma d'assedio di potenza letale, pi&ugrave; potente dei cannoni e dotata di un raggio di tiro maggiore. Come il cannone, ha visibilit&agrave; limitata e dev'essere allestita (al costo di un 1 PM) prima di attaccare; fatto questo, comunque, ha una terribile forza di combattimento a distanza. Inoltre ha l'abilit&agrave; di fuoco indiretto, che le consente di tirare al di l&agrave; degli ostacoli contro bersagli che non &egrave; in grado di vedere direttamente (a patto che siano visibili ad altre unit&agrave; amiche). Come tutte le altre armi d'assedio, anche l'Artiglieria &egrave; vulnerabile agli attacchi ravvicinati. </div></div></div></div></div></div></div></div>
		<h2>Informazioni storiche:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Con l'avanzare del progresso tecnologico l'artiglieria ha assunto un'importanza sempre maggiore sul campo di battaglia. Con il passare degli anni i cannoni dell'epoca napoleonica e della guerra civile americana sono stati rimpiazzati da armi sempre pi&ugrave; potenti, accurate e letali. Il cannone tedesco da 88 mm &egrave; uno dei pezzi d'artiglieria pi&ugrave; potenti e versatili della Seconda Guerra Mondiale. Originariamente progettato per l'antiaerea, si rivelò così efficace come arma anticarro che ne furono create diverse varianti proprio a quello scopo.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

