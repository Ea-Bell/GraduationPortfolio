<%@page import="java.sql.SQLException"%>
<%@page import="org.apache.jasper.tagplugins.jstl.core.Catch"%>
<%@page import="jdbc.connection.ConnectionProvider"%>
<%@page import="java.sql.*"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
<%

try(Connection conn= ConnectionProvider.getConnection()){
	out.println("연결성공");
}catch(Exception ex){
		out.println("커넥션 연결에 실패함"+ ex.getMessage());
		application.log("커넥션 연결에 실패", ex);		
}
%>
</body>
</html>