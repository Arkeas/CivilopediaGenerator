<%@ Page Title="" Language="VB" MasterPageFile="Concepts.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: 複数ターンに跨る移動</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="contentleft">
		&nbsp;
	</div>
	<div class="contentright">
		<div class="title">複数ターンに跨る移動</div>
		<h2>概要:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">指定した場所へユニットを移動させる際に複数のターンが必要である場合、ユニットは自動的に最短ルートを探して、目的地までの移動を開始する。ユニットは指定された場所に辿り着くまで、ターン毎に移動をし続ける。<br /><br />ユニットが指定した場所にたどり着けないと判断した場合(たとえば、探索を行ったことで指定したタイルが海を挟んだ向う側にあることが判明したが、そのユニットが出航を行うことができない場合、さらには、指定した場所に他のユニットが既にいた場合など)ユニットは移動を止め、新しい指示を仰ぐこととなる。<br />指示の変更は、ユニットをクリックすることで何時でも行える。開いたアクションボックスからは、新しい指示や「命令のキャンセル」などが選択できる。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

