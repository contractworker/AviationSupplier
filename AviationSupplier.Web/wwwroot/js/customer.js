var CustomerModule = (function ($) {

    // 🔒 private variables
    var apiUrl = '/Customer/GetCustomers';
    var $tableBody;

    // 🔒 private methods
    function renderTable(data) {
        $tableBody.empty();

        $.each(data, function (i, c) {
            var row = `
                <tr>
                    <td>${c.id}</td>
                    <td>${c.companyName}</td>
                    <td>${c.contactName || ''}</td>
                    <td>${c.email || ''}</td>
                    <td>${c.phone || ''}</td>
                    <td>${c.city || ''}</td>
                    <td>
                        <a href="/Customer/Edit/${c.id}" class="btn btn-sm btn-warning">Edit</a>                        
                    </td>
                </tr>
            `;
            $tableBody.append(row);
        });
    }

    function loadCustomers() {
        $.ajax({
            url: apiUrl,
            type: 'GET',
            success: function (data) {
                renderTable(data);
            },
            error: function (err) {
                console.error("Error loading customers:", err);
            }
        });
    }

    function bindEvents() {
        $('#searchBox').on('keyup', function () {
            var value = $(this).val().toLowerCase();

            $('#customerTable tbody tr').filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });
    }

    // 🌐 public API
    return {
        init: function () {
            $tableBody = $('#customerTable tbody');

            loadCustomers();
            bindEvents();
        }
    };

})(jQuery);