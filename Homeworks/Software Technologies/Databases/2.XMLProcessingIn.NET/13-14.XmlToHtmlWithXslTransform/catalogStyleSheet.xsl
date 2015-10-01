<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
>

  <xsl:template match="/albums">
    <html>
      <body>
        <h1>Some Albums</h1>
        <table bgcolor="#E0E0E0" cellspacing="1">
          <thead>
            <tr bgcolor="#EEEEEE">
              <th>Album name</th>
              <th>Artist</th>
              <th>Year</th>
              <th>Producer</th>
              <th>Price</th>
              <th>Songs</th>
            </tr>
          </thead>
          <tbody>
            <xsl:for-each select="album">
              <tr bgcolor="white">
                <td>
                  <xsl:value-of select="name"/>
                </td>
                <td>
                  <xsl:value-of select="artist"/>
                </td>
                <td>
                  <xsl:value-of select="year"/>
                </td>
                <td>
                  <xsl:value-of select="producer"/>
                </td>
                <td>
                  <xsl:value-of select="price"/>
                </td>
                <td>
                  <xsl:for-each select="songs/song">
                    <div>
                      <p>
                        <span>Title: </span>
                        <xsl:value-of select="title"/>
                      </p>
                      <p>
                        <span>Duration: </span>
                        <xsl:value-of select="duration"/>
                      </p>                      
                    </div>
                  </xsl:for-each>
                </td>                
              </tr>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
