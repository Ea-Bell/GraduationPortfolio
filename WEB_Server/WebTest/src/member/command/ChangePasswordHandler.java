package member.command;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import auth.service.User;
import member.service.ChangePasswordService;
import member.service.InvalidPasswordException;
import member.service.MemberNotFoundException;

/**
 * Servlet implementation class ChangePasswordHandler
 */
@WebServlet("/ChangePasswordHandler")
public class ChangePasswordHandler extends HttpServlet {
	private static final long serialVersionUID = 1L;
    private ChangePasswordService changePwdSvc= new ChangePasswordService();   
    private static final String FORM_VIEW="webTest/View/login/changePwdForm.jsp";
    /**
     * @see HttpServlet#HttpServlet()
     */
    public ChangePasswordHandler() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doPost(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		
		try {
			processSubmit(request, response);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	private void processSubmit(HttpServletRequest request, HttpServletResponse response) throws Exception {
		
		User user = (User)request.getSession().getAttribute("authUser");
		
		String curPwd= request.getParameter("curPwd");
		String newPwd= request.getParameter("newPwd");
		
		//에러처리
		if(curPwd==null||curPwd.isEmpty()) {
			response.sendRedirect("webTest/View/login/changePwdForm.jsp?pwd=currentPwd");
		}else if(newPwd==null||newPwd.isEmpty()) {
			response.sendRedirect("webTest/View/login/changePwdForm.jsp?pwd=newPwd");
		}
		
		
		try {
			changePwdSvc.changePassword(user.getId(), curPwd, newPwd);
			response.sendRedirect("webTest/View/login/changePwdSuccess.jsp");
		}catch (InvalidPasswordException e) {
			// TODO: handle exception
			//비밀번호가 틀렸을때
			
			response.sendRedirect("webTest/View/login/changePwdForm.jsp?pwd=badCurPwd");
		}catch (MemberNotFoundException e) {
			// TODO: handle exception
			response.sendError(HttpServletResponse.SC_BAD_REQUEST);
			
		}
		
	}
}
