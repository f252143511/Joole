$(function () {
    $("#airflow-slider").slider({
        range: true,
        min: 10,
        max: 90,
        values: [10, 90],
        slide: function (event, ui) {
            $("#airflow-min-amount").html(ui.values[0]);
            $("#airflow-max-amount").html(ui.values[1]);
        }
    });
    $("#airflow-min-amount").html($("#airflow-slider").slider("values", 0));
    $("#airflow-max-amount").html($("#airflow-slider").slider("values", 1));
});
$(function () {
    $("#power-slider").slider({
        range: true,
        min: 10,
        max: 65,
        values: [10, 65],
        slide: function (event, ui) {
            $("#power-min-amount").html(ui.values[0]);
            $("#power-max-amount").html(ui.values[1]);
        }
    });
    $("#power-min-amount").html($("#power-slider").slider("values", 0));
    $("#power-max-amount").html($("#power-slider").slider("values", 1));
});
$(function () {
    $("#sound-slider").slider({
        range: true,
        min: 20,
        max: 50,
        values: [20, 50],
        slide: function (event, ui) {
            $("#sound-min-amount").html(ui.values[0]);
            $("#sound-max-amount").html(ui.values[1]);
        }
    });
    $("#sound-min-amount").html($("#sound-slider").slider("values", 0));
    $("#sound-max-amount").html($("#sound-slider").slider("values", 1));
});
$(function () {
    $("#sweep-slider").slider({
        range: true,
        min: 18,
        max: 60,
        values: [18, 60],
        slide: function (event, ui) {
            $("#sweep-min-amount").html(ui.values[0]);
            $("#sweep-max-amount").html(ui.values[1]);
        }
    });
    $("#sweep-min-amount").html($("#sweep-slider").slider("values", 0));
    $("#sweep-max-amount").html($("#sweep-slider").slider("values", 1));
});