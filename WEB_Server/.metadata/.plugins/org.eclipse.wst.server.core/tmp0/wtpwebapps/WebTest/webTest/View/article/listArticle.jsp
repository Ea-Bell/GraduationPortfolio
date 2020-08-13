<%@page import="article.service.ArticlePage"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    <%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<head>
<link rel="stylesheet" type="text/css"
	href="../../Model/mainForm/mainForm.css" />
<meta charset="UTF-8">


<%

/**


**/

%>
<title>게시글목록</title>
</head>
<script type="text/javascript" src="../../Model/mainForm/mainForm.js"></script>
<body>
	<div align="center">

		<form action="mainForm.jsp" method="post">
			<!-- 헤더 -->
			<header>
				<a href="../login/index.jsp"> <img src="../../img/logo.png"
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
					&nbsp; <a href="/ListArticleHandler" id="nav3" style="color: black;">게시판</a>	
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
							<a href="/WebTest/LogoutHandler">[로그아웃하기]</a>
							<a href="changePwdForm.jsp">[암호변경하기]</a>
									&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../list/newMusicForm.jsp">[마이페이지]</a>
						</c:if></td>
				</tr>
			</table>

			<br>
			<table border="1">
				<tr>
						<td><a href="../../../나는가수다.msi" download=>Window다운로드</a></td>
				</tr>
			</table>
		</aside>
		<br>

		<aside id="main_bside" >


<table border="1" style="width: 650px">
 <tr>
 
 <%--이페이지 실행할려면 ListArticleHandler.java에서 직접 실행하시오 . 안할시 데이터 안나옴--%>
 <!-- 
 	<td colspan="4"><a href="/WebTest/WriteArticleHandler">[게시글쓰기]</a></td>
 	 -->
 	 <td colspan="4"><a href="/newArticleForm.jsp">[게시글쓰기]</a></td>
 </tr>
 <tr>
 	<td>번호</td>
 	<td>제목</td>
 	<td>작성자</td>
 	<td>조회수</td>

 	</tr>
 	<c:if test="${articlePage.hasNoArticles()}">
 	<tr>
 		<td colspan="4">게시글이 없습니다</td>
 	</tr>
 	</c:if>
 	<c:forEach var="article" items="${articlePage.content }">
 	<tr>
 		<td>${article.number }</td>
 		<td>
 		<a href="article/read.do?no=${article.number}&pageNo=${articlePage.currentPage}">
 			<c:out value="${article.title}"/>
 		</a>
 	</td>
	<td>${article.writer.name }</td>
	<td>${article.readCount}</td>
	</tr>
 	</c:forEach>
 	<c:if test="${articlePage.hasArticles() }">
 	<tr>
 		<td colspan="4">
 		
 		<c:if test="${articlePage.startPage>5}">
 		<!--  <a href="/WebTest/ListArticleHandler?pageNo=${articlePage.startPage-5 }">[이전]</a>-->
 		<a href="/list.jsp?pageNo=${articlePage.startPage-5 }">[이전]
 		</c:if>
 		
 		<c:forEach var="pNo" begin="${articlePage.startPage}" end="${articlePage.endPage}">
 		<a href="/WebTest/ListArticleHandler?pageNo=${pNo }">[${pNo}]</a>
 		</c:forEach>
 		
 		<c:if test="${articlePage.endPage< articlePage.totalPages }">
 		<a href="/WebTest/ListArticleHandler?pageNo=${articlePage.startPage+5 }">[다음]</a>
 		</c:if>
 		
 		</td>
 		</tr>
 	</c:if>	
 </table>

		</aside>






	</div>
	<!-- 바텀 -->
	<div align="center">


		<br> <br>
		<hr>
	</div>
