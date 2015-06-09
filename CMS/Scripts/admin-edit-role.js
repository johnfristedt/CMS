/// <reference path="jquery-2.1.3.js" />

updateUserBoxes();

$('#add-user').click(function () {
    $('#available-users > option:selected').appendTo('#role-users');
});

$('#remove-user').click(function () {
    $('#role-users > option:selected').appendTo('#available-users');
});

$('#role-select').change(function () {
    updateUserBoxes();
});

$('#submit-role-update').click(function () {
    var users = [];
    $('#role-users option').each(function () {
        users.push($(this).val());
    });

    $.post('EditRole',
            { Role: $('#role-select > option:selected').val(), UsersInRole: users },
            function (data) {
                $('#edit-role-success').html('Role updated successfully');
            });
});

function updateUserBoxes() {
    $('#role-users').empty();
    $('#available-users').empty();
    $('#edit-role-success').html('');

    $.ajax({
        type: 'POST',
        url: 'GetRoleInfo',
        data: { role: $('#role-select > option:selected').val() },
        success: function (data) {
            for (var i = 0; i < data.UsersInRole.length; i++) {
                var opt = $('<option></option>')
                    .val(data.UsersInRole[i].Value)
                    .html(data.UsersInRole[i].Text)
                    .appendTo('#role-users');
            }

            for (var i = 0; i < data.AvailableUsers.length; i++) {
                var opt = $('<option></option>')
                            .val(data.AvailableUsers[i].Value)
                            .html(data.AvailableUsers[i].Text)
                            .appendTo('#available-users');
            }
        }
    });
}