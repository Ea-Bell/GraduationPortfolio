/**
 * 
 */

// 이미지 바꾸기 함수

 function damaY() {
	    var dama = document.getElementById('checkId');	  
	    if (dama.src.match("check1")) {
	        dama.src = "C:/Users/EaBEll/Desktop/java/WebTest/WebContent/webTest/img/login/check2.png";	   
	    } else {
	        dama.src = "C:/Users/EaBEll/Desktop/java/WebTest/WebContent/webTest/img/login/check1.jpg";
	    }
	}