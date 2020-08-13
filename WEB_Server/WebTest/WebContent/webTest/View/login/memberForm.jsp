<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<!-- 너무 복잡하므로 자바스크립트를 별도의 .js파일에 저장하고 include할 필요가 있음 -->
<script src="https://t1.daumcdn.net/mapjsapi/bundle/postcode/prod/postcode.v2.js"></script>
<script>
    //본 예제에서는 도로명 주소 표기 방식에 대한 법령에 따라, 내려오는 데이터를 조합하여 올바른 주소를 구성하는 방법을 설명합니다.
    function sample4_execDaumPostcode() {
        new daum.Postcode({
            oncomplete: function(data) {
                // 팝업에서 검색결과 항목을 클릭했을때 실행할 코드를 작성하는 부분.

                // 도로명 주소의 노출 규칙에 따라 주소를 표시한다.
                // 내려오는 변수가 값이 없는 경우엔 공백('')값을 가지므로, 이를 참고하여 분기 한다.
                var roadAddr = data.roadAddress; // 도로명 주소 변수
                var extraRoadAddr = ''; // 참고 항목 변수

                // 법정동명이 있을 경우 추가한다. (법정리는 제외)
                // 법정동의 경우 마지막 문자가 "동/로/가"로 끝난다.
                if(data.bname !== '' && /[동|로|가]$/g.test(data.bname)){
                    extraRoadAddr += data.bname;
                }
                // 건물명이 있고, 공동주택일 경우 추가한다.
                if(data.buildingName !== '' && data.apartment === 'Y'){
                   extraRoadAddr += (extraRoadAddr !== '' ? ', ' + data.buildingName : data.buildingName);
                }
                // 표시할 참고항목이 있을 경우, 괄호까지 추가한 최종 문자열을 만든다.
                if(extraRoadAddr !== ''){
                    extraRoadAddr = ' (' + extraRoadAddr + ')';
                }

                // 우편번호와 주소 정보를 해당 필드에 넣는다.
                document.getElementById('sample4_postcode').value = data.zonecode;
                document.getElementById("sample4_roadAddress").value = roadAddr;
                document.getElementById("sample4_jibunAddress").value = data.jibunAddress;
                
                // 참고항목 문자열이 있을 경우 해당 필드에 넣는다.
                if(roadAddr !== ''){
                    document.getElementById("sample4_extraAddress").value = extraRoadAddr;
                } else {
                    document.getElementById("sample4_extraAddress").value = '';
                }

                var guideTextBox = document.getElementById("guide");
                // 사용자가 '선택 안함'을 클릭한 경우, 예상 주소라는 표시를 해준다.
                if(data.autoRoadAddress) {
                    var expRoadAddr = data.autoRoadAddress + extraRoadAddr;
                    guideTextBox.innerHTML = '(예상 도로명 주소 : ' + expRoadAddr + ')';
                    guideTextBox.style.display = 'block';

                } else if(data.autoJibunAddress) {
                    var expJibunAddr = data.autoJibunAddress;
                    guideTextBox.innerHTML = '(예상 지번 주소 : ' + expJibunAddr + ')';
                    guideTextBox.style.display = 'block';
                } else {
                    guideTextBox.innerHTML = '';
                    guideTextBox.style.display = 'none';
                }
            }
        }).open();
    }
</script>

<script type="text/javascript">
	function check_validation() { //비밀번호 유효성 검사
		
		var reg = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/;
		var password = document.sign.passwd.value;
		if(false === reg.test(password)) {
		    alert('비밀번호는 8자 이상이어야 하며, 숫자/대문자/소문자/특수문자를 모두 포함해야 합니다.');
		    return false;
		}
		
		return true;
	}
	function checkWrite() {/* 해당 항목의 값이 null인지 체크하기, document.뒤에는 해당 폼의 이름이 들어가야함 */
		
		if (document.sign.id.value == "") {
			alert("아이디 중복체크 하세요");
			document.idcheck.id.value="";
			document.idcheck.id.focus();
			return false;
		}else if (document.sign.name.value == "") {
			alert("이름을 입력하세요");
			document.sign.name.focus();
			return false;
		}
	
		if (document.sign.passwd.value == "") {
			alert("비밀번호를 입력하세요");
			document.sign.passwd.focus();
			return false;
		}
		if (document.sign.passwdchk.value == "") {
			alert("확인 비밀번호를 입력하세요");
			document.sign.passwdchk.focus();
			return false;
		}else{
			if(!check_validation()) 
				return false;
		}
		
		if(document.sign.passwd.value != "" && document.sign.passwdchk.value != ""){
			if(document.sign.passwd.value != document.sign.passwdchk.value){
				alert("비밀번호가 일치하지 않습니다.");
				document.sign.passwd.focus();
				return false;
			}
		}
		
		document.sign.submit();	
	}
	function id_dupchk() {/* 새 윈도우창을 열어서 해당 jsp문을 돌린다 */
		 if(document.idcheck.id.value==""){ //id값이 없을 경우
			 alert("아이디를 입력하세요");         //메세지 경고창을 띄운 후
			 document.idcheck.id.focus();     // id 텍스트박스에 커서를 위치
			
		 }else{	 
		 	document.idcheck.submit();
		 }

	}
	function zipSearch(){
		url = "zipSearch.jsp?search=n";
		window.open(url, "zipCodeSearch", "width=500, height=350, scrollbars=yes");
	}
</script>

<body>
		<article id="arti">
			<table border="1">
				<caption>
					<h2>회원정보</h2>
				</caption>

				<tbody border="1">
					<tr>
						<td class="head">아이디</td>
						<td>
						<form name="idcheck" method="post" action="/JSPEx/MemberMng">
							<input name="action" value="dup" type="hidden"/>
							<input id="id" type="text" maxlength="10" name="id" required = "required">
							<input type="submit" name="dup" onclick="id_dupchk()" value="중복체크"> <!-- onclick="location.href='member_chk.jsp'" -->
						</form>
						</td>
					</tr>
					<form name="sign" method="post" action="/JSPEx/MemberMng">
					<input name="action" value="sign" type="hidden"/>
					<input name="id"  type="hidden"/>
					<tr>
						<td class="head">이름</td>
						<td><input name="name" type="text" required = "required"></td>
					</tr>
					<tr>
						<td class="head">비밀번호</td>
						<td><input name="passwd" type="password" required = "required"
						placeholder="특수문자 대문자 포함 8자리 이상"	></td>
					</tr>

					<tr>
						<td class="head">비밀번호 확인</td>
						<td><input name="passwdchk" type="password" required = "required"
						>
					</tr>

					<tr>

						<td class="head">성별</td>
						<td>남 <input name="gender" type="radio" value="남" checked>
							여 <input name="gender" type="radio" value="여">
					</tr>

					<tr>

						<td class="head">이메일</td>
						<td><input name="email01" type="text"> @ <select
							name="email02">
								<option value="naver.com">naver.com</option>
								<option value="gmail.com">gmail.com</option>
								<option value="hanmail.net">hanmail.net</option>
						</select>
					</tr>

					<tr>

						<td class="head">핸드폰</td>
						<td><select name="phone01">
								<option selected value="010">010</option>
								<option value="011">012</option>
								<option value="012">013</option>
						</select> - <input id="hp" name="phone02" type="text" placeholder="앞자리"> - <input
							id="hp" name="phone03" type="text" placeholder="뒷자리"></td>
					</tr>

					<tr>

						<td class="head">전화번호</td>
						<td><input id="telno" name="tel01" type="text" placeholder="지역번호"> - <input
							id="hp" name="tel02" type="text" placeholder="앞자리"> - <input id="hp"
							name="tel03" type="text" placeholder="뒷자리"></td>
					</tr>

					<tr>

						<td class="head">주소</td>
						<td><input type="text" id="sample4_postcode" placeholder="우편번호">
						<input type="button" onclick="sample4_execDaumPostcode()" value="우편번호 찾기"><br>
						<input type="text" id="sample4_roadAddress" placeholder="도로명주소">
						<input type="text" id="sample4_jibunAddress" placeholder="지번주소">
						<span id="guide" style="color:#999;display:none"></span>
						<input type="text" id="sample4_detailAddress" placeholder="상세주소">
						</td>
						
					</tr>

			<tfoot>
					<tr>

						<td class="head" colspan="2">
						<input type="button" value="회원가입" onclick="javascript:checkWrite()">
						<input type="reset" value="다시 작성">
						</td>

					</tr>
				</form>
				
				</tfoot>
			</table>
		</article>

<%
	String flag = (String) request.getAttribute("flag");
	String id = (String) request.getAttribute("id");
	if(flag != null){
		if(flag.equals("false")){  // 중복된 id일 경우
%>
		<script>
			alert("사용할 수 없는 아이디입니다.");         //메세지 경고창을 띄운 후
			document.sign.id.value ="" ;         
			document.idcheck.id.focus();         // id입력 창에 포커스
		</script>
<%
		}else if(flag.equals("true")) {  //사용가능한 id는 저장
			
%>
		<script>		
			alert("사용 가능한  아이디입니다.");
			document.sign.id.value =document.idcheck.id.value ="<%=id%>"; 
			document.sign.name.focus();
		</script>
<%
		}
		
	}
%>
</body>
</body>
</html>