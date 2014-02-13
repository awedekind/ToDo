var UiApi = (function () {
    var compileTemplate = function (selector) {
        var templateScript = $(selector).html();
        //console.log(templateScript);
        return Handlebars.compile(templateScript);
    };

    /*Generates a modal based on the html template*/
    var genModal = function (element, task) {
        var template = compileTemplate(element);
        $.modal(template(task));
    };

    /*inits shuffle*/
    var shuffleItems = function ($grid) {
        $grid.shuffle({
            itemSelector: ".item"
        });
    };

    /* reshuffle when user clicks a filter item */
    var shuffleFilter = function ($grid) {
        $('#filter a').click(function (e) {
            //e.preventDefault();
            $('#filter a').removeClass('active');
            $(this).addClass('active');
            var groupName = $(this).attr('data-group'); 
            $grid.shuffle('shuffle', groupName);
            return false;
        });
    };

    return {
        genModal: genModal,
        shuffleItems: shuffleItems,
        shuffleFilter: shuffleFilter,
        compileTemplate: compileTemplate
    };
}());




