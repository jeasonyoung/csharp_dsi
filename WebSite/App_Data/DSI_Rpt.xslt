<?xml version="1.0" encoding="utf-8"?>
<!--公示明细报表。-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output encoding="gb2312" method="html" indent="yes"/>
  <!--调用入口。-->
  <xsl:template match="/">
    <xsl:call-template name="Rpt"/>
  </xsl:template>
  <!--绘制报表。-->
  <xsl:template name ="Rpt">
    <!--绘制报表名称。-->
    <div class="TableControl">
      <div style="margin:0 auto; text-align:center; width:100%;">
        <xsl:value-of select ="//Title"/>
      </div>
    </div>
    <!--绘制报表体。-->
    <table class="DataGrid" cellspacing="0" cellpadding="0" rules="all" border="1" style="width:98%;border-collapse:collapse;">
      <!--绘制报表头-->
      <tr class="DataGridHeader">
        <xsl:for-each select="//ReportRow[@rowIndex=0]/Items/ReportItem">
          <xsl:sort select="@order" order="ascending"/>
          <td scope="col" align="center">
            <xsl:value-of select="@name"/>
          </td>
        </xsl:for-each>
      </tr>
      <!--绘制数据-->
      <xsl:for-each select ="//ReportRow">
        <xsl:sort select ="@rowIndex" order="ascending"/>
        <xsl:variable name="Index" select="@rowIndex"/>
        <xsl:for-each select ="Items">
          <tr>
            <xsl:choose>
              <xsl:when test ="$Index mod 2 = 0">
                <xsl:attribute name ="class">
                  <xsl:text>DataGridItem</xsl:text>
                </xsl:attribute>
                <xsl:attribute name ="onmouseout">
                  <xsl:text>this.className='DataGridItem';</xsl:text>
                </xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name ="class">
                  <xsl:text>DataGridAlter</xsl:text>
                </xsl:attribute>
                <xsl:attribute name ="onmouseout">
                  <xsl:text>this.className='DataGridAlter';</xsl:text>
                </xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
            <xsl:attribute name="onmouseover">
              <xsl:text>this.className='DataGridHighLight';</xsl:text>
            </xsl:attribute>

            <xsl:for-each select="ReportItem">
              <xsl:sort select="@order" order="ascending"/>
              <td>
                <xsl:if test ="@align != ''">
                  <xsl:attribute name="align">
                    <xsl:value-of select ="@align"/>
                  </xsl:attribute>
                </xsl:if>
                <xsl:if test ="@width != ''">
                  <xsl:attribute name ="width">
                    <xsl:value-of select ="@width"/>
                  </xsl:attribute>
                </xsl:if>
                <xsl:value-of select ="Data"/>
              </td>
            </xsl:for-each>
          </tr>
        </xsl:for-each>
      </xsl:for-each>
      <!--绘制报表尾-->
      <tr class="DataGridFooter">
        <td>
          <xsl:attribute name ="colspan">
            <xsl:value-of select="count(//ReportRow[@rowIndex=0]/Items/ReportItem)"/>
          </xsl:attribute>
        </td>
      </tr>
    </table>
  </xsl:template>
 
</xsl:stylesheet>
