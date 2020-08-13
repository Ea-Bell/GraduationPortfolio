<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<link rel="stylesheet" href="style_mj.css">
 </head>
 <body>
 <basefont size=6>
 <table width="940">
 <form name="write_form_member" method="post">
   <tr>
      <td><img src="../images/member/join1_top.gif"></td>
   </tr>
   <tr height="327px">
     <td colspan="2" align="left" valign="top" style="20px 0px 0px 0px;">
     <!---------------------내용시작------------------>
   <table width="780">
     <tr>
     </tr>
     <tr>
      <td>
 
         <!--테이블 시작 -->
         <table width="940" style="padding:5px 0 5px 0;">
         <tr>
           <th>이름</th>
          <td><input type="text" name="mbname"></td>
         </tr>
 
        <tr>
         <th>주민등록번호</th>
         <td><input type="text" name="jumin_1"> -
         <input type="password" name="jumin_2"></td>
      </tr>
 
      <tr>
         <th>아이디</th>
         <td> <input type="text" name="mbid"><a href='#' style='cursor:pointer'></a> (영문/숫자 10~12자) </td>
      </tr>
 
      <tr>
         <th>비밀번호</th>
         <td><input type="password" name="mbpw"> 영문/숫자포함 6자 이상</td>
      </tr>
 
      <tr>
         <th>비밀번호 확인</th>
         <td><input type="password" name="mbpw_re"></td>
      </tr>
 
      <tr>
         <th>비밀번호 힌트 답변</th>
         <td><select name='pwhint' size='1' class='select'>
         <option value=''>선택하세요 </option>
         <option value='30'>졸업한 초등학교 이름은?</option>
         <option value='31'>제일 친한 친구의 핸드폰 번호는? </option>
         <option value='32'>아버지 성함은?</option>
         <option value='33'>어머니 성함은?</option>
         <option value='34'>어릴 적 내 별명은?</option>
         <option value='35'>가장 아끼는 물건은?</option>
         <option value='36'>좋아하는 동물은?</option>
         <option value='37'>좋아하는 색깔은?</option>
         <option value='38'>좋아하는 음식은?</option>
      </select>
      </tr>
 
      <tr>
      </td>
         <th>답변</th>
         <td><input type='text' name="pwhintans"></td>
      </tr>
 
      <tr>
         <th>이메일</th>
         <td>
            <input type="text" name="email"> @
            <input type="text" name="email_dns">
               <select name="emailaddr">
                  <option value="">직접입력</option>
                  <option value="daum.net">daum.net</option>
                  <option value="empal.com">empal.com</option>
                  <option value="gmail.com">gmail.com</option>
                  <option value="hanmail.net">hanmail.net</option>
                  <option value="msn.com">msn.com</option>
                  <option value="naver.com">naver.com</option>
                  <option value="nate.com">nate.com</option>
               </select>
            </td>
         </tr>
 
         <tr>
            <th>주소</th>
            <td>
               <input type="text" name="zip_h_1"> - 
               <input type="text" name="zip_h_2">
               <a href='#' style='cursor:hand;'>
               <img src="../images/member/btn_zipcode.gif" style="cursor:pointer"></a><br>
               <input type="text" name="addr_h1"><br>
               <input type="text" name="addr_h1">
            </td>
         </tr>
 
         <tr>
         <th>전화번호</th>
         <td><input type="text" name="cel1"> - 
            <input type="text" name="cel2_1" title="전화번호"> -
            <input type="text" name="cel2_2">
         </td>
      </tr>
 
      <tr>
         <th>핸드폰 번호</th>
         <td><input type="text" name="tel_h1"> - 
            <input type="text" name="tel_h2_1"> -
            <input type="text" name="tel_h2_2">
         </td>
      </tr>
   </table>
   <!--테이블 끝-->
   </td>

 
 <!-- 회원가입 완료와 취소 -->
   <tr>
      <td colspan="2" align="center">
         <div id="member_button">
         <a href="#">
         <img src="../images/member/s01_sub_bt_save.gif" width="104" height="34" border="0"></a>
         <a href="#">
         <img src="../images/member/s01_sub_bt_cancel.gif" width="104" height="34" border="0"></a>
         <div>
      </td>
   </tr>
   </table>
  </td>
 </tr>
</form>
</table>        
</body>
</html>
 
 </body>
</html>