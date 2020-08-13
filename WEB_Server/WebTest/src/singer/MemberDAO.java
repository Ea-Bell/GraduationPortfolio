package singer;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.Vector;
import java.sql.*;
import javax.naming.Context;
import javax.naming.InitialContext;
import javax.sql.DataSource;

/*  Data Access Object * 테이블 당 한개의 DAO를 작성한다. *
 *  JSP_MEMBER 테이블과 연관된 DAO로 
 *  회원 데이터를 처리하는 클래스이다.
 */


public class MemberDAO {
	
	
	private static MemberDAO instance;
	
	//싱글톤
	private MemberDAO() {}
	public static MemberDAO instance() {
		if(instance==null) 
		instance=new MemberDAO(); 
		return instance;	
	}
	
	
   Connection con;
   PreparedStatement ptst;
   ResultSet rs;
   
   
   public void getCon() {
	   con=null;
	   String driver = "oracle.jdbc.driver.OracleDriver";
	   String url = "jdbc:oracle:thin:@localhost:1521:XE";
	   	
	   Boolean connect = false;
	   	
	   try{
	       Class.forName(driver);
	       con=DriverManager.getConnection(url,"Eabell","1234"); //자신의 아이디와 비밀번호	      
	       connect = true;
	       con.close();
	   }catch(Exception e){
	       connect = false;
	       e.printStackTrace();
	   }
   }
	
	}

