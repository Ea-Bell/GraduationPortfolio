package member.service;

import java.sql.Connection;
import java.sql.SQLException;
import java.util.Date;

import jdbc.JdbcUtil;
import jdbc.connection.ConnectionProvider;
import member.dao.MemberDao;
import member.model.Member;

public class JoinServiece {

		private MemberDao memberDao = new MemberDao();
		
		public void join(JoinRequest joinReq) {
			Connection conn= null;
			try {
				conn= ConnectionProvider.getConnection();
				conn.setAutoCommit(false);
				
				Member member = memberDao.selectByid(conn, joinReq.getId());
				if(member !=null) {
					JdbcUtil.rollback(conn);
					throw new DuplicateIdException();
				}
				memberDao.insert(conn, new Member(joinReq.getId(),												 
												  joinReq.getNickname(),											 
												  joinReq.getName(),
												  joinReq.getPw(),
												  joinReq.getGender(),
												  joinReq.getTel(),
												  joinReq.getPhone(),
												  joinReq.getEmail(),
												  joinReq.getAddr(),
												  new Date())
								);
				conn.commit();				
			}catch (SQLException e) {
				System.out.println(e.getMessage());
				JdbcUtil.rollback(conn);
				throw new RuntimeException(e);
				
				
				// TODO: handle exception
			}finally {
			JdbcUtil.close(conn);
			}
		}
}
