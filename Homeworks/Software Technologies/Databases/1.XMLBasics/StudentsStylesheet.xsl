<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:students="urn:students"
>
  <xsl:template match="/students:students">
    <html>
      <body>
        <h1>Some Students</h1>
        <table bgcolor="#E0E0E0" cellspacing="1">
          <thead>
            <tr bgcolor="#EEEEEE">
              <th>Student name</th>
              <th>Gender</th>
              <th>Date of birth</th>
              <th>Phone</th>
              <th>Email</th>
              <th>Course</th>
              <th>Specialty</th>
              <th>Faculty number</th>
              <th>Exams</th>
              <th>Enrollment Information</th>
            </tr>
          </thead>
          <tbody>
            <xsl:for-each select="students:student">
              <tr bgcolor="white">
                <td>
                  <xsl:value-of select="students:name"/>
                </td>
                <td>
                  <xsl:value-of select="students:gender"/>
                </td>
                <td>
                  <xsl:value-of select="students:birthDate"/>
                </td>
                <td>
                  <xsl:value-of select="students:phone"/>
                </td>
                <td>
                  <xsl:value-of select="students:email"/>
                </td>
                <td>
                  <xsl:value-of select="students:course"/>
                </td>
                <td>
                  <xsl:value-of select="students:specialty"/>
                </td>
                <td>
                  <xsl:value-of select="students:facultyNumber"/>
                </td>
                <td>
                  <xsl:for-each select="students:exams/students:exam">
                    <div>
                      <p>
                        <xsl:value-of select="students:name"/>
                      </p>
                      <p>
                        <span>tutor: </span>
                        <xsl:value-of select="students:tutor"/> 
                      </p>
                      <p>
                        <span>score: </span>
                        <xsl:value-of select="students:examScore"/>
                      </p>                      
                    </div>
                  </xsl:for-each>
                </td>
                <td>
                    <div>
                      <p>
                        <span>Date of enrollment: </span>
                        <xsl:value-of select="students:enrollmentInfo/students:enrollmentDate"/>                        
                      </p>
                      <p>
                        <span>Exam score: </span>
                        <xsl:value-of select="students:enrollmentInfo/students:examScore"/>
                      </p>
                      <p>
                        <span>Teacher endorsement: </span>
                        <xsl:value-of select="students:enrollmentInfo/students:teacherEndorsement"/>
                      </p>
                    </div>
                </td>
              </tr>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
