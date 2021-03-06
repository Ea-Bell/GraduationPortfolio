<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
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

<header>
	<div align="center">

		<form action="mainForm.jsp" method="post">
			<!-- 헤더 -->
			
				<a href="/index" style="background: white;"> 
					 <img src="/webTest/img/logo.png"
					 style="position: relative; top: 15px; left: 0px; width: 140px; width:140px"></a>
					  <input type="text" onclick=""
					style="position: relative; left: 20px;">
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
				<br>
				
				<hr id="head_line" size="10px" color="#ECB237">
				
				<br> <a href="" onmouseover="TextMover()"
					onmouseout="TextMount()" id="nav" style="color: black;">차트</a>
				&nbsp; <a href="/fileList" onmouseover="TextMover2()"
					onmouseout="TextMount2()" id="nav2" style="color: black;">최신음악</a>
				&nbsp; <a href="" onmouseover="TextMover3()"
					onmouseout="TextMount3()" id="nav3" style="color: black;">장르음악</a>
						&nbsp; <a href="/ListArticle"  id="nav3" style="color: black;">게시판</a>					
				<br>
				<br>			
		</form>



	</div>
</header>
		<hr id="head_line" size="10px" color="#ECB237">
		<br>
	<!-- 콘텐츠 -->
	
	<div id="content"  style="padding:10px; width: 65%;  float: left;" >
			<!-- 콘텐츠 -->
	<div id="content" align="center" style="background-color: #ffffff; ">
		<section id="main_section">
			<article class="main_article"></article>
		</section>
		<!-- 메인 섹션 건들지 말것. -->

	<form action="/ChangePasswordHandler" method="post">
		<div>
			현재 암호: <br />
			<input type="password" name="curPwd">
			<c:if test="${param.pwd=='currentPwd' }">현재 암호를 입력하세요 </c:if>
			<c:if test="${param.pwd=='badCurPwd'}">현재 암호가 일치하지 않습니다</c:if>
		</div>
		<div>
			새 암호:<br />
			<input type="password" name="newPwd">
			<c:if test="${param.pwd=='newPwd'}">새 암호를 입력하세요.</c:if>
		</div>
		<div>
			<input type="submit" value="암호변경">
		</div>
	</form>



	</div>

	</div>
	
	
	
	<div style="padding:10px; width: 30%; float: right;">
		<aside id="main_aside">

			<table border="0">
				<tr>
					<td><c:if test="${empty authUser }">
							<div align="center"><a href=""></a> <a href="/webTest/login/signUp.jsp">회원가입</a></div>
							<a href="/signUp" ><img alt="" src="/webTest/img/login/login.png" style="height: 42px; width: 244px;"></a>
							<br>

						</c:if> <c:if test="${!empty authUser}">
				${authUser.nickname}님, 안녕하세요.<br />
							<a href="/LogoutHandler">[로그아웃하기]</a>
							<a href="/changePwdForm">[암호변경하기]</a>
									<a href="/fileUpLoad">[마이페이지]</a>
						</c:if></td>
				</tr>
			</table>

			<br>
			<table border="0">
				<tr>

					<td>
				<a href="/나는가수다.msi" download=>Window다운로드</a>
					</td>

				</tr>
			</table>

		</aside>
		</div>
		
		
		
	<!-- 바텀 -->
	<div align="center">

	
		
	</div>

</body>
</html>