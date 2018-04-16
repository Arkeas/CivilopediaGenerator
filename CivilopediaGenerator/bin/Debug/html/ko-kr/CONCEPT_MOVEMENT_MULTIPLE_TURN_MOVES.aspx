<%@ Page Title="" Language="VB" MasterPageFile="Concepts.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 다수 턴 이동 명령</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="contentleft">
		&nbsp;
	</div>
	<div class="contentright">
		<div class="title">다수 턴 이동 명령</div>
		<h2>요약:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">
        유닛이 여러 턴에 걸쳐 지정한 위치로 가는 경우, 해당 위치에 도착할 때까지 유닛은 턴마다 가장 짧은 경로를 선택하여 이동합니다.<br /><br />유닛이 지정한 위치로 갈 수 없게 되면(탐험을 통해 지정한 위치가 이동 유닛이 갈 수 없는 바다임을 알게 되었거나 해당 위치에 이미 다른 유닛이 있는 경우) 유닛은 이동을 멈추고 새 명령을 기다리게 됩니다.<br />언제든지 유닛을 클릭하여 새 명령을 내리거나 "명령 취소"를 선택해 명령을 변경할 수 있습니다.</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

