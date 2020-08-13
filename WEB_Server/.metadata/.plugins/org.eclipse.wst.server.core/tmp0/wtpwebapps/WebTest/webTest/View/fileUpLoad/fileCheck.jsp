<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    
    <% 
     request.setCharacterEncoding("utf-8");
    
    String name=request.getParameter("name");
    String subject = request.getParameter("subject");
    
    String fileName1 = request.getParameter("fileName1");
    String fileName2 = request.getParameter("fileName2");
    
    String originalName1 = request.getParameter("originalName1");
    String originalName2 = request.getParameter("originalName2");
    %>
    
    
<<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta content="text/html; charset=UTF-8" http-equiv="Content-Type">
<title>01_fileCheck.jsp</title>
</head>
<body>
<h3>업로드 파일 확인</h3>
올린 사람:<%= name %><Br>
제목 <%= subject %><br>

파일 <a href="01_fileCheck.jsp?file_name=<%= fileName1 %>"><%= originalName1 %></a><br>
파일 <a href="01_fileCheck.jsp?file_name=<%= fileName2 %>"><%= originalName2 %></a><br>
</body>
</html>