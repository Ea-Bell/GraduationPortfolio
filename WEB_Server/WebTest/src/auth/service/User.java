package auth.service;

public class User {
	private String id;
	private String name;
	private String nickname;
	
	public User(String id, String name, String nickname) {
		this.id=id;
		this.name=name;
		this.nickname=nickname;
	}

	public String getId() {
		return id;
	}

	public String getName() {
		return name;
	}
	public String getNickname() {
		return nickname;
	}
}
