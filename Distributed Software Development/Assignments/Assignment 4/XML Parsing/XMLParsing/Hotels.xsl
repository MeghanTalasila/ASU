<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
      <html>
        <body>
          <h2>Hotel Information</h2>
          <table border="2">
            <tr bgcolor="#00ff00">
              <th style="text-align:left">Hotel Name</th>
              <th style="text-align:left">Phone</th>
              <th style="text-align:left">Email</th>
              <th style="text-align:left">Number</th>
              <th style="text-align:left">Street</th>
              <th style="text-align:left">City</th>
              <th style="text-align:left">Zip</th>
              <th style="text-align:left">Bus Lines</th>
              <th style="text-align:left">Rating</th>
            </tr>
            <xsl:for-each select="Hotels/Hotel">
              <tr>
                <td>
                  <xsl:value-of select="Name"/>
                </td>
                <xsl:for-each select="Contact">
                  <td>
                    <xsl:value-of select="Phone"/>
                  </td>
                  <td>
                    <xsl:value-of select="Email"/>
                  </td>
                </xsl:for-each>
                <xsl:for-each select="Address">
                  <td>
                    <xsl:value-of select="Number"/>
                  </td>
                  <td>
                    <xsl:value-of select="Street"/>
                  </td>
                  <td>
                    <xsl:value-of select="City"/>
                  </td>
                  <td>
                    <xsl:value-of select="Zip"/>
                  </td>
                  <td>
                    <xsl:value-of select="@BusLines"/>
                  </td>
                </xsl:for-each>
                <td>
                  <xsl:value-of select="@Stars"/>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>


