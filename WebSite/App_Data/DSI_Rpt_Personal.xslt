<?xml version="1.0" encoding="utf-8"?>
<!--按个人统计报表。-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output encoding="gb2312" method="html" indent="yes"/>
  <!--调用入口。-->
  <xsl:template match="/">
    <xsl:call-template name="Rpt"/>
  </xsl:template>
  <!--绘制报表。-->
  <xsl:template name ="Rpt">
    <!--绘制报表体。-->
    <table class="DataGrid" cellspacing="0" cellpadding="0" rules="all" border="1" style="width:98%;border-collapse:collapse;">
      <!--绘制报表头-->
      <!--最大列数-->
      <xsl:variable name="maxCols">
        <xsl:call-template name="FindMaxCols"/>
      </xsl:variable>
      <!--最大列所在行号-->
      <xsl:variable name ="maxRowIndex">
        <xsl:call-template name="FindColRowIndex"/>
      </xsl:variable>
      
      <tr class="DataGridHeader">
        <xsl:for-each select="//ReportRow[@rowIndex=$maxRowIndex]/Items/ReportItem">
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
             <!--绘制数据体列-->
            <xsl:for-each select="ReportItem">
              <xsl:sort select="@order" order="ascending"/>
              <xsl:if test ="position() != last()">
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
              </xsl:if>
            </xsl:for-each>
            <!--填充列-->
            <xsl:variable name="col" select="count(ReportItem)"/>
            <xsl:if test="number($col) &lt; number($maxCols)">
              <xsl:call-template name="FillingCols">
                <xsl:with-param name="cols" select="number($maxCols) - number($col)"/>
              </xsl:call-template>
            </xsl:if>
            <!--绘制合计列-->
            <xsl:for-each select="ReportItem">
              <xsl:sort select="@order" order="ascending"/>
              <xsl:if test ="position() = last()">
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
              </xsl:if>
            </xsl:for-each>
          </tr>
        </xsl:for-each>
      </xsl:for-each>
      <!--绘制汇总行-->
      <tr class="DataGridFooter">
        <td align="right">
          <xsl:attribute name ="colspan">
            <xsl:call-template name="FindMaxNonNumericalCols"/>
          </xsl:attribute>
          <xsl:text>汇总：</xsl:text>
          <xsl:for-each select="//ReportRow[@rowIndex=$maxRowIndex]/Items/ReportItem[@align='Right']">
            <xsl:sort select="@order" order="ascending"/>
            <td align="right">
              <!--格式化数据-->
              <xsl:call-template name="FormatNumerical">
                <xsl:with-param name="data">
                  <!--汇总结果-->
                  <xsl:call-template name="SumColsValues">
                    <xsl:with-param name="name" select="@name"/>
                  </xsl:call-template>
                </xsl:with-param>
              </xsl:call-template>
            </td>
          </xsl:for-each>
        </td>
      </tr>
    </table>
  </xsl:template>

  <!--查找最大列的行号-->
  <xsl:template name="FindColRowIndex">
    <xsl:for-each select="//ReportRow">
      <xsl:sort data-type="number" order="descending" select="count(Items/ReportItem)"/>
      <xsl:if test ="position() = 1">
        <xsl:value-of select ="@rowIndex"/>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
  <!--获取最大列的数值-->
  <xsl:template name="FindMaxCols">
    <xsl:for-each select="//ReportRow">
      <xsl:sort data-type="number" order="descending" select="count(Items/ReportItem)"/>
      <xsl:if test ="position() = 1">
        <xsl:value-of select ="count(Items/ReportItem)"/>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
  <!--获取非数值列的个数-->
  <xsl:template name ="FindMaxNonNumericalCols">
    <xsl:for-each select="//ReportRow">
      <xsl:sort data-type="number" order="descending" select="count(Items/ReportItem)"/>
      <xsl:if test ="position() = 1">
        <xsl:value-of select ="count(Items/ReportItem[@align != 'Right'])"/>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
  <!--填充列-->
  <xsl:template name="FillingCols">
    <xsl:param name="cols"/>
    <xsl:if test ="$cols &gt; 0">
      <td align="right">0.00</td>
      <xsl:call-template name="FillingCols">
        <xsl:with-param name="cols" select="number($cols) - 1"/>
      </xsl:call-template>
    </xsl:if>
  </xsl:template>
  <!--汇总数据列-->
  <xsl:template name="SumColsValues">
    <xsl:param name="name"/>
    <xsl:variable name="totalArrary">
      <xsl:for-each select ="//ReportItem[@name=$name]/Data">
        <xsl:variable name="total">
          <xsl:call-template name="ReplaceFunc">
            <xsl:with-param name="text" select="."/>
            <xsl:with-param name="split">,</xsl:with-param>
            <xsl:with-param name="replace"/>
          </xsl:call-template>
        </xsl:variable>
        <xsl:value-of select="number($total)"/>
        <xsl:text>,</xsl:text>
      </xsl:for-each>
    </xsl:variable>
    <!--计算汇总数据-->
    <xsl:call-template name="Total">
      <xsl:with-param name="str" select="$totalArrary"/>
      <xsl:with-param name="split">,</xsl:with-param>
      <xsl:with-param name="value">0</xsl:with-param>
    </xsl:call-template>
  </xsl:template>
  <!--计算汇总数据-->
  <xsl:template name ="Total">
    <xsl:param name ="str"/>
    <xsl:param name="split"/>
    <xsl:param name="value"/>
    <xsl:choose>
      <xsl:when test="$str = ''">
        <xsl:value-of select="number($value)"/>
      </xsl:when>
      <xsl:when test="contains($str,$split)">
        <xsl:variable name ="strValue" select="substring-before($str,$split)"/>
        <xsl:call-template name="Total">
          <xsl:with-param name="str" select="substring-after($str,$split)"/>
          <xsl:with-param name="split" select="$split"/>
          <xsl:with-param name="value" select="number($value) + number($strValue)"/>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:call-template name="Total">
          <xsl:with-param name="str"/>
          <xsl:with-param name="split" select="$split"/>
          <xsl:with-param name="value" select="number($str)"/>
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--替换函数-->
  <xsl:template name ="ReplaceFunc">
    <xsl:param name="text"/>
    <xsl:param name="split"/>
    <xsl:param name="replace"/>
    <xsl:choose>
      <xsl:when test="contains($text,$split)">
        <xsl:value-of select="substring-before($text,$split)"/>
        <xsl:value-of select="$replace"/>
        <xsl:call-template name="ReplaceFunc">
          <xsl:with-param name="text" select="substring-after($text,$split)"/>
          <xsl:with-param name="split" select="$split"/>
          <xsl:with-param name="replace" select="$replace"/>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$text"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <!--格式化-->
  <xsl:template name="FormatNumerical">
    <xsl:param name ="data"/>
    <xsl:choose>
      <!--无小数点-->
      <xsl:when test="not(contains($data,'.'))">
        <!--添加小数点-->
        <xsl:call-template name="FormatNumerical">
          <xsl:with-param name="data">
            <xsl:value-of select="$data"/>
            <xsl:text>.00</xsl:text>
          </xsl:with-param>
        </xsl:call-template>
      </xsl:when>
      <!--有小数点但无分隔符-->
      <xsl:when test="contains($data,'.') and not(contains($data,','))">
        <xsl:variable name="bstr" select="substring-before($data,'.')"/>
        <xsl:variable name="len" select="string-length($bstr)"/>
        <xsl:choose>
          <xsl:when test="$len &gt;3">
            <xsl:call-template name="FormatNumerical">
              <xsl:with-param name="data">
                <xsl:value-of select="substring($bstr,1, number($len) - 3)"/>
                <xsl:text>,</xsl:text>
                <xsl:value-of select ="substring($bstr, number($len) - 2,3)"/>
              </xsl:with-param>
            </xsl:call-template>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="$data"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:when>
      <!--有分隔符-->
      <xsl:when test="contains($data,',')">
        <xsl:variable name="bstr" select="substring-before($data,',')"/>
        <xsl:variable name="len" select="string-length($bstr)"/>
        <xsl:choose>
          <xsl:when test="$len &gt;3">
            <xsl:call-template name="FormatNumerical">
              <xsl:with-param name="data">
                <xsl:value-of select="substring($bstr,1, number($len) - 3)"/>
                <xsl:text>,</xsl:text>
                <xsl:value-of select ="substring($bstr, number($len) - 2,3)"/>
                <xsl:value-of select ="substring($data, $len + 1)"/>
              </xsl:with-param>
            </xsl:call-template>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="$data"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$data"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>
