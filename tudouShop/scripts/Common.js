function confirmL(msg, callBack) {
    var div = document.createElement("div");
    $(div).html(msg).dialog({
        title: "提醒",
        modal: true,
        resizable: false,
        buttons: {
            "确定": function (e) {
                $(this).dialog("close");
                if (callBack != null) {
                    callBack();
                }

            }, "取消": function (e) {
                $(this).dialog("close");

            }
        }
    });
}
