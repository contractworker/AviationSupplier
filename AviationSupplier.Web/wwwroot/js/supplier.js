var SupplierModule = (function ($) {

    // =============================
    // PRIVATE VARIABLES
    // =============================
    var supplierId = 0;
    var apiUrl = '/Supplier/GetSuppliers';

    var $supplierTableBody;

    // =============================
    // INIT
    // =============================
    function init(id) {

        supplierId = id || 0;

        $supplierTableBody = $('#supplierTable tbody');

        loadSuppliers();
        bindSearch();
    }

    // =============================
    // SUPPLIER LIST
    // =============================
    function loadSuppliers() {

        $.ajax({
            url: apiUrl,
            type: 'GET',
            success: function (data) {
                renderSuppliers(data);
            },
            error: function (err) {
                console.error("Error loading suppliers:", err);
            }
        });
    }

    function renderSuppliers(data) {

        $supplierTableBody.empty();

        if (!data || data.length === 0) {
            $supplierTableBody.append(`
                <tr>
                    <td colspan="6" class="text-center">No suppliers found</td>
                </tr>
            `);
            return;
        }

        $.each(data, function (i, s) {

            var row = `
                <tr>
                    <td>${s.id}</td>
                    <td>${s.name || ''}</td>
                    <td>${s.email || ''}</td>
                    <td>${s.phone || ''}</td>
                    <td>${s.city || ''}</td>
                    <td>
                        <a href="/Supplier/Edit/${s.id}" class="btn btn-sm btn-warning">
                            Edit
                        </a>
                    </td>
                </tr>
            `;

            $supplierTableBody.append(row);
        });
    }

    // =============================
    // SEARCH
    // =============================
    function bindSearch() {

        $('#searchBox').on('keyup', function () {

            var value = $(this).val().toLowerCase();

            $('#supplierTable tbody tr').filter(function () {
                $(this).toggle(
                    $(this).text().toLowerCase().indexOf(value) > -1
                );
            });
        });
    }

    // =============================
    // PUBLIC API
    // =============================
    return {
        init: init
    };

})(jQuery);