<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<link rel="stylesheet" type="text/css"
	href="../../Model/mainForm/mainForm.css" />
<script type="text/javascript" src="../../Model/mainForm/mainForm.js"></script>

<meta charset="UTF-8">
<title>회원제 게시판 예시</title>
</head>
<body>
	<div align="center">

		<form action="mainForm.jsp" method="post">
			<!-- 헤더 -->
			<header>
				<a href="index.jsp"> <img
					src="../../img/logo.png"
					style="position: relative; top: 15px; left: 0px; width: 140px; width:140px">
				</a> <input type="text" onclick=""
					style="position: relative; left: 20px;">
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
				<br>
				<br> <a href="" onmouseover="TextMover()"
					onmouseout="TextMount()" id="nav" style="color: black;">차트</a>
				&nbsp; <a href="../fileUpLoad/fileList.jsp" onmouseover="TextMover2()"
					onmouseout="TextMount2()" id="nav2" style="color: black;">최신음악</a>
				&nbsp; <a href="" onmouseover="TextMover3()"
					onmouseout="TextMount3()" id="nav3" style="color: black;">장르음악</a>
						&nbsp; <a href="../article/list.jsp"  id="nav3" style="color: black;">게시판</a>					
				<br>
				<br>

			</header>
		</form>

		<hr id="hr">
		<br>

	</div>

	<!-- 콘텐츠 -->
	<div id="content" align="center" style="background-color: #ffffff;">
		<section id="main_section">
			<article class="main_article"></article>
		</section>
		<!-- 메인 섹션 건들지 말것. -->

		<aside id="main_aside">

			<table border="1">
				<tr>
					<td><c:if test="${empty authUser }">
							<div align="center"><a href=""></a> <a href="../login/signUp.jsp">회원가입</a></div>
							<a href="../login/login.jsp" ><img alt="" src="../../img/login/login.png" style="height: 42px; width: 244px;"></a>
							<br>

						</c:if> <c:if test="${!empty authUser}">
				${authUser.nickname}님, 안녕하세요.<br />
							<a href="/LogoutHandler">[로그아웃하기]</a>
							<a href="changePwdForm.jsp">[암호변경하기]</a>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../list/newMusicForm.jsp">[마이페이지]</a>
						</c:if></td>
				</tr>
			</table>

			<br>
			<table border="1">
				<tr>
					<td><a href="downLoad.jsp">Window다운로드</a></td>
				</tr>
			</table>

		</aside>
암호가 변경되었습니다.

</body>
</html>