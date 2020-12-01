
function setaCamposMascaras() {
    
    jQuery('.campo-data-hora').mask('00/00/0000 00:00');
    jQuery(".campo-data-hora").datetimepicker({
        format: 'dd/mm/yyyy hh:ii',
        language: "pt-BR",
        autoclose: true,
        todayBtn: "linked",
        todayHighlight: true,
        minuteStep: 10
    });

    $('.campo-data-hora').attr('autocomplete', 'off');
}
