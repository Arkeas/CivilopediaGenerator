<%@ Page Title="" Language="VB" MasterPageFile="Technologies.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: гильдий</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/TECH_GUILDS.png" alt="гильдий" class="contentimage" />
	<div class="contentleft">
		<h2>Стоимость:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">275 <img src="/civilopedia/images/research.png" alt="research" /></div></div></div></div></div></div></div></div>
		<h2>Нужные технологии:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_CURRENCY.aspx" onmouseover="return tooltip('денег');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_CURRENCY.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Ведет к технологиям:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_CHIVALRY.aspx" onmouseover="return tooltip('Рыцарство');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_CHIVALRY.png" /></a><a href="TECH_MACHINERY.aspx" onmouseover="return tooltip('Машиностроение');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_MACHINERY.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>Открывает здания:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="BUILDING_NATIONAL_TREASURY.aspx" onmouseover="return tooltip('Ост-Индская компания');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_NATIONAL_TREASURY.png" /></a><a href="BUILDING_MACHU_PICHU.aspx" onmouseover="return tooltip('Мачу-Пикчу');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_MACHU_PICHU.png" /></a><a href="BUILDING_ARTISTS_GUILD.aspx" onmouseover="return tooltip('Гильдия художников');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_ARTISTS_GUILD.png" /></a></div></div></div></div></div></div></div></div>
        
		
		<h2>Открывает действия:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="IMPROVEMENT_POLDER.aspx" onmouseover="return tooltip('Создать польдер');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/IMPROVEMENT_POLDER.png" /></a><a href="IMPROVEMENT_TRADING_POST.aspx" onmouseover="return tooltip('Построить торг. пост');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/IMPROVEMENT_TRADING_POST.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">гильдий</div>
		<h2>Игровая информация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Позволяет рабочим строить <span class="color_positive_text">торговые посты</span>, повышающие производство <img src="/civilopedia/images/gold.png" alt="gold" /> золота на клетке. Кроме того, ваши города смогут превращать <img src="/civilopedia/images/production.png" alt="production" /> продукцию в <img src="/civilopedia/images/gold.png" alt="gold" /> золото, вместо того чтобы расходовать ее на здания или юниты.</div></div></div></div></div></div></div></div>
		
		<h2>Цитата:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><br />"Пришли купцы и торговцы; их прибыли предопределены...".<br /> - Шри Гуру Грант Сахиб<br /></div></div></div></div></div></div></div></div>
		<h2>Историческая информация:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Ремесленная гильдия - это профессиональное объединение мастеров. Гильдии сохраняли секреты ремесла и заботились о благосостоянии и процветании своих членов. Ремесленные гильдии, или цеха, возникли задолго до начала индустриализации: подобные организации существовали уже в III в. до н.э. в Древнем Риме и Ханьском Китае. К началу IV в. н.э. союзы ремесленников появились в эллинистическом Египте и государстве Гуптов (Индия). В эпоху Средневековья обычай создавать гильдии распространился из Италии по всей Европе. В парижских и лондонских документах XII в. упоминается более сотни гильдий, учрежденных городскими властями. В некоторых случаях в руках гильдий было сосредоточено больше власти, чем у городской управы. Чтобы убедиться в этом, стоит лишь взглянуть на дома гильдий в Германии, Швейцарии и Голландии. <br /><br />Со временем гильдии стали гарантами качества выпускаемой продукции и непрерывности ремесленных традиций. Именно в гильдиях устоялась концепция товарного знака. Товарный знак означал, что то или иное изделие соответствует государственным стандартам и стандартам цеха. Кроме того, гильдии сами обучали новых работников. Теоретически, любой член гильдии мог пойти путь от подмастерья до главы цеха. Упадок ремесленных цехов начался из-за трений с правительством, чрезмерной раздробленности гильдий из-за возникновения новых видов ремесел, а также из-за растущих объемов серийного производства. Во Франции закон Ле Шапелье упразднил гильдии в 1791 г. Схожим образом ситуация развивалась и в других странах. С наступлением индустриализации на смену ремесленным цехам пришли профсоюзы, однако гильдии не по-прежнему не забыты. В наши дни это форма объединения людей творческих профессий.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

