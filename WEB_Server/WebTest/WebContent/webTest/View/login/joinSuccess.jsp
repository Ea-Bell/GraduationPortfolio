<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>가입 완료</title>
</head>
<body>
	<%@ page language="java" contentType="text/html; charset=UTF-8"
		pageEncoding="UTF-8"%>
	<!DOCTYPE html>
<html>
<head>
<link rel="stylesheet" type="text/css"
	href="../../Model/mainForm/mainForm.css" />
<meta charset="UTF-8">
<title>main</title>
</head>
<script type="text/javascript" src="../../Model/mainForm/index.js"></script>
<body>
	<div align="center">

		<form action="mainForm.jsp" method="post">
			<!-- 헤더 -->
			<header>
				<a href="index.jsp"> <img src="../../img/logo.png"
					style="position: relative; top: 20px; left: 10px">
				</a> <input type="text" onclick=""
					style="position: relative; left: 20px;">
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
				<br>
				<br> <a href="" onmouseover="TextMover()"
					onmouseout="TextMount()" id="nav" style="color: black;">차트</a>
				&nbsp; <a href="" onmouseover="TextMover2()"
					onmouseout="TextMount2()" id="nav2" style="color: black;">최신음악</a>
				&nbsp; <a href="" onmouseover="TextMover3()"
					onmouseout="TextMount3()" id="nav3" style="color: black;">장르음악</a>
				<br>
				<br>

			</header>
		</form>

		<hr id="hr">
		<br>

	</div>

	${param.name}님, 회원가입에 성공하셨습니다.
	<!-- 바텀 -->
	<div align="center">
		<hr>
		<footer style="width: 80%; height: 50px;">미지정</footer>
	</div>

</body>
</html>