﻿<%@ Page Title="" Language="VB" MasterPageFile="Technologies.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: Lavorazione del bronzo</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/TECH_BRONZE_WORKING.png" alt="Lavorazione del bronzo" class="contentimage" />
	<div class="contentleft">
		<h2>Costo:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">55 <img src="/civilopedia/images/research.png" alt="research" /></div></div></div></div></div></div></div></div>
		<h2>Tecnologie propedeutiche:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_MINING.aspx" onmouseover="return tooltip('Estrazione mineraria');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_MINING.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Conduce alle tecnologie:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_IRON_WORKING.aspx" onmouseover="return tooltip('Lavorazione del ferro');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_IRON_WORKING.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Unit&agrave; sbloccate:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_CELT_PICTISH_WARRIOR.aspx" onmouseover="return tooltip('Guerriero Pitto');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_CELT_PICTISH_WARRIOR.png" /></a><a href="UNIT_HUN_BATTERING_RAM.aspx" onmouseover="return tooltip('Ariete');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_HUN_BATTERING_RAM.png" /></a><a href="UNIT_SPEARMAN.aspx" onmouseover="return tooltip('Lanciere');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_SPEARMAN.png" /></a><a href="UNIT_GREEK_HOPLITE.aspx" onmouseover="return tooltip('Oplita');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_GREEK_HOPLITE.png" /></a><a href="UNIT_PERSIAN_IMMORTAL.aspx" onmouseover="return tooltip('Immortale');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_PERSIAN_IMMORTAL.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Edifici sbloccati:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="BUILDING_STATUE_ZEUS.aspx" onmouseover="return tooltip('Statua di Zeus');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_STATUE_ZEUS.png" /></a><a href="BUILDING_KREPOST.aspx" onmouseover="return tooltip('Krepost');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_KREPOST.png" /></a><a href="BUILDING_BARRACKS.aspx" onmouseover="return tooltip('Caserma');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_BARRACKS.png" /></a><a href="BUILDING_IKANDA.aspx" onmouseover="return tooltip('Ikanda');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_IKANDA.png" /></a></div></div></div></div></div></div></div></div>
        
		<h2>Risorse rivelate:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="RESOURCE_IRON.aspx" onmouseover="return tooltip('Ferro');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_IRON.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Azioni permesse:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CONCEPT_WORKERS_CLEARINGLAND.aspx" onmouseover="return tooltip('Elimina la Giungla');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/IMPROVEMENT_REMOVE_JUNGLE.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">Lavorazione del bronzo</div>
		<h2>Informazione sulla partita:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Rivela la posizione dei giacimenti di <img src="/civilopedia/images/res_iron.png" alt="iron" /> <span class="color_positive_text">Ferro</span> e permette ai tuoi lavoratori di <span class="color_positive_text">Disboscare la giungla</span>, liberando la casella e permettendo la costruzione di miglioramenti. Ti permette anche di costruire il <span class="color_positive_text">Lanciere</span>, un'unit&agrave; militare particolarmente indicata contro i nemici a cavallo.</div></div></div></div></div></div></div></div>
		
		<h2>Citazione:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><br />"Ed ecco che entrò Ettore, impugnando una lancia lunga undici cubiti; la punta di bronzo brillava davanti a lui ed era fissata all'asta con un anello d'oro."<br /> - Omero<br /></div></div></div></div></div></div></div></div>
		<h2>Informazioni storiche:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Il bronzo &egrave; una lega metallica formata da rame e stagno. Il materiale risultante &egrave; pi&ugrave; resistente di entrambi i componenti e pi&ugrave; facile da fondere e lavorare (ad esempio versandolo in stampi per creare punte di lancia e altri oggetti utili). Il rame &egrave; stato usato per la prima volta in Egitto, probabilmente ancor prima del 5000 a.C. Il primo oggetto di bronzo risale a circa 1.300 anni pi&ugrave; tardi: un bastone, ritrovato in una piramide del 3700 a.C. In Asia il bronzo &egrave; comparso molto dopo, intorno al 1500 a.C., e nelle Americhe ancora pi&ugrave; tardi, tra il 100 e il 200 d.C.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

