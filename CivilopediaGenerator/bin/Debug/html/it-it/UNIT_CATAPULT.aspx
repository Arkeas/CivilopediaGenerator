﻿<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: Catapulta</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_CATAPULT.png" alt="Catapulta" class="contentimage" />
	<div class="contentleft">
		<h2>Costo:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">75 <img src="/civilopedia/images/production.png" alt="production" /> / 150 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>Tipo di combattimento:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Armi d'assedio</div></div></div></div></div></div></div></div>
		<h2>Combattimento:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">7 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>Combattimento a distanza:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">8 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>Raggio d'azione:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2</div></div></div></div></div></div></div></div>
		<h2>Movimento:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>Abilit&agrave;:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('Non può attaccare in mischia');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('Bonus contro le citt&agrave; (200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('Nessun bonus difensivo per terreno');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('Deve eseguire l\'allestimento per attaccare a distanza');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('Visibilit&agrave; limitata');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>Tecnologie propedeutiche:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_MATHEMATICS.aspx" onmouseover="return tooltip('Matematica');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_MATHEMATICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Diventa obsoleto con:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_PHYSICS.aspx" onmouseover="return tooltip('Fisica');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_PHYSICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Aggiorna unit&agrave;</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_TREBUCHET.aspx" onmouseover="return tooltip('Trabocco');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_TREBUCHET.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">Catapulta</div>
		<h2>Informazione sulla partita:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Prima unit&agrave; d'assedio del gioco. Infligge gravi danni alle unit&agrave; e alle citt&agrave; attaccando da lontano, ma prima di tirare deve eseguire l'allestimento.</div></div></div></div></div></div></div></div>
		<h2>Strategia:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">La Catapulta &egrave; un'arma d'assedio, utilissima per assaltare le citt&agrave; nemiche. Si tratta di un'unit&agrave; lenta, estremamente vulnerabile agli attacchi nemici; pertanto dev'essere sempre protetta da altre unit&agrave;. La Catapulta dev'essere allestita (al costo di un 1 punto movimento) prima di poter attaccare.</div></div></div></div></div></div></div></div>
		<h2>Informazioni storiche:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">La data esatta dell'invenzione della catapulta &egrave; ignota, ma i Greci la utilizzavano gi&agrave; nel III secolo a.C. Le catapulte lanciano proiettili a grande distanza grazie all'energia immagazzinata in corde ritorte o legno piegato. Non sono molto precise, ma possono essere mortali contro bersagli grandi o lenti, come ad esempio le fortificazioni (che sono piuttosto grosse e non si muovono affatto). In genere le catapulte erano trasportate in pezzi e assemblate sul campo di battaglia. Occasionalmente potevano anche essere costruite sul posto dai genieri. Le ultime catapulte furono usate nella Prima Guerra Mondiale dai francesi per lanciare granate nelle trincee nemiche.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

