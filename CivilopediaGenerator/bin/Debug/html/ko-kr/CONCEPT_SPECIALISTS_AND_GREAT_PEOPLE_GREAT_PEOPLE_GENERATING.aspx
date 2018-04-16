<%@ Page Title="" Language="VB" MasterPageFile="Concepts.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 위인의 생성</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="contentleft">
		&nbsp;
	</div>
	<div class="contentright">
		<div class="title">위인의 생성</div>
		<h2>요약:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">도시에서 전문가와 불가사의를 통해 위대한 예술가, 기술자, 상인, 과학자가 만들어지면 '위인(GP)' 포인트를 얻게 됩니다. 도시에 따라 GP 포인트를 생성하지 못할 수도 있고, 한 종류의 GP 포인트만 생성할 수 있거나 다양한 종류의 GP 포인트를 생성할 수도 있습니다. 각 도시의 GP 포인트는 별개로 계산됩니다. 예를 들어 교토에서 턴마다 예술가 GP 포인트 1과 기술자 GP 포인트 2가 생성된다면, 3턴 후에는 예술가 GP 포인트는 3, 기술자 GP 포인트는 6이 됩니다. 두 종류의 포인트는 합산되지 않습니다.<br /><br />도시에 특정 유형의 GP 포인트가 일정량 모이게 되면 포인트를 사용해 해당 유형의 위인을 생성할 수 있습니다. 위인을 생성하면 해당 플레이어의 모든 도시에서 해당 유형의 위인 생성에 필요한 포인트의 양이 상승합니다.<br /><br />예를 들어 한 플레이어가 위인을 생성하기 위해 GP 포인트가 10 필요하다고 가정해 봅시다. 5턴이 지나면 교토에 위대한 기술자를 생성할 수 있는 기술자 GP 포인트가 쌓일 것입니다. 위대한 기술자를 생성하면 교토의 위대한 기술자 포인트는 0이 되고 위대한 예술가 포인트는 5 남습니다. 그리고 다음 위인을 생성하는 데 필요한 GP 포인트는 15로 상승합니다. 8턴 후 교토에는 위대한 예술가 포인트 13과 위대한 기술자 포인트 16이 쌓이고, 또 한 번 위대한 기술자를 생성할 수 있게 됩니다.<br /><br />정원 건물은 위인 생성 효율을 올리며, '전사 규범' 사회 정책은 즉시 위대한 장군을 생성한다는 것도 알아 두십시오.<br /><br />또한, 산업 시대로 발전하면 사회 정책에 따라 신앙을 소비하여 위인을 구매할 수 있습니다.
</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

