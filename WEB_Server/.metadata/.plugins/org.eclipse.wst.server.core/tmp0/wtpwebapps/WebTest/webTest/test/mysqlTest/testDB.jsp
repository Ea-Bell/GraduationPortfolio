<%@page import="java.sql.SQLException"%>
<%@page import="java.sql.DriverManager"%>
<%@page import="java.sql.ResultSet"%>
<%@page import="java.sql.Statement" %>
<%@page import="java.sql.Connection"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>

member 테이블의 내용
<table width="100%" border="1">
<tr>
	<td>이름</td><td>아이디</td><td>성별</td><td>이메일</td>
	</tr>
<%
	Class.forName("com.mysql.jdbc.Driver");
	
	Connection conn=null;
	Statement stmt=null;
	ResultSet rs= null;
	
	 try{
		 String jdbcDriver ="jdbc:mysql://localhost:3306/bbs?useSSL=false&useUnicode=true&characterEncoding=utf8";
		 String dbUser ="root";
		 String dbPass="root";
		 
		 String query = "select *from bbs";
	 	 
		 //2. 데이터베이스 커넥션 생성
		 conn = DriverManager.getConnection(jdbcDriver,dbUser, dbPass);

		 
		 //3. Statement생성
		 stmt=conn.createStatement();
		 
		 //4. 쿼리 실행
		 rs=stmt.executeQuery(query);
		 
		 //5 쿼리실행 결과 출력
		 while(rs.next()){
%>

<tr>
	<td><%= rs.getString("userID") %></td>
	<td><%= rs.getString("userPassword") %></td>
	<td><%= rs.getString("userGender") %></td>
	<td><%= rs.getString("userEmail") %></td>
</tr>
<%
		 }		 
	 }catch(SQLException ex)
	 {
		 out.println(ex.getMessage());
		 ex.printStackTrace();
	 }
	 finally{
		 //6. 사용한 Statement 종료
		 if(rs!=null)try{rs.close();}catch(SQLException ex){}
		 if(stmt !=null)try{stmt.close();}catch(SQLException ex){}
		 
		 //7. 커넥션 종료
		 if(conn !=null)try{conn.close();}catch(SQLException ex){}
	 }
%>
	 
</table>
</body>
</html>
