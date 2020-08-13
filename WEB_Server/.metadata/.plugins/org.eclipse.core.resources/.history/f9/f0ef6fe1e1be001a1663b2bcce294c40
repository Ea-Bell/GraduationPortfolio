<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>게시글 삭제</title>
</head>
<body>
<form action="/WebTest/delete.do" method="POST">
	<p>
		번호:<br/>${delReq.articleNumber}
	</p>
	<p>
		제목:<br/><input type ="text" name="title" value="${delReq.title }">
	</p>
	<p>
	내용<br/>
		<textarea name="content" rows="5" cols="30">${delReq.content}</textarea>
	</p>
	<input type="text" name="no" value="<%=request.getParameter("no") %>" style="visibility: hidden; ">   
	<input type="submit" value="글 삭제">
</form>
</body>
</html>