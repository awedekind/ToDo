var ServiceApi = (function () {
    var loadTasks = function () {
        var results;
        $.ajax({
            url: "tasks",
            async: false,
            success: function (data) {
                data = lowercaseKeys(JSON.stringify(data));
                //data = convertEnumToString(data);
                results = JSON.parse(data);
            }
        });
        console.log(results);
        return results;
    };

    var lowercaseKeys = function(data) {
        return regexReplace(data, /"\w*":/g, function($0) {
            return $0.toLowerCase();
        });
    };

    //var convertEnumToString = function (data) {
    //    data = regexReplace(data, /:0/g, ':"ToDo"');
    //    data = regexReplace(data, /:1/g, ':"Doing"');
    //    data = regexReplace(data, /:2/g, ':"Done"');
    //    return data;
    //};

    var regexReplace = function(data, regex, replacer) {
        return data.replace(regex, replacer);
    };

    var saveTask = function (task) {
        $.ajax({
            url: "newtask",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(task),
            success: function (data) {
                UiApi.renderTask(lowercaseKeys(data));
            }
        });
        $.modal.close();
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
    };

    return {
        loadTasks: loadTasks,
        saveTask: saveTask,
        updateTask: updateTask,
        removeTask: removeTask
    };
}());
