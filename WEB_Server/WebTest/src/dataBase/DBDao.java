package dataBase;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Timestamp;
import java.util.Date;

import jdbc.JdbcUtil;
import member.model.Member;

public class DBDao {
	
	Connection conn=null;
	PreparedStatement stmt=null;
	ResultSet rs=null;


		public Member selectByid(Connection conn, String id) throws SQLException{
			PreparedStatement pstmt= null;
			ResultSet rs =null;
			try {
				pstmt= conn.prepareStatement("select * from memberid  =?");
				pstmt.setString(1, id);
				rs=  pstmt.executeQuery();
				Member member= null;
				if(rs.next()) {
					member= new Member(rs.getString("id"), rs.getString("pw"), rs.getString("nickname"), rs.getString("name"),  
									   rs.getString("gender"), rs.getString("tel"), rs.getString("phone"), rs.getString("email"), 
									   rs.getString("addr"), toDate(rs.getTimestamp("regdate"))
									  );
				
				}
				return member;
			}

			finally {
				// TODO: handle finally clause
				JdbcUtil.close(rs);
				JdbcUtil.close(pstmt);
			}
		}

		private Date toDate(Timestamp date) {
			// TODO Auto-generated method stub
			return date== null?null:new Date(date.getTime());
		
		}
		
		@SuppressWarnings("unused")
		public void insert(Connection conn, Member mem)throws SQLException{
			try(PreparedStatement pstmt=
					conn.prepareStatement("insert into bbs values(?,?,?,?,?,?,?,?,?,?)")) {
				pstmt.setString(1, mem.getId());
				pstmt.setString(2, mem.getPw());
				pstmt.setString(3,mem.getNickname());
				pstmt.setString(4, mem.getName());	
				pstmt.setString(5, mem.getGender());
				pstmt.setString(6, mem.getTel());
				pstmt.setString(7, mem.getPhone());		
				pstmt.setString(8, mem.getEmail());
				pstmt.setString(9, mem.getAddr());
				pstmt.setTimestamp(10, new Timestamp(mem.getRegDate().getTime()));
				pstmt.execute();
				
			}
		}
}
