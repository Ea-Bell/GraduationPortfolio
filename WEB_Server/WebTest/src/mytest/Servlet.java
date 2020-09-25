package mytest;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import member.service.JoinRequest;
import member.service.JoinServiece;

/**
 * Servlet implementation class Servlet
 */
@WebServlet("/WebTest/Servlet")
public class Servlet extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private JoinServiece joinServiece = new JoinServiece();

	/**
	 * @see HttpServlet#HttpServlet()
	 */
	public Servlet() {
		super();
		// TODO Auto-generated constructor stub
	}

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// TODO Auto-generated method stub
		response.setContentType("text/html; charset=UTF-8");
		doPost(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
	 *      response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		// TODO Auto-generated method stub

		// 요기서 받은 값을을 합쳐서 넘기기.

		try {
			doProcess(request, response);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		//request.getRequestDispatcher("/index").forward(request, response);
		response.sendRedirect("/index");
	}

	public void doProcess(HttpServletRequest request, HttpServletResponse response) throws Exception {
		// String name =request.getParameter("join");
		try {
			JoinRequest joinReq = new JoinRequest();
			joinReq.setId(request.getParameter("id"));
			joinReq.setNickname(request.getParameter("nickname"));
			joinReq.setPw(request.getParameter("pw"));
			//joinReq.setConfirmPw(request.getParameter("confirmPw"));
			joinReq.setName(request.getParameter("name"));
			joinReq.setGender(request.getParameter("gender"));
			//joinReq.setGender("남");
			joinReq.setTel(request.getParameter("tel1") + "-" + request.getParameter("tel2") + "-"
					+ request.getParameter("tel3"));
			joinReq.setPhone(request.getParameter("phone1") + "-" + request.getParameter("phone2") + "-"
					+ request.getParameter("phone3"));
			joinReq.setEmail(request.getParameter("email1") + "@" + request.getParameter("email2"));
			joinReq.setAddr(request.getParameter("addr1") + " " + request.getParameter("addr2") + " "
					+ request.getParameter("addr3") + " " + request.getParameter("addr4") + " "
					+ request.getParameter("addr5"));

			joinServiece.join(joinReq);

//	RequestDispatcher dispatcher = null;
//	request.setAttribute("form",name);
//			dispatcher = request.getRequestDispatcher("/webTest/View/mainForm/mainForm.jsp");
//			dispatcher.forward(request, response);

		} catch (Exception e) {
			// TODO: handle exception
		}
		
		//response.sendRedirect("/webTest/View/mainForm/mainForm.jsp");
	}
}
