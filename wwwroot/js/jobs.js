$(document).ready(function () {
    //console.log(typeof TestJson());
    SetDataTable();
    //if ($('#jobs-applied-to')) {
        //SetDataTable(); //do not set table if it is not on the datatable page!
        //I DO want a redirect no matter what with the form submission! That
           //way it will handle submission scenarios
    //}
    //$('#job-submit').submit(function (e) {

    //})
});

function SetDataTable() {
    $('#jobs-applied-to').DataTable({
        ajax: {
            url: '/Jobs/GetAllJobs',
            type: "GET",
            datatype: "json",
            dataSrc: ""
        },
        columns: [
            { data: 'jobTitle', title: 'Name of Listed Job' },
            { data: 'organization', title: 'Organization Listing Job' },
            { data: 'jobPlatform', title: 'Site Listing Job' },
            { data: 'notes', title: 'Additional Notes' },
            { data: 'created', title: 'Date Job Entry Created' },
            {
                data: null, title: 'Remove Job', render: function (data, type, row) {
                    return '<a href="#" class="job-remove text-danger"><i class="fa fa-window-close fa-lg"></i></a>'
                }
            }
        ]
    });
}

//function CreateJobAndReSetTable() {
//    if (DataTable.isDataTable('#jobs-applied-to')) {
//        $('#jobs-applied-to').DataTable().destroy();
//    }

//}

function TestJson() {
    var settings = {
        url: "/Jobs/GetAllJobs",
        method: "GET"
    }
    return $.ajax(settings);
}