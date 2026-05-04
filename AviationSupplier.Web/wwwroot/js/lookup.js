var LookupModule = (function ($) {

    // =============================
    // PRIVATE VARIABLES
    // =============================
    var apiCountryUrl = '/Home/GetCountry';
    
    // =============================
    // INIT
    // =============================
    function init() {
        loadCountry();       
    }

    function loadCountry() {
        $.ajax({
            url: apiCountryUrl,
            type: 'GET',
            success: function (data) {
                renderCustomers(data);
            },
            error: function (err) {
                console.error("Error loading country:", err);
            }
        });
    }

  
    return {
        init: init       
    };

})(jQuery);