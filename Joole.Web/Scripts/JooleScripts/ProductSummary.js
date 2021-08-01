$(function () {
    $("#airflow-slider").slider({
        range: true,
        min: 10,
        max: 90,
        values: [10, 90],
        slide: function (event, ui) {
            $("#airflow-min-amount").val(ui.values[0]);
            $("#airflow-max-amount").val(ui.values[1]);
        }
    });
    $("#airflow-min-amount").val($("#airflow-slider").slider("values", 0));
    $("#airflow-max-amount").val($("#airflow-slider").slider("values", 1));
});
$(function () {
    $("#power-slider").slider({
        range: true,
        min: 10,
        max: 65,
        values: [10, 65],
        slide: function (event, ui) {
            $("#power-min-amount").val(ui.values[0]);
            $("#power-max-amount").val(ui.values[1]);
        }
    });
    $("#power-min-amount").val($("#power-slider").slider("values", 0));
    $("#power-max-amount").val($("#power-slider").slider("values", 1));
});
$(function () {
    $("#sound-slider").slider({
        range: true,
        min: 20,
        max: 50,
        values: [20, 50],
        slide: function (event, ui) {
            $("#sound-min-amount").val(ui.values[0]);
            $("#sound-max-amount").val(ui.values[1]);
        }
    });
    $("#sound-min-amount").val($("#sound-slider").slider("values", 0));
    $("#sound-max-amount").val($("#sound-slider").slider("values", 1));
});
$(function () {
    $("#sweep-slider").slider({
        range: true,
        min: 18,
        max: 60,
        values: [18, 60],
        slide: function (event, ui) {
            $("#sweep-min-amount").val(ui.values[0]);
            $("#sweep-max-amount").val(ui.values[1]);
        }
    });
    $("#sweep-min-amount").val($("#sweep-slider").slider("values", 0));
    $("#sweep-max-amount").val($("#sweep-slider").slider("values", 1));
});


var viewdetails;
var compare;
$(document).ready(function () {
    var numchecked = 0;
    $('input[type="checkbox"]').click(function () {
        if ($(this).prop("checked") == true) {
            numchecked++;
            if (numchecked == 4) {
                alert("Can not compare more than 3 items!");
                $(this).prop("checked", false);
                numchecked--;
            }
        }
        else if ($(this).prop("checked") == false) {
            numchecked--;
        }
    });
    viewdetails = function(id) {
        $.ajax({
            url: '@Url.Action("ProductDetails", "Index")',
            dataType: 'html',
            method: 'POST',
            data: { "id": id },
            success: function (res) {
                console.log("success");
            },
            error: function (err) {
                console.log(err);
            }
        })
    }
    compare = function () {
        var list_id = [];
        $("input[type='checkbox']:checked").each(function () {
            list_id.push($(this).attr("id"));
        });
        var param = "";
        for (var i = 0; i < list_id.length; i++) {
            param += "id" + (i+1) + "=" + list_id[i] + "&";
        }
        window.location.replace('~/Product/ProductsCompare?'+ param);
        
    }
});