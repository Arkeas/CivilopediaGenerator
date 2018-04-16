<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 폭격기</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_BOMBER.png" alt="폭격기" class="contentimage" />
	<div class="contentleft">
		<h2>비용:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">375 <img src="/civilopedia/images/production.png" alt="production" /></div></div></div></div></div></div></div></div>
		<h2>전투 종류: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">폭격 유닛</div></div></div></div></div></div></div></div>
		
		<h2>원거리 전투: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">65 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>사정거리:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">10</div></div></div></div></div></div></div></div>
		<h2>이동:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		
		<h2>필요 자원:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="RESOURCE_OIL.aspx" onmouseover="return tooltip('석유');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_OIL.png" /></a></div></div></div></div></div></div></div></div>
		<h2>기술 조건: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_RADAR.aspx" onmouseover="return tooltip('레이더');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_RADAR.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>유닛 업그레이드:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_STEALTH_BOMBER.aspx" onmouseover="return tooltip('스텔스 폭격기');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_STEALTH_BOMBER.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">폭격기</div>
		<h2>게임 정보:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">상공에서 적 유닛과 도시를 폭격하는 항공 유닛입니다.</div></div></div></div></div></div></div></div>
		<h2>전략:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">폭격기는 공중 유닛입니다. 지상에 있는 목표물에게 가장 효과적이며, 해상 유닛을 폭격할 때는 효과가 떨어지며, 적의 비행기에 취약합니다. 폭격기는 플레이어 소유 도시에 배치할 수도 있고, 항공모함에 탑재할 수도 있습니다. 사정거리인 10타일 내에서 다른 기지로 이동하거나 목표물을 공격할 수 있습니다. 폭격기로 적 유닛과 도시를 공격하세요. 가능하면 전투기를 먼저 보내 해당 턴의 적의 대공 방어 능력을 ‘소진’시키세요. 자세한 정보는 비행기에 대한 규칙을 참고하세요.</div></div></div></div></div></div></div></div>
		<h2>역사적 정보:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">폭격기는 적 병사와 기갑부대 그리고 시설을 파괴하기 위해 설계된 비행기다. 보통 폭격기는 아주 넓은 작전 반경을 가지고 있어서 적 지역 깊숙이 들어가 치명적인 폭탄을 투하할 수 있다. 기관총이나 근접전용 무기가 장착돼 있어도 기본적으로 폭격기는 적 전투기 앞에서는 무력하며 적 전투기로부터 보호해 줄 수 있는 아군 전투기의 호위가 필요하다.<br /><br />모든 주요 열강들은 2차 세계대전 중 폭격기를 운용했다. 독일의 "기습"은 공중 공격으로 영국의 산업(런던과 다른 도시는 말할 것도 없이)을 파괴하는 것이었으며, 이에 대응하여 연합군 폭격기들이 독일의 도시와 공장 그리고 철도 및 기간시설에 엄청난 양의 폭탄을 투하했다. 태평양에서는 일본 폭격기들이 연합군 도시와 군사 시설을 폭격하였고, 그중 진주만 공격은 눈에 띌만한 성과였다. 연합군이 하늘을 장악하자 연합군 공군은 일본의 도시와 군대에 대대적인 공격을 감행했다. 폭격기(그리고 친척뻘인 탄도 미사일)는 여전히 현대의 무기 중 가장 위협적인 무기다.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

