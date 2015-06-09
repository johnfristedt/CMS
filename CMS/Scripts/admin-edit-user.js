/// <reference path="jquery-2.1.3.js" />

updateRoleBoxes();

$('#add-role').click(function () {
    $('#available-roles > option:selected').appendTo('#user-roles');
});

$('#remove-role').click(function () {
    $('#user-roles > option:selected').appendTo('#available-roles');
});

$('#user-select').change(function () {
    updateRoleBoxes();
});

$('#submit-user-update').click(function () {
    var roles = [];
    $('#user-roles option').each(function () {
        roles.push($(this).val());
    });

    $.post('EditUser',
            { User: $('#user-select > option:selected').val(), UserRoles: roles },
            function (data) {
                $('#edit-user-success').html('User updated successfully');
            });
});

function updateRoleBoxes() {
    $('#user-roles').empty();
    $('#available-roles').empty();
    $('#edit-user-success').html('');

    $.ajax({
        type: 'POST',
        url: 'GetUserRoleInfo',
        data: { username: $('#user-select > option:selected').val() },
        success: function (data) {
            for (var i = 0; i < data.UserRoles.length; i++) {
                var opt = $('<option></option>')
                    .val(data.UserRoles[i].Value)
                    .html(data.UserRoles[i].Text)
                    .appendTo('#user-roles');
            }

            for (var i = 0; i < data.AvailableRoles.length; i++) {
                var opt = $('<option></option>')
                            .val(data.AvailableRoles[i].Value)
                            .html(data.AvailableRoles[i].Text)
                            .appendTo('#available-roles');
            }
        }
    });
}