<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<script type="text/javascript" src="../../Model/login/info.js"></script>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
테스트페이지2입니다.
<%
request.setCharacterEncoding("UTF-8");
String id = request.getParameter("id");
%>
이름 : <%=id %>

<br />

</body>
</html>