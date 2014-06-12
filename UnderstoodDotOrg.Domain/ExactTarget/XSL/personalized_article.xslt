<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">
      <td style="padding:0 18px 0 0;">
        <xsl:for-each select="articles/article[position() = 1]">
          <xsl:call-template name="article"/>
        </xsl:for-each>
        <xsl:if test="count(articles/article) > 1">
          <table class="flexible" align="right" width="391" cellpadding="0" cellspacing="0" style="border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;">
            <tr>
              <td>
                <xsl:for-each select="articles/article[position() > 1]">
                  <xsl:call-template name="article"/>
                </xsl:for-each>
              </td>
            </tr>
          </table>
        </xsl:if>
      </td>
    </xsl:template>

  <xsl:template name="article">
    <table class="flexible" width="160" align="left" cellpadding="0" cellspacing="0" style="border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt;">
      <tr>
        <td align="center" style="padding:0 0 29px;">
          <a>
            <xsl:attribute name="href">
              <xsl:value-of select="url" />
            </xsl:attribute>
            <img title="img-2" alt="img-2" width="160" height="90" border="0" hspace="0" vspace="0" mdid="96a56179-2441-4f48-936d-b7134b75e893">
              <xsl:attribute name="src">
                <xsl:value-of select="img"/>
              </xsl:attribute>
            </img>
          </a>
        </td>
      </tr>
      <tr>
        <td style="font:22px/28px Arial, Helvetica, sans-serif; color:#406cab; padding:0 0 12px;">
          <xsl:value-of select="title"/>
        </td>
      </tr>
      <tr>
        <td style="font:15px/26px Arial, Helvetica, sans-serif; color:#696969; padding:0 0 26px;">
          A trio of new tablet apps for young learners can encourage an early love for reading. <br />
          <a style="text-decoration:underline; color:#426da9;" href="#">See the list</a>
        </td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>
