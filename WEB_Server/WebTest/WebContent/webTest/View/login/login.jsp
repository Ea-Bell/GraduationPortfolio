<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>

<!DOCTYPE html>
<html>
<head>
<link rel="stylesheet" type="text/css"
	href="../../Model/login/login.css" />
<meta charset="UTF-8">
<title>로그인</title>
</head>
<script type="text/javascript" src="../../Model/login/login.js"></script>
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
					style="position: relative; top: 15px; left: 0px; width: 140px; width:140px">
				</a> <input type="text" onclick=""
					style="position: relative; left: 20px;">
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
				<br>
				<br> <a href="" onmouseover="TextMover()"
					onmouseout="TextMount()" id="nav" style="color: black;">차트</a>
				&nbsp; <a href="../chart/recentMusic.jsp" onmouseover="TextMover2()"
					onmouseout="TextMount2()" id="nav2" style="color: black;">최신음악</a>
				&nbsp; <a href="" onmouseover="TextMover3()"
					onmouseout="TextMount3()" id="nav3" style="color: black;">장르음악</a>
				<br>
				<br>

			</header>
		</form>
		</div>
		<hr>

		<div align="center">
			<form action="/LoginHandler" method="post">
				<br>

				<div>
					<input type="text" id="id" name="id" placeholder="아이디">
				</div>

				<div>
					<c:if test="${param.id =='idIsEmpty'}">아이디를 입력하시오</c:if>
				</div>
				<br>
				<div>
					<input type="password" id="password" name="password"
						placeholder="비밀번호" />
				</div>

				<div>
					<c:if test="${param.pwd =='pwdIsEmpty'}">비밀번호를 입력하시오.</c:if>
					<c:if test="${param.pwd =='pwdIsNotMatch'}">비밀번호가 다릅니다.</c:if>
				</div>
				<br> <input type="submit" id="subLogin" value="로그인" /> <br />
				<div align="center" style="height: 10px; width: 100%;"></div>
				<span> <img src="../../img/login/check1.jpg" id="checkId" name="checkId" onclick="damaY()">로그인저장
				 &nbsp; <a href="signUp.jsp">회원가입</a>

				</span>
				<p></p>
			</form>
		</div>




		<!-- 바텀 -->
		<div align="center">


			<br> <br>
			<hr>
		</div>
</html>