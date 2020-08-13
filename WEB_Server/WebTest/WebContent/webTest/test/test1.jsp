<%@page import="javax.security.auth.message.callback.SecretKeyCallback.Request"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    <%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
테스트페이지1입니다.
<br>
<%
request.setCharacterEncoding("UTF-8");
String id = request.getParameter("id");
%>


이름 : <%=id %><br />

form join <%=request.getAttribute("form") %><br>

${param.name }님 회원가입을 추가드립니다.




</body>
</html>