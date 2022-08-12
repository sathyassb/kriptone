$(function () {
    $(".coursename").autocomplete({
        minLength: 2,
        delay:250,
        selectFirst: true,
        autoFocus: true,
        source:
            function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "../../autocomplete/coursename.ashx?q=" + request.term.replace(' ','+'),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.Key,
                                value: item.Key
                            };
                        }));
                    },
                    error: function () {
                        alert("An unexpected error has occurred during processing.");
                    }
                });
            },
        select: function (event, ui) {
            $("#" + this.id.replace("txt", "hd")).val(ui.item.value);
            $(this).val(ui.item.label);
            var inputs = $(this).closest('form').find(':input[type=text]');
            inputs.eq(inputs.index(this) + 1).focus();
            return false;
        }

    });
    $(".collegename").autocomplete({
        minLength: 1,
        delay: 250,
        selectFirst: true,
        autoFocus: true,
        source:
            function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "../../autocomplete/collegename.ashx?q=" + request.term.replace(' ', '+'),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.instname,
                                value: item.instname,
                                cid:item.instid
                            };
                        }));
                    },
                    error: function () {
                        alert("An unexpected error has occurred during processing.");
                    }
                });
            },
        select: function (event, ui) {
            $("#" + this.id.replace("txt", "hdn")).val(ui.item.cid);
            $(this).val(ui.item.label);
            return false;
        }

    });
    $(".collegemap").autocomplete({
        minLength: 1,
        delay: 250,
        selectFirst: true,
        autoFocus: true,
        source:
            function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "../../autocomplete/collegemap.ashx?q=" + request.term.replace(' ', '+'),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.instname,
                                value: item.instname,
                                cid: item.instid
                            };
                        }));
                    },
                    error: function () {
                        alert("An unexpected error has occurred during processing.");
                    }
                });
            },
        select: function (event, ui) {
            window.location.href = 'institution-signup-link?key=' + ui.item.cid + '&id=' + getUrlParameter('id') + '&packageid=' + getUrlParameter('packageid');
            //$("#" + this.id.replace("txt", "hdn")).val(ui.item.cid);
            $(this).val(ui.item.label);
            return false;
        }

    });
    $(".scholarship").autocomplete({
        minLength: 1,
        delay: 250,
        selectFirst: true,
        autoFocus: true,
        source:
            function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "../../autocomplete/scholarship.ashx?q=" + request.term.replace(' ', '+'),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.title,
                                value: item.title,
                                cid: item.scholarshipid
                            };
                        }));
                    },
                    error: function () {
                        alert("An unexpected error has occurred during processing.");
                    }
                });
            },
        select: function (event, ui) {
            $("#" + this.id.replace("txt", "hdn")).val(ui.item.cid);
            $(this).val(ui.item.label);
            return false;
        }


    });
    $(".companyname").autocomplete({
        minLength: 1,
        delay: 250,
        selectFirst: true,
        autoFocus: true,
        source:
            function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "../../autocomplete/companyname.ashx?q=" + request.term.replace(' ', '+'),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.companyname,
                                value: item.companyname,
                                cid: item.companyid
                            };
                        }));
                    },
                    error: function () {
                        alert("An unexpected error has occurred during processing.");
                    }
                });
            },
        select: function (event, ui) {
            $("#" + this.id.replace("txt", "hdn")).val(ui.item.cid);
            $(this).val(ui.item.label);
            return false;
        }

    });
    $(".cityname").autocomplete({
        minLength: 1,
        delay: 250,
        selectFirst: true,
        autoFocus: true,
        source:
            function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "../../autocomplete/cityname.ashx?q=" + request.term.replace(' ', '+'),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.city,
                                value: item.city,
                                cid: item.cityid
                            };
                        }));
                    },
                    error: function () {
                        alert("An unexpected error has occurred during processing.");
                    }
                });
            },
        select: function (event, ui) {
            $("#" + this.id.replace("txt", "hdn")).val(ui.item.cid);
            $(this).val(ui.item.label);
            return false;
        }

    });
    $(".examtitle").autocomplete({
        minLength: 1,
        delay: 250,
        selectFirst: true,
        autoFocus: true,
        source:
            function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "../../autocomplete/examtitle.ashx?q=" + request.term.replace(' ', '+'),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.examtitle,
                                value: item.examtitle,
                                cid: item.cexamid
                            };
                        }));
                    },
                    error: function () {
                        alert("An unexpected error has occurred during processing.");
                    }
                });
            },
        select: function (event, ui) {
            $("#" + this.id.replace("txt", "hdn")).val(ui.item.cid);
            $(this).val(ui.item.label);
            return false;
        }

    });
    $(".associations").autocomplete({
        minLength: 0,
        delay: 250,
        selectFirst: true,
        autoFocus: true,
        source:
            function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "../../autocomplete/association.ashx?t=" + $("#ddlAss").val() + "&q=" + request.term,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.Key,
                                value: item.Key
                            };
                        }));
                    },
                    error: function () {
                        if (request.term !== null) {
                            //alert("An unexpected error has occurred during processing.");
                        }
                    }
                });
            },
        select: function (event, ui) {
            $("#" + this.id.replace("txt", "hd")).val(ui.item.value);
            $(this).val(ui.item.label);
            var inputs = $(this).closest('form').find(':input[type=text]');
            inputs.eq(inputs.index(this) + 1).focus();
            return false;
        }

    });
});

function getUrlParameter(name) {
    name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
    var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
    var results = regex.exec(location.search);
    return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
};
