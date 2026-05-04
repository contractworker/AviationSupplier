var CustomerModule = (function ($) {

    // =============================
    // PRIVATE VARIABLES
    // =============================
    var customerId = 0;
    var apiUrl = '/Customer/GetCustomers';

    var $customerTableBody;
    var $addressTableBody;

    // =============================
    // INIT
    // =============================
    function init(id) {

        customerId = id || 0;

        $customerTableBody = $('#customerTable tbody');
        $addressTableBody = $('#addressTable tbody');

        loadCustomers();
        bindSearch();
        loadCountry();

        if (customerId > 0) {
            bindAddressEvents();
            loadAddresses();
        }
    }

    // =============================
    // CUSTOMER LIST
    // =============================
    function loadCustomers() {

        $.ajax({
            url: apiUrl,
            type: 'GET',
            success: function (data) {
                renderCustomers(data);
            },
            error: function (err) {
                console.error("Error loading customers:", err);
            }
        });
    }

    function renderCustomers(data) {

        $customerTableBody.empty();

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
                        <a href="/Customer/Edit/${c.id}" class="btn btn-sm btn-warning">
                            Edit
                        </a>
                    </td>
                </tr>
            `;

            $customerTableBody.append(row);
        });
    }

    function loadCountry() {
        $.ajax({
            url: apiUrl,
            type: 'GET',
            success: function (data) {
                renderCustomers(data);
            },
            error: function (err) {
                console.error("Error loading customers:", err);
            }
        });
    }

    // =============================
    // SEARCH
    // =============================
    function bindSearch() {

        $('#searchBox').on('keyup', function () {

            var value = $(this).val().toLowerCase();

            $('#customerTable tbody tr').filter(function () {
                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
            });
        });
    }

    // =============================
    // ADDRESS MODULE
    // =============================
    function bindAddressEvents() {

        $("#btnAddAddress").on("click", function () {
            clearModal();
            $("#addressModal").modal("show");
        });

        $("#saveAddress").on("click", function () {
            saveAddress();
        });
    }

    function loadAddresses() {

        if (customerId === 0) return;

        $.ajax({
            url: "/Customer/GetAddresses",
            type: "GET",
            data: { customerId: customerId },
            success: function (data) {
                renderAddresses(data);
            },
            error: function () {
                console.error("Failed to load addresses");
            }
        });
    }

    function renderAddresses(data) {

        $addressTableBody.empty();

        if (!data || data.length === 0) {
            $addressTableBody.append(`
                <tr>
                    <td colspan="5" class="text-center">No addresses found</td>
                </tr>
            `);
            return;
        }

        $.each(data, function (i, item) {

            var row = `
                <tr>
                    <td>${item.companyName || ""}</td>
                    <td>${item.contactName || ""}</td>
                    <td>${item.city || ""}</td>
                    <td>${item.phone || ""}</td>
                    <td>
                        <button class="btn btn-sm btn-primary me-1"
                            onclick="CustomerModule.editAddress(${item.id})">
                            <i class="fa fa-edit"></i>
                        </button>

                        <button class="btn btn-sm btn-danger"
                            onclick="CustomerModule.removeAddress(${item.id})">
                            <i class="fa fa-trash"></i>
                        </button>
                    </td>
                </tr>
            `;

            $addressTableBody.append(row);
        });
    }

    function saveAddress() {

        if (customerId === 0) {
            alert("Please save customer first.");
            return;
        }

        var model = {
            CompanyName: $("#addrCompany").val(),
            ContactName: $("#addrContact").val(),
            City: $("#addrCity").val(),
            Phone: $("#addrPhone").val()
        };

        $.ajax({
            url: "/Customer/AddAddress",
            type: "POST",
            data: {
                customerId: customerId,
                model: model
            },
            success: function () {
                $("#addressModal").modal("hide");
                loadAddresses();
            },
            error: function () {
                alert("Error saving address");
            }
        });
    }

    function removeAddress(id) {

        if (!confirm("Delete this address?")) return;

        $.ajax({
            url: "/Customer/DeleteAddress",
            type: "POST",
            data: { id: id },
            success: function () {
                loadAddresses();
            },
            error: function () {
                alert("Error deleting address");
            }
        });
    }

    function editAddress(id) {
        console.log("Edit address:", id);
        // future: load and open modal
    }

    function clearModal() {
        $("#addrCompany").val("");
        $("#addrContact").val("");
        $("#addrCity").val("");
        $("#addrPhone").val("");
    }

    // =============================
    // PUBLIC API
    // =============================
    return {
        init: init,
        editAddress: editAddress,
        removeAddress: removeAddress
    };

})(jQuery);