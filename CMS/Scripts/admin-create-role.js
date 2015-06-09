/// <reference path="jquery-2.1.3.js" />

$('#submit-role-create').click(function () {
    $.post('CreateRole',
            $('#create-role-form').serialize(),
            function (data) {
                console.log('Success');
            }
    )
});