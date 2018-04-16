<%@ Page Title="" Language="VB" MasterPageFile="Concepts.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 消耗移動值</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="contentleft">
		&nbsp;
	</div>
	<div class="contentright">
		<div class="title">消耗移動值</div>
		<h2>摘要：</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">
        單位消耗移動值以進入單元格。單位進入的單元格地形決定其所需消耗的移動值。移動值只在進入單元格時消耗，則離開當前單元格無需消耗移動值。<br /><br />關於移動值消耗的詳細說明，請參考地形規則。不過，通常進入像草原及平原一類的開闊地形時，只消耗1點移動值；而森林和叢林則需要消耗2點移動值。跨河則將消耗所有移動值（除其上建有道路外）。<br /><br />只要還有移動值，單位可隨時再移動一單元格；並且無論進入單元格將花費多少移動值，其都可進入。當單位移動值耗盡時，其將停止移動。
      </div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

