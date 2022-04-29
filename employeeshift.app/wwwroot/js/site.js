// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var empId = 0;

$(document).ready(function () {
    loadTable();
    loadDrpDwnList();
});

function loadTable() {
    var url = "https://localhost:44359/api/employeeshift";

    if (empId > 0)
        url += "?id=" + empId;

    $.ajax({
        type: 'GET',
        url: url,
        contentType: false,
        processData: true,
        success: function (data) {
            $("#tblEmployeeShifts").empty();
            $.each(data, function (index, value) {
                var empId = value.employeeId == 0 ? '' : value.employeeId;
                var fullName = value.fullName == 0 ? '' : value.fullName;
                $("#tblEmployeeShifts").append("<tr><td>" + empId + "</td><td>" + fullName + "</td>" + "<td>" + value.month + "</td><td>" + value.totalNumberWorkHours + "</td></tr>");
            });
        },
        error: function (err) {
            console.log(err)
        }
    });

}


function loadDrpDwnList() {
    $.ajax({
        type: 'GET',
        url: "https://localhost:44359/api/employee",
        contentType: false,
        processData: false,
        success: function (data) {
            var empList = [];
            for (var i = 0; i < data.length; i++) {
                $('#drpEmployeeList').append($('<option>', { value: data[i].employeeId, text: data[i].fullName }));
            };
        },
        error: function (err) {
            console.log(err)
        }
    });

}

function onFilterEmployeeChange() {
    this.empId = $("#drpEmployeeList").val();
    loadTable();
}