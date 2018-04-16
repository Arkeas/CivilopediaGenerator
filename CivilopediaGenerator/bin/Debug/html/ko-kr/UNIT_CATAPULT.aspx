<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 캐터펄트</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_CATAPULT.png" alt="캐터펄트" class="contentimage" />
	<div class="contentleft">
		<h2>비용:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">75 <img src="/civilopedia/images/production.png" alt="production" /> / 150 <img src="/civilopedia/images/peace.png" alt="faith" /></div></div></div></div></div></div></div></div>
		<h2>전투 종류: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">공성 무기</div></div></div></div></div></div></div></div>
		<h2>전투: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">7 <img src="/civilopedia/images/strength.png" alt="strength" /></div></div></div></div></div></div></div></div>
		<h2>원거리 전투: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">8 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>사정거리:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2</div></div></div></div></div></div></div></div>
		<h2>이동:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>능력:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_ONLY_DEFENSIVE.aspx" onmouseover="return tooltip('근접 공격 불가');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_CITY_SIEGE.aspx" onmouseover="return tooltip('도시 대항 보너스(200)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a><a href="PROMOTION_NO_DEFENSIVE_BONUSES.aspx" onmouseover="return tooltip('방어 지형 보너스 없음');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_MUST_SET_UP.aspx" onmouseover="return tooltip('설치 후 원거리 공격');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a><a href="PROMOTION_SIGHT_PENALTY.aspx" onmouseover="return tooltip('시계 제한');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_57.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>기술 조건: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_MATHEMATICS.aspx" onmouseover="return tooltip('수학');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_MATHEMATICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>업그레이드 조건:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_PHYSICS.aspx" onmouseover="return tooltip('물리학');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_PHYSICS.png" /></a></div></div></div></div></div></div></div></div>
		<h2>유닛 업그레이드:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_TREBUCHET.aspx" onmouseover="return tooltip('트리뷰셋');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_TREBUCHET.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">캐터펄트</div>
		<h2>게임 정보:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">최초의 공성 유닛이며 원거리에서 유닛과 도시에 심각한 피해를 입힙니다. 공격하려면 포를 설치해야 합니다.</div></div></div></div></div></div></div></div>
		<h2>전략:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">캐터펄트는 초반 적 도시를 공격하는 데 매우 유용한 공성 무기입니다. 속도가 느리고 적의 근접 공격에 극도로 취약하므로 전장에 있을 때는 반드시 다른 유닛이 동행하는 것이 좋습니다. 캐터펄트는 공격 전에 반드시 ‘설치’(이동력 1 소모)해야 합니다.</div></div></div></div></div></div></div></div>
		<h2>역사적 정보:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">캐터펄트가 정확하게 언제 발명됐는지 알 수 없지만, 그리스군이 기원전 3세기부터 사용한 것으로 알려져있다. 캐터펄트는 비틀린 밧줄이나 구부러진 나무에 저장된 힘을 이용해 발사체를 먼 거리까지 보낸다. 캐터펄트는 정확도가 많이 떨어지기는 하지만 요새처럼 부피가 크거나 속도가 느린 목표물에는 치명적일 수 있다. (요새는 상당히 크고 움직이지 않는다.) 보통 캐터펄트는 여러 개의 부품으로 나뉘어 이동한 후 전장에서 조립했다. 때때로 기술자들이 현장에서 직접 제작을 하기도 했다. 1차 세계대전에서 프랑스군은 적군의 참호에 수류탄을 던지는 데 캐터펄트를 사용했으며 이것이 마지막으로 사용된 캐터펄트이다.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

