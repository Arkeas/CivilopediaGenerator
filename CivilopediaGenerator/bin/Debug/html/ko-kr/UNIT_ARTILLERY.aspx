<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 야포</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_ARTILLERY.png" alt="야포" class="contentimage" />
	<div class="contentleft">
		<h2>비용:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">250 <img src="/civilopedia/images/production.png" alt="production" /> / 500 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>전투 종류: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">공성 무기</div></div></div></div></div></div></div></div>
		<h2>전투: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">21 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>원거리 전투: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">28 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>사정거리:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">3</div></div></div></div></div></div></div></div>
		<h2>이동:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>능력:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_INDIRECT_FIRE.aspx" onmouseover="return tooltip('간접 사격');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_35.png" /></a><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('근접 공격 불가');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('도시 대항 보너스(200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('방어 지형 보너스 없음');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('설치 후 원거리 공격');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('시계 제한');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>기술 조건: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_DYNAMITE.aspx" onmouseover="return tooltip('다이너마이트');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_DYNAMITE.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>유닛 업그레이드:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_ROCKET_ARTILLERY.aspx" onmouseover="return tooltip('로켓포');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_ROCKET_ARTILLERY.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">야포</div>
		<h2>게임 정보:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">3칸 떨어진 적을 포격할 수 있는 첫 번째 공성 유닛입니다. 공격하려면 포를 설치해야 합니다.</div></div></div></div></div></div></div></div>
		<h2>전략:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">야포는 치명적인 공성 무기로 대포보다 강력하고 사정거리도 더 깁니다. 대포와 마찬가지로 시야가 좁고 공격 전에 설치(행동력 1 소모)해야 하지만, 그 원거리 전투력만큼은 무시무시합니다. 또한 야포는 ‘간접 사격’ 능력을 통해 직접 볼 수 없는 목표물도 (이때 다른 아군 유닛은 목표물을 볼 수 있어야 합니다) 장애물을 넘어 사격할 수 있습니다. 다른 공성 무기와 마찬가지로 근접 공격에 취약합니다.</div></div></div></div></div></div></div></div>
		<h2>역사적 정보:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">기술이 발전함에 따라 전장에서 대포의 중요성은 더욱 커졌다. 나폴레옹의 시대와 미국 남북 전쟁 시대의 19세기 총은 시간이 지남에 따라 그 어느 때보다 크고 정밀하며 치명적인 무기들로 교체되었다. 독일제 88밀리 포는 2차 세계대전 최고의 무기 중 하나이자 가장 용도가 다양한 무기다. 원래는 대공포로 설계되었지만 대전차 무기로서의 성능이 워낙 뛰어났기에 오직 대전차 무기 용도로 다른 모델들이 제작되기도 했다.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

