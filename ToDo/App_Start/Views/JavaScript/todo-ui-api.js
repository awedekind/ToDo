var UiApi = (function () {
    var compileTemplate = function (selector) {
        var templateScript = $(selector).html();
        return Handlebars.compile(templateScript);
    };

    var renderTask = function (task) {
        var template = compileTemplate("#task-template");
        $("#tasklist").append(template(task));
    };

    var renderUpdatedTasks = function () {
        $("#tasklist").empty();
        var tasks = ServiceApi.loadTasks();
        var task = tasks["tasks"];
        renderTask(task);

    };

    var newTaskModal = function () {
        var template = compileTemplate("#new-task-modal-template");
        $.modal(template());
    };

    var updateTaskModal = function (task) {
        var template = compileTemplate("#update-task-modal-template");
        $.modal(template(task));
    };

    var shuffle = function () {
        /*Shuffle Init*/
        var $grid = $('#tasklist');
        $grid.shuffle({
            itemSelector: '.task'
        });

        /* reshuffle when user clicks a filter item */
        $('#filter a').click(function (e) {
            e.preventDefault();

            // set active class
            $('#filter a').removeClass('active');
            $(this).addClass('active');

            // get group name from clicked item
            var groupName = $(this).attr('data-group');

            // reshuffle grid
            $grid.shuffle('shuffle', groupName);
        });
    };

    return {
        newTaskModal: newTaskModal,
        updateTaskModal: updateTaskModal,
        renderTask: renderTask,
        renderUpdatedTasks: renderUpdatedTasks,
        compileTemplate: compileTemplate,
        shuffle: shuffle
    };
}());




$(function () {
    var tasks = ServiceApi.loadTasks();
    var template = UiApi.compileTemplate("#task-template");
    $("#tasklist").append(template(tasks["tasks"]));
    UiApi.shuffle();
});