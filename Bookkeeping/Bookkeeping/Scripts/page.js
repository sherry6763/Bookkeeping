(function () {
    var app = {
        initial: function (elements) {

            var pageUrl = elements.pageUrl;
            var targetDiv = $('#' + elements.targetDiv);

            function fetchPage(page) {
                $.get(pageUrl, { page: page }, function (data) {                  
                    targetDiv.html(data);
                    $('.pagination li a', targetDiv).each(function (i, item) {
                        var hyperLinkUrl = $(item).attr('href');
                        if (typeof hyperLinkUrl !== 'undefined' && hyperLinkUrl !== false) {
                            var pageNumber = $(item).attr('href').replace('/?page=', '');
                            $(item).attr('href', '#').click(function (event) {
                                event.preventDefault();
                                $(event.target).attr('href');
                                fetchPage(pageNumber);
                            });
                        }
                    });
                });
            }
        }
    };
    $.extend(window.app, app);
})();


