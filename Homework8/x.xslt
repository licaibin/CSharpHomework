<?xml version="1.0" encoding = "UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>
				<head>
						<title>Orders</title>
				</head>
				<body>
					<xsl:for-each select="ArrayOfOrder/Order">
						<ul>
							<br/>
							<li>订单号：<xsl:value-of select="Id" /></li>
							<li>客户姓名：<xsl:value-of select="Customer/Name" /></li>
							<li>订单电话：<xsl:value-of select="Phone" /></li>
							<br/>
							<li>订单明细</li>
							<xsl:for-each select="Details/OrderDetail">
							<li>明细编号：<xsl:value-of select="Id" /></li>
							<li>商品名称：<xsl:value-of select="Goods/Name" /></li>
							<li>商品单价：<xsl:value-of select="Goods/Price" /></li>
							<li>商品数量：<xsl:value-of select="Quantity" /></li>
							<br/>
							<br/>
							</xsl:for-each>
						</ul>
					</xsl:for-each>
				</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
