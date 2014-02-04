var UiApi = (function () {
    var compileTemplate = function(selector) {
        var templateScript = $(selector).html();
        return Handlebars.compile(templateScript);
    };

    var renderTask = function (task) {
        var template = compileTemplate("#task-template");
        $(".tasks").append(template(task));
    };

    var renderUpdatedTasks = function () {
        $(".tasks").empty();
        console.log("task emptied");
        var tasks = ServiceApi.loadTasks();
        console.log(JSON.stringify(tasks));
        var task = tasks["tasks"];
        console.log(JSON.stringify(task));
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

    return {
        newTaskModal: newTaskModal,
        updateTaskModal: updateTaskModal,
        renderTask: renderTask,
        renderUpdatedTasks: renderUpdatedTasks,
        compileTemplate: compileTemplate
    };
}());

$(function () {
    var tasks = ServiceApi.loadTasks();
    var template = UiApi.compileTemplate("#task-template");
    $(".tasks").append(template(tasks["tasks"]));
});