<%@ Page Title="" Language="VB" MasterPageFile="Units.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 전투기</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/UNIT_FIGHTER.png" alt="전투기" class="contentimage" />
	<div class="contentleft">
		<h2>비용:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">375 <img src="/civilopedia/images/production.png" alt="production" /></div></div></div></div></div></div></div></div>
		<h2>전투 종류: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">전투 유닛</div></div></div></div></div></div></div></div>
		
		<h2>원거리 전투: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">45 <img src="/civilopedia/images/range_strength.png" alt="range strength" /></div></div></div></div></div></div></div></div>
		<h2>사정거리:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">8</div></div></div></div></div></div></div></div>
		<h2>이동:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">2 <img src="/civilopedia/images/moves.png" alt="moves" /></div></div></div></div></div></div></div></div>
		
		<h2>능력:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="PROMOTION_INTERCEPTION_IV.aspx" onmouseover="return tooltip('요격(100)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_58.png" /></a><a href="PROMOTION_AIR_SWEEP.aspx" onmouseover="return tooltip('대공 무력화');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_58.png" /></a><a href="PROMOTION_AIR_RECON.aspx" onmouseover="return tooltip('공중 정찰');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_58.png" /></a><a href="PROMOTION_ANTI_AIR_II.aspx" onmouseover="return tooltip('폭격기 및 헬리콥터 유닛 대항 보너스(150)');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/PROMOTION_59.png" /></a></div></div></div></div></div></div></div></div>
		<h2>필요 자원:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="RESOURCE_OIL.aspx" onmouseover="return tooltip('석유');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/RESOURCE_OIL.png" /></a></div></div></div></div></div></div></div></div>
		<h2>기술 조건: </h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_RADAR.aspx" onmouseover="return tooltip('레이더');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_RADAR.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>유닛 업그레이드:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="UNIT_JET_FIGHTER.aspx" onmouseover="return tooltip('제트 전투기');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/UNIT_JET_FIGHTER.png" /></a></div></div></div></div></div></div></div></div>
		
	</div>
	<div class="contentright">
		<div class="title">전투기</div>
		<h2>게임 정보:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">제공권을 장악하고 다가오는 적 항공기를 요격하기 위해 개발된 항공 유닛입니다.</div></div></div></div></div></div></div></div>
		<h2>전략:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">전투기는 중간 정도 위력의 공중 유닛입니다. 플레이어 소유 도시에 배치하거나, 항공모함에 탑재할 수 있습니다. 사정거리인 8타일 내에서 다른 도시로 (또는 항공모함으로) 이동하거나 ‘임무’를 수행할 수 있습니다. 전투기로 적의 비행기와 지상 유닛을 공격하고, 적의 위치를 정찰하고, 적의 공중 공격을 방어하세요. 전투기는 특히 헬리콥터에 강합니다. 자세한 정보는 비행기에 대한 규칙을 참고하세요.</div></div></div></div></div></div></div></div>
		<h2>역사적 정보:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">전투기는 1차 세계대전 때 개발되었다. 최초의 "전투기"는 기관총과 자체 추진 장치를 장착한 연에 지나지 않았다. 2차 세계대전에 들어 기술과 정책 모두 상당히 발전하였고 이 때문에 위협적인 살인 병기인 단엽기를 제작하는 것이 가능해졌다. 전투기의 주된 역할은 전장에서 적 비행기를 격추하거나 쫓아내어 아군 폭격기가 지상의 적이나 해군을 향해 폭탄을 투하할 수 있도록 하늘을 장악하는 것이었다. 일부 전투기는 지상 유닛을 공격할 수 있도록 폭탄을 적재하기도 하지만 폭탄이 없어도 지상의 적군이나 해군을 기관총으로 공격해 치명상을 입힐 수 있다.<br /><br />현대의 제트 전투기는 2차 세계대전의 전투기보다 더 빠르고 더 좋은 무기와 강화된 동체로 만들어 졌다. 하지만, 공중전의 기본 원칙은 동일하며 공중 장악력을 가지고 있는 쪽이 적군과 비교하면 훨씬 더 유리하다.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

