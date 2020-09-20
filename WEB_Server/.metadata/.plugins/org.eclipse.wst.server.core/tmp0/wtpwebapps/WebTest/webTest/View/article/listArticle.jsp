<%@page import="article.service.ArticlePage"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
    <%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<link rel="stylesheet" type="text/css"
	href="../../Model/mainForm/mainForm.css" />
<meta charset="UTF-8">


<%

/**


**/

%>
<title>게시글목록</title>
<link rel="stylesheet" type="text/css" href="/webTest/Model/login/info.css" />
<link rel="stylesheet" type="text/css"
	href="/webTest/Model/mainForm/mainForm.css" />
<script type="text/javascript" src="/webTest/Model/mainForm/mainForm.js"></script>
</head>
<%-- 기본 기능 스크립트--%>
<script type="text/javascript" src="/webTest/Model/login/info.js"></script>

<%-- 다음 주소 스크립트--%>
<script
	src="https://t1.daumcdn.net/mapjsapi/bundle/postcode/prod/postcode.v2.js"></script>

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
				&nbsp; <a href="/webTest/View/fileUpLoad/fileList.jsp" onmouseover="TextMover2()"
					onmouseout="TextMount2()" id="nav2" style="color: black;">최신음악</a>
				&nbsp; <a href="" onmouseover="TextMover3()"
					onmouseout="TextMount3()" id="nav3" style="color: black;">장르음악</a>
						&nbsp; <a href="/webTest/article/list.jsp"  id="nav3" style="color: black;">게시판</a>					
				<br>
				<br>			
		</form>



	</div>
</header>
		<hr id="head_line" size="10px" color="#ECB237">
		<br>
	<!-- 사이드 컨텐츠 -->
	<div style="padding:10px; width: 30%; float: right;">
		<aside id="main_aside">

			<table border="0">
				<tr>
					<td><c:if test="${empty authUser }">
							<div align="center"><a href=""></a> <a href="/webTest/login/signUp.jsp">회원가입</a></div>
							<a href="/webTest/login/login.jsp" ><img alt="" src="/webTest/img/login/login.png" style="height: 42px; width: 244px;"></a>
							<br>

						</c:if> <c:if test="${!empty authUser}">
				${authUser.nickname}님, 안녕하세요.<br />
							<a href="/LogoutHandler">[로그아웃하기]</a>
							<a href="changePwdForm.jsp">[암호변경하기]</a>
									<a href="/webTest/list/newMusicForm.jsp">[마이페이지]</a>
						</c:if></td>
				</tr>
			</table>

			<br>
			<table border="0">
				<tr>

					<td>
				<a href="/webTest/나는가수다.msi" download=>Window다운로드</a>
					</td>

				</tr>
			</table>

		</aside>
		</div>
		
		<div id="content"  style="padding:10px; width: 65%;  float: left;" >

<!-- 메인 컨텐츠 -->
<div style="float: left; width: 30%;">

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
</div>
		
	<!-- 바텀 -->
	<div align="center">

	
		
	</div>

</body>
</html>


