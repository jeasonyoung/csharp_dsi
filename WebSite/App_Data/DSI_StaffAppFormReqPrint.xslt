<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output encoding="utf-8" method="html" indent="yes"/>

  <xsl:template match="/">
    <style type="text/css">
      <![CDATA[
        .TextBox{margin-left:1px;margin-top:3px;margin-right:1px;padding-left:5px;border-bottom:solid 1px Olive;display:block;}
        .TextBox2{float:left;padding-left:10px;padding-right:3px;border-bottom:solid 1px Olive;}
      ]]>
    </style>
    <div style="float:left;width:750px;margin-left:10px; border:solid 0px #afd8f5;">
      <div style="float:left;width:100%;">
        <div style="float:right;margin-right:20px;">
          <span style="cursor:hand;color:Red;" onclick="javascript:window.print();">[打印]</span>
        </div>
      </div>
      <div style="float:left;width:100%;">
        <center>
          <h1>芙蓉区教育局困难教职工救助申请表</h1>
        </center>
      </div>
      <div style="float:left;width:100%;">
        <xsl:call-template name="StaffFormReq"/>
      </div>
    </div>
  </xsl:template>
  <!--教职工申报信息-->
  <xsl:template name="StaffFormReq">
    <table class="DataGrid" cellpadding="0" cellspacing="0" border="1" style="border-collapse:collapse;">
      <tr class="DataGridItem">
        <td style="text-align:center;">职工编号</td>
        <td colspan="3">
          <span class="TextBox">
            <xsl:value-of select="//Staff/StaffCode"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">身份</td>
        <td>
          <span class="TextBox">
            <xsl:value-of select="//Staff/TheidentityName"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">困难类别</td>
        <td>
          <span class="TextBox">
            <xsl:value-of select="//Staff/HardCategoryName"/>
            <br/>
          </span>
        </td>
      </tr>
      <tr class="DataGridItem" align="center">
        <td style="text-align:center;">姓名</td>
        <td style="text-align:center;">民族</td>
        <td style="text-align:center;">性别</td>
        <td style="text-align:center;">政治面貌</td>
        <td style="text-align:center;">出生日期</td>
        <td style="text-align:center;">身份证号</td>
        <td style="text-align:center;">健康状况</td>
        <td style="text-align:center;">疾病名称/残疾类别</td>
      </tr>
      <tr class="DataGridItem">
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/StaffName"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/PeopleName"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/GenderName"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/PoliticalFaceName"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="substring-before(//Staff/Birthday,'T')"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/IDCard"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/HealthStatusName"/>
            <br/>
          </span>
        </td>
        <td>
          <span class="TextBox">
            <xsl:value-of select="//Staff/Disability"/>
            <br/>
          </span>
        </td>
      </tr>
      <tr class="DataGridItem" align="center">
        <td>住房类型</td>
        <td colspan="3">建筑面积</td>
        <td>邮政编码</td>
        <td>联系电话</td>
        <td>参加工作时间</td>
        <td>婚姻状况</td>
      </tr>
      <tr class="DataGridItem">
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/HouseTypeName"/>
            <br/>
          </span>
        </td>
        <td colspan="3">
          <span class="TextBox" style="text-align:right;">
            <xsl:value-of select="format-number(//Staff/BuildArea,'###,###.00')"/>
            <span style="padding-left:5px;margin-right:5px;">(平方米)</span>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/ZipCode"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/Contact"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="substring-before(//Staff/TimeWorkStart,'T')"/>
            <br/>
          </span>
        </td>
        <td style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/MaritalstatusName"/>
            <br/>
          </span>
        </td>
      </tr>
      <tr class="DataGridItem" align="center">
        <td colspan="4">工作单位</td>
        <td colspan="2">家庭住址</td>
        <td colspan="2">是否有一定自救能力</td>
      </tr>
      <tr class="DataGridItem">
        <td colspan="4">
          <span class="TextBox">
            <xsl:value-of select="//Staff/UnitName"/>
            <br/>
          </span>
        </td>
        <td colspan="2">
          <span class="TextBox">
            <xsl:value-of select="//Staff/Address"/>
            <br/>
          </span>
        </td>
        <td colspan="2" style="text-align:center;">
          <span class="TextBox">
            <xsl:value-of select="//Staff/SelfHelpName"/>
            <br/>
          </span>
        </td>
      </tr>
      <tr class="DataGridItem" align="center">
        <td colspan="4">本人月平均收入</td>
        <td>家庭年度总收入</td>
        <td>家庭人口</td>
        <td colspan="2">家庭年人均收入</td>
      </tr>
      <tr class="DataGridItem" align="center">
        <td colspan="4">
          <span class="TextBox" style="text-align:right;padding-right:10px">
            <xsl:value-of select="format-number(//Staff/AvgIncome,'###,###.00')"/>
            <br/>
          </span>
        </td>
        <td>
          <span class="TextBox" style="text-align:right;padding-right:10px">
            <xsl:value-of select="format-number(//Staff/FamilyIncome,'###,###.00')"/>
            <br/>
          </span>
        </td>
        <td>
          <span class="TextBox" style="text-align:right;padding-right:10px">
            <xsl:value-of select="//Staff/FamilyCount"/>
            <br/>
          </span>
        </td>
        <td colspan="2">
          <span class="TextBox" style="text-align:right;padding-right:10px">
            <xsl:value-of select="format-number(//Staff/FamilyAvgIncome,'###,###.00')"/>
            <br/>
          </span>
        </td>
      </tr>
      <tr class="DataGridItem">
        <td colspan="8" style="padding-top:2px; padding-bottom:2px; padding-left:1px; padding-right:1px;">
          <fieldset>
            <legend style="color:#ccc;">家庭成员</legend>
            <table class="DataGrid" cellspacing="0" rules="all" border="1" style="border-collapse:collapse;width:100%;">
              <tr class="DataGridHeader" align="center">
                <td style="width:11%;">姓名</td>
                <td style="width:9%;">关系</td>
                <td style="width:5%;">性别</td>
                <td style="width:10%;">政治面貌</td>
                <td style="width:17%;">身份证号</td>
                <td style="width:8%;">出生日期</td>
                <td style="width:10%;">健康状况</td>
                <td style="width:8%;">月收入</td>
                <td style="width:9%;">身份</td>
                <td style="width:13%;">单位或学校</td>
              </tr>
              <xsl:for-each select="//DSIStaffFamilyMember">
                <tr class="DataGridItem">
                  <td style="text-align:center;">
                    <xsl:value-of select="MemberName"/>
                  </td>
                  <td style="text-align:center;">
                    <xsl:value-of select="RelationName"/>
                  </td>
                  <td style="text-align:center;">
                    <xsl:value-of select="GenderName"/>
                  </td>
                  <td style="text-align:center;">
                    <xsl:value-of select="PoliticalFaceName"/>
                  </td>
                  <td style="text-align:left;">
                    <xsl:value-of select="IDCard "/>
                  </td>
                  <td style="text-align:center;">
                    <xsl:value-of select="substring-before(Birthday,'T')"/>
                  </td>
                  <td style="text-align:center;">
                    <xsl:value-of select="HealthStatusName "/>
                  </td>
                  <td style="text-align:right;padding-right:10px;">
                    <xsl:value-of select="format-number(Income,'###,###.00')"/>
                  </td>
                  <td style="text-align:center;">
                    <xsl:value-of select="TheidentityName "/>
                  </td>
                  <td style="text-align:left;">
                    <xsl:value-of select="UnitSchool"/>
                  </td>
                </tr>
              </xsl:for-each>
              <tr class="DataGridFooter">
                <td colspan="10">
                  <br/>
                </td>
              </tr>
            </table>
          </fieldset>
        </td>
      </tr>
      <tr class="DataGridItem">
        <td style="text-align:center;">致困主要原因</td>
        <td colspan="7">
          <span class="TextBox">
            <xsl:value-of select="//Staff/HardBecauseName"/>
            <br/>
          </span>
        </td>
      </tr>
      <tr class="DataGridItem">
        <td style="text-align:center;">其他情况<br/>补充说明</td>
        <td colspan="7" style="text-align:center;">
          <span class="TextBox">
            <pre>            
              <xsl:value-of select="//Staff/HardBecauseDesc"/>
              <br/>
            </pre>
          </span>
        </td>
      </tr>
      <tr class="DataGridItem">
        <td colspan="8">
          <fieldset>
            <legend style="color:#ccc;">证明材料附件</legend>
            <table class="DataGrid" cellpadding="0" cellspacing="0" rules="all" style="border-collapse:collapse;width:100%;">
              <tr class="DataGridHeader" align="center">
                <td style="width:65%;">文件名</td>
                <td style="width:15%;">文件类型</td>
                <td style="width:20%;">文件大小(M)</td>
              </tr>
              <xsl:for-each select="//DSIAttachment">
                <tr class="DataGridItem">
                  <td style="padding-left:5px;">
                    <a target="_blank">
                      <xsl:attribute name="href">
                        <xsl:text>AccessoriesDownload.ashx?FileID=</xsl:text>
                        <xsl:value-of select="ID"/>
                      </xsl:attribute>
                      <xsl:number/>
                      <span>.</span>
                      <xsl:value-of select="Name"/>
                    </a>
                  </td>
                  <td style="text-align:center;">
                    <xsl:value-of select="ContentType"/>
                  </td>
                  <td style="text-align:right;padding-right:10px;">
                    <xsl:value-of select="format-number(Size,'###,###.00')"/>
                  </td>
                </tr>
              </xsl:for-each>
              <tr class="DataGridFooter">
                <td colspan="3">
                  <br/>
                </td>
              </tr>
            </table>
          </fieldset>
        </td>
      </tr>
      <tr class="DataGridItem" style="padding-bottom:5px;">
        <td colspan="8">
          <table class="DataGrid" cellpadding="0" cellspacing="0" rules="all" style="border-collapse:collapse;">
            <tr class="DataGridItem">
              <td rowspan="2" style="width:50px; text-align:center;">
                基层<br />工会<br />意见
              </td>
              <td rowspan="2" style="width:298px;">
                <div style="float:left; width:100%;">
                  <div Style="float:left;color:#aaa;padding-left:5px;">拟申请补助金额：</div>
                  <div class="TextBox2" style="width:70px;text-align:right;">
                    <xsl:value-of select="format-number(//PrimaryAllowance,'###,###.00')"/>
                  </div>
                </div>
                <div style="float:left;margin-top:5px;width:100%;">
                  <div style="float:right;margin-right:5px;">
                    <div Style="float:left;color:#aaa;">审核人：</div>
                    <div class="TextBox2" style="width:80px;">
                      <xsl:value-of select="//PrimaryAudit"/>
                    </div>
                  </div>
                </div>
                <div style="float:left;margin-top:5px;width:100%;">
                  <div style="float:right;margin-right:5px;">
                    <div Style="float:left;color:#aaa;">日期：</div>
                    <div class="TextBox2" style="width:80px;">
                      <xsl:value-of select="substring-before(//PrimaryAuditTime,'T')"/>
                    </div>
                  </div>
                </div>
              </td>
              <td style="width:128px;text-align:center;">审查委员意见</td>
              <td style="width:168px;">
                <div Style="float:left;color:#aaa; padding-left:5px;">拟补助：</div>
                <div class="TextBox" style="width:80px;text-align:right;">
                  <xsl:value-of select="format-number(//CommitteeAllowance,'###,###.00')"/>
                </div>
              </td>
              <td style="width:128px;text-align:center;"> 总责任人意见</td>
              <td style="width:128px;">
                <div Style="float:left;color:#aaa; padding-left:5px;">拟补助：</div>
                <div class="TextBox" style="float:left;width:65px;text-align:right;">
                  <xsl:value-of select="format-number(//LeadershipAllowance,'###,###.00')"/>
                </div>
              </td>
            </tr>
            <tr class="DataGridItem">
              <td style="text-align:center;">主管领导意见</td>
              <td>
                <div Style="float:left;color:#aaa; padding-left:5px;">拟补助：</div>
                <div class="TextBox" style="width:80px;text-align:right;">
                  <xsl:value-of select="format-number(//FinalAllowance,'###,###.00')"/>
                </div>
              </td>
              <td style="text-align:center;">领取人签名</td>
              <td>
                <span class="TextBox">
                  <xsl:value-of select="//Payee"/>
                  <br/>
                </span>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>