function ConfigureDataTables() {
    $('.dataTableControl').each(function () {
        $(this).find('table').each(function () {
            $(this).DataTable({
                paging: false,
                scrollY: 300,

            });
            $(this).find('td').each(function () {
                ConfigureDataTablesClick($(this))
            });
            
        });
    });
}

function ConfigureDataTablesClick(obj) {
    $(obj).on('click', function (e) {
        
        var row = $(this).closest('tr');
        if ($(row).hasClass('scSelectedRow')) {
            $(row).removeClass('scSelectedRow');
            $(row).find('td').each(function () {
                $(this).removeClass(' scSelectedItem');
            });
        }
        else {
            if (!e.ctrlKey) {
                $(row).closest('table').find('.scSelectedRow').each(function () {
                    $(this).removeClass('scSelectedRow');
                    $(this).find('td').each(function () {
                        $(this).removeClass(' scSelectedItem');
                    });
                });
            }
            $(row).addClass(' scSelectedRow');
            $(row).find('td').each(function () {
                $(this).addClass(' scSelectedItem');
            });
        }
         
    });
}