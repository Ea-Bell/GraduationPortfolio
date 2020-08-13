package member.service;

import java.util.Map;

public class JoinRequest {

	private String id;
	private String nickname;
	private String name;
	private String pw;
	private String confirmPw;
	private String gender;
	private String tel;
	private String phone;
	private String email;
	private String addr;

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public String getNickname() {
		return nickname;
	}

	public void setNickname(String nickname) {
		this.nickname = nickname;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPw() {
		return pw;
	}

	public void setPw(String pw) {
		this.pw = pw;
	}

	public String getConfirmPw() {
		return confirmPw;
	}

	public void setConfirmPw(String confirmPw) {
		this.confirmPw = confirmPw;
	}

	public String getGender() {
		return gender;
	}

	public void setGender(String gender) {
		this.gender = gender;
	}

	public String getTel() {
		return tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	public String getPhone() {
		return phone;
	}

	public void setPhone(String phone) {
		this.phone = phone;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getAddr() {
		return addr;
	}

	public void setAddr(String addr) {
		this.addr = addr;
	}

	public boolean isPasswordEqualToConfirm() {
		return pw != null && pw.equals(confirmPw);
	}

	// 유효성 검사
	public void validate(Map<String, Boolean> errors) {
		checkEmpty(errors, id, "id");
		checkEmpty(errors, nickname, "nickname");
		checkEmpty(errors, pw, "pw");
		checkEmpty(errors, confirmPw, "confirmPw");
		checkEmpty(errors, name, "name");
		checkEmpty(errors, gender, "gender");
		checkEmpty(errors, tel, "tel");
		checkEmpty(errors, phone, "phone");
		checkEmpty(errors, email, "email");
		checkEmpty(errors, addr, "addr");
		if (!errors.containsKey("confirmPw")) {
			if (!isPasswordEqualToConfirm()) {
				errors.put("notMathc", Boolean.TRUE);
			}
		}

	}

	private void checkEmpty(Map<String, Boolean> errors, String value, String fieldName) {
		if (value == null || value.isEmpty())
			errors.put(fieldName, Boolean.TRUE);
	}
}
