package member.command;

import java.util.HashMap;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import member.service.DuplicateIdException;
import member.service.JoinRequest;
import member.service.JoinServiece;
import mvc.command.CommandHandler;

public class JoinHandler implements CommandHandler {	
	private static final String FORM_VIEW ="/webTest/View/login/signUp.jsp";
	//private static final String FORM_VIEW ="/WEB-INF/view/signUp.jsp";
	private JoinServiece joinService = new JoinServiece();
	
	@Override
	public String process(HttpServletRequest req, HttpServletResponse res) throws Exception {
		// TODO Auto-generated method stub
		if(req.getMethod().equalsIgnoreCase("Get")) {
			return process(req, res);
		}else if(req.getMethod().equalsIgnoreCase("POST")) {
			return process(req, res);
		}else {
			res.setStatus(HttpServletResponse.SC_METHOD_NOT_ALLOWED);		
		return null;
		}
	}
	
	@SuppressWarnings("unused")
	private String processForm(HttpServletRequest req, HttpServletResponse res) {
		System.out.println(FORM_VIEW);
		return FORM_VIEW;
	}

	@SuppressWarnings("unused")
	private String processSubmit(HttpServletRequest req, HttpServletResponse res) {
		JoinRequest joinReq= new JoinRequest();
		
		//요기서 받은 값을을 합쳐서 넘기기.
		joinReq.setId(req.getParameter("id"));
		joinReq.setNickname(req.getParameter("nickname"));
		joinReq.setPw(req.getParameter("pw"));
		joinReq.setConfirmPw(req.getParameter("confirmPw"));
		joinReq.setName(req.getParameter("name"));
		joinReq.setGender(req.getParameter("gender"));
		joinReq.setTel(req.getParameter("tel1")+"-"+req.getParameter("tel2")+"-"+req.getParameter("tel3"));
		joinReq.setPhone(req.getParameter("phone1")+"-"+req.getParameter("phone2")+"-"+req.getParameter("phone3"));
		joinReq.setEmail(req.getParameter("email1")+"@"+req.getParameter("email2"));
		joinReq.setAddr(req.getParameter("addr1")+" "+req.getParameter("addr2")+" "+req.getParameter("addr3")+" "+req.getParameter("addr4")+" "+req.getParameter("addr5"));
		
		Map<String, Boolean> errors = new HashMap<>();
		req.setAttribute("error", errors);
		joinReq.validate(errors);
		
		if(!errors.isEmpty()) {
			return FORM_VIEW;
		}
		try {
			joinService.join(joinReq);
			return "/webTest/View/login/joinSuccess.jsp";	
			//return"/WEB-INF/view/signUp.jsp";
			
		} catch(DuplicateIdException e) {
			errors.put("duplicateId", Boolean.TRUE);	
			return FORM_VIEW;	
		}
	}
}
