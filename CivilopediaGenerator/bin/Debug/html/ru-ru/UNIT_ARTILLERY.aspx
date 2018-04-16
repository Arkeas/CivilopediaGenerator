<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: Артиллерийская батарея</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_ARTILLERY.png" alt="Артиллерийская батарея" class="contentimage" />
	<div class="contentleft">
		<h2>Стоимость:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">250 <img src="/civilopedia/images/production.png" alt="production" /> / 500 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>Тип юнита:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">осадных орудий</div></div></div></div></div></div></div></div>
		<h2>Бой:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">21 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>Дальний бой:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">28 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>Радиус:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">3</div></div></div></div></div></div></div></div>
		<h2>Перемещение:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>Возможности:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_INDIRECT_FIRE.aspx" onmouseover="return tooltip('Огонь с закрытых позиций');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_35.png" /></a><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('Не может атаковать в ближнем бою');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('Бонус против городов (200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('Не получает бонусов от местности в обороне');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('Нужна подготовка перед стрельбой');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('Ограниченная видимость');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>Нужные технологии:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_DYNAMITE.aspx" onmouseover="return tooltip('Динамит');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_DYNAMITE.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>Модернизировать</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_ROCKET_ARTILLERY.aspx" onmouseover="return tooltip('РСЗО');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_ROCKET_ARTILLERY.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">Артиллерийская батарея</div>
		<h2>Игровая информация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Мощный осадный юнит Новейшего времени. Перед ведением огня требуется развертывание.</div></div></div></div></div></div></div></div>
		<h2>Описание:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Смертоносное осадное орудие, более мощное и дальнобойное, чем пушки. Как и в случае с пушкой, артиллерийская батарея имеет ограниченный обзор, и ей необходимо подготовить орудия (1 очко движения) к стрельбе, зато мощь ее атаки очень высока. Кроме того, артиллерийская батарея может вести огонь с закрытых позиций, то есть обстреливать цели вне зоны видимости, если их видит дружественный юнит. Как и другие осадные орудия, артиллерийская батарея уязвима в ближнем бою.</div></div></div></div></div></div></div></div>
		<h2>Историческая информация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">По мере развития технологий артиллерия приобретала все большее значение на поле боя. В XIX веке пушки Наполеоновских войн и Гражданской войны в Америке быстро устарели. Им на смену пришли более точные и смертоносные орудия. Немецкая 88-мм пушка - один из лучших образцов артиллерии Второй мировой войны. Изначально она разрабатывалась как зенитное орудие, но настолько хорошо зарекомендовала себя против танков, что некоторые варианты создавались специально для этих целей.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

