<%@ Page Title="" Language="VB" MasterPageFile="##MASTER##.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: ##TITLE##</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/##IMAGE##.png" alt="##TITLE##" class="contentimage" />
	<div class="contentleft">
		&nbsp;
	</div>
	<div class="contentright">
		<div class="title">##TITLE##</div>
		<div class="t">
			<div class="b">
				<div class="l">
					<div class="r">
						<div class="bl">
							<div class="br">
								<div class="tl">
									<div class="tr">
										##QUOTE##
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="contentwide">
		<h2>##TITLE##</h2>
		<div class="t">
			<div class="b">
				<div class="l">
					<div class="r">
						<div class="bl">
							<div class="br">
								<div class="tl">
									<div class="tr">
										##DESC##
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>

