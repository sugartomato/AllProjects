/*
for ( var i=0;i<document.querySelectorAll("#wrapper ul li").length;i++ ) {
	document.querySelectorAll("#wrapper ul li")[i].colorfulBg(); 
}
*/


																					
//var generatedCount = 0;																			
function pullDownRefresh() {
	wrapper.refresh();
	//setTimeout(function () { //Simulate network congestion, remove setTimeout from production!
		//var ul, li, i;																		
		//ul = document.querySelector("#wrapper ul");
		//ul.innerHTML='';
		/*
		for ( i=0; i<11; i++) {																		 
			li = document.createElement('li');													
			li.appendChild(document.createTextNode('async row ' + (++generatedCount)));				
			ul.insertBefore(li, ul.childNodes[0]);														
		}*/																					 
		//wrapper.refresh();//remember to refresh after  action completed！ ---yourId.refresh();
		//for ( var i=0; i < document.querySelectorAll("#wrapper ul li").length;i++ ) {
			//document.querySelectorAll("#wrapper ul li")[ i ].colorfulBg(); 
		//}
	//}, 100);
}
function pullUpRefresh() {
	wrapper.refresh();
	//setTimeout(function () {//Simulate network congestion, remove setTimeout from production!
		//var ul, li, i;
		//ul = document.querySelector("#wrapper ul");
		//for ( var i = 0; i < 2; i++ ) {
			//li = document.createElement('li');
			//li.appendChild(document.createTextNode('async row ' + (++generatedCount)));
			//ul.appendChild(li, ul.childNodes[0]);
		//}
		//wrapper.refresh();//remember to refresh after action completed！！！
		//var pullUpLabel = document.querySelector('.pullUpLabel');
		//alert( pullUpLabel );
		//for(var i=0;i<document.querySelectorAll("#wrapper ul li").length;i++){
		//document.querySelectorAll("#wrapper ul li")[i].colorfulBg(); }
	//}, 10);
}
(function(){
	refresher.init( {
		id:'wrapper'
		,pullUpLableTip: ' ' //document.title 
		,pullDownAction:pullDownRefresh                                                           
		,pullUpAction:pullUpRefresh 																			
	});

	window.onload = function() {
		var mainpic = document.getElementById('mainpic'), bghead = document.getElementById('bghead');
		bghead.style.cssText = 'background:#000;color:#aaa;height:' + (mainpic.offsetHeight/2) + 'px;visibility:visible;';
		//height: 736, 732, 667, 627, 640, 568, 480
		src2_1_load();
	};
	
}());

function src2_1_load() {
	var src2_1 = document.getElementById('src2_1'); //top:278px;
	if ( !src2_1 ) return;
	var src2_2 = document.getElementById('src2_2');//top:440px;
	installEvent( src2_1 );
	installEvent( src2_2 );
	var sys_screen_h = window.screen.height, visibility = 'visibility:visible;', y1 = 0, y2 = 0, size = 93;
	//alert(sys_screen_h);
	switch( sys_screen_h ) {
		case 480://iphone 4
			size = 90;
			src2_1.style.cssText = 'top:-330px;width:' + size + 'px;height:' + size + 'px;left:35px;' + visibility;
			src2_2.style.cssText = 'top:-186px;width:' + size + 'px;height:' + size + 'px;left:-56px;' + visibility;
			return;
		case 568://iphone 5
			size = 93;
			src2_1.style.cssText = 'top:-331px;width:' + size + 'px;height:' + size + 'px;left:33px;' + visibility;
			src2_2.style.cssText = 'top:-186px;width:' + size + 'px;height:' + size + 'px;left:-60px;' + visibility;
			return;
		case 667://iphone 6
			size = 108;
			src2_1.style.cssText = 'top:-388px;width:' + size + 'px;height:' + size + 'px;left:40px;' + visibility;
			src2_2.style.cssText = 'top:-218px;width:' + size + 'px;height:' + size + 'px;left:-68px;' + visibility;
			return;
		case 736://iphone 6 Plus
			size = 105;
			src2_1.style.cssText = 'top:-421px;width:' + size + 'px;height:' + size + 'px;left:52px;' + visibility;
			src2_2.style.cssText = 'top:-235px;width:' + size + 'px;height:' + size + 'px;left:-54px;' + visibility;
			return;
		case 1024://ipad
			size = 195;
			src2_1.style.cssText = 'top:-776px;width:' + size + 'px;height:' + size + 'px;left:96px;' + visibility;
			src2_2.style.cssText = 'top:-428px;width:' + size + 'px;height:' + size + 'px;left:-96px;' + visibility;
			return;
		case 1366://ipad pro
			size = 260;
			src2_1.style.cssText = 'top:-1030px;width:' + size + 'px;height:' + size + 'px;left:128px;' + visibility;
			src2_2.style.cssText = 'top:-571px;width:' + size + 'px;height:' + size + 'px;left:-131px;' + visibility;
			return;
		case 627://微信开发工具
			y1 = sys_screen_h - 336; //-162
			y2 = sys_screen_h - 168;
			src2_1.style.cssText = 'top:' + y1 + 'px;width:93px;height:93px;left:47px;' + visibility;
			src2_2.style.cssText = 'top:' + y2 + 'px;width:93px;height:93px;left:47px;' + visibility;
			return;
		case 640://galaxy 5s
			size = 93;
			src2_1.style.cssText = 'top:-367px;width:' + size + 'px;height:' + size + 'px;left:44px;' + visibility;
			src2_2.style.cssText = 'top:-205px;width:' + size + 'px;height:' + size + 'px;left:-49px;' + visibility;
			return;
		case 732: // Nexus 5X
			size = 105;
			src2_1.style.cssText = 'top:-418px;width:' + size + 'px;height:' + size + 'px;left:51px;' + visibility;
			src2_2.style.cssText = 'top:-233px;width:' + size + 'px;height:' + size + 'px;left:-54px;' + visibility;
			return;
	}
 
}
function installEvent( o ) {
	if ( o.ontouchstart ) {
		o.ontouchstart = function() { clickEvent( this ); }
	} else {
		o.onclick = function() { clickEvent( this ); }
	}
}
function clickEvent( o ) {
	var tooltip = document.getElementById('tooltip');
	if ( !tooltip ) {
		tooltip = document.createElement('div');
		tooltip.style.cssText = 'width:100%;height:100%;position:absolute;left:0;top:0;z-index: 3;background:rgba(0,0,0,0.5);text-align: center;';
		tooltip.id = 'tooltip';
		document.body.appendChild(tooltip);
	} else {
		if ( tooltip.style.display == 'none' ) tooltip.style.display = '';
	}
	tooltip.innerHTML = '<img src="' + o.src + '" style="width:80%;height:auto;margin-top:40%;" id="wechatqrcode" /><span id="closeds" style="display: block;text-align:center;font-size: 14px;color: #fff;margin-top:20px;">[关闭]</span>';

	var closeds =  document.getElementById('closeds');
	if ( closeds.ontouchstart ) {
		closeds.ontouchstart = function() { tooltip_close( this ); }
	} else {
		closeds.onclick = function() { tooltip_close( this ); }
	}
	
	var wechatqrcode = document.getElementById('wechatqrcode');
	if ( wechatqrcode.ontouchstart ) {
		wechatqrcode.ontouchstart = function() { wechatqrcode_click( event ); }
	} else {
		wechatqrcode.onclick = function() { wechatqrcode_click( event ); }
	}
}
function wechatqrcode_click( e ) {
	e.stopPropagation();
	//e.preventDefault();
}
function tooltip_close( o ) {
	document.getElementById('tooltip').style.display = 'none';
}















