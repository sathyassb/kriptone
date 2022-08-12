$(function () {

    if (window.statusMsg.length != 0) {
        var msgs = window.statusMsg.split(';');
        var htm = '<div class="statusMsg ' + window.statusType + '"><ul>';
        $.each(msgs, function (key, msg) {
            if (msg.length > 0)
                htm += '<li>' + msg + '</li>';
        });
        htm += '</ul></div>';
        $('.statusMain').prepend(htm);


    }
    var t = setTimeout(function () { $('.statusMain').fadeOut('slow'); }, 5000);
    $('.statusMain').click(function () {
        $('.statusMain').fadeOut('slow');

    });
});
