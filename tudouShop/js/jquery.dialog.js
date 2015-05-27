/*
#######################
Copyright (c) 2008 (Cnitsky.Net)
Author : Eric.Xu
#######################
*/

var __div_dialog_action_obj = null;
var __div_dialog_close_callback = null;

function ShowDialog(div_dialog_title, div_dialog_url, div_dialog_action_obj, close_callback, is_default_close_execute_callback)
{
    __div_dialog_action_obj = div_dialog_action_obj;
    __div_dialog_close_callback = close_callback;
    
    if($("#div_dialog").css("display") == "none")
    {
	    $(div_dialog_action_obj).TransferTo(
	    {
		     to: "div_dialog",
		     className: "dialog_action",
		     duration: 400,
		     complete: function()
		     {
			      $("#div_dialog").show();
			      $("#div_dialog_title").html(div_dialog_title);
			      $("#div_dialog_frame").attr("src", div_dialog_url);
			      
			      $("#div_form_context").block({ 
                    message: null, 
                    css: { border: '3px solid #a00' } 
                  });
		     }
	    });
    }
    $("#div_dialog_close").unbind("click");
    $("#div_dialog_close").bind("click", function(){ CloseDialog(is_default_close_execute_callback, null) });
}

function CloseDialogHelper(close_callback, callback_args)
{
    $("#div_dialog_title").html("");
    $("#div_dialog_frame").attr("src", "#");
    
    $("#div_form_context").unblock();
    
    $("#div_dialog").TransferTo(
    {
        to: __div_dialog_action_obj,
        className: "dialog_action", 
        duration: 400
    }).hide();
    
    __div_dialog_action_obj = null;
    __div_dialog_close_callback = null; 
    
    if(close_callback)
    {
        close_callback(callback_args);
    }
}
function CloseDialog(is_execute_callback, callback_args)
{
    if(is_execute_callback)
    {
        CloseDialogHelper(__div_dialog_close_callback, callback_args);
    }
    else
    {
        CloseDialogHelper(null, callback_args);
    }
}
function DialogSetWidth(width)
{
    $("#div_dialog").width(width);
}

var mouse_obj = null;
var pX;
var pY;
document.onmousemove = OnDrag;
document.onmouseup = StopDrag;
function StartDrag()
{
    mouse_obj = document.getElementById("div_dialog");
    pX = mouse_obj.style.pixelLeft - event.x;
    pY = mouse_obj.style.pixelTop - event.y;	    
    event.srcElement.setCapture();
}
function StartDragEx(obj)
{
    mouse_obj =  document.getElementById(obj);
    pX = mouse_obj.style.pixelLeft - event.x;
    pY = mouse_obj.style.pixelTop - event.y;	    
    event.srcElement.setCapture();
}
function OnDrag()
{
    if(mouse_obj) 
    {
        mouse_obj.style.left = pX + event.x;
        mouse_obj.style.top = pY + event.y;
         
        if(mouse_obj.style.pixelLeft < 0)
        {
            mouse_obj.style.left = 0;
        }
        if(mouse_obj.style.pixelTop < 0)
        { 
            mouse_obj.style.top = 0;
        }
        
        event.returnValue = false;
        
        window.status = mouse_obj.style.pixelLeft + ":";
        window.status = window.status + mouse_obj.style.pixelTop + ":";
        window.status = window.status + (mouse_obj.clientWidth + mouse_obj.style.pixelLeft) + ":";
        window.status = window.status + (mouse_obj.clientHeight + mouse_obj.style.pixelTop) + " ";
        window.status = window.status + mouse_obj.style.left + ":" + mouse_obj.style.top;
    }
}
function StopDrag()
{
    if(mouse_obj) 
    {
        mouse_obj = null;
        event.srcElement.releaseCapture();
    } 
}

function showWindow(_sUrl, _iWidth, _iHeight, _sMode, _sTitle)
{
    var oWindow;
    var sLeft = (screen.width) ? (screen.width - _iWidth)/2 : 0;
    var iTop = -80 + (screen.height - _iHeight)/2;
    iTop = iTop > 0 ? iTop : (screen.height - _iHeight)/2;
    var sTop = (screen.height) ? iTop : 0;
    if(window.showModalDialog && _sMode == "m"){
	    oWindow = window.showModalDialog(_sUrl,_sTitle,"dialogWidth:" + _iWidth + "px;dialogheight:" + _iHeight + "px");
    } else {
	    oWindow = window.open(_sUrl, _sTitle, 'height=' + _iHeight + ', width=' + _iWidth + ', top=' + sTop + ', left=' + sLeft + ', toolbar=no, menubar=no, scrollbars=' + _sMode + ', resizable=no,location=no, status=no');
    }
}	