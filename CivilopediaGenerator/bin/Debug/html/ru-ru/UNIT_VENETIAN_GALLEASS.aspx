<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: Великий галеас</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_VENETIAN_GALLEASS.png" alt="Великий галеас" class="contentimage" />
	<div class="contentleft">
		<h2>Стоимость:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">110 <img src="/civilopedia/images/production.png" alt="production" /></div></div></div></div></div></div></div></div>
		<h2>Тип юнита:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">кораблей дальн. боя</div></div></div></div></div></div></div></div>
		<h2>Бой:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">18 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>Дальний бой:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">20 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>Радиус:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2</div></div></div></div></div></div></div></div>
		<h2>Перемещение:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">3 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>Цивилизация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CIVILIZATION_VENICE.aspx" onmouseover="return tooltip('Венецианская республика');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/CIVILIZATION_VENICE.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Возможности:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('Не может атаковать в ближнем бою');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_OCEAN_IMPASSABLE.aspx" onmouseover="return tooltip('Не может выйти в океан');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>Нужные технологии:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_COMPASS.aspx" onmouseover="return tooltip('Компас');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_COMPASS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Устаревает после:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_NAVIGATION.aspx" onmouseover="return tooltip('Навигация');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_NAVIGATION.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Модернизировать</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_FRIGATE.aspx" onmouseover="return tooltip('Фрегат');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_FRIGATE.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Замещает:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_GALLEASS.aspx" onmouseover="return tooltip('Галеас');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_GALLEASS.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">Великий галеас</div>
		<h2>Игровая информация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Могучее судно эпохи Средневековья, позволяющее побороться за господство на море при помощи дистанционной атаки. Имеет показатели атаки и защиты выше, чем у обычного галеаса, но и стоит дороже. Строить их могут только венецианцы.</div></div></div></div></div></div></div></div>
		<h2>Описание:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Великие галеасы замещают галеасы, и строить их могут только венецианцы. У них более мощная дистанционная атака, они более прочные и стоят дороже, чем обычные галеасы.</div></div></div></div></div></div></div></div>
		<h2>Историческая информация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Галеасы появились в результате усовершенствования крупных торговых галер и практически не менялись до 1660 года, когда венецианцы построили свой первый линейный корабль. Обычно у галеасов было три мачты с косыми парусами. Для увеличения скорости галеасы оснащались дополнительными парусами и веслами. Над головами гребцов у этих венецианских военных кораблей была орудийная палуба. Галеасы продолжали бороздить Средиземное море еще долгое время после того, как появились более крупные, надежные и устойчивые военные корабли других стран. </div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

