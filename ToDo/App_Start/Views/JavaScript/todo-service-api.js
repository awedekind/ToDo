var ServiceApi = (function () {
    var loadTasks = function () {
        var results;
        $.ajax({
            url: "tasks",
            async: false,
            success: function (data) {
                data = lowercaseKeys(JSON.stringify(data));
                results = JSON.parse(data);
            }
        });
        return results;
    };

    var saveTask = function (task) {
        $.ajax({
            url: "newtask",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(task),
            success: function (data) {
                UiApi.renderTask(JSON.parse(lowercaseKeys(JSON.stringify(data))));
            }
        });
        $.modal.close();
        //UiApi.renderUpdatedTasks();
       
    };

    var updateTask = function (task) {
        $.ajax({
            url: "updatetask",
            contentType: "application/json",
            data: JSON.stringify(task),
            type: "POST",
        });
        $.modal.close();
        UiApi.renderUpdatedTasks();
        $(document).ready(UiApi.shuffle());
    };

    var removeTask = function (id) {
        var json = { id: id };
        $.ajax({
            url: "removetask",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(json),
            async: false,
        });
        UiApi.renderUpdatedTasks();
        $(document).ready(UiApi.shuffle());
    };

    var lowercaseKeys = function (data) {
        return regexReplace(data, /"\w*":/g, function ($0) {
            return $0.toLowerCase();
        });
    };

    var regexReplace = function (data, regex, replacer) {
        return data.replace(regex, replacer);
    };

    return {
        loadTasks: loadTasks,
        saveTask: saveTask,
        updateTask: updateTask,
        removeTask: removeTask
    };
}());
