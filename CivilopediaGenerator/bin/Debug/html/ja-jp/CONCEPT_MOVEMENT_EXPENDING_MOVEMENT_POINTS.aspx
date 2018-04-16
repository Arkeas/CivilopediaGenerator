<%@ Page Title="" Language="VB" MasterPageFile="Concepts.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 移動ポイントの消費</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="contentleft">
		&nbsp;
	</div>
	<div class="contentright">
		<div class="title">移動ポイントの消費</div>
		<h2>概要:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">ユニットはタイルを移動する事で移動ポイント(MP)を消費する。移動先のタイルの地形によって、移動ポイントの消費量は変化する。移動元のタイルは、移動ポイントの消費量には影響を与えない。<br /><br />移動ポイントの詳細については地形ルールの項目を参照のこと。通常では、草原や平原のような開けた大地では移動ポイントの消費量は1で、森林やジャングルのようなタイルに入ると移動ポイントを2消費する。河川を渡ると(道路が敷かれていない限り)、移動ポイントを全て消費する。<br /><br />ユニットに移動ポイントが1以上残っていれば、必ず1タイルは移動できるようになっている。そのタイルの移動コストがいくら高くても、ユニットに移動ポイントが残されている限りはそのタイルへ入ることができる。移動ポイントを全て消費したユニットは、その場所で次のターンを待つことになる。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

