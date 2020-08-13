 <%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>회원가입</title>
</head>
<body>






	<div align="center">
		<h3>회원정보</h3>
		<form action="/Test_jsp/DB" method="post" name="form2" name="ddd">
			<table border="1">
				<tr>
					<td>아이디</td>
					<td><input type="text" id="id"> <input type="submit"
						id="idcheck" value="중복체크"></td>
				</tr>
				<tr>
					<td>이름</td>
					<td><input type="text" id="name"></td>
				</tr>
				<tr>
					<td>비밀번호</td>
					<td><input type="password" id="pwd" maxlength="8"></td>
				</tr>
				<tr>
					<td>비밀번호확인</td>
					<td><input type="password" id="pwdcheck" maxlength="8"></td>
				</tr>
				<tr>
					<td>성별</td>
					<td>남자<input type="radio" name="sex" value="man"
						checked="checked"> 여자<input type="radio" name="sex"
						value="woman">
					</td>
				</tr>
				<tr>
					<td>이메일</td>
					<td><input type="text" id="mainEmail"> @ <select
						name="lastEmail">
							<option value=" " selected>-- 선택 --</option>
							<option value="naver">naver</option>
							<option value="daum">daum</option>
							<option value="gmail">gmail</option>
					</select></td>
				</tr>
				<tr>
					<td>핸드폰</td>
					<td><select name="phone1">
							<option value=010 selected>010</option>
							<option value="011">011</option>
							<option value="032">032</option>
					</select>-<input type="text" id="phone2">-<input type="text"
						id="phone3">
				<tr>
					<td>전화번호</td>
					<td><input type="text" id="tel1">-<input type="text"
						id="tel2">-<input type="text" id="tel3"></td>
				</tr>
				<tr>
					<td>주소</td>
					<td><input type="text" id="addr"></td>
				</tr>
				<tr>
					<td><input type="submit" value="회원가입" name="완료"> <input
						type="reset" value="다시작성"></td>
				</tr>
			</table>
		</form>
	</div>



</body>
</html>