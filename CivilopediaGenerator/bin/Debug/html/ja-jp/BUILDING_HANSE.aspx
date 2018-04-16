<%@ Page Title="" Language="VB" MasterPageFile="Buildings.master" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<title>CIVILOPEDIA Online: ハンザ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<img src="/civilopedia/images/large/BUILDING_HANSE.png" alt="ハンザ" class="contentimage" />
	<div class="contentleft">
		<h2>コスト:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">200 <img src="/civilopedia/images/production.png" alt="production" /></div></div></div></div></div></div></div></div>
		
		
		
		<h2>ゴールド:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">+2 <img src="/civilopedia/images/gold.png" alt="gold" /> +25% <img src="/civilopedia/images/gold.png" alt="gold" /> </div></div></div></div></div></div></div></div>
		
		
        
        
		
		<h2>文明:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="CIVILIZATION_GERMANY.aspx" onmouseover="return tooltip('ドイツ文明');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/CIVILIZATION_GERMANY.png" /></a></div></div></div></div></div></div></div></div>
		
        
		
		<h2>必要なテクノロジー:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="TECH_BANKING.aspx" onmouseover="return tooltip('銀行制度');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/TECH_BANKING.png" /></a></div></div></div></div></div></div></div></div>
		<h2>必要な建造物:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="BUILDING_BAZAAR.aspx" onmouseover="return tooltip('バザー');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_BAZAAR.png" /></a><a href="BUILDING_MARKET.aspx" onmouseover="return tooltip('市場');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_MARKET.png" /></a></div></div></div></div></div></div></div></div>
		<h2>専門家:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="SPECIALIST_MERCHANT.aspx" onmouseover="return tooltip('商人');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/SPECIALIST_MERCHANT.png" /></a></div></div></div></div></div></div></div></div>
		
		<h2>同種ユニット:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr"><a href="BUILDING_BANK.aspx" onmouseover="return tooltip('銀行');" onmouseout="return hideTip();"><img src="/civilopedia/images/small/BUILDING_BANK.png" /></a></div></div></div></div></div></div></div></div>
	</div>
	<div class="contentright">
		<div class="title">ハンザ</div>
		<h2>ゲーム情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">銀行に替わるドイツの固有建造物。自文明と都市国家を結ぶ交易路1つにつき<img src="/civilopedia/images/production.png" alt="production" />生産力+5%。他のプレイヤーがハンザのある都市に交易路を引くと、さらに<img src="/civilopedia/images/gold.png" alt="gold" />ゴールド1がその都市の所有者の懐に入る。また、交易路の所有者もさらに<img src="/civilopedia/images/gold.png" alt="gold" />ゴールド1を得る。</div></div></div></div></div></div></div></div>
		<h2>戦略:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">通常の銀行のボーナス（<img src="/civilopedia/images/gold.png" alt="gold" />ゴールド産出量と交易路からの<img src="/civilopedia/images/gold.png" alt="gold" />ゴールド収入を増やす）に加え、ハンザは都市国家へとつながる国内の交易路1つごとに<img src="/civilopedia/images/production.png" alt="production" />生産力ボーナスをもたらす。交易路がハンザのない都市を経由している場合でも、このボーナスは得られる（例：ベルリンからジュネーヴ、ミュンヘンからジュネーヴ、ミュンヘンからベルリン、ベルリンからブリュッセルに交易路が引かれている場合、ハンザのある都市はすべて<img src="/civilopedia/images/production.png" alt="production" />生産力+15%を得る）。ドイツだけが建設できる。</div></div></div></div></div></div></div></div>
		<h2>歴史情報:</h2><div class="t"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="tl"><div class="tr">古期フランス語で“商人組合”を意味するハンザは、商業と輸送を保護し、促進するために商人や交易業者が自主的に結成した、町規模の連合組織であった。13世紀になると、これらの交易組合は、同じく“ハンザ”と呼ばれる複合施設を本部とし、バルト海や北海の商港で絶大な権力と影響力を持つようになる。最も大規模なハンザは、組合の管理事務所だけでなく、貯蔵室、会議室、食料品店、銀行なども備えていた。海に面したハンザには、ドックまで設けられていたほどである。このように高度に発達したハンザをいち早く建設したのは、リューベックだったと考えられている。1159年頃に建てられたリューベックのハンザは、西ヨーロッパとロシア北部の資源豊富な地域との交易促進を目指した。やがてハンザは、ハンザ同盟にその名を受け継がれる。1250年頃にいくつかのドイツの組合が集まって組織したハンザ同盟は、バルト海の交易路の安全確保、約束手形の統一、加盟都市の商業的発展を趣旨とした。その後、同盟は、1600年代後期に至るまで、北ヨーロッパの政治、軍事（ハンザ同盟による小規模紛争には、1438～1441年のオランダとの戦争や、1470～1474年のイギリスとの戦争がある）、経済に影響力を及ぼし続けた。</div></div></div></div></div></div></div></div>
	</div>
</asp:Content>

