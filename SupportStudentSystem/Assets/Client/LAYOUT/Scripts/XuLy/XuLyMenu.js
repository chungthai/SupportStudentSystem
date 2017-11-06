var clicked = false;
function CheckBrowser() {
    if (clicked == false) {
        //Browser closed
    }
    else {
        //redirected
        clicked = false;
    }
}

function Logout() {
    if (clicked == false)//browser is closed
    {
        window.location.href = "/Home/Logout";
    }
}
$(document).ready(function () {
    $('#login').on('shown.bs.modal', function () {
        $("#mssv").focus();
    });
    $("#btn-CTDT, #btn-TuVan, #btn-NopDon, #btn-TTCN").click(function () {
        if (user.trim().length == 0) {
            $('body').find('.jGrowl').attr('class', '').attr('id', '').hide();
            $.jGrowl('Bạn chưa đăng nhập', {
                position: 'center',
                life: 2000,
                theme: 'bg-danger',
                close: function () {
                    $('div div.jGrowl-notification').parent().jGrowl('shutdown').remove();
                }
            });
            $('#btnLogin').click();
            return false;
        }
        //else {
        //    $.blockUI({
        //        message: '<i class="icon-spinner4 spinner">Đang xử lý, xin vui lòng chờ trong giây lát...</i>',
        //        overlayCSS: {
        //            backgroundColor: '#1b2024',
        //            opacity: 0.7,
        //            cursor: 'wait'
        //        },
        //        css: {
        //            border: 0,
        //            color: '#fff',
        //            padding: 0,
        //            backgroundColor: 'transparent'
        //        }
        //    });
        //}
    });

    //check and replace special char
    function trim(s) {
        return s.replace(/^\s+|\s+$/, '');
    };
    
    $('#login').on('hidden.bs.modal', function () {
        $('#mssv').val('');
        $('#matkhau').val('');
        $("body .jGrowl").jGrowl("close");
    });

    function KiemTra() {
        var d = "";
        if (trim($('#mssv').val()).length < 1) {
            $('#mssv-val').text('Bạn chưa nhập MSSV!');
            $('#mssv').focus();
            return false;
        }
        else {
            $('#mssv-val').text('');
        }

        if (trim($('#matkhau').val()).length < 1) {
            $('#matkhau-val').text('Bạn chưa nhập mật khẩu!');
            $('#matkhau').focus();
            return false;
        }
        else {
            $('#matkhau-val').text('');
        }
        return true;
    }
    AddAntiForgeryToken = function (data) {
        data.__RequestVerificationToken = $('#loginForm input[name=__RequestVerificationToken]').val();
        return data;
    };

    $('#loginForm').on('submit', function (e) {
        e.preventDefault();
        var returnUrl = window.location.search.split('returnUrl=')[1];
        if (KiemTra())
            $.ajax({
                cache: false,
                type: "POST",
                url: '/Home/Login',
                data: AddAntiForgeryToken({ "UserName": $('#mssv').val(), "Password": $('#matkhau').val() }),
                dataType: "html",
                async: false,
                success: function (res) {
                    res = JSON.parse(res);
                    if (res.status) {
                        if (returnUrl) {
                            window.location = returnUrl;
                        }
                        location.reload();
                    }
                    else {
                        $('body').find('.jGrowl').attr('class', '').attr('id', '').hide();
                        $.jGrowl('MSSV hoặc mật khẩu vừa nhập không chính xác!', {
                            position: 'center',
                            life: 2000,
                            theme: 'bg-danger',
                            close: function () {
                                $('div div.jGrowl-notification').parent().jGrowl('shutdown').remove();
                                
                            }
                        });
                    }
                },
                error: function (e) {
                    new PNotify({
                        title: e.statusText,
                        styling: "jqueryui",
                        type: "error",
                        delay: 2000,
                        icon: 'icon-warning2',
                        addclass: 'bg-warning'
                    });
                }
            });
    });

    var permanotice
    function warningPopup(text) {
        var exists = false;
        $(".ui-pnotify-text").each(function () {
            if ($(this).html() === text)
                exists = true;
        });
        if (!exists) {
            permanotice = new PNotify({
                text: text,
                styling: "jqueryui",
                type: "notice",
                delay: 2000,
                icon: 'icon-warning2',
                addclass: 'bg-warning',
                animate: {
                    animate: true,
                    in_class: 'slideInDown',
                    out_class: 'bounceOut'
                }
            });
        }
    }
});