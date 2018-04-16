<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: баллист</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_ROMAN_BALLISTA.png" alt="баллист" class="contentimage" />
	<div class="contentleft">
		<h2>Стоимость:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">75 <img src="/civilopedia/images/production.png" alt="production" /> / 150 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>Тип юнита:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">осадных орудий</div></div></div></div></div></div></div></div>
		<h2>Бой:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">8 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>Дальний бой:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">10 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>Радиус:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2</div></div></div></div></div></div></div></div>
		<h2>Перемещение:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		<h2>Цивилизация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CIVILIZATION_ROME.aspx" onmouseover="return tooltip('Римская империя');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/CIVILIZATION_ROME.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Возможности:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('Не может атаковать в ближнем бою');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('Бонус против городов (200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('Не получает бонусов от местности в обороне');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('Нужна подготовка перед стрельбой');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('Ограниченная видимость');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>Нужные технологии:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_MATHEMATICS.aspx" onmouseover="return tooltip('Математика');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_MATHEMATICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Устаревает после:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_PHYSICS.aspx" onmouseover="return tooltip('Физика');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_PHYSICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Модернизировать</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_TREBUCHET.aspx" onmouseover="return tooltip('требушетов');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_TREBUCHET.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Замещает:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_CATAPULT.aspx" onmouseover="return tooltip('катапульт');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_CATAPULT.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">баллист</div>
		<h2>Игровая информация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Осадный юнит, обладающий мощнейшей дальнобойной атакой. Для его подготовки к бою требуется время. Строить его могут только римляне. Мощь <img src="/civilopedia/images/range_strength.png" alt="range strength" /> дальнего боя у этого юнита выше, чем у катапульт, которые он замещает.</div></div></div></div></div></div></div></div>
		<h2>Описание:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Римское уникальное подразделение, более мощное по сравнению с обычными катапультами. Баллисты - превосходное осадное орудие. Они весьма эффективны против городов, но уязвимы для нападения пехотинцев. Не забывайте защищать свои баллисты другими боевыми подразделениями. Перед атакой баллисты необходимо подготовить, на что уходит 1 очко передвижения.</div></div></div></div></div></div></div></div>
		<h2>Историческая информация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Римские баллисты - это усовершенствованная разновидность катапульт. С их помощью во врага метали камни или деревянные снаряды. Баллиста, сооруженная из дерева и укрепленная металлическими пластинами, была на удивление точным оружием в руках подготовленных воинов. Дальность ее стрельбы достигала примерно 450 м. Эффективная дальность стрельбы - в особенности против вражеских укреплений - была значительно меньше. Юлий Цезарь использовал баллисты в походах против германцев и бриттов.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

