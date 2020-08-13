<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    <%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>게시글 쓰기</title>
</head>
<body>
<form action="/WebTest/WriteArticleHandler" method="post">
<!-- 로그인 필터 안먹혀서 로그이 관련된건 무조건 직접 처리해서 로그인여부 확인 할것. -->
<div>
<p>
	제목:<br/><input type="text" name="title" value="${param.title}">
	<c:if test="${errors.title}">제목을 입력하세요</c:if>
	</p>
</div>
<div>
<p>
	내용:<br/>
	<textarea rows="content" rows="5" cols="30">${param.content}</textarea>
</p>
</div>
<div>
	<input type="submit" value="새 글 등록">
</div>
</form>
</body>
</html>