<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: Catapulta</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_CATAPULT.png" alt="Catapulta" class="contentimage" />
	<div class="contentleft">
		<h2>Coste:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">75 <img src="/civilopedia/images/production.png" alt="production" /> / 150 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>Tipo de combate:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Armas de asedio</div></div></div></div></div></div></div></div>
		<h2>Combate:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">7 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>Combate a distancia:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">8 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>Alcance:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2</div></div></div></div></div></div></div></div>
		<h2>Movimiento:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>Capacidades:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('No puede atacar cuerpo a cuerpo');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('Bonificaci&oacute;n contra ciudades (200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('Sin bonificaciones defensivas por terreno');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('Desplegarse y atacar a distancia');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('Visibilidad limitada');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>Tecnolog&iacute;as necesarias:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_MATHEMATICS.aspx" onmouseover="return tooltip('Matem&aacute;ticas');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_MATHEMATICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Queda obsoleta con:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_PHYSICS.aspx" onmouseover="return tooltip('F&iacute;sica');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_PHYSICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>Modernizar unidad</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_TREBUCHET.aspx" onmouseover="return tooltip('Trabuquete');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_TREBUCHET.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">Catapulta</div>
		<h2>Informaci&oacute;n de la partida:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Primera unidad de asedio del juego. Inflige un gran da&ntilde;o a las unidades y ciudades desde lejos, pero debe desplegarse antes de disparar.</div></div></div></div></div></div></div></div>
		<h2>Estrategia:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">La Catapulta es un arma de asedio, extremadamente &uacute;til para asaltar las primeras ciudades enemigas. Es lenta y muy vulnerable a los ataques cuerpo a cuerpo del enemigo y, mientras se encuentre en el campo, siempre ha de contar con el apoyo de otras unidades. Para poder atacar, la Catapulta ha de "desplegarse" (1 punto de movimiento).</div></div></div></div></div></div></div></div>
		<h2>Informaci&oacute;n hist&oacute;rica:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">Se desconoce la fecha exacta de la invenci&oacute;n de la catapulta, pero s&iacute; se sabe que los griegos ya la empleaban en el siglo III a. C. Las catapultas aprovechan la energ&iacute;a acumulada en una cuerda retorcida o madera doblada para lanzar proyectiles a grandes distancias. Son bastante imprecisas, pero pueden ser mortales contra objetivos grandes o lentos, como las fortificaciones. Sol&iacute;an transportarse en piezas que despu&eacute;s se ensamblaban en el mismo campo de batalla. A veces eran construidas in situ por los ingenieros. Las &uacute;ltimas catapultas se vieron en la Primera Guerra Mundial; los franceses las usaron para arrojar granadas a las trincheras enemigas.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

