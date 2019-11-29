$(function () {
    $.validator.addMethod('date',
    function (value, element) {
        if (this.optional(element)) { return true; }

        try {
            $.datepicker.parseDate('dd/mm/yy', value);
            return true;
        }
        catch (err) {
            return false;
        }

    });
    $(".datefield").datepicker(
        {
            dateFormat: "dd/mm/yy",
            showStatus: true,
            showWeeks: true,
            currentText: 'Now',
            autoSize: true,
            gotoCurrent: true,
            showAnim: 'blind',
            highlightWeek: true,
            changeYear: true
        });
});